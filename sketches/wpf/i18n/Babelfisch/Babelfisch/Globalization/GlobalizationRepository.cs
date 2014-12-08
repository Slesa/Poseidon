using System.Linq;
using System.Xml.Linq;

namespace Babelfisch.Globalization
{
    public class GlobalizationRepository
    {
        public static string GetString(string cultureId, string id)
        {
            var doc = XDocument.Load("data/texts.xml");
            if (doc.Root != null)
            {
                var xCulture = doc.Root.Elements("Culture").FirstOrDefault(c => c.Attribute("id").Value == cultureId);
                if (xCulture != null)
                {
                    var xEntry = xCulture.Elements("Entry").FirstOrDefault(e => e.Attribute("id").Value == id);
                    if (xEntry != null)
                    {
                        return xEntry.Value;
                    }
                }
            }
            return "!! " + id + " !!";
        } 
    }
}