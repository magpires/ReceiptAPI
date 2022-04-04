using AutoMapper;
using Flunt.Notifications;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;
using ReceiptAPI.Enumerators;
using ReceiptAPI.Repositories.Interfaces;
using ReceiptAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Services
{
    public class EnumService
    {
        private static IMapper _mapper;

        public EnumService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static ResponseDto GetPaymentsMethods()
        {
            var enums = Enum.GetValues<PaymentMethod>().Cast<PaymentMethod>()
                            .Select(v => v.ToString());

            var enumInt = Enum.GetValues<PaymentMethod>().Cast<PaymentMethod>();

            return new ResponseDto(200, enumInt);
        }
    }
}
