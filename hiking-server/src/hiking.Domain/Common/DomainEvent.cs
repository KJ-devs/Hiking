using System;

namespace Hiking.Domain.Common;

/// <summary>
/// Classe de base pour les événements du domaine
/// </summary>
public abstract class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; }

    protected DomainEvent()
    {
        OccurredOn = DateTime.UtcNow;
    }
}