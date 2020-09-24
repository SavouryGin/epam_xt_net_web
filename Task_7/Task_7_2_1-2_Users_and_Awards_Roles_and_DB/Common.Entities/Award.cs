using Common.Entities.Abstract;
using System;

namespace Common.Entities
{
    public class Award : BaseEntity
    {
        public string Title { get; private set; }

        public string Avatar { get; set; }

        private Award()
        {
            Id = Guid.NewGuid();
        }

        public Award(string title, string ava = null) : this()
        {
            Title = title;
            Avatar = ava;
        }
    }
}
