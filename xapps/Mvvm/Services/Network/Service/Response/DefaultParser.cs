using System;
using System.Xml.Linq;

namespace xapps
{
    public class DefaultParser
    {
        public string getElementData(XElement element) {
            if(isValidData(element) == true) {
				return element.Value.ToString();
            }
            return "";
        }
        
        public bool isValidData(XElement element) {
            if(element == null || String.IsNullOrEmpty(element.Value)) {
                return false;
            }

            return true;
        }
    }
}
