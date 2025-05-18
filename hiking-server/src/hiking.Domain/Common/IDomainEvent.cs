using System;

namespace Hiking.Domain.Common;

/// <summary>
/// Interface pour les événements du domaine
/// </summary>
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}