using System.ComponentModel.Composition;
using _11_Screens.Framework;

namespace _11_Screens.Orders {
    [Export(typeof(OrderViewModel)), PartCreationPolicy(CreationPolicy.NonShared)]
    
    public class OrderViewModel : DocumentBase {
        public void Save() {
            IsDirty = false;
            Dialogs.ShowMessageBox("Your data has been successfully saved.", "Data Saved");
        }
    }
}