using AutoMapper;
using Flunt.Notifications;
using ReceiptAPI.Dtos.Request;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;
using ReceiptAPI.Repositories.Interfaces;
using ReceiptAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;

        public LoginService(IUserRepository repository, IMapper mapper, ITokenService token)
        {
            _repository = repository;
            _mapper = mapper;
            _token = token;
        }

        public async Task<ResponseDto> AuthenticateAsync(UserLoginPostDto user)
        {
            var contractNotifications = user.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var userDatabase = await _repository.GetUserByEmailAsync(user.Email);     
            
            var userNotFound = userDatabase == null;

            if (userNotFound)
            {
                notifications.Add(new Notification("userNotFound", "Nenhum usuário corresponde ao endereço de email informado."));
                return new ResponseDto(404, notifications);
            }

            var passwordIncorrect = !BCrypt.Net.BCrypt.Verify(user.Password, userDatabase.Password);

            if (passwordIncorrect)
            {
                notifications.Add(new Notification("passwordIncorrect", "A senha fornecida é inválida."));
                return new ResponseDto(400, notifications);
            }

            var userResponse = _mapper.Map<UserDetailsDto>(userDatabase);
            var token = _token.GenerateToken(userDatabase);

            TokenDto tokenDto = new TokenDto
            {
                User = userResponse,
                Token = token,
            };

            return new ResponseDto(200, tokenDto);
        }
    }
}
