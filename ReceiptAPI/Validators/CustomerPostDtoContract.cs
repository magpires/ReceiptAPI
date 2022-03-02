using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class CustomerPostDtoContract : Contract<CustomerPostDtoContract>
    {
        public CustomerPostDtoContract(CustomerPostDto customerPostDto)
        {
            Requires()
                .IsNotNullOrEmpty(customerPostDto.Name, "data.nome", "O nome do cliente não pode ser nulo.")
                .IsNotNullOrEmpty(customerPostDto.PhoneNumber, "data.phoneNumber", "O telefone do cliente não pode ser nulo.")
                .IsLowerThan(customerPostDto.PhoneNumber, 12, "data.phoneNumber", "O telefone do cliente não deve ter mais que 11 digitos.")
                .IsGreaterThan(customerPostDto.HouseNumber, 0, "data.houseNumber", "O número da casa não pode ser menor ou igual a 0.")
                .IsNotNullOrEmpty(customerPostDto.PostalCode, "data.postalCode", "O CEP do cliente não pode ser nulo.")
                .IsLowerThan(customerPostDto.PostalCode, 9, "data.postalCode", "O CEP do cliente não deve ter mais que 8 digitos.")
                .IsNotNullOrEmpty(customerPostDto.District, "data.district", "O bairro do cliente não pode ser nulo.")
                .IsNotNullOrEmpty(customerPostDto.City, "data.city", "A cidade do cliente não pode ser nula.")
                .IsNotNullOrEmpty(customerPostDto.State, "data.state", "O Estado do cliente não pode ser nulo.");

            var emailNotNull = !string.IsNullOrEmpty(customerPostDto.Email);

            if (emailNotNull) IsEmail(customerPostDto.Email, "data.email", "Email inválido.");
        }
    }
}
