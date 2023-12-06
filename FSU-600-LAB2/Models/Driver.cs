using System.Collections.Generic;

namespace FSU_600_LAB2.Models;

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string City { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
