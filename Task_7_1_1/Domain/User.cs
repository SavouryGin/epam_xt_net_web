using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Award> Awards { get; set; }

        public Guid Id { get; set; }
    }
}
