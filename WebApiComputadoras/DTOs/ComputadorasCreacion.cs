using System.ComponentModel.DataAnnotations;
using WebApiComputadoras.Validaciones;

namespace WebApiComputadoras.DTOs
{
    public class ComputadorasCreacion
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo es invalido")]
        [PrimeraLetraMayuscula]
        public string Marca { get; set; }
    }
}
