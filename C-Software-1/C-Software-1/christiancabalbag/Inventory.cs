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

        public static bool removeProduct(int productId)
        {
            bool success = false;
            foreach (Product prod in Products)
            {
                if (prod.ProductId == productId)
                {
                    Products.Remove(prod);
                    return success = true;
                }
                else
                {
                    MessageBox.Show("Remove failed.");
                    return false;
                }
            }
            return success;
        }
        public static Product lookupProduct(int productId)
        {
            foreach (Product prod in Products)
            {
                if (prod.ProductId == productId)
                { return prod; }
            }
            return null;
        }
        public static void updateProduct(int productID, Product product)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductId == productID)
                {
                    Products[i] = product;
                    return;
                }
            }

        }
        public static void addPart(Part part)
        {
            AllParts.Add(part);
        }
        public static bool deletePart(Part part)
        {            
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
            foreach (Part part in  AllParts)
                if(part.PartId == partId)
                {
                    return part; 
                }
            return null;
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
            AllParts.Clear();
            //nt partId, string name, int inStock, int max, int min, decimal price, int machineId
            Part exampleInPart1 = new Inhouse(1, "Pedal", 15, 3, 20, 1, 33);
            Part exampleInPart2 = new Inhouse(2, "Bell", 3, 7, 25, 1, 23);
            Part exampleInPart3 = new Inhouse(3, "Tire", 5, 2, 20, 1, 13);
            AllParts.Add(exampleInPart1);
            AllParts.Add(exampleInPart2);
            AllParts.Add(exampleInPart3);
        }
        public static void exampleLists2()
        {
            Products.Clear();
            Product prodexample = new Product(1, "Blue Bike", 3, 5, 1, 25);
            Products.Add(prodexample);
            var prodexample2 = new Product(2, "Red Bike", 4, 3, 1, 10);
            Products.Add(prodexample2);
            var prodexample3 = new Product(3, "Yellow Bike", 5, 3, 1, 15);
            Products.Add(prodexample3);
        }
    }
}
