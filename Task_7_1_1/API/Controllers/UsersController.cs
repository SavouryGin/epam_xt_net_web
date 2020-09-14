using Mappers;
using Models;
using Services;
using Services.Abstract;

namespace API.Controllers
{
    public class UsersController
    {
        private readonly IUsersService _usersService;
        private readonly IAwardsService _awardsService;

        public UsersController()
        {
            _usersService = new UsersService();
            _awardsService = new AwardsService();
        }

        public void AddNewUser(UserModel model)
        {
            _usersService.AddUser(model.ModelToDomain());
        }

        public void AddAwardToUser(AwardModel award, UserModel user)
        {
            _usersService.AddAwardToUser(award.Id, user.Id);
        }

        public void RemoveAwardFromUser(AwardModel award, UserModel user)
        {
            _usersService.RemoveAwardFromUser(award.Id, user.Id);
        }

        public void AddNewAward(AwardModel model)
        {
            _awardsService.AddAward(model.ModelToDomain());
        }

        public void SaveAllChanges()
        {
            _usersService.SaveAllChanges();
            _awardsService.SaveAllChanges();
        }
    }
}
