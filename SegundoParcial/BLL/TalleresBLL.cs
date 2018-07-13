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
    public class TalleresBLL
    {
        public static bool Guardar(Talleres Taller)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.talleres.Add(Taller) != null)
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

        public static bool Modificar(Talleres Taller)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Taller).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar No se encuentran talleres registrados en el ID ");
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Talleres Taller = contexto.talleres.Find(id);

                contexto.talleres.Remove(Taller);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar No se encuentran talleres registrados en el ID");
            }
            return paso;
        }

        public static Talleres Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Talleres Taller = new Talleres();
            try
            {
                Taller = contexto.talleres.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("No encuentran talleres registrados en este ID");
            }
            return Taller;
        }


        public static List<Talleres> GetList(Expression<Func<Talleres, bool>> expression)
        {
            List<Talleres> Taller = new List<Talleres>();
            Contexto contexto = new Contexto();
            try
            {
                Taller = contexto.talleres.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("No encuentran talleres registrados"); 
            }
            return Taller;
        }
    }
}
