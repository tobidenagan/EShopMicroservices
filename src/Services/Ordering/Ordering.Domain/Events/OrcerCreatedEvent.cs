namespace Ordering.Domain.Events;

public record OrcerCreatedEvent(Order order) : IDomainEvent;