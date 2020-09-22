using Common.Entities.Abstract;
using System;

namespace Common.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Avatar { get; set; }

        // New fields for the Role Model
        public string Password { get; set; }

        public bool IsAdmin { get; set; }


        private User()
        {
            Id = Guid.NewGuid();
            DateOfCreation = DateTime.Now;
        }

        public User(string name, DateTime date, string ava = null, bool isAdmin = false) : this()
        {
            Name = name;
            DateOfBirth = date;
            Avatar = ava;
            IsAdmin = isAdmin;
            Password = null;

            // Calculate age based on date of birth
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirth.Year;
            if (DateOfBirth > now.AddYears(-age)) age--;
            Age = age;
        }
    }
}
