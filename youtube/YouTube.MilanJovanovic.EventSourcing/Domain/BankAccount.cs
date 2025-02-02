namespace YouTube.MilanJovanovic.EventSourcing.Domain;

#pragma warning disable CS8618
// Domain aggregate
public class BankAccount
{
    public Guid Id { get; private set; }
    public string AccountHolder { get; private set; }
    public decimal Balance { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    // Acts like my "stream of events". In real life we usually use Event Store to save and keep the immutable events in log append    
    public List<Event> Events { get; } = [];

    private BankAccount() { }

    public static BankAccount Open(string accountHolder, decimal initialDeposit, string currency = "USD")
    {
        if (string.IsNullOrWhiteSpace(accountHolder)) throw new ArgumentException("Account Holder name is required");

        if (initialDeposit < 0) throw new ArgumentException("The initial deposit can't be negative");

        var bankAccount = new BankAccount();

        var @event = new AccountOpened(Guid.NewGuid(), accountHolder, initialDeposit, currency);

        bankAccount.Apply(@event);

        return bankAccount;
    }

    public void Deposit(decimal amount, string description)
    {
        EnsureAccountIsActive();

        if (amount <= 0) throw new ArgumentException("Deposit amount must be positive");

        Apply(@event: new MoneyDeposited(Id, amount, description));
    }

    public void Withdraw(decimal amount, string description)
    {
        EnsureAccountIsActive();

        if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive");
        if (Balance - amount < 0) throw new InvalidOperationException("Insufficient funds");

        Apply(new MoneyWithdrawn(Id, amount, description));
    }

    public void TransferTo(Guid toAccountId, decimal amount, string description)
    {
        EnsureAccountIsActive();

        if (amount <= 0) throw new ArgumentException("Transfer amount must be positive");
        if (Balance - amount < 0) throw new InvalidOperationException("Insufficient funds");

        Apply(new MoneyTransferred(Id, toAccountId, amount, description));
    }

    public void Close(string reason)
    {
        EnsureAccountIsActive();

        if (Balance != 0) throw new InvalidOperationException("Cannot close account with non-zero balance");

        Apply(new AccountClosed(Id, reason));
    }

    /// <summary>
    /// Obtém os eventos da stream de eventos do determinado identificador do agregado e faz o replay de todos eventos pegando o estado atual do objeto de domínio manipulado
    /// </summary>
    /// <param name="events"></param>
    /// <returns></returns>
    public static BankAccount ReplayEvents(IEnumerable<Event> events)
    {
        BankAccount bankAccount = new();

        foreach (var @event in events) bankAccount.Apply(@event);

        return bankAccount;
    }

    private void EnsureAccountIsActive()
    {
        if (!IsActive) throw new InvalidOperationException("Account is closed");
    }

    private void Apply(Event @event)
    {
        switch (@event)
        {
            case AccountOpened e:
                Id = e.AccountId;
                AccountHolder = e.AccountHolder;
                Balance = e.InitialDeposit;
                Currency = e.Currency;
                IsActive = true;
                break;

            case MoneyDeposited e:
                Balance += e.Amount;
                break;

            case MoneyWithdrawn e:
                Balance -= e.Amount;
                break;

            case MoneyTransferred e:
                Balance -= e.Amount;
                break;

            case AccountClosed e:
                IsActive = false;
                break;
        }

        Events.Add(@event);
    }
}