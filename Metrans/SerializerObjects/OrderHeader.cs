using System.Xml.Serialization;

namespace Metrans.SerializerObjects
{
    public class OrderHeader
    {
        [XmlElement("Id")]
        public int Id { get; set; }


        [XmlElement("CustomerId")]
        public int CustomerId { get; set; }


        [XmlElement("OrderDate")]
        public DateTime OrderDate { get; set; }
    }
}
