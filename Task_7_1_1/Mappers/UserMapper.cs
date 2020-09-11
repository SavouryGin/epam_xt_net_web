using System.Linq;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this User user)
        {
            if (user == null) return null;

            return new UserEntity
            {
                Age = user.Age,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth
            };
        }

        public static User ToDomain(this UserModel user)
        {
            if (user == null) return null;

            return new User
            {
                Name = user.Name,
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Awards = user.Awards.Select(x => x.ToDomain()).ToList()
            };
        }

        public static UserModel ToModel(this User user)
        {
            if (user == null) return null;

            return new UserModel
            {
                Name = user.Name,
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Awards = user.Awards.Select(x => x.ToModel()).ToList()
            };
        }
    }
}
