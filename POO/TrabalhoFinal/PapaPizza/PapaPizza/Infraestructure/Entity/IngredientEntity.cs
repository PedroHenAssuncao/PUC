using PapaPizza.Infraestructure.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Entity
{
    public class IngredientEntity : EntityBase
    {

        public string Name { get; set; } = string.Empty;

        public int Amount { get; set; } = 0;

        public static IngredientEntity CreateIngredient(string[] fields)
        {
            var result = new IngredientEntity();

            result.Id = Guid.Parse(fields[0]);
            result.Name = fields[1];
            result.Amount = int.Parse(fields[2]);

            return result;
        }
    }
}
