using System;
using System.IO;

namespace BankInterface
{
    class DepositWithdraw
    {
        string LocalPath;
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
        public string Balance(string username)
        {
            LocalPath = $@"D:\projectWithFiles\users\{username}.txt";
            
            string[] AllInfo = File.ReadAllLines(LocalPath);
            string[] ZeroLine = TakeZeroLine(AllInfo);
            Console.Clear();

            return ZeroLine[3];
        }
        public void DepositOrWithdraw(string username, string depositOrWithdraw)
        {
            LocalPath = $@"D:\projectWithFiles\users\{username}.txt";
            int code;
            int amount;
            string[] AllInfo = File.ReadAllLines(LocalPath);
            string[] ZeroLine = TakeZeroLine(AllInfo);

            Console.Clear();

            if (depositOrWithdraw == "Deposit")
            {
                do
                {
                    Console.Write("Verify 4-digit code: ");
                    code = int.Parse(Console.ReadLine());

                    if (ZeroLine[0] != code.ToString())
                    {
                        Console.WriteLine("Number does not match!");
                    }

                } while (ZeroLine[0] != code.ToString());

                do
                {
                    Console.Write("Type deposit amount: ");
                    amount = int.Parse(Console.ReadLine());

                    if (amount > 1000 || amount < 10)
                    {
                        Console.WriteLine("Deposit must be between 10 - 1000!");
                    }

                } while (amount > 1000 || amount < 10);

                double a = Convert.ToDouble(ZeroLine[3]) + amount;
                ZeroLine[3] = a.ToString();
                AllInfo[0] = "";

                for (int i = 0; i < ZeroLine.Length; i++)
                {
                    AllInfo[0] += ZeroLine[i] + "|";
                }

                File.WriteAllLines(LocalPath, AllInfo);

                Console.Clear();
                Console.WriteLine("Deposit successful!");
            }
            else if (depositOrWithdraw == "Withdraw")
            {
                do
                {
                    Console.Write("Verify 4-digit code: ");
                    code = int.Parse(Console.ReadLine());

                    if (ZeroLine[0] != code.ToString())
                    {
                        Console.WriteLine("Number does not match!");
                    }

                } while (ZeroLine[0] != code.ToString());

                do
                {
                    Console.Write("Type withdraw amount: ");
                    amount = int.Parse(Console.ReadLine());

                    if ((amount > 1000 || amount < 10) || Convert.ToDouble(ZeroLine[3]) - amount < 0)
                    {
                        Console.WriteLine("Withdraw must be between 10 - 1000 and within your balance!");
                    }

                } while ((amount > 1000 || amount < 10) || Convert.ToDouble(ZeroLine[3]) - amount < 0);

                double a = Convert.ToDouble(ZeroLine[3]) - amount;
                ZeroLine[3] = a.ToString();
                AllInfo[0] = "";

                for (int i = 0; i < ZeroLine.Length; i++)
                {
                    AllInfo[0] += ZeroLine[i] + "|";
                }

                File.WriteAllLines(LocalPath, AllInfo);

                Console.Clear();
                Console.WriteLine("Withdraw successful!");
            }
        }
    }
}
