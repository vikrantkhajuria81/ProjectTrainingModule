using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class ProductEntity
    {

        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int discountPercentage { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public int stock { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public string thumbnail { get; set; }
    }
}
