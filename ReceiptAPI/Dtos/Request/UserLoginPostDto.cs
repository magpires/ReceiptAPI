using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class UserLoginPostDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserLoginPostDtoContract Validate()
        {
            return new UserLoginPostDtoContract(this);
        }
    }
}
