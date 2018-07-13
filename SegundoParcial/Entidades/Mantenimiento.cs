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

        public float SubTotal { get; set; }

        public float Itbis { get; set; }

        public float Total { get; set; }

        public virtual ICollection<MantenimientoDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientoDetalle>();
        }

        public void AgregarDetalle(int id, int mantenimientoId, int ArticuloId, int talleresId, int vehiculoId, string nombreArticulo, float cantidad, float precio, float importe)
        {
            this.Detalle.Add(new MantenimientoDetalle( id, mantenimientoId, ArticuloId, talleresId, vehiculoId, nombreArticulo, cantidad, precio, importe));
        }
    }
}
