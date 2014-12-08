using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace Babelfisch.Globalization
{
    public class SupportedCulture : SelectableItem
    {
        // All culture information
        public CultureInfo CultureInfo { get; set; }

        // Flag for graphical representation
        public ImageSource Flag { get; set; }

        // Language setting in XAML code
        public XmlLanguage XmlLanguage { get; set; }

        // Flow direction
        public FlowDirection FlowDirection { get; set; }

        public string this[string id]
        {
            get { return GlobalizationRepository.GetString(CultureInfo.Name, id); }
        }

        public SupportedCulture(string cultureId, EventHandler isSelectedChangEventHandler)
        {
            CultureInfo = CultureInfo.GetCultureInfo(cultureId);
            Flag = (ImageSource) App.Current.FindResource(cultureId);
            XmlLanguage = XmlLanguage.GetLanguage(CultureInfo.Name);
            FlowDirection = CultureInfo.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            IsSelectedChanged += isSelectedChangEventHandler;
        }
    }
}