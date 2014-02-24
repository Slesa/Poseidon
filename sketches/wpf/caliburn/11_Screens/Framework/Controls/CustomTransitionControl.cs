using System;
using System.Windows.Controls;

namespace _11_Screens.Framework.Controls {
    public class CustomTransitionControl : ContentControl {
        public event EventHandler ContentChanged = delegate { };

        protected override void OnContentChanged(object oldContent, object newContent) {
            base.OnContentChanged(oldContent, newContent);
            ContentChanged(this, EventArgs.Empty);
        }
    }
}