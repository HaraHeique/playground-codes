using YouTube.MilanJovanovic.EventSourcing.Domain;

Console.WriteLine("Event Sourcing simple sample!");

var bankAccount = BankAccount.Open("M J", 1000);
bankAccount.Deposit(500, "Salary deposit");
bankAccount.Withdraw(200, "ATM withdrawal");
bankAccount.TransferTo(Guid. NewGuid(), 300, "Transfer to savings"); bankAccount. Withdraw (bankAccount. Balance, "Withdrawing before closing account"); bankAccount.Close("Completing the demo");

// Print the final balance and all events
Console.WriteLine($"Final balance: {bankAccount. Balance}");

foreach (var @event in bankAccount.Events)
{
    Console.WriteLine($"Event: {@event.GetType().Name} at {@event. Timestamp}");
}

// Replaying all events from stream
var events = bankAccount.Events;
var theSameAccount = BankAccount.ReplayEvents(events);

//Trying to deposit a deactivated account
try
{
    theSameAccount.Deposit(100, "Replaying deposit");
}   
catch (Exception e)
{
    Console.WriteLine(e);
}
