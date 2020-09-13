using Mappers;
using Models;
using Services;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AwardsController
    {
        private readonly IAwardsService _awardsService;

        public AwardsController()
        {
            _awardsService = new AwardsService();
        }

        public void CreateNewAward(AwardModel model)
        {
            _awardsService.CreateNewAward(model.ToDomain());
        }
    }
}
