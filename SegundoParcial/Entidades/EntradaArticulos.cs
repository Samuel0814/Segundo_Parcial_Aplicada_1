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

        public string NombreArticulo { get; set; }

        public int CantidadArticulo { get; set; }


        public EntradaArticulos()
        {
            EntradaID = 0;
            Fecha = DateTime.Now;
            NombreArticulo = string.Empty;
            CantidadArticulo = 0;
        }
    }
}
