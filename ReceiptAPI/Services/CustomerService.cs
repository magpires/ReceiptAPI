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

            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto> PostCustomerAsync(CustomerPostDto customer)
        {
            var contractNotifications = customer.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var addCustomer = _mapper.Map<Customer>(customer);

            _repository.Add(addCustomer);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("data.customer", "Erro ao salvar o cliente."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(400, notifications);

            var customerResponse = _mapper.Map<CustomerDetailsDto>(addCustomer);

            return new ResponseDto(200, customerResponse);
        }
    }
}
