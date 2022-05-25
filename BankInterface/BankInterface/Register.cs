using System;
using System.IO;

namespace BankInterface
{
    class Register
    {
        string LocalPath;
        public bool CheckExistance()
        {
            return File.Exists(LocalPath);
        }
        public void CreateFile(string[] info)
        {
            File.Create(LocalPath).Close();
            for (int i = 0; i < info.Length; i++)
            {
                File.AppendAllText(LocalPath, info[i]);
            }
            File.AppendAllText(LocalPath, "\nRegister at: " + DateTime.Now.ToString());
        }
        public void ExecuteRegistry()
        {
            Random random = new Random();
            double balance = 50;
            int fourDigitCode = random.Next(1000, 10000);

            Console.Clear();
            Console.Write("Type username: ");
            string username = Console.ReadLine();

            LocalPath = $@"D:\projectWithFiles\users\{username}.txt";

            if (CheckExistance())
            {
                Console.Clear();
                Console.WriteLine("Username taken!");
            }
            else
            {
                Console.Write("Type password: ");
                string password = Console.ReadLine();

                string[] UserInfo = { fourDigitCode.ToString() + "|", username + "|", password + "|", balance.ToString() + "|" };
                Console.Clear();
                CreateFile(UserInfo);
                Console.WriteLine($"You registered successfully, {username}! Your 4-digit code is: {fourDigitCode}");
            }
        }
    }
}
