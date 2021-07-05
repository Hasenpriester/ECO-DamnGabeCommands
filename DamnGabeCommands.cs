using System;
using System.Linq;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Utils;
using Eco.Gameplay.Economy;

namespace DamnGabeCommand
{
    class DamnGabeCommands : IModKitPlugin, IInitializablePlugin, IChatCommandHandler
    {
        public string GetStatus()
        {
            return String.Empty;
        }

        public void Initialize(TimedTask timer)
        {
            
        }

        [ChatSubCommand("Money", "Removes the mess that Gabe left behind", "damngabe", ChatAuthorizationLevel.Admin)]
        public static void DamnGabe(User user, float amount = 1000)
        {
            foreach(BankAccount b in BankAccountManager.Obj.Accounts)
            {
                foreach (Currency c in CurrencyManager.Currencies)
                {
                    b.AddCurrency(c, (amount * -1), true);
                }
            }
        }

        [ChatSubCommand("Money", "Does what you originally expected from the gabe command", "santa", ChatAuthorizationLevel.Admin)]
        public static void Santa(User user, BankAccount account, Currency currency, float amount = 1000)
        {
            float holding = account.GetCurrencyHoldingVal(currency);

            if (holding > 0)
            {
                int availableAccounts = BankAccountManager.Obj.Accounts.Count() - 1;

                if (holding < (amount * availableAccounts))
                    amount = holding / availableAccounts;

                account.AddCurrency(currency, (amount * -1));

                foreach (BankAccount b in BankAccountManager.Obj.Accounts)
                {
                    if (b.Id != account.Id)
                        b.AddCurrency(currency, amount);
                }
            }
        }

        [ChatSubCommand("Money", "Does what you originally expected from the gabe command", "ubi", ChatAuthorizationLevel.Admin)]
        public static void UBI(User user, Currency currency, float amount = 1000)
        {
            int availableAccounts = BankAccountManager.Obj.Accounts.Count() - 1;

            foreach (BankAccount b in BankAccountManager.Obj.Accounts)
                b.AddCurrency(currency, amount);
        }

        [ChatSubCommand("Money", "Removes currency from an account", "removecurrencyfromaccount", ChatAuthorizationLevel.Admin)]
        public static void RemoveCurrencyFromAccount(User user, BankAccount account, Currency currency)
        {
            account.RemoveCurrency(currency);
        }

        [ChatSubCommand("Money", "Transfer an amount from one account to another", "lastschrift", ChatAuthorizationLevel.Admin)]
        public static void Lastschrift(User user, BankAccount sourceAccount, BankAccount targetAccount, Currency currency, float amount)
        {
            float holding = sourceAccount.GetCurrencyHoldingVal(currency);
            if (holding < amount)
            {
                user.Player.ErrorLoc($"{sourceAccount.Name} has insufficient funds.");
                return;
            }

            sourceAccount.AddCurrency(currency, (amount * -1));
            targetAccount.AddCurrency(currency, amount);
        }
    }
}
