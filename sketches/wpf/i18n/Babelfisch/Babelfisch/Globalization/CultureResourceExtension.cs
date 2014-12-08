using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace Babelfisch.Globalization
{
    public class CultureResourceExtension : MarkupExtension
    {
        public string Id { get; set; }

        public CultureResourceExtension()
        {
        }

        public CultureResourceExtension(string id)
        {
            Id = id;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding("SelectedCulture[" + Id + "]")
            {
                Source = GlobalizationUtilities.TheInstance
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
}