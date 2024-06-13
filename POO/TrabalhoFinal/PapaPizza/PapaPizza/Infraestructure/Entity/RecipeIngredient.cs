using PapaPizza.Infraestructure.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Entity
{
    public class RecipeIngredient : EntityBase
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }

        public int Amount { get; set; }
    }
}
