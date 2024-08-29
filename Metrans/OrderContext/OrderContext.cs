using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AutoMapper;
using DAL.Models;
using DAL.OrderSystem;
using Metrans.SerializerObjects;

namespace Metrans.OrderContext
{
    public class OrderContext : IOrderContext
    {
        private readonly IDbCollectionGateway myDbCollectionGateway;
        private readonly IMapper myMapper;
        private static string projectDirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly string xmlFile = Path.Combine(projectDirectoryPath, "order.xml");
        private readonly string xsdFile = Path.Combine(projectDirectoryPath, "order.xsd");

        public OrderContext(IDbCollectionGateway collectionGateway, IMapper mapper)
        {
            myDbCollectionGateway = collectionGateway;
            myMapper = mapper;
        }
        public void ValidateXml()
        {
            XmlReaderSettings settings = new XmlReaderSettings();

            try
            {

                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add("", xsdFile);

                settings.Schemas.Add(schemas);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationEventHandler += (sender, e) => { Console.WriteLine($"{e.Severity}: {e.Message}"); };
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Setting up schema failed: {ex.Message}");
                throw new Exception();
            }


            try
            {
                using (XmlReader reader = XmlReader.Create(xmlFile, settings))
                {
                    while (reader.Read()) { }
                    Console.WriteLine("XML is valid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation failed: {ex.Message}");
                throw new Exception();
            }

        }

        public async Task DeserializeAndSaveToDb()
        {
            var orderItems = new List<OrderItem>();
            var orderObject = new OrderObject();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OrderObject));
                using (StreamReader reader = new StreamReader(xmlFile))
                {
                    orderObject = (OrderObject)serializer.Deserialize(reader);

                }

                foreach (var item in orderObject.Items)
                {
                    orderItems.Add(item);
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during deserialization: {ex.Message}");
                throw new Exception();
            }


            var order = myMapper.Map<Order>(orderObject);
            var items = new List<Item>();

            foreach (var orderItem in orderItems)
            {
                if (orderItem.OrderId.Equals(order.Id))
                {
                    var item = myMapper.Map<Item>(orderItem);
                    items.Add(item);
                }
            }

            await SaveToDb(order, items);
        }

        private async Task SaveToDb(Order order, List<Item> items)
        {
            if (!await myDbCollectionGateway.OrderExists(order.Id))
            {
                var pom = await myDbCollectionGateway.CreateOrder(order);

            }
            else
            {
                Console.WriteLine($"The order with id {order.Id} already exists!");
            }

            foreach (var item in items)
            {
                if (!await myDbCollectionGateway.ItemExists(item.Id))
                {
                    await myDbCollectionGateway.CreateItem(item);
                }

                else
                {
                    Console.WriteLine($"The item with id {item.Id} already exists!");
                }
            }
        }


    }
}
