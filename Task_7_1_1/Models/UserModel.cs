using System;
using System.Collections.Generic;

namespace Models
{
    public class UserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<AwardModel> Awards { get; set; }

        public override string ToString()
        {
            string userDescription = string.Format("\tFirst Name: {0}\n" +
                "\tLast Name: {1}\n \tBirthday: {2:M}",
                this.FirstName, this.LastName, this.DateOfBirth);
            return userDescription;
        }
    }
}
