using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this User user)
        {
            return new UserEntity
            {
                Age = user.Age,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                UserId = user.UserId
            };
        }

        public static User ToDomain(this UserModel user)
        {
            if (user == null) return null;

            return new User
            {
                Name = user.Name,
                Age = user.Age,
                UserId = user.UserId,
                DateOfBirth = user.DateOfBirth,
                Awards = user.Awards.Select(x => x.ToDomain()).ToList()
            };
        }
    }
}
