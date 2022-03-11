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

        public async Task<ResponseDto> PostProductAsync(ProductPostDto product)
        {
            var contractNotifications = product.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var addProduct = _mapper.Map<Product>(product);

            _repository.Add(addProduct);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("saveChangesError", "Erro ao salvar o produto."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var productResponse = _mapper.Map<ProductDetailsDto>(addProduct);

            return new ResponseDto(200, productResponse);
        }

        //public async Task<ResponseDto> UpdateCustomerAsync(int id, CustomerUpdateDto customer)
        //{
        //    List<Notification> notifications = new List<Notification>();

        //    if (id <= 0)
        //        notifications.Add(new Notification("idInvalid", "O id do cliente é inválido"));

        //    var contractNotifications = customer.Validate();

        //    var dataInvalid = !contractNotifications.IsValid || notifications.Count > 0;

        //    if (dataInvalid)    
        //        return new ResponseDto(400, contractNotifications, notifications);

        //    var customerDatabase = await _repository.GetCustomerByIdAsync(id);

        //    var customerNotFound = customerDatabase == null;

        //    if (customerNotFound)
        //    {
        //        notifications.Add(new Notification("customerNotFound", "Cliente não encontrado."));
        //        return new ResponseDto(404, notifications); ;
        //    }

        //    var emailExists = await _repository.GetCustomerByEmailAsync(customer.Email) != null;

        //    if (emailExists)
        //    {
        //        notifications.Add(new Notification("emailExists", "Já existe um cliente com este endereço de email."));
        //        return new ResponseDto(400, notifications); ;
        //    }

        //    var customerUpdate = _mapper.Map(customer, customerDatabase);

        //    _repository.Update(customerUpdate);

        //    if (!await _repository.SaveChangesAsync())
        //        notifications.Add(new Notification("saveChangesError", "Erro ao atualizar o cliente"));

        //    var errorSaveChanges = notifications.Count > 0;

        //    if (errorSaveChanges)
        //        return new ResponseDto(500, notifications);

        //    var customerResponse = _mapper.Map<CustomerDetailsDto>(customerUpdate);

        //    return new ResponseDto(200, customerResponse);
        //}

        //public async Task<ResponseDto> DeleteCustomerAsync(int id)
        //{
        //    List<Notification> notifications = new List<Notification>();

        //    if (id <= 0)
        //        notifications.Add(new Notification("idInvalid", "O id do cliente é inválido"));

        //    var dataInvalid = notifications.Count > 0;

        //    if (dataInvalid)
        //        return new ResponseDto(400, notifications);

        //    var customer = await _repository.GetCustomerByIdAsync(id);

        //    var customerNotFound = customer == null;

        //    if (customerNotFound)
        //    {
        //        notifications.Add(new Notification("customerNotFound", "Cliente não encontrado."));
        //        return new ResponseDto(404, notifications); ;
        //    }

        //    _repository.Delete(customer);

        //    if (!await _repository.SaveChangesAsync())
        //        notifications.Add(new Notification("saveChangesError", "Erro ao excluir o cliente."));

        //    var errorSaveChanges = notifications.Count > 0;

        //    if (errorSaveChanges)
        //        return new ResponseDto(500, notifications);

        //    return new ResponseDto();
        //}
    }
}
