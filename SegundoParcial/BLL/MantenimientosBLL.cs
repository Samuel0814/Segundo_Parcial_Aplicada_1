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
                    foreach (var item in mantenimiento.Detalle)
                    {
                        var articulo = contexto.articulos.Find(item.ArticulosID);
                        if(articulo.Inventario<item.Cantidad)
                        {
                            return false;
                        }
                        articulo.Inventario -= item.Cantidad;
                        var vehiculo = contexto.Vehiculos.Find(item.VehiculosId);
                        vehiculo.TotalMantenimiento =Convert.ToInt32( item.Importe);

                    }
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
                int sum = 0;
                int sumTotal = 0;
                foreach (var item in mantenimientoDetalle.Detalle)
                {
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;

                    //TODO:
                   // BLL.EntradaArticulosBLL.ModificarCantidadInvitario(item.ArticulosID);
                    sum += item.Cantidad;
                    sumTotal += Convert.ToInt32(item.Importe);
                    contexto.articulos.Find(item.ArticulosID).Inventario -= sum;
                    contexto.Vehiculos.Find(item.VehiculosId).TotalMantenimiento = int.Parse(sumTotal.ToString());
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

                
                foreach (var item in mantenimiento.Detalle)
                {
                   var articulo= contexto.articulos.Find(item.ArticulosID);
                   articulo.Inventario += item.Cantidad;
                   var vehiculo = contexto.Vehiculos.Find(item.VehiculosId);
                   vehiculo.TotalMantenimiento -=Convert.ToInt32( item.Importe);
                   

                }
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

        public static void removerDetalle( Mantenimiento mantenimiento,int id)
        {
            Contexto contexto = new Contexto();
            var tmp = contexto.Mantenimientos.Find(mantenimiento.MantenimientoID);
            if (tmp != null)
            {
                var item =( from detalle in tmp.Detalle
                           where detalle.ID == id
                           select detalle).First();

                tmp.Detalle.Remove((MantenimientoDetalle)item);
                contexto.articulos.Find(item.ArticulosID).Inventario += item.Cantidad;
                mantenimiento= contexto.Mantenimientos.Find(mantenimiento.MantenimientoID);
                contexto.SaveChanges();
                
            }
            else
            {
                var item = (from detalle in mantenimiento.Detalle
                           where detalle.ID == id
                           select detalle).First();
                mantenimiento.Detalle.Remove((MantenimientoDetalle)item);

            }

                      
        }

    }
}
