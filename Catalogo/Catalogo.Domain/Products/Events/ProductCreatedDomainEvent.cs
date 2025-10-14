﻿using Catalogo.Domain.Abstractions;

namespace Catalogo.Domain.Products.Events
{
    public sealed record ProductCreatedDomainEvent(Guid productId) : IDomainEvent;

}
