using PapaPizza.Infraestructure.Entity;
using PapaPizza.Infraestructure.Repository.Implementation.Base;
using PapaPizza.Infraestructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Repository.Implementation
{
    public class IngredientRepository : Repository<IngredientEntity>, IIngredientRepository
    {
        protected override IngredientEntity? Parse(string objectString)
        {
            return IngredientEntity.CreateIngredient(objectString.Split(';'));
        }

        protected override string Parse(IngredientEntity objectToParse)
        {
            return $"{objectToParse.Id};{objectToParse.Name};{objectToParse.Amount}";
        }
    }
}
