using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string  Barcode { get; set; }
        public int ReOrderLevel { get; set; }
        public decimal Price { get; set; }
        public int QuantityRemaining { get; set; }

    }
}
