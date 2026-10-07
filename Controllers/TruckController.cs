using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckRegistration.Data;
using TruckRegistration.DTOs;
using TruckRegistration.Models;

namespace TruckRegistration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrucksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TrucksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Truck>>> Index()
    {
        // Rails: @Trucks = Caminhao.all
        var Trucks = await _context.Trucks.ToListAsync();
        return Ok(Trucks); // Retorna HTTP 200 com a lista em JSON
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Truck>> Show(int id)
    {
        // Rails: @caminhao = Caminhao.find_by(id: params[:id])
        var truck = await _context.Trucks.FindAsync(id);

        if (truck == null)
            return NotFound(new { mensagem = "Caminhão não encontrado." }); // HTTP 404

        return Ok(truck); // HTTP 200
    }

    [HttpPost]
    public async Task<ActionResult<Truck>> Create([FromBody] TruckDto dto)
    {
        var truck = new Truck
        {
            Model = dto.Model,
            Plate = dto.Plate.ToUpper(),
            FabricationYear = dto.FabricationYear,
            CargoCapacityTons = dto.CargoCapacityTons
        };

        _context.Trucks.Add(truck);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Show), new { id = truck.Id }, truck);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TruckDto dto)
    {
        var truck = await _context.Trucks.FindAsync(id);

        if (truck == null)
            return NotFound(new { mensagem = "Caminhão não encontrado." });

        // Atualizamos os atributos no objeto em memória
        truck.Model = dto.Model;
        truck.Plate = dto.Plate.ToUpper();
        truck.FabricationYear = dto.FabricationYear;
        truck.CargoCapacityTons = dto.CargoCapacityTons;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var truck = await _context.Trucks.FindAsync(id);

        if (truck == null)
            return NotFound(new { mensagem = "Caminhão não encontrado." });

        // Rails: caminhao.destroy
        _context.Trucks.Remove(truck);
        await _context.SaveChangesAsync();

        return NoContent(); // HTTP 204
    }
}