using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Entity.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public EntityBase() {
            
            Id = Guid.NewGuid();
        }
    }
}
