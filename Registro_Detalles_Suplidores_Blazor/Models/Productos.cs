using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalles_Suplidores_Blazor.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = " ")]
        public string Descripcion { get; set; }
        [Range(minimum: 10, maximum: 1000000, ErrorMessage = "El Costo no es válido.")]
        public decimal Costo { get; set; }

        public float Inventario { get; set; }
    }
}
