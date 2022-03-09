using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class CustomerPostDtoContract : Contract<CustomerPostDtoContract>
    {
        public CustomerPostDtoContract(CustomerPostDto customer)
        {
            Requires()
                .IsNotNullOrEmpty(customer.Name, "nameNotNullOrEmpty", "O nome do cliente não pode ser nulo.")
                .IsLowerOrEqualsThan(customer.Name, 255, "nameIsLowerOrEqualsThan", "O nome do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.PhoneNumber, "phoneNumberIsNotNullOrEmpty", "O telefone do cliente não pode ser nulo.")
                .Matches(customer.PhoneNumber, @"^\d+$", "phoneNumberNumberOly", "O telefone do cliente deve ter apenas números.")
                .IsLowerOrEqualsThan(customer.PhoneNumber, 11, "phoneNumberIsLowerOrEqualsThan", "O telefone do cliente não deve ter mais que 11 digitos.")
                .IsGreaterThan(customer.HouseNumber, 0, "houseNumberIsGreaterThan", "O número da casa não pode ser menor ou igual a 0.")
                .IsNotNullOrEmpty(customer.PostalCode, "postalCodeIsNotNullOrEmpty", "O CEP do cliente não pode ser nulo.")
                .Matches(customer.PostalCode, @"^\d+$", "data.postalCode", "O CEP do cliente deve ter apenas números.")
                .IsLowerOrEqualsThan(customer.PostalCode, 8, "postalCodeNumberOly", "O CEP do cliente não deve ter mais que 8 digitos.")
                .IsNotNullOrEmpty(customer.Street, "streetIsNotNullOrEmpty", "A rua do cliente não pode ser nula.")
                .IsLowerOrEqualsThan(customer.Street, 255, "streetIsLowerOrEqualsThan", "A rua do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.District, "districtIsNotNullOrEmpty", "O bairro do cliente não pode ser nulo.")
                .IsLowerOrEqualsThan(customer.District, 255, "districtIsLowerOrEqualsThan", "O bairro do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.City, "cityIsNotNullOrEmpty", "A cidade do cliente não pode ser nula.")
                .IsLowerOrEqualsThan(customer.City, 255, "districtIsLowerOrEqualsThan", "A cidade do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.State, "stateIsNotNullOrEmpty", "O Estado do cliente não pode ser nulo.")
                .IsLowerOrEqualsThan(customer.State, 255, "districtIsLowerOrEqualsThan", "O Estado do cliente não deve ter mais que 255 digitos.");

            var emailNotNull = customer.Email != null;

            if (emailNotNull)
            {
                IsEmail(customer.Email, "emailIsEmail", "Email inválido.");
                IsLowerThan(customer.Email, 101, "emailIsLowerThan", "O email do cliente não pode ter mais que 100 digitos");
            }
        }
    }
}
