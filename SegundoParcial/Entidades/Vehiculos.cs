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

        public string Descripcion { get; set; }

        public float TotalMantenimiento { get; set; }

        public Vehiculos(int articuloID, float CostoMantenimiento)
        {
            this.VehiculoID = VehiculoID;
            this.Descripcion = Descripcion;
            this.TotalMantenimiento = CostoMantenimiento;
        }

        public Vehiculos()
        {
            this.VehiculoID = 0;
            this.Descripcion = string.Empty;
            this.TotalMantenimiento = 0;
        }
    }
}
