using Microsoft.EntityFrameworkCore;
using TruckRegistration.Models;

namespace TruckRegistration.Data;

public class AppDbContext : DbContext
{
    // O construtor recebe as opções de configuração (como a string de conexão ou o banco em memória)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Representa a tabela "Trucks" no banco de dados.
    // É através desse `Trucks` que faremos consultas tipo: _context.Trucks.ToListAsync()
    public DbSet<Truck> Trucks { get; set; }
}