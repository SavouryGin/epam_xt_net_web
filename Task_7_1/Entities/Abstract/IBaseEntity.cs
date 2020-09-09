using System;

namespace Entities.Abstract

{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime DateOfCreation { get; set; }
    }
}
