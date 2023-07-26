using System;
using System.Collections.Generic;

// Memento class
public class AccountMemento
{
    public decimal Balance { get; }

    public AccountMemento(decimal balance)
    {
        Balance = balance;
    }
}

// Originator class
public class BankAccount
{
    private decimal _balance;

    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public decimal Balance
    {
        get { return _balance; }
        set
        {
            _balance = value;
            Console.WriteLine("BankAccount: Balance updated to " + _balance);
        }
    }

    public AccountMemento Save()
    {
        Console.WriteLine("BankAccount: Saving current state...");
        return new AccountMemento(_balance);
    }

    public void Restore(AccountMemento memento)
    {
        _balance = memento.Balance;
        Console.WriteLine("BankAccount: Restoring to previous balance: " + _balance);
    }
}

// Caretaker class
public class TransactionHistory
{
    private Stack<AccountMemento> _mementos = new Stack<AccountMemento>();

    public void Push(AccountMemento memento)
    {
        _mementos.Push(memento);
    }

    public AccountMemento Pop()
    {
        return _mementos.Pop();
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000);
        TransactionHistory history = new TransactionHistory();

        // First transaction
        account.Balance += 500;
        // Save the current state
        history.Push(account.Save());

        // Second transaction
        account.Balance -= 200;
        // Save the current state
        history.Push(account.Save());

        // Third transaction
        account.Balance += 300;
        // Save the current state
        history.Push(account.Save());

        // Undo and restore to previous states
        account.Restore(history.Pop()); // Restores balance to 1600
        account.Restore(history.Pop()); // Restores balance to 1300
        account.Restore(history.Pop()); // Restores balance to 1500

        // Output:
        // BankAccount: Balance updated to 1500
        // BankAccount: Saving current state...
        // BankAccount: Balance updated to 1300
        // BankAccount: Saving current state...
        // BankAccount: Balance updated to 1600
        // BankAccount: Saving current state...
        // BankAccount: Restoring to previous balance: 1600
        // BankAccount: Restoring to previous balance: 1300
        // BankAccount: Restoring to previous balance: 1500
    }
}

/*
In this example, the BankAccount class represents a user's bank account. Users can deposit and withdraw 
money from their account using the Balance property. The TransactionHistory class serves as the caretaker, 
managing the stack of AccountMemento instances, which store the previous states of the account balance. 
Users can perform transactions, save the current state, and then use the caretaker to undo and restore to 
previous states of the account balance.

The Memento pattern is used to effectively manage the state of the bank account transactions, providing an 
undo/redo feature to the users. The example demonstrates how the Memento pattern can be applied to a real-world 
.NET application scenario.
*/