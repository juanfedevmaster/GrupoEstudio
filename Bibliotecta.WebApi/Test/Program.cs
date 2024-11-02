namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<House> houseList = new List<House>();
/**/
            // Añadir 10 objetos House a la lista
            houseList.Add(new House("123 Elm St", 3, 250000.0, true));
            houseList.Add(new House("456 Oak St", 4, 300000.0, false));
            houseList.Add(new House("789 Maple St", 2, 150000.0, true));
            houseList.Add(new House("101 Pine St", 5, 350000.0, true));
            houseList.Add(new House("202 Birch St", 3, 200000.0, false));
            houseList.Add(new House("303 Cedar St", 4, 275000.0, true));
            houseList.Add(new House("404 Spruce St", 3, 240000.0, false));
            houseList.Add(new House("505 Ash St", 2, 180000.0, true));
            houseList.Add(new House("606 Walnut St", 4, 320000.0, false));
            houseList.Add(new House("707 Cherry St", 3, 230000.0, true));

            House result = houseList.FirstOrDefault();
        }
    }
}
