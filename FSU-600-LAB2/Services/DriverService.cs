using Microsoft.EntityFrameworkCore;
using FSU_600_LAB2.Models;

public class DriverService
{
    private readonly ApplicationDbContext _context;

    public DriverService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Driver>> GetAllDriversAsync()
    {
        return await _context.Drivers.Include(d => d.Vehicles).ToListAsync();
    }

    public async Task<Driver> GetDriverByIdAsync(int id)
    {
        return await _context.Drivers
            .Include(d => d.Vehicles)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddDriverAsync(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDriverAsync(Driver driver)
    {
        _context.Drivers.Update(driver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDriverAsync(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver != null)
        {
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Driver>> GetActiveDriversAsync()
    {
        return await _context.Drivers
                             .Include(d => d.Vehicles)
                             .Where(d => d.Status == "Active") // Assuming "Active" is the status for active drivers
                             .ToListAsync();
    }

}
