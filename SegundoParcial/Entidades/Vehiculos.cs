using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoID { get; set; }
        public int CostoMantenimiento { get; set; }

        public Vehiculos(int articuloID, int CantidadCotizada)
        {
            this.VehiculoID = articuloID;
            this.CostoMantenimiento = CostoMantenimiento;
        }

        public Vehiculos()
        {
            this.VehiculoID = 0;
            this.CostoMantenimiento = 0;
        }
    }
}
