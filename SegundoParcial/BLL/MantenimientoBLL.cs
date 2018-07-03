using SegundoParcial.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class MantenimientoBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Mantenimientos.Add(mantenimiento) != null)
                {
                    contexto.SaveChanges(); 
                    paso = true;
                }
                
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                foreach (var item in mantenimiento.Detalle)
                {
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(mantenimiento).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Mantenimiento mantenimiento = contexto.Mantenimientos.Find(id);

                contexto.Mantenimientos.Remove(mantenimiento);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Mantenimiento Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mantenimiento mantenimiento = new Mantenimiento();
            try
            {
                mantenimiento = contexto.Mantenimientos.Find(id);

                mantenimiento.Detalle.Count();

                foreach (var item in mantenimiento.Detalle)
                {
                    string s = item.Articulos.Descripcion;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return mantenimiento;
        }

        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> expression)
        {
            List<Mantenimiento> Mantenimientos = new List<Mantenimiento>();
            Contexto contexto = new Contexto();
            try
            {
                Mantenimientos = contexto.Mantenimientos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Mantenimientos;
        }
    }
}
