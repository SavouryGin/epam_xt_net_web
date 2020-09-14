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
        public void SaveAwardToRepository(Award award)
        {
            _awardsRepository.CreateNewAward(award.DomainToEntity());
        }

        public void SaveAllChanges()
        {
            foreach (var award in _listOfAwards)
            {
                SaveAwardToRepository(award);
            }
        }

        public void AddAward(Award award)
        {
            if (_listOfAwards.Contains(award))
            {
                UpdateAward(award);
            }
            else
            {
                _listOfAwards.Add(award);
            }
        }

        public void DeleteAwardById(Guid id)
        {
            var award = GetAwardById(id);
            _listOfAwards.Remove(award);
            _awardsRepository.DeleteAwardById(id);
        }

        public Award GetAwardById(Guid id)
        {
            return _listOfAwards.FirstOrDefault(n => n.Id == id);
        }

        public void UpdateAward(Award award)
        {
            DeleteAwardById(award.Id);
            _listOfAwards.Add(award);
        }
    }
}
