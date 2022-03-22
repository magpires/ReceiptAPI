using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class UserCreateDtoContract : Contract<UserCreateDtoContract>
    {
        public UserCreateDtoContract(UserCreateDto user)
        {
            Requires()
                .IsNotNullOrEmpty(user.Name, "nameIsNotNullOrEmpty", "O nome do usuário não pode ser nulo.")
                .IsLowerOrEqualsThan(user.Name, 255, "nameIsLowerOrEqualsThan", "O nome do usuário não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(user.Email, "emailIsNotNullOrEmpty", "O email do usuário não pode ser nulo.")
                .IsEmail(user.Email, "emailIsEmail", "Email inválido.")
                .IsLowerThan(user.Email, 100, "emailIsLowerThan", "O email do usuário não pode ter mais que 100 digitos")
                .IsNotNullOrEmpty(user.Password, "passwordIsNotNullOrEmpty", "A senha do usuário não pode ser nula.")
                .IsLowerOrEqualsThan(user.Password, 255, "passwordIsLowerOrEqualsThan", "A senha do usuário não deve ter mais que 255 digitos.")
                .IsGreaterOrEqualsThan(user.Password, 8, "passwordIsGreaterOrEqualsThan", "A senha do usuário não deve ter menos que 8 digitos.")
                .IsNotNullOrEmpty(user.ConfirmPassword, "confirmPasswordIsNotNullOrEmpty", "A confirmação de senha não pode ser nula.")
                .AreEquals(user.Password, user.ConfirmPassword, "passwordAreEquals", "As senhas não coincidem.");
        }
    }
}
