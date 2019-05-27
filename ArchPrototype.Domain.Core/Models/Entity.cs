using System;

namespace ArchPrototype.Domain.Core.Models
{
    public abstract class Entity
    {
        public DateTime CreateDate { get; private set; }

        public Entity()
        {
            CreateDate = DateTime.Now;
        }
    }
}