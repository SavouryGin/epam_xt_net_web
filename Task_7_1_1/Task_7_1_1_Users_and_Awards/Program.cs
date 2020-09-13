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
            user1.FirstName = "Dmitriy";
            user1.LastName = "Surovyagin";
            user1.DateOfBirth = new DateTime(1989, 4, 7).Date;
            user1.Awards = new List<AwardModel>();

            //UserModel user2 = new UserModel();
            //user2.FirstName = "Anna";
            //user2.LastName = "Petrova";
            //user2.Age = 26;
            //user2.DateOfBirth = new DateTime(1996, 12, 12).Date;
            //user2.Awards = new List<AwardModel>();

            UsersController c1 = new UsersController();
            c1.CreateNewUser(user1);
            //c1.CreateNewUser(user2);

            AwardModel award1 = new AwardModel();
            award1.Title = "First Plase";
            award1.UsersAwarded = new List<UserModel> { user1 };

            AwardsController a1 = new AwardsController();
            a1.CreateNewAward(award1);

            Console.WriteLine("Enter your first Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter your last Name: ");
            string lname = Console.ReadLine();


        }
    }
}
