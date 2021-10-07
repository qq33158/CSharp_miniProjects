using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var account = new BankAccount("Ame", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            // 嘗試建立有負餘額帳戶,是否有攔截錯誤狀況
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            // 測試負的Balance
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(account.GetAccountHistory());

            // ChristmaxsTree
            ChristmaxsTree christmaxstree = new ChristmaxsTree();

            // GusessGame
            GuessGame guessGame = new GuessGame();

            // GetMax
            int[] tAry = new int[] { 12, 15, 38, 21, 25};
            Console.WriteLine(" === 陣列元素如下=== \n");
            for (int i = 0; i <= tAry.GetUpperBound(0); i++)
            {
                Console.Write($" {tAry[i]}, ");
            }
            Console.WriteLine("\n");
            GetMax getMax = new GetMax();
            Console.WriteLine($"\n 陣列最大值:{getMax.Get_Max(ref tAry)}");

            Console.WriteLine("\n 程式結束");
        }
    }
}
