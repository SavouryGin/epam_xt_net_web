using System;

namespace Common.Entities
{
    public class Nexus : BaseEntity
    {
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
