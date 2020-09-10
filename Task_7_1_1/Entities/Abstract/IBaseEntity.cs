using System;

namespace Entities.Abstract

{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime DateOfCreation { get; set; }
    }
}
