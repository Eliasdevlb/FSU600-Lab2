using System.Collections.Generic;

namespace FSU_600_LAB2.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Status { get; set; }
    public ICollection<Driver> Drivers { get; set; }
}
