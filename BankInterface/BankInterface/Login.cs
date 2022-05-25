using System;
using System.IO;

namespace BankInterface
{
    class Login
    {
        string LocalPath;
        public bool CheckExistance()
        {
            return File.Exists(LocalPath);
        }
        public bool Logout()
        {
            Console.Clear();
            Console.Write("Do you want to log out? : ");
            if (Console.ReadLine() == "yes")
            {
                File.AppendAllText(LocalPath, "\nLogout at: " + DateTime.Now);
                Console.Clear();
                return true;
            }

            Console.Clear();

            return false;
        }
        public string ExecuteLogin()
        {
            string username, password;
            Console.Clear();

            do
            {
                Console.Write("Type username: ");
                username = Console.ReadLine();

                LocalPath = $@"D:\projectWithFiles\users\{username}.txt";

                if (!CheckExistance())
                {
                    Console.WriteLine("User not found!");
                }

            } while (!CheckExistance());

            string[] AllUserInfo = File.ReadAllLines(LocalPath);
            string firstLine = AllUserInfo[0], final = "";
            int count = 0;

            do
            {
                Console.Write("Type password: ");
                password = Console.ReadLine();

                for (int i = 0; i < firstLine.Length; i++)
                {
                    if (firstLine[i] == '|')
                    {
                        count++;
                    }

                    if (count == 2 && firstLine[i] != '|')
                    {
                        final += firstLine[i];
                    }
                }

                if (password != final)
                {
                    Console.WriteLine("Wrong password!");
                }

            } while (password != final);

            Console.Clear();
            File.AppendAllText(LocalPath, "\nLogin at: " + DateTime.Now);
            Console.WriteLine($"Login successful! Welcome, {username}!");

            return username;
        }
    }
}
