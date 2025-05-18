using System;

namespace Hiking.Domain.Common;

/// <summary>
/// Classe de base pour les agrégats
/// </summary>
public abstract class AggregateRoot : Entity
{
    // Un agrégat est une entité racine qui peut contenir d'autres entités
    // Pour notre exemple, User, Post et ChatGroup sont des agrégats
}