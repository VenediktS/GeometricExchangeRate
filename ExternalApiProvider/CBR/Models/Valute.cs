using System.Xml.Serialization;

namespace ExternalApiProvider.CBR.Models
{
    public class Valute
    {
        [XmlElement("CharCode")]
        public string CharCode { get; set; }
        [XmlElement("Value")]
        public string Value { get; set; }
    }
}
