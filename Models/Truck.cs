namespace TruckRegistration.Models;

public class Truck
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public int FabricationYear { get; set; }
    public decimal CargoCapacityTons { get; set; }
}