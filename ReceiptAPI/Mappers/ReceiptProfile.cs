using AutoMapper;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;

namespace ReceiptAPI.Mappers
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerDetailsDto>();
        }
    }
}
