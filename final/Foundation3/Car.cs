// Car class represents specific attributes of cars
class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public int PassengerCapacity { get; set; }

    public Car(string make, string model, int year, double rentalPrice, int doors, int capacity)
        : base(make, model, year, rentalPrice)
    {
        NumberOfDoors = doors;
        PassengerCapacity = capacity;
    }
}