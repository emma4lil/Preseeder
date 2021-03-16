using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreSeeder.Model
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int Quantity { get; set; }

        public ICollection<Product> Products { get; set; }
        public User Owner { get; set; }
    }
}