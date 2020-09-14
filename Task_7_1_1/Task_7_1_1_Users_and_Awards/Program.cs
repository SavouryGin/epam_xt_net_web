﻿using API.Controllers;
using Models;
using System;

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

            controller.AddAwardToUser(award1, user1);
            controller.AddAwardToUser(award2, user1);
            controller.AddAwardToUser(award2, user2);

            controller.SaveAllChanges();

            Console.ReadLine();
        }
    }
}
