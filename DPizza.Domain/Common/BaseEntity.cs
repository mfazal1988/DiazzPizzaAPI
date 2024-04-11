﻿namespace DPizza.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
