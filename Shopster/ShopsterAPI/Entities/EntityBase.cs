﻿namespace Shopster.Entities;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }
}