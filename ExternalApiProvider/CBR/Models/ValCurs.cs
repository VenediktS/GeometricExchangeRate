using System.Xml.Serialization;

namespace ExternalApiProvider.CBR.Models
{
    [XmlRoot("ValCurs")]
    public class ValCurs
    {
        [XmlElement("Valute")]
        public Valute[] Valutes { get; set; }
    }
}
