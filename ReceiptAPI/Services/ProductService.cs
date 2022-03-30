using AutoMapper;
using Flunt.Notifications;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using ReceiptAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> GetProductsAsync()
        {
            var product = await _repository.GetProductsAsync();

            var productsResponse =  _mapper.Map<List<ProductDto>>(product);

            return new ResponseDto(200, productsResponse);
        }

        public async Task<ResponseDto> GetProductByIdAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id do produto é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var product = await _repository.GetProductByIdAsync(id);

            var productNotFound = product == null;

            if (productNotFound)
            {
                notifications.Add(new Notification("productNotFound", "Produto não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var productResponse = _mapper.Map<ProductDetailsDto>(product);

            return new ResponseDto(200, productResponse);
        }

        public async Task<ResponseDto> PostProductAsync(ProductCreatetDto product)
        {
            var contractNotifications = product.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var addProduct = _mapper.Map<Product>(product);
            addProduct.SetCreatedAt();

            _repository.Add(addProduct);

            var saveChangesError = !await _repository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao salvar o produto."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var productResponse = _mapper.Map<ProductDetailsDto>(addProduct);

            return new ResponseDto(200, productResponse);
        }

        public async Task<ResponseDto> UpdateProductAsync(int id, ProductUpdateDto product)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id do produto é inválido"));

            var contractNotifications = product.Validate();

            var dataInvalid = !contractNotifications.IsValid || notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications, notifications);

            var productDatabase = await _repository.GetProductByIdAsync(id);

            var productNotFound = productDatabase == null;

            if (productNotFound)
            {
                notifications.Add(new Notification("productNotFound", "Produto não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var productUpdate = _mapper.Map(product, productDatabase);
            productUpdate.SetUpdatedAt();

            _repository.Update(productUpdate);

            var saveChangesError = !await _repository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao atualizar o produto."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var productResponse = _mapper.Map<ProductDetailsDto>(productUpdate);

            return new ResponseDto(200, productResponse);
        }

        public async Task<ResponseDto> DeleteProductAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id do produto é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var product = await _repository.GetProductByIdAsync(id);

            var productNotFound = product == null;

            if (productNotFound)
            {
                notifications.Add(new Notification("productNotFound", "Produto não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            _repository.Delete(product);

            var saveChangesError = !await _repository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao excluir o produto."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            return new ResponseDto();
        }
    }
}
