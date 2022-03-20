using System;
using System.Collections.Generic;

namespace InventoryManagement
{
    public class Inventory
    {
        public int Sum { get; set; }
        public List<Seeds> Rice;
        public List<Seeds> Pulses;
        public List<Seeds> Wheat;
    }

    public class Seeds
    {
        public string Brand;
        public int PricePerKg;
        public int Weight;
        public int TotalPrice;

        public override string ToString()
        {
            return string.Format("name:\t{0}\nprice per KG:\t{1}\nWeight:\t{2}\nTotalPrice:\t{3}", this.Brand, this.PricePerKg, this.Weight, this.TotalPrice);
        }
    }
}
