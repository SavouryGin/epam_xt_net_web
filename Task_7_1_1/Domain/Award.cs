using System.Collections.Generic;

namespace Domain
{
    public class Award
    {
        public string Title { get; set; }

        public List<User> UsersAwarded { get; set; }

    }
}
