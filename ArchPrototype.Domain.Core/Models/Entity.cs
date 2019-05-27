using System;

namespace ArchPrototype.Domain.Core.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            CreateDate = DateTime.Now;
        }

        public DateTime CreateDate { get; }
    }
}