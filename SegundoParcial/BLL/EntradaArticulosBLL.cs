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
    public class EntradaArticulosBLL
    {
        public static bool Guardar(EntradaArticulos Entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                if (contexto.entradaArticulos.Add(Entrada) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("No se encuentran entradas de articulos registradas");
            }
            return paso;
        }

        public static bool Modificar(EntradaArticulos Entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Entrada).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("No se encuentran entradas de articulos registradas");
            }
            ;
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                EntradaArticulos Entrada = contexto.entradaArticulos.Find(id);

                contexto.entradaArticulos.Remove(Entrada);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encuentran entradas de articulos registradas");
            }
            return paso;
        }

        public static EntradaArticulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EntradaArticulos Entrada = new EntradaArticulos();
            try
            {
                Entrada = contexto.entradaArticulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("No se encuentran entradas de articulos registradas");
            }
            return Entrada;
        }



        public static List<EntradaArticulos> GetList(Expression<Func<EntradaArticulos, bool>> expression)
        {
            List<EntradaArticulos> Entrada = new List<EntradaArticulos>();
            Contexto contexto = new Contexto();
            try
            {
                Entrada = contexto.entradaArticulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("No se encuentran entradas de articulos registradas");
            }
            return Entrada;
        }

        
    }
}
