using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class CustomerUpdateDtoContract : Contract<CustomerUpdateDtoContract>
    {
        public CustomerUpdateDtoContract(CustomerUpdateDto customer)
        {
            Requires()
                .IsNotNullOrEmpty(customer.Name, "data.name", "O nome do cliente não pode ser nulo.")
                .IsLowerThan(customer.Name, 256, "data.name", "O nome do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.PhoneNumber, "data.phoneNumber", "O telefone do cliente não pode ser nulo.")
                .Matches(customer.PhoneNumber, @"^\d+$", "data.phoneNumber", "O telefone do cliente deve ter apenas números.")
                .IsLowerThan(customer.PhoneNumber, 12, "data.phoneNumber", "O telefone do cliente não deve ter mais que 11 digitos.")
                .IsGreaterThan(customer.HouseNumber, 0, "data.houseNumber", "O número da casa não pode ser menor ou igual a 0.")
                .IsNotNullOrEmpty(customer.PostalCode, "data.postalCode", "O CEP do cliente não pode ser nulo.")
                .Matches(customer.PostalCode, @"^\d+$", "data.postalCode", "O CEP do cliente deve ter apenas números.")
                .IsLowerThan(customer.PostalCode, 9, "data.postalCode", "O CEP do cliente não deve ter mais que 8 digitos.")
                .IsNotNullOrEmpty(customer.Street, "data.street", "A rua do cliente não pode ser nula.")
                .IsLowerThan(customer.Street, 256, "data.street", "A rua do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.District, "data.district", "O bairro do cliente não pode ser nulo.")
                .IsLowerThan(customer.District, 256, "data.district", "O bairro do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.City, "data.city", "A cidade do cliente não pode ser nula.")
                .IsLowerThan(customer.City, 256, "data.district", "A cidade do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(customer.State, "data.state", "O Estado do cliente não pode ser nulo.")
                .IsLowerThan(customer.State, 256, "data.district", "O Estado do cliente não deve ter mais que 255 digitos.");

            var emailNotNull = customer.Email != null;

            if (emailNotNull)
            {
                IsEmail(customer.Email, "data.email", "Email inválido.");
                IsLowerThan(customer.Email, 101, "data.email", "O email do cliente não pode ter mais que 100 digitos");
            }
        }
    }
}
