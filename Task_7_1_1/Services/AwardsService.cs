using Data.Repositories.Abstract;
using Data.Repositories;
using Domain;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mappers;

namespace Services
{
    public class AwardsService : IAwardsService
    {
        private readonly IAwardsRepository _awardsRepository;
        public AwardsService()
        {
            _awardsRepository = new AwardsRepository();
        }
        public void CreateNewAward(Award award)
        {
            _awardsRepository.CreateNewAward(award.ToEntity());
        }

        public void DeleteAwardById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Award GetAwardById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAward(Award award)
        {
            throw new NotImplementedException();
        }
    }
}
