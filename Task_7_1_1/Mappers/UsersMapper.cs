using System;
using System.Linq;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class UsersMapper
    {
        public static UserEntity ToEntity(this User user)
        {
            if (user == null) return null;
            DateTime created = DateTime.Now;

            return new UserEntity
            {
                Age = user.Age,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Id = user.Id,
                DateOfCreation = created
            };
        }

        public static User ModelToDomain(this UserModel user)
        {
            if (user == null) return null;

            return new User
            {
                Name = string.Format("{0}|{1}", user.FirstName, user.LastName),
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Id = Guid.NewGuid(),
                Awards = user.Awards.Select(x => x.ToDomain()).ToList()
            };
        }

        public static User EntityToDomain(this UserEntity user)
        {
            return new User
            {
                Name = user.Name,
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Id = user.Id
            };
        }

        public static UserModel ToModel(this User user)
        {
            if (user == null) return null;

            return new UserModel
            {
                FirstName = user.Name.Split('|')[0],
                LastName = user.Name.Split('|')[1],
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Awards = user.Awards.Select(x => x.ToModel()).ToList()
            };
        }
    }
}
