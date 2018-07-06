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

        public int SubTotal { get; set; }

        public int Itbis { get; set; }

        public int Total { get; set; }

        public virtual ICollection<MantenimientoDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientoDetalle>();
        }

        public void AgregarDetalle( int ArticuloID, string NombreArticulo, float Cantidad, float Precio, float Importe)
        {
            this.Detalle.Add(new MantenimientoDetalle( ArticuloID, NombreArticulo, Cantidad, Precio, Importe));
        }
    }
}
