using System;
using System.ComponentModel.Composition;
using _11_Screens.Framework;

namespace _11_Screens.Customers
{
    [Export(typeof(IWorkspace))]
    public class CustomersWorkspaceViewModel : DocumentWorkspace<CustomerViewModel>
    {
        readonly Func<CustomerViewModel> createCustomerViewModel;
        static int count = 1;

        [ImportingConstructor]
        public CustomersWorkspaceViewModel(Func<CustomerViewModel> customerVMFactory) {
            createCustomerViewModel = customerVMFactory;
        }

        public override string IconName {
            get { return "Customers"; }
        }

        public override string Icon {
            get { return "../Customers/Resources/Images/man1-48.png"; }
        }

        public void New() {
            var vm = createCustomerViewModel();
            vm.DisplayName = "Customer " + count++;
            vm.IsDirty = true;
            Edit(vm);
        }
    }
}