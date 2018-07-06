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

        public int ArticulosID { get; set; }

        public string NombreArticulo { get; set; }

        public float Cantidad { get; set; }

        public float Precio { get; set; }

        public float Importe { get; set; }

        
        [ForeignKey("ArticulosID")]
        public virtual Articulos Articulos { get; set; }

        public MantenimientoDetalle()
        {
            this.ArticulosID = 0;
            this.NombreArticulo = string.Empty;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
        }

        public MantenimientoDetalle( int ArticuloId, string nombreArticulo, float cantidad, float precio, float importe)
        {
            ArticulosID = ArticuloId;
            NombreArticulo = nombreArticulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
