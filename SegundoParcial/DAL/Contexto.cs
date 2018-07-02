using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SegundoParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Vehiculos> Vehiculos { get; set; }

        public DbSet<Servicios> servicios { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public DbSet<MantenimientoDetalle> MantenimientoDetalles { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
