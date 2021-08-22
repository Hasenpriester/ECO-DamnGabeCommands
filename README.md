# ECO-DamnGabeCommands
Adds the following useful admin commands, for managing bank accounts, to the game:

`/damngabe [Amount = 1000]` Does exactly the opposite of what the `/gabe` (old: `/steamsale`) command does.

`/santa BankAccount, Currency [, Amount = 1000]` Transfers the specified amount (default 1000) to each player from the specified account in the specified currency.
If the account does not have enough funds, the existing balance will be divided among all players.

`/ubi Currency [, Amount = 1000]` Gives the specified amount (default 1000) to each player in the specified currency.

`/removecurrencyfromaccount BankAccount, Currency` Removes all funds of the specified currency from the specified account.

`/lastschrift SourceBankAccount, TargetBankAccount, Currency, Amount` Transfers an amount from one account to another.


## Installation
Just put the File DamnGabeCommands.cs in the Folder /Mods/UserCode/ Thats it, restart Server.
Thats it, restart Server.
