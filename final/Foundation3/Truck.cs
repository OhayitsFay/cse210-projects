// Truck class represents specific attributes of trucks
class Truck : Vehicle
{
    public double CargoCapacity { get; set; }
    public double TowingCapacity { get; set; }

    public Truck(string make, string model, int year, double rentalPrice, double cargoCapacity, double towingCapacity)
        : base(make, model, year, rentalPrice)
    {
        CargoCapacity = cargoCapacity;
        TowingCapacity = towingCapacity;
    }
}
