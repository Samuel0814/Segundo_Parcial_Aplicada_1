using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class EntradaArticulos
    {
        [Key]

        public int EntradaID { get; set; }

        public DateTime Fecha { get; set; }

        public float CantidadArticulo { get; set; }


        public EntradaArticulos()
        {
            EntradaID = 0;
            Fecha = DateTime.Now;
            CantidadArticulo = 0;
        }
    }
}
