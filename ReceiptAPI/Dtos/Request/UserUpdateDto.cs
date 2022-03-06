using ReceiptAPI.Validators;

namespace ReceiptAPI.Dtos.Request
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserUpdateDtoContract Validate()
        {
            return new UserUpdateDtoContract(this);
        }
    }
}
