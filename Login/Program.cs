using System;
using System.Collections.Generic;

namespace Login
{
    class Program
    {
        //Method to get a username
        static string username()
        {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            return username;
        }
        //Method to get a password
        static string password()
        {
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            return password;
        }
        static void Main(string[] args)
        {
            //Declaring the dictionary of existing users
            var users = new Dictionary<string, string>(){
                {"user1", "pass1"},
                {"user2", "pass2"},
                {"user3", "pass3"}
            };

            //Start here
            //Begins by calling upon the username and password functions to get user input
            string user = username();
            string pass = password();
            int tryCount = 1;

            //Checks if the user entered is in the dictionary
            //Checks if the password entered is matching the value of key provided(user) 
            if (users.ContainsKey(user) && pass == users[user])
            {
                Console.WriteLine("You're logged in");
            }
            else
            {
                //While the username and password being entered is not in the dictionary, it'll run the loop
                while ((users.ContainsKey(user) && pass == users[user]) != true)
                {
                    Console.WriteLine("Invalid login");
                    user = username();
                    pass = password();
                    tryCount++;
                    //Too many attempts prompts the user if they want to register
                    if (tryCount == 3)
                    {
                        Console.WriteLine("Do you want to register? y/n");
                        string choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            user = username();
                            pass = password();
                            //Adds the user information into the dictionary so the
                            //condition on line 44 becomes true
                            users.Add(user, pass);
                            //Since you registered, you technically logged in
                            Console.WriteLine("You're registered and logged in!");
                        }
                        else
                        {
                            tryCount = 0;
                        }
                    }
                }
            }
        }
    }
}