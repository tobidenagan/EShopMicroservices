namespace Ordering.Domain.Events;

public record OrcerUpdatedEvent(Order order) : IDomainEvent;