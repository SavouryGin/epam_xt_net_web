using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int UserId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Award> Awards { get; set; }
    }
}
