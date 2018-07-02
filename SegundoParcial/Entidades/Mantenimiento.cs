using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoID { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime ProximoMantenimiento { get; set; }
        public string Taller { get; set; }
        public int Total { get; set; }

        public virtual List<MantenimientoDetalle> mantenimientoDetalle { get; set; }

        public Mantenimiento()
        {
            this.mantenimientoDetalle = new List<MantenimientoDetalle>();
        }

        public void AgregarDetalle(int id, String Servicio, int Cantidad, float Precio, float Importe)
        {
            this.mantenimientoDetalle.Add(new MantenimientoDetalle(id, Servicio, Cantidad, Precio, Importe));
        }
    }
}
