namespace MainTask
{
    internal class Program
    {
        public class Account
        {
            public string Name { get; set; }
            public double Balance { get; set; }

            public Account(string name = "Unnamed Account", double balance = 0.0)
            {
                this.Name = name;
                this.Balance = balance;
            }

            public virtual bool Deposit(double amount)
            {
                if (amount < 0)
                    return false;
                else
                {
                    Balance += amount;
                    return true;
                }
            }

            public virtual bool Withdraw(double amount)
            {
                if (Balance - amount >= 0 && amount>0)
                {
                    Balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class SavingsAccount:Account
        {
            private double InterestRate { set; get; }
            public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0) : base(name , balance)
            {
                this.InterestRate = interestRate;
            }
            public override bool Deposit(double amount)
            {
                if(amount>0)
                {
                    Balance += amount + (InterestRate/100.0)*amount;
                    return true;
                }
                return false;
                
            }
            public override bool Withdraw(double amount)
            {
                return base.Withdraw(amount);
            }
        }
        public class CheckingAccount:Account
        {
            private double Fee { get; set; }
            public CheckingAccount(string name = "Unnamed Account", double balance = 0.0):base(name, balance)
            {
                Fee = 1.5;
            }
            public override bool Withdraw(double amount)
            {
                return base.Withdraw(amount+Fee);
            }
        }
        public class TrustAccount:Account
        {
            private double PercentageWithdraw { get; set; }
            private int NumOfWithdraws { get; set; }
            private double InterestRate { get; set; }
            public TrustAccount(string name = "Unnamed Account", double balance = 0, double interestRate = 0.0) : base(name, balance)
            {
                NumOfWithdraws = 0;
                PercentageWithdraw = 0.2;
                this.InterestRate = interestRate;
            }
            public override bool Deposit(double amount)
            {
                if (amount > 0)
                {
                    if(amount>=5000)
                    {
                        Balance += 50;
                    }
                    Balance += amount + (InterestRate/100.0)*amount;
                    return true;
                }
                return false;

            }
            public override bool Withdraw(double amount)
            {
                if(amount < PercentageWithdraw*Balance && NumOfWithdraws<=3 && amount>0)
                {
                    Balance -= amount;
                    NumOfWithdraws++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<Account>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<Account>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();
        }
        public static class AccountUtil
        {
            // Utility helper functions for Account class
            public static void Deposit(List<Account> accounts, double amount)
            {
                Console.WriteLine("\n=== Depositing to Accounts =================================");
                foreach (var acc in accounts)
                {
                    if (acc.Deposit(amount))
                        Console.WriteLine($"Deposited {amount} to {acc.Name}");
                    else
                        Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
                }
            }

            public static void Withdraw(List<Account> accounts, double amount)
            {
                Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
                foreach (var acc in accounts)
                {
                    if (acc.Withdraw(amount))
                        Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                    else
                        Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
                }
            }
        }
    }
}
