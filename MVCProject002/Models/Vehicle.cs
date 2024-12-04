namespace MVCProject002.Models
{
    // транспортний засіб
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Engine {  get; set; } // should be a class
        public int Mass { get; set; }
        public string Color { get; set; }
        public int SeatsCount { get; set; }
    }
}
