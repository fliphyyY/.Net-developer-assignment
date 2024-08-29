using System.Xml.Serialization;

namespace Metrans.SerializerObjects
{
    public class OrderItem
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("OrderId")]
        public int OrderId { get; set; }

        [XmlElement("ProductName")]
        public string ProductName { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        [XmlElement("UnitPrice")]
        public double UnitPrice { get; set; }

        [XmlElement("TotalPrice")]
        public double TotalPrice { get; set; }
    }
}
