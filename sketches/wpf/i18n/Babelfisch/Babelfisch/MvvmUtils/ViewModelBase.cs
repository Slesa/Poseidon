using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Babelfisch.Globalization;

namespace Babelfisch.MvvmUtils
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private SupportedCulture _currentCulture;

        public SupportedCulture CurrentCulture
        {
            get { return _currentCulture; }
            set
            {
                if (_currentCulture == value) return;
                _currentCulture = value;
                OnCurrentCultureChanged();
            }
        }

        // Konstruktor. Richtet Kultur und Änderungsbenachrichtigung ein
        public ViewModelBase()
        {
            _currentCulture = GlobalizationUtilities.TheInstance.SelectedCulture;
            GlobalizationUtilities.TheInstance.SelectedCultureChanged += OnSelectedCultureChanged;
        }

        // Die Kultur hat sich geändert
        void OnSelectedCultureChanged(object sender, EventArgs e)
        {
            CurrentCulture = GlobalizationUtilities.TheInstance.SelectedCulture;
        }

        // Diese Methode wird bei Änderungen aufgerufen und muss von abgeleiteten ViewModels implementiert werden
        protected abstract void OnCurrentCultureChanged();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            GlobalizationUtilities.TheInstance.SelectedCultureChanged -= OnSelectedCultureChanged;
        }
    }
}