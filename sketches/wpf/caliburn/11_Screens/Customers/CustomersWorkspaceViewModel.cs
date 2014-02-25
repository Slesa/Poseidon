using System;
using System.ComponentModel.Composition;
using _11_Screens.Framework;

namespace _11_Screens.Customers
{
    [Export(typeof(IWorkspace))]
    public class CustomersWorkspaceViewModel : DocumentWorkspace<CustomerViewModel>
    {
        readonly Func<CustomerViewModel> _createCustomerViewModel;
        static int _count = 1;

        [ImportingConstructor]
        public CustomersWorkspaceViewModel(Func<CustomerViewModel> customerVMFactory) 
        {
            _createCustomerViewModel = customerVMFactory;
        }

        public override string IconName 
        {
            get { return "Customers"; }
        }

        public override string Icon 
        {
            get { return "../Customers/Resources/Images/man1-48.png"; }
        }

        public void New() 
        {
            var vm = _createCustomerViewModel();
            vm.DisplayName = "Customer " + _count++;
            vm.IsDirty = true;
            Edit(vm);
        }
    }
}