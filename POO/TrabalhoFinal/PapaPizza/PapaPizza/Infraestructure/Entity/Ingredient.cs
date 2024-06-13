using PapaPizza.Infraestructure.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Entity
{
    public class Ingredient : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public int Amount { get; set; } = 0;
    }
}
