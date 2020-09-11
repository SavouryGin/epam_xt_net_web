using System;
using System.Collections.Generic;

namespace Models
{
    public class UserModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<AwardModel> Awards { get; set; }
    }
}
