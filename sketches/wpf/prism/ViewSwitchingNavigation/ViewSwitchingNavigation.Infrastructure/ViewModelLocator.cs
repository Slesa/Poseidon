﻿using System;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ViewSwitchingNavigation.Infrastructure
{
    public class ViewModelLocator<TViewModel> where TViewModel : class
    {
        readonly Lazy<IUnityContainer> _container;
        readonly bool _inDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());

        public ViewModelLocator()
        {
            if (!_inDesignTime)
            {
                _container = new Lazy<IUnityContainer>(() => ServiceLocator.Current != null ? ServiceLocator.Current.GetInstance<IUnityContainer>() : null);
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