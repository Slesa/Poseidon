using System.ComponentModel.Composition;
using _11_Screens.Framework;

namespace _11_Screens.Customers
{
    [Export(typeof(CustomerViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerViewModel : DocumentBase
    {
        public void Save() {
            IsDirty = false;
            Dialogs.ShowMessageBox("Your data has been successfully saved.", "Data Saved");
        }

        public void EditAddress() {
            Dialogs.ShowDialog(new AddressViewModel());
        }
    }
}