using System;

namespace Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string Avatar { get; set; }

        private User()
        {
            Id = Guid.NewGuid();
            DateOfCreation = DateTime.Now;
        }

        public User(string name, DateTime date, string ava = null) : this()
        {
            Name = name;
            DateOfBirth = date;
            Avatar = ava;

            // Calculate age based on date of birth
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirth.Year;
            if (DateOfBirth > now.AddYears(-age)) age--;
            Age = age;
        }
    }
}
