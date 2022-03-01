using AutoMapper;
using Flunt.Notifications;
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

            var customersDto =  _mapper.Map<List<CustomerDto>>(customers);

            return new ResponseDto(200, customersDto);
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

            var customersDto = _mapper.Map<CustomerDetailsDto>(customer);

            return new ResponseDto(200, customersDto);

            throw new System.NotImplementedException();
        }
    }
}
