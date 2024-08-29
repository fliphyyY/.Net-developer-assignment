using System.Xml.Serialization;

namespace Metrans.SerializerObjects
{
    public class OrderFooter
    {
        [XmlElement("TotalAmount")]
        public double TotalAmount { get; set; }

        [XmlElement("Status")]
        public string Status { get; set; }
    }
}
