using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace InventoryManagement
{
    public class InventoryImplementation
    {
        private static string filepath = @"E:\BridgeLabzAssignment\Inventory Management\InventoeyManagement\InventoeyManagement\InventoryManagement.json";

        public void Add()
        {
            string jsonfile = File.ReadAllText(filepath);

            Inventory myinventory;
            myinventory = (Inventory)JsonConvert.DeserializeObject<Inventory>(jsonfile);
            if (myinventory == null)
            {
                myinventory = new Inventory();
            }
            int sum = 0;
            if (myinventory != null)
            {
                sum = myinventory.Sum;
            }

            Seeds item = new Seeds();
            Console.WriteLine("Enter 1 for Rice\nEnter 2 for Pulses\nEnter 3 for Wheats");
            int earned = int.Parse(Console.ReadLine());

            Console.WriteLine("please Enter the name of the product: ");
            item.Brand = Console.ReadLine();

            Console.WriteLine("Enter Price Per KG: ");
            item.PricePerKg = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Weight");
            item.Weight = int.Parse(Console.ReadLine());

            item.TotalPrice = item.PricePerKg * item.Weight;

            if (myinventory != null)
            {
                sum = sum + item.TotalPrice;
            }
            else
            {
                sum = item.TotalPrice;
            }

            switch (earned)
            {
                case 1:
                    {
                        if (myinventory.Rice == null)
                        {
                            myinventory.Rice = new List<Seeds>();
                        }
                    }
                    myinventory.Rice.Add(item);
                    break;
                case 2:
                    {
                        if (myinventory.Pulses == null)
                        {
                            myinventory.Pulses = new List<Seeds>();
                        }

                    }
                    myinventory.Pulses.Add(item);
                    break;
                case 3:
                    {
                        if (myinventory.Wheat == null)
                        {
                            myinventory.Wheat = new List<Seeds>();
                        }
                    }
                    myinventory.Wheat.Add(item);
                    break;
                default:
                    {
                        Console.WriteLine("Enter Right number");
                    }
                    break;

            }
            myinventory.Sum = sum;
            using StreamWriter writer = File.CreateText(@"E:\BridgeLabzAssignment\Inventory Management\InventoeyManagement\InventoeyManagement\InventoryManagement.json");
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, myinventory);
                Console.WriteLine("new Product added into Inventory");

            }
        }
        public void Display()
        {
            string jsonfile = File.ReadAllText(@"E:\BridgeLabzAssignment\Inventory Management\InventoeyManagement\InventoeyManagement\InventoryManagement.json");
            if (jsonfile.Length < 1)
            {
                Console.WriteLine("Inventory is empty please add content");
                return;
            }
            Inventory myinventory = JsonConvert.DeserializeObject<Inventory>(jsonfile);
            Console.WriteLine("Enter 1 to show the total Inventory cost\n enter 2 for Display json string");
            int entered = int.Parse(Console.ReadLine());

            switch (entered)
            {
                case 1:
                    {
                        Console.WriteLine(" total inventory cost is : " + myinventory.Sum);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine(jsonfile);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                    break;
            }
        }



        public void Delete()
        {
            Console.WriteLine("You can delete any of the item");
            string jsonfile = File.ReadAllText(@"E:\BridgeLabzAssignment\Inventory Management\InventoeyManagement\InventoeyManagement\InventoryManagement.json");
            Inventory myinventory = JsonConvert.DeserializeObject<Inventory>(jsonfile);

            Console.WriteLine("Enter 1 for rice\n Enter 2 for Pulses\nEnter 3 for Wheat");
            int entered = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the name of the Brand");

            string brand = Console.ReadLine();
            int sum = myinventory.Sum;

            switch (entered)
            {
                case 1:
                    {
                        foreach (Seeds item in myinventory.Rice)
                        {
                            if(item.Brand.Equals(brand))
                            {
                                sum = sum - item.TotalPrice;
                                myinventory.Rice.Remove(item);
                                break;
                            }
                        }
                    }
                    break;

                case 2:
                    {
                        foreach (Seeds item in myinventory.Pulses)
                        {
                            if (item.Brand.Equals(brand))
                            {
                                sum = sum - item.TotalPrice;
                                myinventory.Pulses.Remove(item);
                                break;
                            }
                        }
                    }
                    break;

                case 3:
                    {
                        foreach (Seeds item in myinventory.Wheat)
                        {
                            if (item.Brand.Equals(brand))
                            {
                                sum = sum - item.TotalPrice;
                                myinventory.Wheat.Remove(item);
                                break;
                            }
                        }
                    }
                    break;
                default:
                    {
                        Console.WriteLine("please select correct brand");
                    }
                    break;

                    myinventory.Sum = sum;
                     StreamWriter writer = File.CreateText(@"E:\BridgeLabzAssignment\Inventory Management\InventoeyManagement\InventoeyManagement\InventoryManagement.json");
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, myinventory);
                    }
            }
        }
    }
} 
