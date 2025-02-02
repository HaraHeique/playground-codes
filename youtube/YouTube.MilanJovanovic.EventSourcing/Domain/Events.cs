namespace YouTube.MilanJovanovic.EventSourcing.Domain;

// Base event type
public abstract record Event(Guid StreamId)
{
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}

// Specific events for bank account domain
public record AccountOpened(Guid AccountId, string AccountHolder, decimal InitialDeposit, string Currency = "USD") : Event(AccountId);

public record MoneyDeposited(Guid AccountId, decimal Amount, string Description) : Event(AccountId);

public record MoneyWithdrawn(Guid AccountId, decimal Amount, string Description) : Event(AccountId);

public record MoneyTransferred(Guid AccountId, Guid ToAccountId, decimal Amount, string Description) : Event(AccountId);

public record AccountClosed(Guid AccountId, string Reason) : Event(AccountId);