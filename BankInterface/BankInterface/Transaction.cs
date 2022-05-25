using System;
using System.IO;

namespace BankInterface
{
    class Transaction
    {
        string LocalPath;
        public bool CheckExistance()
        {
            return File.Exists(LocalPath);
        }
        public string[] TakeAllUserInfo(string username)
        {
            string[] arr = File.ReadAllLines($@"D:\projectWithFiles\users\{username}.txt");
            return arr;
        }
        public string[] TakeZeroLine(string[] arr)
        {
            string[] ZeroLine = new string[4];
            int j = 0;

            for (int i = 0; i < arr[0].Length; i++)
            {
                if (arr[0][i] == '|')
                {
                    j++;
                }
                else
                {
                    ZeroLine[j] += arr[0][i];
                }
            }

            return ZeroLine;
        }
        public void MainTransaction(string username)
        {
            string reciever;
            double amount;

            Console.Clear();

            do
            {
                Console.Write("Type username of reciever: ");
                reciever = Console.ReadLine();

                LocalPath = $@"D:\projectWithFiles\users\{reciever}.txt";

                if (!CheckExistance() || username == reciever)
                {
                    Console.WriteLine("User not available!");
                }

            } while (!CheckExistance() || username == reciever);

            string[] giverInfo = TakeAllUserInfo(username);
            string[] recieverInfo = TakeAllUserInfo(reciever);

            string[] ZeroLineGiverInfo = TakeZeroLine(giverInfo);
            string[] ZeroLineRecieverInfo = TakeZeroLine(recieverInfo);

            do
            {
                Console.Write("Type amount: ");
                amount = double.Parse(Console.ReadLine());

                if (Convert.ToDouble(ZeroLineGiverInfo[3]) - amount >= 0 && amount > 0)
                {
                    double a = Convert.ToDouble(ZeroLineGiverInfo[3]);
                    double b = Convert.ToDouble(ZeroLineRecieverInfo[3]);
                    a -= amount;
                    b += amount;
                    ZeroLineGiverInfo[3] = a.ToString();
                    ZeroLineRecieverInfo[3] = b.ToString();
                    break;
                }
                else
                {
                    Console.WriteLine("Insufficient funds!");
                }
            } while (true);

            giverInfo[0] = "";
            recieverInfo[0] = "";

            for (int i = 0; i < ZeroLineGiverInfo.Length; i++)
            {
                giverInfo[0] += ZeroLineGiverInfo[i] + "|";
                recieverInfo[0] += ZeroLineRecieverInfo[i] + "|";
            }

            File.WriteAllLines($@"D:\projectWithFiles\users\{username}.txt", giverInfo);
            File.WriteAllLines($@"D:\projectWithFiles\users\{reciever}.txt", recieverInfo);
            Console.Clear();

            Console.WriteLine("Transaction successful!");
        }
    }
}
