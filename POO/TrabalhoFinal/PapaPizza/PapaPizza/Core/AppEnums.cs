using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Core
{
    public static class AppEnums
    {
        public enum HomeOptionsEnum
        {
            ListIngredients = 1,
            ListRecipes,
            Exit
        }

        public enum MenuOptionsIngredient
        {
            Create = 1,
            Delete,
            Exit
        }

        public enum MenuOptionsRecipe
        {
            Create = 1,
            Delete,
            Detail,
            Update,
            Exit
        }
    }
}
