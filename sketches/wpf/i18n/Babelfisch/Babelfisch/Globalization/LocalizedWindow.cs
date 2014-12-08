using System.Windows;
using System.Windows.Data;

namespace Babelfisch.Globalization
{
    public class LocalizedWindow : Window
    {
        public LocalizedWindow()
        {
            var languageBinding = new Binding("SelectedCulture.XmlLanguage")
            {
                Source = GlobalizationUtilities.TheInstance
            };
            SetBinding(LanguageProperty, languageBinding);

            var flowBinding = new Binding("SelectedCulture.FlowDirection")
            {
                Source = GlobalizationUtilities.TheInstance
            };
            SetBinding(FlowDirectionProperty, flowBinding);
        }
    }
}