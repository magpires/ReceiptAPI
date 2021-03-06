using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class UserUpdateDtoContract : Contract<UserCreateDtoContract>
    {
        public UserUpdateDtoContract(UserUpdateDto user)
        {
            Requires()
                .IsNotNullOrEmpty(user.Name, "nameIsNotNullOrEmpty", "O nome do usuário não pode ser nulo.")
                .IsLowerOrEqualsThan(user.Name, 255, "nameIsLowerOrEqualsThan", "O nome do cliente não deve ter mais que 255 digitos.")
                .IsNotNullOrEmpty(user.Email, "emailIsNotNullOrEmpty", "O email do usuário não pode ser nulo.")
                .IsEmail(user.Email, "emailIsEmail", "Email inválido.")
                .IsLowerThan(user.Email, 101, "emailIsLowerThan", "O email do usuário não pode ter mais que 100 digitos");
                
            var passwordNotNull = user.Password != null;

            if (passwordNotNull)
            {
                Requires()
                    .IsNotNullOrEmpty(user.Password, "passwordIsNotNullOrEmpty", "A senha do usuário não pode ser vazia.")
                    .IsLowerOrEqualsThan(user.Password, 256, "passwordIsLowerOrEqualsThan", "A senha do usuário não deve ter mais que 255 digitos.")
                    .IsGreaterOrEqualsThan(user.Password, 8, "passwordIsGreaterOrEqualsThan", "A senha do usuário não deve ter menos que 8 digitos.")
                    .IsNotNullOrEmpty(user.ConfirmPassword, "confirmPasswordIsNotNullOrEmpty", "A confirmação de senha não pode ser nula.")
                    .AreEquals(user.Password, user.ConfirmPassword, "passwordAreEquals", "As senhas não coincidem.");
            }
        }
    }
}
