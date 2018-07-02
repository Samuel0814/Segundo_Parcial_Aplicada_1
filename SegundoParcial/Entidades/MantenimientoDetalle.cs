using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class MantenimientoDetalle
    {
        [Key]
        public int Id { get; set; }

        public int MantenimientoID { get; set; }

        public int VehiculosID { get; set; }

        public string Servicio { get; set; }

        public float Cantidad { get; set; }

        public float Precio { get; set; }

        public float Importe { get; set; }

        [ForeignKey("VehiculosID")]
        public virtual Vehiculos Vehiculos { get; set; }


        public MantenimientoDetalle()
        {
            this.Id = 0;
            this.MantenimientoID = 0;
            this.VehiculosID = 0;
            this.Servicio = string.Empty;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
        }

        public MantenimientoDetalle(int id, int MantenimientoId, int VehiculosId, String servicio, int cantidad, int importe , int precio)
        {
            Id = id;
            MantenimientoID = MantenimientoId;
            VehiculosID = VehiculosId;
            Servicio = servicio;
            Cantidad = Cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
