using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcial.BLL
{
    public class VehiculosBLL
    {
        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();
            Contexto contexto = new Contexto();
            try
            {
                vehiculos = contexto.Vehiculos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculos;
        }
    }
}
