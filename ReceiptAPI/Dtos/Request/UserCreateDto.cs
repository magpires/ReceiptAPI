using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserCreateDtoContract Validate()
        {
            return new UserCreateDtoContract(this);
        }
    }
}
