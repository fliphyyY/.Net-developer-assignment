using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Order
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int CustomerId { get; set; }


        public DateTime OrderDate { get; set; }


        public double TotalAmount { get; set; }


        public string Status { get; set; }

        public IList<Item> OrderItem { get; set; }
    }
}
