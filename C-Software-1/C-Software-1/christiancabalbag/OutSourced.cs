using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christiancabalbag
{
    public class OutSourced : Part
    {
        private string companyName;
        public string CompanyName { get; set; }
        public OutSourced() { }
        public OutSourced (int partId, string name, int inStock, decimal price, int max, int min, string companyName)
        {
            PartId = partId;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Max = max;
            Min = min;
            CompanyName = companyName;
            

        }
        public OutSourced(int partId, string name, int inStock, decimal price, int max, int min)
        {
            PartId = partId;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Max = max;
            Min = min;
            


        }
    }
}
