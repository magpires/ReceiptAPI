using AutoMapper;
using Flunt.Notifications;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using ReceiptAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ReceiptService(IReceiptRepository receiptRepository, ICustomerRepository customerRepository, IProductRepository productRepository, IMapper mapper)
        {
            _receiptRepository = receiptRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> GetReceiptsAsync()
        {
            var receipts = await _receiptRepository.GetReceiptsAsync();

            var receiptsResponse = _mapper.Map<List<ReceiptDto>>(receipts);

            return new ResponseDto(200, receiptsResponse);
        }

        public async Task<ResponseDto> GetReceiptsByCustomerIdAsync(int customerId)
        {
            List<Notification> notifications = new List<Notification>();

            var customerNotFound = await _customerRepository.GetCustomerByIdAsync(customerId) == null;

            if (customerNotFound)
            {
                notifications.Add(new Notification("customerNotFound", "Cliente não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var receipts = await _receiptRepository.GetReceiptsByCustomerIdAsync(customerId);

            var receiptsResponse = _mapper.Map<List<ReceiptDto>>(receipts);

            return new ResponseDto(200, receiptsResponse);
        }

        public async Task<ResponseDto> GetReceiptByIdAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id da nota fiscal é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var receipt = await _receiptRepository.GetReceiptByIdAsync(id);

            var receiptNotFound = receipt == null;

            if (receiptNotFound)
            {
                notifications.Add(new Notification("receiptNotFound", "Nota fiscal não encontrada."));
                return new ResponseDto(404, notifications); ;
            }

            var receiptResponse = _mapper.Map<ReceiptDetailsDto>(receipt);
            receiptResponse.CalculateTotalReceipt();

            return new ResponseDto(200, receiptResponse);
        }

        public async Task<ResponseDto> PostReceiptAsync(ReceiptCreateDto receipt)
        {
            var contractNotifications = receipt.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var customerDatabase = await _customerRepository.GetCustomerByIdAsync(receipt.CustomerId);

            var customerNotFound = customerDatabase == null;

            if (customerNotFound)
            {
                notifications.Add(new Notification("customerNotFound", "Cliente não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            foreach (var product in receipt.ProductReceipts)
            {
                var contractProductNotifications = product.Validate();

                var dataProductInvalid = !contractProductNotifications.IsValid;

                if (dataProductInvalid)
                    return new ResponseDto(400, contractProductNotifications);
            }

            var productsDatabase =await _productRepository.GetProductsByIdsAsync(receipt.ProductReceipts.Select(product => product.ProductId).ToArray());

            var productsNotFound = productsDatabase == null || productsDatabase.Count() < receipt.ProductReceipts.Count();

            if (productsNotFound)
            {
                notifications.Add(new Notification("productsNotFound", "Um ou mais produtos informados não puderam ser encontrados."));
                return new ResponseDto(404, notifications); ;
            }

            var addReceipt = _mapper.Map<Receipt>(receipt);
            addReceipt.SetCreatedAt();

            _receiptRepository.Add(addReceipt);

            var saveChangesError = !await _receiptRepository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao salvar a nota fiscal."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            foreach (var productReceipt in receipt.ProductReceipts)
            {
                _receiptRepository.Add(new ProductReceipt
                {
                    ProductId = productReceipt.ProductId,
                    ReceiptId = addReceipt.Id,
                    Quantity = productReceipt.Quantity,
                });
            }

            var saveChangesProductsError = !await _receiptRepository.SaveChangesAsync();

            if (saveChangesProductsError)
                notifications.Add(new Notification("saveChangesProductsError", "Erro ao salvar os produtos da nota fiscal."));

            var errorSaveChangesProducts = notifications.Count > 0;

            if (errorSaveChangesProducts)
                return new ResponseDto(500, notifications);

            var receiptResponse = _mapper.Map<ReceiptDetailsDto>(addReceipt);
            receiptResponse.CalculateTotalReceipt();

            return new ResponseDto(200, receiptResponse);
        }

        public async Task<ResponseDto> UpdateReceiptAsync(int id, ReceiptUpdateDto receipt)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id da nota fiscal é inválido"));

            var contractNotifications = receipt.Validate();

            var dataInvalid = !contractNotifications.IsValid || notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications, notifications);

            foreach (var product in receipt.ProductReceipts)
            {
                var contractProductNotifications = product.Validate();

                var dataProductInvalid = !contractProductNotifications.IsValid;

                if (dataProductInvalid)
                    return new ResponseDto(400, contractProductNotifications);
            }

            var productsDatabase = await _productRepository.GetProductsByIdsAsync(receipt.ProductReceipts.Select(product => product.ProductId).ToArray());

            var productsNotFound = productsDatabase == null || productsDatabase.Count() < receipt.ProductReceipts.Count();

            if (productsNotFound)
            {
                notifications.Add(new Notification("productsNotFound", "Um ou mais produtos informados não puderam ser encontrados."));
                return new ResponseDto(404, notifications); ;
            }

            var receiptDatabase = await _receiptRepository.GetReceiptByIdAsync(id);

            var receiptNotFound = receiptDatabase == null;

            if (receiptNotFound)
            {
                notifications.Add(new Notification("receiptNotFound", "Nota fiscal não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var receiptUpdate = _mapper.Map(receipt, receiptDatabase);
            receiptUpdate.ProductReceipts.Clear();
            receiptUpdate.SetUpdatedAt();

            _receiptRepository.Update(receiptUpdate);

            var saveChangesError = !await _receiptRepository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao atualizar a nota fiscal."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            foreach (var productReceipt in receipt.ProductReceipts)
            {
                _receiptRepository.Add(new ProductReceipt
                {
                    ProductId = productReceipt.ProductId,
                    ReceiptId = receiptUpdate.Id,
                    Quantity = productReceipt.Quantity,
                });
            }

            var saveChangesProductsError = !await _receiptRepository.SaveChangesAsync();

            if (saveChangesProductsError)
                notifications.Add(new Notification("saveChangesProductsError", "Erro ao atualizar os produtos da nota fiscal."));

            var errorSaveChangesProducts = notifications.Count > 0;

            if (errorSaveChangesProducts)
                return new ResponseDto(500, notifications);

            var customerResponse = _mapper.Map<ReceiptDetailsDto>(receiptUpdate);

            return new ResponseDto(200, customerResponse);
        }

        public async Task<ResponseDto> DeleteReceiptAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id da nota fiscal é inválido."));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var receipt = await _receiptRepository.GetReceiptByIdAsync(id);

            var receiptNotFound = receipt == null;

            if (receiptNotFound)
            {
                notifications.Add(new Notification("receiptNotFound", "Nota fiscal não encontrada."));
                return new ResponseDto(404, notifications); ;
            }

            _receiptRepository.Delete(receipt);

            var saveChangesError = !await _receiptRepository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao excluir a nota fiscal."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            return new ResponseDto();
        }
    }
}
