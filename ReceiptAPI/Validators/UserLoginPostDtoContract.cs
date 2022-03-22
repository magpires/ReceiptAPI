using Flunt.Validations;
using ReceiptAPI.Dtos.Request;

namespace ReceiptAPI.Validators
{
    public class UserLoginPostDtoContract : Contract<UserLoginPostDtoContract>
    {
        public UserLoginPostDtoContract(UserLoginPostDto user)
        {
            Requires()
                .IsNotNullOrEmpty(user.Email, "emailIsNotNullOrEmpty", "Por favor, insira seu email.")
                .IsEmail(user.Email, "emailIsEmail", "Email inválido.")
                .IsNotNullOrEmpty(user.Password, "passwordIsNotNullOrEmpty", "Por favor, insira sua senha.")
                .IsLowerOrEqualsThan(user.Password, 255, "passwordIsLowerOrEqualsThan", "A senha do usuário não deve ter mais que 255 digitos.");
        }
    }
}
