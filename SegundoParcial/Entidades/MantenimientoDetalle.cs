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
        public int ID { get; set; }

        public int MantenimientoID { get; set; }

        public int VehiculosID { get; set; }

        public int TalleresID { get; set; }

        public int ArticulosID { get; set; }

        public float Cantidad { get; set; }

        public float Precio { get; set; }

        public float Importe { get; set; }

        [ForeignKey("VehiculosID")]
        public virtual Vehiculos Vehiculos { get; set; }

        [ForeignKey("TallerID")]
        public virtual Talleres Talleres { get; set; }

        [ForeignKey("ArticulosID")]
        public virtual Articulos Articulos { get; set; }

        public MantenimientoDetalle()
        {
            this.ID = 0;
            this.MantenimientoID = 0;
            this.VehiculosID = 0;
            this.TalleresID = 0;
            this.ArticulosID = 0;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
        }

        public MantenimientoDetalle(int Id, int VehiculoId, int TallerId, int ArticuloId, float cantidad, float precio, float importe)
        {
            ID = Id;
            VehiculosID = VehiculoId;
            TalleresID = TallerId;
            ArticulosID = ArticuloId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

        public override string ToString()
        {
            return "Vehiculos: " + this.VehiculosID.ToString() + ":Cantidad " + this.Cantidad;
        }
    }
}
