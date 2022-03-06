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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> GetCustomersAsync()
        {
            var customers = await _repository.GetCustomersAsync();

            var customersResponse =  _mapper.Map<List<CustomerDto>>(customers);

            return new ResponseDto(200, customersResponse);
        }

        public async Task<ResponseDto> GetCustomerByIdAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("id", "O id do cliente é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var customer = await _repository.GetCustomerByIdAsync(id);

            var customerNotFound = customer == null;

            if (customerNotFound)
            {
                notifications.Add(new Notification("data.customer", "Cliente não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var customerResponse = _mapper.Map<CustomerDetailsDto>(customer);

            return new ResponseDto(200, customerResponse);
        }

        public async Task<ResponseDto> PostCustomerAsync(CustomerPostDto customer)
        {
            var contractNotifications = customer.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var emailExists = await _repository.GetCustomerByEmailAsync(customer.Email) != null;

            if (emailExists)
            {
                notifications.Add(new Notification("data.customer", "Já existe um cliente com este endereço de email."));
                return new ResponseDto(400, notifications); ;
            }

            var addCustomer = _mapper.Map<Customer>(customer);

            _repository.Add(addCustomer);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("data.customer", "Erro ao salvar o cliente."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var customerResponse = _mapper.Map<CustomerDetailsDto>(addCustomer);

            return new ResponseDto(200, customerResponse);
        }

        public async Task<ResponseDto> UpdateCustomerAsync(int id, CustomerUpdateDto customer)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("id", "O id do cliente é inválido"));

            var contractNotifications = customer.Validate();

            var dataInvalid = !contractNotifications.IsValid || notifications.Count > 0;

            if (dataInvalid)    
                return new ResponseDto(400, contractNotifications, notifications);

            var customerDatabase = await _repository.GetCustomerByIdAsync(id);

            var customerNotFound = customerDatabase == null;

            if (customerNotFound)
            {
                notifications.Add(new Notification("data.customer", "Cliente não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var emailExists = await _repository.GetCustomerByEmailAsync(customer.Email) != null;

            if (emailExists)
            {
                notifications.Add(new Notification("data.customer", "Já existe um cliente com este endereço de email."));
                return new ResponseDto(400, notifications); ;
            }

            var customerUpdate = _mapper.Map(customer, customerDatabase);

            _repository.Update(customerUpdate);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("data.customer", "Erro ao atualizar o cliente"));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var customerResponse = _mapper.Map<CustomerDetailsDto>(customerUpdate);

            return new ResponseDto(200, customerResponse);
        }

        public async Task<ResponseDto> DeleteCustomerAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("id", "O id do cliente é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var customer = await _repository.GetCustomerByIdAsync(id);

            var customerNotFound = customer == null;

            if (customerNotFound)
            {
                notifications.Add(new Notification("data.customer", "Cliente não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            _repository.Delete(customer);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("data.customer", "Erro ao excluir o cliente."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            return new ResponseDto();
        }
    }
}
