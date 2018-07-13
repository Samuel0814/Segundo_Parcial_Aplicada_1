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

        public int MantenimientoId { get; set; }

        public int ArticulosID { get; set; }

        public int VehiculosId { get; set; }

        public int TalleresId { get; set; }

        public string NombreArticulo { get; set; }

        public float Cantidad { get; set; }

        public float Precio { get; set; }

        public float Importe { get; set; }

        [ForeignKey("ArticulosID")]
        public virtual Articulos Articulos { get; set; }

        [ForeignKey("VehiculosId")]
        public virtual Vehiculos Vehiculos { get; set; }

        [ForeignKey("TalleresId")]
        public virtual Talleres Talleres { get; set; }


        public MantenimientoDetalle()
        {
            this.ID = 0;
            this.MantenimientoId = 0;
            this.ArticulosID = 0;
            this.TalleresId = 0;
            this.VehiculosId = 0;
            this.NombreArticulo = string.Empty;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
        }

        public MantenimientoDetalle( int id, int mantenimientoId , int ArticuloId ,int talleresId, int vehiculoId, string nombreArticulo, float cantidad, float precio, float importe)
        {
            ID = id;
            MantenimientoId = mantenimientoId;
            ArticulosID = ArticuloId;
            TalleresId = talleresId;
            VehiculosId = vehiculoId;
            NombreArticulo = nombreArticulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;

        }
    }
}
