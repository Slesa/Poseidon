using System;
using System.ComponentModel.Composition;
using _11_Screens.Framework;

namespace _11_Screens.Orders
{
    [Export(typeof(IWorkspace))]
    public class OrdersWorkspaceViewModel : DocumentWorkspace<OrderViewModel>
    {
        static int _count = 1;
        readonly Func<OrderViewModel> _createOrderViewModel;

        [ImportingConstructor]
        public OrdersWorkspaceViewModel(Func<OrderViewModel> orderVMFactory) 
        {
            _createOrderViewModel = orderVMFactory;
        }

        public override string IconName 
        {
            get { return "Orders"; }
        }

        public override string Icon 
        {
            get { return "../Orders/Resources/Images/shopping-cart-full48.png"; }
        }

        public void New() 
        {
            var vm = _createOrderViewModel();
            vm.DisplayName = "Order " + _count++;
            vm.IsDirty = true;
            Edit(vm);
        }
    }
}