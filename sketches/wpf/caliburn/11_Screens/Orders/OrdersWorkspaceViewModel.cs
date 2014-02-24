using System;
using System.ComponentModel.Composition;
using _11_Screens.Framework;

namespace _11_Screens.Orders
{
    [Export(typeof(IWorkspace))]
    public class OrdersWorkspaceViewModel : DocumentWorkspace<OrderViewModel>
    {
        static int count = 1;
        readonly Func<OrderViewModel> createOrderViewModel;

        [ImportingConstructor]
        public OrdersWorkspaceViewModel(Func<OrderViewModel> orderVMFactory) {
            createOrderViewModel = orderVMFactory;
        }

        public override string IconName {
            get { return "Orders"; }
        }

        public override string Icon {
            get { return "../Orders/Resources/Images/shopping-cart-full48.png"; }
        }

        public void New() {
            var vm = createOrderViewModel();
            vm.DisplayName = "Order " + count++;
            vm.IsDirty = true;
            Edit(vm);
        }
    }
}