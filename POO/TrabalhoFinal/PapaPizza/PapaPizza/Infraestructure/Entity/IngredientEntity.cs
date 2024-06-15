using PapaPizza.Infraestructure.Entity.Base;

namespace PapaPizza.Infraestructure.Entity
{
    public class IngredientEntity : EntityBase
    {

        public string Name { get; set; } = string.Empty;

        public static IngredientEntity CreateIngredient(string[] fields)
        {
            var result = new IngredientEntity();

            result.Id = Guid.Parse(fields[0]);
            result.Name = fields[1];

            return result;
        }
    }
}
