using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailServer
{
    public class Product
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return Name + " " + Price;
        }
    }
}
