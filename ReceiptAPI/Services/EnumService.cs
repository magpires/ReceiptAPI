using AutoMapper;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using ReceiptAPI.Shared.Helpers;

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
            var enums = Enum.GetValues<PaymentMethod>().Cast<PaymentMethod>();

            var paymentsMethods = new List<PaymentMethodDto>();

            foreach (var enumValue in enums)
            {
                paymentsMethods.Add(new PaymentMethodDto
                {
                    Description = TranslateToPtBrHelper.TranslatePaymentMethod(enumValue),
                    Value = enumValue
                });
            }

            return new ResponseDto(200, paymentsMethods);
        }
    }
}
