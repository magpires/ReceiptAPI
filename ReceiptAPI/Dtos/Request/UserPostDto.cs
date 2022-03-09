using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class UserPostDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserPostDtoContract Validate()
        {
            return new UserPostDtoContract(this);
        }
    }
}
