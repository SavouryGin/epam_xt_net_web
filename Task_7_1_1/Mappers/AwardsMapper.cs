using Domain;
using Entities;
using Models;
using System;
using System.Linq;

namespace Mappers
{
    public static class AwardsMapper
    {
        public static AwardEntity ToEntity(this Award award)
        {
            DateTime created = DateTime.Now;

            return new AwardEntity
            {
                Title = award.Title,
                DateOfCreation = created,
                Id = award.Id
            };
        }

        public static Award ToDomain(this AwardModel award)
        {
            if (award == null) return null;

            return new Award
            {
                Title = award.Title,
                UsersAwarded = award.UsersAwarded.Select(x => x.ModelToDomain()).ToList(),
                Id = Guid.NewGuid()
            };
        }

        public static AwardModel ToModel(this Award award)
        {
            if (award == null) return null;

            return new AwardModel
            {
                Title = award.Title,
                UsersAwarded = award.UsersAwarded.Select(x => x.ToModel()).ToList()
            };
        }
    }
}
