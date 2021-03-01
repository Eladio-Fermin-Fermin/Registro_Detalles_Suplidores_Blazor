using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalles_Suplidores_Blazor.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Selecione un suplidor para realizar la ordén.")]
        public int SuplidorId { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalles> Detalle { get; set; }

        public Ordenes()
        {
            Fecha = DateTime.Now;
            Detalle = new List<OrdenesDetalles>();
        }
    }
}
