using System;

namespace Entities.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
