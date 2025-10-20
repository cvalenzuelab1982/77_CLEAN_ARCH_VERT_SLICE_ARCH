namespace AutoAlquila.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvent = new();

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; } //init: el set tendra un id que no cambiara

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
