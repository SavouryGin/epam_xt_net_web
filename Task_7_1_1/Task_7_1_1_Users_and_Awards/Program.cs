using API.Controllers;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_1_1_Users_and_Awards
{
    class Program
    {
        static void Main(string[] args)
        {
            UserModel user1 = new UserModel();
            user1.Age = 31;
            user1.Name = "Dmitriy";
            user1.DateOfBirth = new DateTime(1989, 4, 7);
            user1.Awards = new List<AwardModel>();
            user1.Id = Guid.NewGuid();
            Console.WriteLine(user1.Id);

            UsersController c1 = new UsersController();
            c1.AddUser(user1);

        }
    }
}
