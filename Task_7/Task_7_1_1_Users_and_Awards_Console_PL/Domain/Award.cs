using System;
using System.Collections.Generic;

namespace Domain
{
    public class Award
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Guid> UsersAwarded { get; set; }

    }
}
