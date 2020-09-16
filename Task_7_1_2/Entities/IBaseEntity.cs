using System;

namespace Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime DateOfCreation { get; set; }
    }
}
