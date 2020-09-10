using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class AwardMapper
    {
        public static AwardEntity ToEntity(this Award award)
        {
            return new AwardEntity
            {
                AwardId = award.AwardId,
                Title = award.Title,
                //UserId = award.UserId
            };
        }

        public static Award ToDomain(this AwardModel award)
        {
            if (award == null) return null;

            return new Award
            {
                Title = award.Title,
                AwardId = award.AwardId
            };
        }
    }
}
