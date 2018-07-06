using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Articulos
    {
        [Key]

        public int ArticulosId { get; set; }

        public string Descripcion { get; set; }

        public float Precio { get; set; }

        public float Costo { get; set; }

        public float PorcientoGanancia { get; set; }

        public float Inventario { get; set; }


        public Articulos()
        {
            ArticulosId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            PorcientoGanancia = 0;
            Inventario = 0;
        }

    }
}
