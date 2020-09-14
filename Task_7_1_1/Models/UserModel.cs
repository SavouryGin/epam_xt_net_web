using System;
using System.Collections.Generic;

namespace Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        //public List<Guid> Awards { get; set; }

        public override string ToString() => string.Format("Name: {0}; Birthday: {1:M}.", Name, DateOfBirth);
    }
}
