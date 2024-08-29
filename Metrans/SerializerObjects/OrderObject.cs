using System.Xml.Serialization;

namespace Metrans.SerializerObjects
{
    [XmlRoot("Order")]
    public class OrderObject
    {
        [XmlElement("OrderHeader")]
        public OrderHeader OrderHeader { get; set; }

        // Define the OrderDetails property which is a list of Items
        [XmlArray("OrderDetails")]
        [XmlArrayItem("Item")]
        public List<OrderItem> Items { get; set; }

        // Define the OrderFooter property
        [XmlElement("OrderFooter")]
        public OrderFooter OrderFooter { get; set; }
    }
}
