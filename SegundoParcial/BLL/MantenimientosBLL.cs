using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial.BLL
{
    public class MantenimientosBLL
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
                MessageBox.Show("Error al guardar");
            }
            return paso;
        }

        public static bool Modificar(Mantenimiento mantenimientoDetalle)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                foreach (var item in mantenimientoDetalle.Detalle)
                {
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(mantenimientoDetalle).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encuentras detalles de mantenimiento registrados en el ID seleccionado");
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
                MessageBox.Show("No se encuentras mantenimientos registrados en el ID seleccionado");
            }
            return paso;
        }

        public static Mantenimiento Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mantenimiento mantenimientoDetalle = new Mantenimiento();
            try
            {
                mantenimientoDetalle = contexto.Mantenimientos.Find(id);

                mantenimientoDetalle.Detalle.Count();

                foreach (var item in mantenimientoDetalle.Detalle)
                {
                    string s = item.Articulos.Descripcion;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {

                MessageBox.Show("No se encuentras detalles de mantenimiento registrados en el ID Seleccionado");
            }
            return mantenimientoDetalle;
        }

        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> expression)
        {
            List<Mantenimiento> mantenimientos = new List<Mantenimiento>();
            Contexto contexto = new Contexto();
            try
            {
                mantenimientos = contexto.Mantenimientos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encuentras mantenimientos registrados"); 
            }
            return mantenimientos;
        }

    }
}
