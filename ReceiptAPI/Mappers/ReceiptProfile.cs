﻿using AutoMapper;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;
using ReceiptAPI.Shared.Helpers;

namespace ReceiptAPI.Mappers
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .AfterMap((src, dest) => dest.PhoneNumber = CustomerHelper.FormatPhonNumbere(src.PhoneNumber));
            CreateMap<Customer, CustomerDetailsDto>()
                .AfterMap((src, dest) => dest.PhoneNumber = CustomerHelper.FormatPhonNumbere(src.PhoneNumber))
                .AfterMap((src, dest) => dest.PostalCode = CustomerHelper.FormatPostalCode(src.PostalCode));
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CustomerUpdateDto, Customer>()
                .ForMember(dest => dest.Email, opt => opt.Condition(srcMember => (srcMember.Email != "")));

            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductCreatetDto, Product>();
            CreateMap<ProductUpdateDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Receipt, ReceiptDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .AfterMap((src, dest) => dest.PaymentMethod = TranslateToPtBrHelper.TranslatePaymentMethod(src.PaymentMethod));
            CreateMap<ProductReceipt, ProductReceiptDetailsDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Quantitity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quantity * src.Product.Price));
            CreateMap<Receipt, ReceiptDetailsDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductReceipts))
                .AfterMap((src, dest) => dest.PaymentMethod = TranslateToPtBrHelper.TranslatePaymentMethod(src.PaymentMethod))
                .AfterMap((src, dest) => dest.Total = ReceiptHelper.CalculateTotalReceiptPrice(dest.Products));
            CreateMap<ReceiptCreateDto, Receipt>()
                .ForMember(dest => dest.ProductReceipts, opt => opt.Ignore());
            CreateMap<ReceiptUpdateDto, Receipt>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ReceiptUpdateDto, Receipt>()
                .ForMember(dest => dest.ProductReceipts, opt => opt.Ignore());

            CreateMap<User, UserDto>();
            CreateMap<User, UserDetailsDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserLoginPostDto, User>();
        }
    }
}
