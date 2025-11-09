using AutoAlquila.Application.Exceptions;
using AutoAlquila.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAlquila.Infraestructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //APLICAR AUTOMATICAMENTE LA CONFIGURACIONES A LAS ENTIDADADES CON LA TABLAS
            //CON ESTO YA NO ES NECESARIO DECLARA  public DbSet<PruebaEntity> Prueba { get; set; }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);
                await PublishDomainEventAsync();
                return result;
            }
            catch (DbUpdateConcurrencyException ex) //SI HAY UN PROBLEMA CON LA REGLAS DE LA DB ALGUN ERROR DEL MOTOR COMO ESCRITURA O VIOLACION DE LLAVES ETC
            {
                throw new ConcurrencyExpection("La excepcion por concurrencia se disparo", ex);
            }
        }

        private async Task PublishDomainEventAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.GetDomainEvents();
                    entity.ClearDomainEvents();
                    return domainEvents;
                }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}
