using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        // List of user awards
        public List<Award> Awards { get; set; }
    }
}
