using System;

namespace BankV05
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            BankAccount theAccount = new BankAccount();

            theAccount.Deposit(2000);
            Console.WriteLine("Account balance is : {0}", theAccount.Balance);

            theAccount.Withdraw(1500);
            Console.WriteLine("Account balance is : {0}", theAccount.Balance);

            // The LAST line of code should be ABOVE this line
        }
    }
}