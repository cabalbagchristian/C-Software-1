using christiancabalbag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christiancabalbag
{
    public class Product
    {
        private int productId;
        private string name;
        private int inStock;
        private decimal price;
        private int min;
        private int max;
        public BindingList<Part> AssociatedParts = new BindingList<Part>();
        public int ProductId { get; set; }
        public string Name { get; set; }        
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
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Product() { }
        public Product(int productID, string name, int inStock, decimal price, int min, int max)
        {
            ProductId = productID;
            Name = name;
            InStock = inStock;
            Price = price.ToString();           
            Min = min;
            Max = max;
        }
        public void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }
        //public bool removeAssociatedPart(int partId)
        //{
        //    //bool success = false;
        //    //foreach (Part part in AssociatedParts)
        //    //{
        //    //    if (part.PartId == partID)
        //    //    {
        //    //        AssociatedParts.Remove(part);
        //    //        return success = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        success = false;
        //    //    }
        //    //    return success;

        //    //}

        //}
        public Part lookupAssociatedPart(int partId)
        {
            foreach (Part part in AssociatedParts)
            {
                if(part.PartId == partId) { return part; }
            }
            return null;
        }
    }

}
