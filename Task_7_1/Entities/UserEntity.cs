using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int UserId { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
