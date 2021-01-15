using Cap11.Exercise02.Entities.Exceptions;

namespace Cap11.Exercise02.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account() { }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
                throw new AccountDomainException("Insufficient funds for the withdraw operation.");
            else if (amount > WithdrawLimit)
                throw new AccountDomainException("Withdraw request exceeds Account's Withdraw Limit.");
            Balance -= amount;
        }
    }
}
