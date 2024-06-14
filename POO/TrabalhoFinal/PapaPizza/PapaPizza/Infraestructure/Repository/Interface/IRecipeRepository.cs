using PapaPizza.Infraestructure.Entity;
using PapaPizza.Infraestructure.Repository.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Repository.Interface
{
    public interface IRecipeRepository : IRepository<RecipeEntity>
    {
    }
}
