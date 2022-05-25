using System;

namespace BankInterface
{
    class FinalProduct
    {
        public static void Menu()
        {
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - Exit");
        }
        public static void MenuAfterLogin()
        {
            Console.WriteLine("1 - Check Balance");
            Console.WriteLine("2 - Deposit");
            Console.WriteLine("3 - Withdraw");
            Console.WriteLine("4 - Transaction");
            Console.WriteLine("5 - Log Out");
        }
        static void Main(string[] args)
        {
            int choice, choice2;
            bool actualChoice;
            
            Login l = new Login();
            Register r = new Register();
            Transaction t = new Transaction();
            DepositWithdraw dw = new DepositWithdraw();

            do
            {
                Menu();
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        r.ExecuteRegistry();
                        break;

                    case 2:
                        string usernameGivenBack = l.ExecuteLogin();
                        do
                        {
                            actualChoice = false;
                            MenuAfterLogin();
                            choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine("Your balance is: " + dw.Balance(usernameGivenBack)); 
                                    break;
                                case 2:
                                    dw.DepositOrWithdraw(usernameGivenBack, "Deposit");
                                    break;
                                case 3:
                                    dw.DepositOrWithdraw(usernameGivenBack, "Withdraw");
                                    break;
                                case 4:
                                    t.MainTransaction(usernameGivenBack);
                                    break;
                                case 5:
                                    actualChoice = l.Logout();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Wrong number!");
                                    break;
                            }
                        } while (!actualChoice);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("See you later");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong number!");
                        break;
                }
            } while (choice != 3);
        }
    }
}
