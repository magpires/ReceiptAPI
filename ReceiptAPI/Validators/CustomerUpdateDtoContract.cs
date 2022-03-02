using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class CustomerUpdateDtoContract : Contract<CustomerUpdateDtoContract>
    {
        public CustomerUpdateDtoContract(CustomerUpdateDto customer)
        {
            IsNotNullOrEmpty(customer.Name, "data.nome", "O nome do cliente não pode ser nulo.")
                .IsNotNullOrEmpty(customer.PhoneNumber, "data.phoneNumber", "O telefone do cliente não pode ser nulo.")
                .IsLowerThan(customer.PhoneNumber, 12, "data.phoneNumber", "O telefone do cliente não deve ter mais que 11 digitos.")
                .IsGreaterThan(customer.HouseNumber, 0, "data.houseNumber", "O número da casa não pode ser menor ou igual a 0.")
                .IsNotNullOrEmpty(customer.PostalCode, "data.postalCode", "O CEP do cliente não pode ser nulo.")
                .IsLowerThan(customer.PostalCode, 9, "data.postalCode", "O CEP do cliente não deve ter mais que 8 digitos.")
                .IsNotNullOrEmpty(customer.District, "data.district", "O bairro do cliente não pode ser nulo.")
                .IsNotNullOrEmpty(customer.City, "data.city", "A cidade do cliente não pode ser nula.")
                .IsNotNullOrEmpty(customer.State, "data.state", "O Estado do cliente não pode ser nulo.");

            var emailNotNull = customer.Email != null;

            if (emailNotNull) IsEmail(customer.Email, "data.email", "Email inválido.");
        }
    }
}
