﻿using AutoMapper;
using ReceiptAPI.Dtos.Request;
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
            CreateMap<CustomerPostDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CustomerUpdateDto, Customer>()
                .ForMember(dest => dest.Email, opt => opt.Condition(srcMember => (srcMember.Email != "")));
        }
    }
}
