using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Empleado : BaseEntity
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public int IdCargo { get; set; }
        public Cargo Cargos { get; set; }
        public int IdMunicipio { get; set; }
        public Municipio Municipios { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}