using Domain;
using Entities;
using Models;
using System.Linq;

namespace Mappers
{
    public static class AwardMapper
    {
        public static AwardEntity ToEntity(this Award award)
        {
            return new AwardEntity
            {
                Title = award.Title
            };
        }

        public static Award ToDomain(this AwardModel award)
        {
            if (award == null) return null;

            return new Award
            {
                Title = award.Title,
                UsersAwarded = award.UsersAwarded.Select(x => x.ToDomain()).ToList()
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
