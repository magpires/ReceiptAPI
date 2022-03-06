﻿namespace ReceiptAPI.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void EncryptPassword()
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }
    }
}
