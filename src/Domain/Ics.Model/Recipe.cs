using System.Collections.Generic;
using Model.Shared;

namespace Ics.Model
{
    public class Recipe : DomainEntity
    {
        readonly IList<RecipeItem> _recipeItems = new List<RecipeItem>();

        /// <summary>
        /// To have no further knowledge of the PMS, this is only the plu of the selling article
        /// </summary>
        public virtual int Plu { get; set; }

        public virtual IEnumerable<RecipeItem> RecipeItems
        {
            get { return _recipeItems; }
        }

        public virtual void AddRecipeItem(RecipeItem recipeItem)
        {
            recipeItem.Recipe = this;
            _recipeItems.Add(recipeItem);
        }

        public virtual void RemoveRecipeItem(RecipeItem recipeItem)
        {
            _recipeItems.Remove(recipeItem);
        }
    }
}