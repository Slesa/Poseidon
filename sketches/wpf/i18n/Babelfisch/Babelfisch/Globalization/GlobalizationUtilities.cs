using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Babelfisch.Globalization
{
    public class GlobalizationUtilities : INotifyPropertyChanged
    {
        public static readonly GlobalizationUtilities TheInstance = new GlobalizationUtilities();

        public List<SupportedCulture> SupportedCultures { get; set; }

        public SupportedCulture SelectedCulture { get; set; }
        public event EventHandler SelectedCultureChanged;


        public GlobalizationUtilities()
        {
            SupportedCultures = new List<SupportedCulture>();
            SupportedCultures.Add(new SupportedCulture("de-DE", OnSelectedCultureChanged));
            SupportedCultures.Add(new SupportedCulture("en-GB", OnSelectedCultureChanged));
            SupportedCultures.Add(new SupportedCulture("en-US", OnSelectedCultureChanged));
            SupportedCultures.Add(new SupportedCulture("fr-FR", OnSelectedCultureChanged));
            SupportedCultures.Add(new SupportedCulture("fa-IR", OnSelectedCultureChanged));

            SelectedCulture = SupportedCultures.FirstOrDefault();
        }

        void OnSelectedCultureChanged(object sender, EventArgs args)
        {
            var culture = sender as SupportedCulture;
            if (culture.IsSelected)
            {
                SelectCulture(culture);
            }
        }

        private void SelectCulture(SupportedCulture culture)
        {
            if (SelectedCulture != null)
            {
                SelectedCulture.IsSelected = false;
            }
            SelectedCulture = culture;

            Thread.CurrentThread.CurrentCulture = culture.CultureInfo;
            Thread.CurrentThread.CurrentUICulture = culture.CultureInfo;

            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
            if (SelectedCultureChanged != null) SelectedCultureChanged(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}