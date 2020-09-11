using System;
using Entities;


namespace Data.Repositories.Abstract
{
    public interface IUsersRepository
    {
        void AddUser(UserEntity user);

        void UpdateUser(UserEntity user);

        UserEntity GetUserById(Guid id);

        void DeleteUserById(Guid id);

    }
}
