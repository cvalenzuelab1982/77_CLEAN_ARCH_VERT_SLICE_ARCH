using AutoAlquila.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlquila.Domain.Usuarios.Events
{
    public sealed record UsuarioCreatedDomainEvent(Guid UsuarioId) : IDomainEvent;
 
}
