namespace AutoAlquila.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvent = new();

        public Guid Id { get; init; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvent.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvent.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvents)
        {
            _domainEvent.Add(domainEvents);
        }
    }
}
