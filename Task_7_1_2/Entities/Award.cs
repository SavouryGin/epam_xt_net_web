using System;

namespace Entities
{
    public class Award : IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DateOfCreation { get; set; }
        public string Title { get; private set; }
        public string Avatar { get; set; }

        private Award()
        {
            Id = Guid.NewGuid();
            DateOfCreation = DateTime.Now;
        }

        public Award(string title, string ava = null) : this()
        {
            Title = title;
            Avatar = ava;
        }
    }
}
