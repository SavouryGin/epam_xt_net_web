using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<AwardEntity> Awards { get; set; }
    }
}
