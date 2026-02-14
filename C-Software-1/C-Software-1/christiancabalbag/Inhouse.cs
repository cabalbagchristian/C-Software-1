using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christiancabalbag
{
    public class Inhouse : Part
    {
        private int machineID;
        public int MachineID { get; set; } //make label prop then put in constructor
        public Inhouse() { }
        public Inhouse(int partId, string name, int inStock, decimal price, int max, int min, int machineID) 
        {
            PartId = partId;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Max = max;
            Min = min;            
            MachineID = machineID;

        }
        public Inhouse(int partId, string name, int inStock, decimal price, int max, int min)
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
