using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Poseidon.BackOffice.Common.Controls
{
    public class ModuleListControl : HeaderedContentControl
    {
        public static readonly DependencyProperty ParentModuleProperty =
            DependencyProperty.Register("ParentModule", typeof (IOfficeModule), typeof (ModuleListControl), new PropertyMetadata(null));

        public IOfficeModule ParentModule
        {
            get { return (IOfficeModule) GetValue(ParentModuleProperty); }
            set { SetValue(ParentModuleProperty, value); }
        }

        public static readonly DependencyProperty ModuleChildrenProperty =
            DependencyProperty.Register("ModuleChildren", typeof (IEnumerable<IOfficeModule>), typeof (ModuleListControl), new PropertyMetadata(default(IEnumerable<IOfficeModule>)));

        public IEnumerable<IOfficeModule> ModuleChildren
        {
            get { return (IEnumerable<IOfficeModule>) GetValue(ModuleChildrenProperty); }
            set { SetValue(ModuleChildrenProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof (ICommand), typeof (ModuleListControl), new PropertyMetadata(default(ICommand)));

        public ICommand ClickCommand
        {
            get { return (ICommand) GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        static ModuleListControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModuleListControl), new FrameworkPropertyMetadata(typeof(ModuleListControl)));
        }
    }
}
