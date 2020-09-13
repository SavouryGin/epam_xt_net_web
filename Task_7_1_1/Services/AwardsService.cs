using Data.Repositories.Abstract;
using Data.Repositories;
using Domain;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Mappers;

namespace Services
{
    public class AwardsService : IAwardsService
    {
        private readonly IAwardsRepository _awardsRepository;

        private static List<Award> _listOfAwards = new List<Award>();

        public AwardsService()
        {
            _awardsRepository = new AwardsRepository();

            foreach (var award in _awardsRepository.GetAllAwards())
            {
                _listOfAwards.Add(award.EntityToDomain());
            }
        }
        public void CreateNewAward(Award award)
        {
            _awardsRepository.CreateNewAward(award.DomainToEntity());
        }

        public void DeleteAwardById(Guid id)
        {
            // TODO: DeleteAwardById
            throw new NotImplementedException();
        }

        public Award GetAwardById(Guid id)
        {
            return _listOfAwards.FirstOrDefault(n => n.Id == id);
        }

        public List<Award> GetAwardsList()
        {
            return _listOfAwards;
        }

        public void UpdateAward(Award award)
        {
            // TODO: UpdateAward
            throw new NotImplementedException();
        }
    }
}
