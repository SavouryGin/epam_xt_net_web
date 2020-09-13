﻿using Data.Repositories.Abstract;
using Data.Repositories;
using Domain;
using Services.Abstract;
using System;
using Mappers;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        private static List<User> _listOfUsers = new List<User>();

        public UsersService()
        {
            _usersRepository = new UsersRepository();

            foreach (var user in _usersRepository.GetAllUsers())
            {
                _listOfUsers.Add(user.EntityToDomain());
            }
        }

        public void CreateNewUser(User user)
        {
            _usersRepository.CreateNewUser(user.ToEntity());
        }

        public void DeleteUserById(Guid id)
        {
            // TODO: DeleteUserById
            throw new NotImplementedException();
        }

        public User GetUserById(Guid id)
        {
            return _listOfUsers.FirstOrDefault(n => n.Id == id);
        }

        public void UpdateUser(User user)
        {
            // TODO: UpdateUser
            throw new NotImplementedException();
        }

        public List<User> GetUsersList()
        {
            return _listOfUsers;
        }
    }
}
