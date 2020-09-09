using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Entities;

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
    }
}
