﻿namespace Domain.Abstraction.Entitites
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}
