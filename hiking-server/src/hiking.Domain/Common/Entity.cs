using System;
using System.Collections.Generic;

namespace Hiking.Domain.Common
{
    /// <summary>
    /// Classe de base pour les entités
    /// </summary>
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyCollection<IDomainEvent> DomainEvents => (_domainEvents ?? []).AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= [];
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (GetHashCode() != other.GetHashCode())
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }
    }
}