using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christiancabalbag
{
    public abstract class Part
    {
        private int partId;
        private string name;
        private int inStock;
        private int min;
        private int max;
        public int PartId { get; set; }
        public string Name { get; set; }
        public int InStock { get; set; }
        private decimal price { get; set; }
        public string Price //make sure this works
        {
            get { return price.ToString("C"); }
            set
            {
                if (value.StartsWith("$"))
                {
                    price = decimal.Parse(value.Substring(1));
                }
                else
                {
                    price = decimal.Parse(value);
                }
            }
        }
         public int Max { get; set; }
         public int Min { get; set; }


    }
}
