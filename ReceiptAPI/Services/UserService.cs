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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();

            var usersResponse =  _mapper.Map<List<UserDto>>(users);

            return new ResponseDto(200, usersResponse);
        }

        public async Task<ResponseDto> GetUserByIdAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id do usuário é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var user = await _repository.GetUserByIdAsync(id);

            var userNotFound = user == null;

            if (userNotFound)
            {
                notifications.Add(new Notification("userNotFound", "Usuário não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var userResponse = _mapper.Map<UserDetailsDto>(user);

            return new ResponseDto(200, userResponse);
        }
        
        public async Task<ResponseDto> PostUserAsync(UserPostDto user)
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

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("saveChangesError", "Erro ao salvar o usuário."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var userResponse = _mapper.Map<UserDetailsDto>(addUser);

            return new ResponseDto(200, userResponse);
        }

        public async Task<ResponseDto> UpdateUserAsync(int id, UserUpdateDto user)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id do usuário é inválido"));

            var contractNotifications = user.Validate();

            var dataInvalid = !contractNotifications.IsValid || notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, contractNotifications, notifications);

            var userDatabase = await _repository.GetUserByIdAsync(id);

            var userNotFound = userDatabase == null;

            if (userNotFound)
            {
                notifications.Add(new Notification("userNotFound", "Usuário não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            var emailChanged = user.Email != userDatabase.Email;

            if (emailChanged)
            {
                var emailExists = await _repository.GetUserByEmailAsync(user.Email) != null;

                if (emailExists)
                {
                    notifications.Add(new Notification("emailExists", "O email informado já está cadastrado."));
                    return new ResponseDto(400, notifications); ;
                }
            }

            var passwordChanged = !string.IsNullOrEmpty(user.Password);

            var userUpdate = _mapper.Map(user, userDatabase);
            userUpdate.SetUpdatedAt();

            if (passwordChanged)
                userUpdate.EncryptPassword(user.Password);

            _repository.Update(userUpdate);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("saveChangesError", "Erro ao atualizar o usuário"));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var userResponse = _mapper.Map<UserDetailsDto>(userUpdate);

            return new ResponseDto(200, userResponse);
        }

        public async Task<ResponseDto> DeleteUserAsync(int id)
        {
            List<Notification> notifications = new List<Notification>();

            if (id <= 0)
                notifications.Add(new Notification("idInvalid", "O id do usuário é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var user = await _repository.GetUserByIdAsync(id);

            var userNotFound = user == null;

            if (userNotFound)
            {
                notifications.Add(new Notification("userNotFound", "Usuário não encontrado."));
                return new ResponseDto(404, notifications); ;
            }

            _repository.Delete(user);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("saveChangesError", "Erro ao excluir o usuário."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            return new ResponseDto();
        }
    }
}
