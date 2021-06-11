using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCidenet.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int IdPais { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public int NumIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string OtrosNombres { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int idArea { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public SelectList listaTipoIdentificacion { get; set; }

        [NotMapped]
        public SelectList listaPaises { get; set; }

        [NotMapped]
        public SelectList listaAreas { get; set; }
    }
}
