using Data.Repositories.Abstract;
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

        public void SaveUserToRepository(User user)
        {
            _usersRepository.CreateNewUser(user.DomainToEntity());
        }

        public void SaveAllChanges()
        {
            foreach (var user in _listOfUsers)
            {
                SaveUserToRepository(user);
            }
        }

        public void AddUser(User user)
        {
            if (_listOfUsers.Contains(user))
            {
                UpdateUser(user);
            } else
            {
                _listOfUsers.Add(user);
            }           
        }


        public void DeleteUserById(Guid id)
        {
            var user = GetUserById(id);
            _listOfUsers.Remove(user);
            _usersRepository.DeleteUserById(id);
        }

        public User GetUserById(Guid id)
        {
            return _listOfUsers.FirstOrDefault(n => n.Id == id);
        }

        public void UpdateUser(User user)
        {
            DeleteUserById(user.Id);
            _listOfUsers.Add(user);
            
        }

        public List<User> GetUsersList()
        {
            return _listOfUsers;
        }

        public void AddAwardToUser(Guid awardId, Guid userId)
        {
            var user = GetUserById(userId);
            var _newAwardsService = new AwardsService();
            var award = _newAwardsService.GetAwardById(awardId);
            user.Awards.Add(award.Id);
            award.UsersAwarded.Add(user.Id);
            UpdateUser(user);
            _newAwardsService.UpdateAward(award);

        }

        public void RemoveAwardFromUser(Guid awardId, Guid userId)
        {
            var user = GetUserById(userId);
            var _newAwardsService = new AwardsService();
            var award = _newAwardsService.GetAwardById(awardId);
            user.Awards.Add(award.Id);
            award.UsersAwarded.Remove(user.Id);
            UpdateUser(user);
            _newAwardsService.UpdateAward(award);
        }
    }
}
