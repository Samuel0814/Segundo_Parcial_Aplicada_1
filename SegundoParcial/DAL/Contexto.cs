﻿using SegundoParcial.Entidades;
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

        public DbSet<Talleres> servicios { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public DbSet<Articulos>articulos  { get; set; }

        public DbSet<EntradaArticulos> entradaArticulos { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
