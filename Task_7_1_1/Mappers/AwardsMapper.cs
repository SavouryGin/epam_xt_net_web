using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace Mappers
{
    public static class AwardsMapper
    {
        public static AwardEntity DomainToEntity(this Award award)
        {
            if (award == null) return null;

            DateTime created = DateTime.Now;

            return new AwardEntity
            {
                Id = award.Id,
                Title = award.Title,
                UsersAwarded = award.UsersAwarded,
                DateOfCreation = created
            };
        }

        public static Award EntityToDomain(this AwardEntity award)
        {
            if (award == null) return null;

            return new Award
            {
                Id = award.Id,
                Title = award.Title,
                UsersAwarded = award.UsersAwarded
            };
        }

        public static Award ModelToDomain(this AwardModel award)
        {
            if (award == null) return null;

            return new Award
            {
                Id = award.Id,
                Title = award.Title,
                UsersAwarded = new List<Guid>()
            };
        }

        public static AwardModel DomainToModel(this Award award)
        {
            if (award == null) return null;

            return new AwardModel
            {
                Id = award.Id,
                Title = award.Title
            };
        }
    }
}
