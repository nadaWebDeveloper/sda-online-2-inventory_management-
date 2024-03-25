using ItemSpace;
class Programs{
   public static void Main(string[] args)
   {
   //  ItemSpace.Items Item = new ItemSpace.Items("Water Bottle", -78, new DateTime(2023, 1, 1));
    ItemSpace.Items waterBottle = new ItemSpace.Items("Water Bottle", 78, new DateTime(2023, 1, 1));
    ItemSpace.Items coffee = new ItemSpace.Items("coffee", 78, new DateTime(2023, 1, 1));
    ItemSpace.Items sandwich = new ItemSpace.Items("sandwich", 78, new DateTime(2023, 1, 1));
    ItemSpace.Items batteries = new ItemSpace.Items("batteries", 78, new DateTime(2023, 1, 1));
    ItemSpace.Items umbrella = new ItemSpace.Items("umbrella");
    ItemSpace.Items sunscreen = new ItemSpace.Items("sunscreen", 78);
    Console.WriteLine($"{sunscreen}");
        Console.WriteLine($"{umbrella}");
    Console.WriteLine($"{waterBottle}");



   }
}