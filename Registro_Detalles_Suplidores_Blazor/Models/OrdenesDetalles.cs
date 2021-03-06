﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalles_Suplidores_Blazor.Models
{
    public class OrdenesDetalles
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public decimal Costo { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
    }
}
