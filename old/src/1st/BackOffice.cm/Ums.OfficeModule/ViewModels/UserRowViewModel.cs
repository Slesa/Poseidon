using System;
using BackOffice.Shared.ViewModels;
using Ums.Model;

namespace Ums.OfficeModule.ViewModels
{
    public class UserRowViewModel : SelectableRowViewModelBase<User>
    {
        public UserRowViewModel(User user)
        {
            ElementData = user;
        }
        public void ExchangeData(User user)
        {
            ElementData = user;
        }

        public int Id { get { return ElementData.Id; } }
        public string Name { get { return ElementData.Name; } }
        public UserRole UserRole { get { return ElementData.UserRole; } }

    }
}