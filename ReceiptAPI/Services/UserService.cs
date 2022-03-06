﻿using AutoMapper;
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
                notifications.Add(new Notification("id", "O id do usuário é inválido"));

            var dataInvalid = notifications.Count > 0;

            if (dataInvalid)
                return new ResponseDto(400, notifications);

            var user = await _repository.GetUserByIdAsync(id);

            var userNotFound = user == null;

            if (userNotFound)
            {
                notifications.Add(new Notification("data.user", "Usuário não encontrado."));
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
                notifications.Add(new Notification("data.user", "O email informado já está cadastrado."));
                return new ResponseDto(400, notifications); ;
            }

            var addUser = _mapper.Map<User>(user);
            addUser.EncryptPassword();
            addUser.SetCreatedAt();

            _repository.Add(addUser);

            if (!await _repository.SaveChangesAsync())
                notifications.Add(new Notification("data.user", "Erro ao salvar o usuário."));

            var errorSaveChanges = notifications.Count > 0;

            if (errorSaveChanges)
                return new ResponseDto(500, notifications);

            var userResponse = _mapper.Map<UserDetailsDto>(addUser);

            return new ResponseDto(200, userResponse);
        }

        //public async Task<ResponseDto> UpdateCustomerAsync(int id, CustomerUpdateDto customer)
        //{
        //    List<Notification> notifications = new List<Notification>();

        //    if (id <= 0)
        //        notifications.Add(new Notification("id", "O id do cliente é inválido"));

        //    var contractNotifications = customer.Validate();

        //    var dataInvalid = !contractNotifications.IsValid || notifications.Count > 0;

        //    if (dataInvalid)    
        //        return new ResponseDto(400, contractNotifications, notifications);

        //    var customerDatabase = await _repository.GetCustomerByIdAsync(id);

        //    var customerNotFound = customerDatabase == null;

        //    if (customerNotFound)
        //    {
        //        notifications.Add(new Notification("data.customer", "Cliente não encontrado."));
        //        return new ResponseDto(404, notifications); ;
        //    }

        //    var customerUpdate = _mapper.Map(customer, customerDatabase);

        //    _repository.Update(customerUpdate);

        //    if (!await _repository.SaveChangesAsync())
        //        notifications.Add(new Notification("data.customer", "Erro ao atualizar o cliente"));

        //    var errorSaveChanges = notifications.Count > 0;

        //    if (errorSaveChanges)
        //        return new ResponseDto(500, notifications);

        //    var customerResponse = _mapper.Map<CustomerDetailsDto>(customerUpdate);

        //    return new ResponseDto(200, customerResponse);
        //}

        //public async Task<ResponseDto> DeleteCustomerAsync(int id)
        //{
        //    List<Notification> notifications = new List<Notification>();

        //    if (id <= 0)
        //        notifications.Add(new Notification("id", "O id do cliente é inválido"));

        //    var dataInvalid = notifications.Count > 0;

        //    if (dataInvalid)
        //        return new ResponseDto(400, notifications);

        //    var customer = await _repository.GetCustomerByIdAsync(id);

        //    var customerNotFound = customer == null;

        //    if (customerNotFound)
        //    {
        //        notifications.Add(new Notification("data.customer", "Cliente não encontrado."));
        //        return new ResponseDto(404, notifications); ;
        //    }

        //    _repository.Delete(customer);

        //    if (!await _repository.SaveChangesAsync())
        //        notifications.Add(new Notification("data.customer", "Erro ao excluir o cliente."));

        //    var errorSaveChanges = notifications.Count > 0;

        //    if (errorSaveChanges)
        //        return new ResponseDto(500, notifications);

        //    return new ResponseDto();
        //}
    }
}
