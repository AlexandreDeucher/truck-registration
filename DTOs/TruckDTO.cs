using System.ComponentModel.DataAnnotations;

namespace TruckRegistration.DTOs;

public class TruckDto
{
    [Required(ErrorMessage = "O modelo é obrigatório.")]
    [StringLength(50, ErrorMessage = "O modelo pode ter no máximo 50 caracteres.")]
    public string Model { get; set; } = string.Empty;

    [Required(ErrorMessage = "A placa é obrigatória.")]
    // Regra regex para formato de placa tradicional ou Mercosul (ex: ABC1D23 ou ABC1234)
    [RegularExpression(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$", ErrorMessage = "Placa em formato inválido.")]
    public string Plate { get; set; } = string.Empty;

    [Range(1900, 2030, ErrorMessage = "Ano de fabricação inválido.")]
    public int FabricationYear { get; set; }

    [Range(0.1, 100.0, ErrorMessage = "A capacidade deve ser entre 0.1 e 100 toneladas.")]
    public decimal CargoCapacityTons { get; set; }
}