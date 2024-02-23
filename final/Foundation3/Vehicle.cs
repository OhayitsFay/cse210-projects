// Vehicle class represents common attributes of all vehicles
class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double RentalPrice { get; set; }

    public Vehicle(string make, string model, int year, double rentalPrice)
    {
        Make = make;
        Model = model;
        Year = year;
        RentalPrice = rentalPrice;
    }
}