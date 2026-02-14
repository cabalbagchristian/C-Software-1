using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace christiancabalbag
{
    public class Inventory //put static back after texting
    {
        public static BindingList<Part> AllParts = new BindingList<Part>();
        public static BindingList<Product> Products = new BindingList<Product>();
        // bindinglist that holds my list( which is named Products, which holds all new data items containing that list) = this side instatiates the list

        
        //needed for uml
        public static void addProduct (Product prod)
        {
            Products.Add(prod);            
        }

        //public static bool removeProduct(int productId)
        //{
        //    bool success = false;
        //    foreach (Product prod in Products)
        //    {
        //        if (productId == productId.ProductId)
        //        {
        //            Products.Remove(prod);
        //            return success = true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Remove failed.");
        //            return false;
        //        }
        //    }
        //}
        public static void addPart(Part part)
        {
            AllParts.Add(part);
        }
        public static bool deletePart(Part part)
        {
            //if (part  == null) return false;
            //else
            //{
            //    AllParts.Remove(part);
            //    return true;
            //}
            try
            {
                AllParts.Remove(part);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static Part lookupPart(int partId)
        {
            foreach (Part part in AllParts)
            {
                if (part.PartId == partId) 
                { return part; }
            }
            Part emptyPart = new Inhouse();
            return emptyPart;
            
        }       
        public static void updatePart(int id, Part updatedPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].PartId == id)
                {
                    AllParts[i] = updatedPart;
                    return;
                }
            }
        }



        //end needed for uml
        public static void exampleLists()
        {
            //nt partId, string name, int inStock, int max, int min, decimal price, int machineId
            Part exampleInPart1 = new Inhouse(1, "Pedal", 15, 3, 20, 1, 33);
            Part exampleInPart2 = new Inhouse(2, "Bell", 3, 7, 25, 1, 23);
            Part exampleInPart3 = new Inhouse(3, "Tire", 5, 2, 20, 1, 13);
            AllParts.Add(exampleInPart1);
            AllParts.Add(exampleInPart2);
            AllParts.Add(exampleInPart3);

            Product prodexample = new Product(1, "Blue Bike", 3, 5, 20, 1);
            Products.Add(prodexample);
            var prodexample2 = new Product(2, "Red Bike", 24, 3, 1, 5);
            Products.Add(prodexample2);
        }
    }
}
