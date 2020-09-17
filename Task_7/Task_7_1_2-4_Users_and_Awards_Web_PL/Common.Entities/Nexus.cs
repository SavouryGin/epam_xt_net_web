using System;

namespace Common.Entities
{
    public class Nexus : IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public Guid UserId { get; private set; }

        public Guid AwardId { get; private set; }

        private Nexus()
        {
            Id = Guid.NewGuid();
        }

        public Nexus(Guid userId, Guid awardId) : this()
        {
            UserId = userId;
            AwardId = awardId;
        }
    }
}
