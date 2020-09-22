using System;

namespace Common.Entities.Abstract
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
