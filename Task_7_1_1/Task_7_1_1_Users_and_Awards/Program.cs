using API.Controllers;
using Models;
using System;
using System.Collections.Generic;

namespace Task_7_1_1_Users_and_Awards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Project Demo ===");

            // Create new users
            UserModel user1 = new UserModel();
            user1.Name = "Dmitriy";
            user1.DateOfBirth = new DateTime(1989, 4, 7).Date;
            user1.Id = Guid.NewGuid();

            UserModel user2 = new UserModel();
            user2.Name = "Anna";
            user2.DateOfBirth = new DateTime(1996, 12, 12).Date;
            user2.Id = Guid.NewGuid();

            // Create new awards
            AwardModel award1 = new AwardModel();
            award1.Title = "Gold";
            award1.Id = Guid.NewGuid();
            AwardModel award2 = new AwardModel();
            award2.Title = "Silver";
            award2.Id = Guid.NewGuid();

            // Launch controller for working with users and awards
            UsersController controller = new UsersController();

            // Save users and awards to the JSON-storage
            controller.AddNewUser(user1);
            controller.AddNewUser(user2);

            controller.AddNewAward(award1);
            controller.AddNewAward(award2);

            // // Update services
            // UsersController c2 = new UsersController();
            // AwardsController a2 = new AwardsController();

            // Add awards to the users
            controller.AddAwardToUser(award1, user1);
            controller.AddAwardToUser(award2, user1);
            controller.AddAwardToUser(award2, user2);

            controller.SaveAllChanges();



            // // Display information about stored entities
            // c2.DisplayAllUsers();
            // a2.DisplayAllAwards();

            // // Find user by name
            // Console.WriteLine("Enter your first Name: ");
            // string fname = Console.ReadLine();
            // Console.WriteLine("Enter your last Name: ");
            // string lname = Console.ReadLine();

            //var fuser = c2.FindUserByName(fname, lname);
            // if (fuser == null)
            // {
            //     Console.WriteLine("There is no such user in the repository. ");
            // }
            // else
            // {
            //     Console.WriteLine(fuser);
            // }

            // // Find user by title
            // Console.WriteLine("Enter award title: ");
            // string title = Console.ReadLine();

            // var faward = a2.FindAwardByTitle(title);
            // if (faward == null)
            // {
            //     Console.WriteLine("There is no such award in the repository. ");
            // }
            // else
            // {
            //     Console.WriteLine(faward);
            // }


            Console.ReadLine();
        }
    }
}
