using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Talleres
    {
        [Key]
        public int TalleresID { get; set; }

        public string Nombre { get; set; }

        public Talleres()
        {
            TalleresID = 0;
            Nombre = String.Empty;
        }
        
    }
}
