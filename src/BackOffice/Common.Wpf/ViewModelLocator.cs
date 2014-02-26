using System;
using System.Windows;
using LightCore;
using Microsoft.Practices.ServiceLocation;

namespace Poseidon.Common.Wpf
{
    public class ViewModelLocator<TViewModel> where TViewModel : class
    {
        readonly Lazy<IContainer> _container;
        readonly bool _inDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());

        public ViewModelLocator()
        {
            if (!_inDesignTime)
            {
                _container = new Lazy<IContainer>(() => ServiceLocator.Current != null ? ServiceLocator.Current.GetInstance<IContainer>() : null);
            }
        }

        public TViewModel ViewModel
        {
            get
            {
                return _inDesignTime ? null : _container.Value.Resolve<TViewModel>();
            }
        }
    }
}