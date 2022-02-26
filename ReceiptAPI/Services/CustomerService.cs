using AutoMapper;
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
    }
}
