using System;

namespace Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString() => string.Format("Name: {0}; Birthday: {1:M}.", Name, DateOfBirth);
    }
}
