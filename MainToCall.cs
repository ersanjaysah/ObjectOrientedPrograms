using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class MainToCall
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Inventory Management");
            InventoryImplementation obj = new InventoryImplementation();
            while (true)
            {
                Console.WriteLine("Enter 1 for add\nEnter 2 for Delete\nEnter 3 for Display");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        {
                            Console.WriteLine("welcome to the adding Item");
                            obj.Add();
                            obj.Display();
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("welcome to the Deleting Item");
                            obj.Delete();
                            obj.Display();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("here are all the list");
                            obj.Display();
                        }
                        break;
                }
            }
        }
    }
}
