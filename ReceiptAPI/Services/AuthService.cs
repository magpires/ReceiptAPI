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
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;

        public AuthService(IUserRepository repository, IMapper mapper, ITokenService token)
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

        public async Task<ResponseDto> RegisterAsync(UserCreateDto user)
        {
            var contractNotifications = user.Validate();
            List<Notification> notifications = new List<Notification>();

            var dataInvalid = !contractNotifications.IsValid;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications);

            var emailExists = await _repository.GetUserByEmailAsync(user.Email) != null;

            if (emailExists)
            {
                notifications.Add(new Notification("emailExists", "O email informado já está cadastrado."));
                return new ResponseDto(400, notifications); ;
            }

            var addUser = _mapper.Map<User>(user);
            addUser.EncryptPassword(user.Password);
            addUser.SetCreatedAt();

            _repository.Add(addUser);

            var saveChangesError = !await _repository.SaveChangesAsync();

            if (saveChangesError)
                notifications.Add(new Notification("saveChangesError", "Erro ao salvar o usuário."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var userResponse = _mapper.Map<UserDetailsDto>(addUser);
            var token = _token.GenerateToken(addUser);

            TokenDto tokenDto = new TokenDto
            {
                User = userResponse,
                Token = token,
            };

            return new ResponseDto(200, tokenDto);
        }
    }
}
