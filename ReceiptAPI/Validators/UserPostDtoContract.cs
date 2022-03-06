using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class UserPostDtoContract : Contract<UserPostDtoContract>
    {
        public UserPostDtoContract(UserPostDto user)
        {
            Requires()
                .IsNotNullOrEmpty(user.Name, "data.name", "O nome do usuário não pode ser nulo.")
                .IsLowerOrEqualsThan(user.Name, 255, "data.name", "O nome do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(user.Email, "data.email", "O email do usuário não pode ser nulo.")
                .IsEmail(user.Email, "data.email", "Email inválido.")
                .IsLowerThan(user.Email, 101, "data.email", "O email do usuário não pode ter mais que 100 digitos")
                .IsNotNullOrEmpty(user.Password, "data.password", "A senha do usuário não pode ser nula.")
                .IsLowerOrEqualsThan(user.Password, 256, "data.password", "A senha do usuário não deve ter mais que 255 digitos.")
                .IsGreaterOrEqualsThan(user.Password, 8, "data.password", "A senha do usuário não deve ter menos que 8 digitos.")
                .IsNotNullOrEmpty(user.ConfirmPassword, "data.confirmPassword", "A confirmação de senha não pode ser nula.")
                .AreEquals(user.Password, user.ConfirmPassword, "data.password", "As senhas não coincidem.");
        }
    }
}
