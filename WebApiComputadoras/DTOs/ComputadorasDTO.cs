using System.ComponentModel.DataAnnotations;
using WebApiComputadoras.Validaciones;

namespace WebApiComputadoras.DTOs
{
    public class ComputadorasDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        [PrimeraLetraMayuscula]
        public string Marca
        {
            get; set;
        }
    }
}
