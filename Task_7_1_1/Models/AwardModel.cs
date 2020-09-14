using System;
using System.Collections.Generic;

namespace Models
{
    public class AwardModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        //public List<string> UsersAwarded { get; set; }

        public override string ToString() => string.Format("Award Title: {0}", Title);
    }
}
