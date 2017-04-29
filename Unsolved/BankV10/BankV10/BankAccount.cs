namespace BankV10
{
    public class BankAccount
    {
        private double _balance;

        public double Balance
        {
            get { return _balance; }
        }

        public BankAccount()
        {
            _balance = 0.0;
        }

        public void Deposit(double amount)
        {
            _balance = _balance + amount;
        }

        public void Withdraw(double amount)
        {
            _balance = _balance - amount;
        }
    }
}