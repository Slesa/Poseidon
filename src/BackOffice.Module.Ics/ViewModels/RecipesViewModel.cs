using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class RecipesViewModel
    {
        readonly IDbConversation _dbConversation;

        public RecipesViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<Recipe> Recipes { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    Recipes = new ObservableCollection<Recipe>(_dbConversation.Query(new AllRecipesQuery()));
                });
        }
    }
}