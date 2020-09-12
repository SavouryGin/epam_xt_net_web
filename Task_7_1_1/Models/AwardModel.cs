using System.Collections.Generic;

namespace Models
{
    public class AwardModel
    {
        public string Title { get; set; }

        public List<UserModel> UsersAwarded { get; set; }

    }
}
