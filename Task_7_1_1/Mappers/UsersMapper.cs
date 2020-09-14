using System;
using System.Collections.Generic;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class UsersMapper
    {
        public static UserEntity DomainToEntity(this User user)
        {
            if (user == null) return null;

            DateTime created = DateTime.Now;

            return new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Awards = user.Awards,
                DateOfCreation = created
            };
        }

        public static User ModelToDomain(this UserModel user)
        {
            if (user == null) return null;

            DateTime now = DateTime.Today;
            int age = now.Year - user.DateOfBirth.Year;
            if (user.DateOfBirth > now.AddYears(-age)) age--;

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Age = age,
                DateOfBirth = user.DateOfBirth,
                Awards = new List<Guid>()
            };
        }

        public static User EntityToDomain(this UserEntity user)
        {
            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Awards = user.Awards
            };
        }

        public static UserModel DomainToModel(this User user)
        {
            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}
