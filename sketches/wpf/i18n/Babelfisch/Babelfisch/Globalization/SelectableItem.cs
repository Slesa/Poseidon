using System;

namespace Babelfisch.Globalization
{
    public class SelectableItem
    {
        public event EventHandler IsSelectedChanged;

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                if (IsSelectedChanged != null) IsSelectedChanged(this, EventArgs.Empty);
            }
        }
    }
}