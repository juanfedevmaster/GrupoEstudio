using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class House
    {
        public string Address { get; set; }
        public int NumRooms { get; set; }
        public double Price { get; set; }
        public bool HasGarden { get; set; }

        // Constructor
        public House(string address, int numRooms, double price, bool hasGarden)
        {
            Address = address;
            NumRooms = numRooms;
            Price = price;
            HasGarden = hasGarden;
        }

        public override string ToString()
        {
            return $"House{{ Address = {Address}, NumRooms = {NumRooms}, Price = {Price}, HasGarden = {HasGarden} }}";
        }
    }

}
