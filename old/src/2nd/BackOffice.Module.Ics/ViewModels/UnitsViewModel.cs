using System.Collections.ObjectModel;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Queries;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class UnitsViewModel
    {
        readonly IDbConversation _dbConversation;

        public UnitsViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;

            CreateDatasets();
        }

        public ObservableCollection<Unit> Units { get; set; }

        void CreateDatasets()
        {
            _dbConversation.UsingTransaction(() =>
                {
                    Units = new ObservableCollection<Unit>(_dbConversation.Query(new AllUnitsQuery()));
                });
        }
    }
}