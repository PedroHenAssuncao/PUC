using PapaPizza.Infraestructure.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Entity
{
    public class RecipeEntity : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int DurationInMinutes { get; set; } = 0;

        public static RecipeEntity CreateRecipe(string[] fields)
        {
            var result = new RecipeEntity();

            result.Id = Guid.Parse(fields[0]);
            result.Name = fields[1];
            result.Description = fields[2];
            result.DurationInMinutes = int.Parse(fields[3]);

            return result;
        }
    }
}
