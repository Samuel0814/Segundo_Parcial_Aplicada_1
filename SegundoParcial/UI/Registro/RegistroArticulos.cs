using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial.UI.Registro
{
    public partial class RegistroArticulos : Form
    {
        public RegistroArticulos()
        {
            InitializeComponent();
        }

        private Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();

            articulo.ArticulosId = Convert.ToInt32(ArticuloIdnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Costo = Convert.ToSingle(CostonumericUpDown.Text);
            articulo.Precio = Convert.ToSingle(PrecionumericUpDown.Value);
            articulo.PorcientoGanancia = Convert.ToSingle(GanancianumericUpDown.Text);
            

            return articulo;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            
            var articulo = BLL.ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdnumericUpDown.Value));
            
            if (articulo != null)
            {
                DescripciontextBox.Text = articulo.Descripcion;
                CostonumericUpDown.Text = articulo.Costo.ToString();
                PrecionumericUpDown.Text = articulo.Precio.ToString();
                GanancianumericUpDown.Text = articulo.PorcientoGanancia.ToString();
                InventariotextBox.Text = articulo.Inventario.ToString();
                  
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            ArticuloIdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CostonumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            GanancianumericUpDown.Value = 0;
            InventariotextBox.Clear();
            MyerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Articulos articulo;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            articulo = LlenaClase();

            
            if (ArticuloIdnumericUpDown.Value == 0)
                Paso = BLL.ArticulosBLL.Guardar(articulo);
            else
                Paso = BLL.ArticulosBLL.Modificar(LlenaClase());


            if (Paso)
            {
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArticuloIdnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyerrorProvider.SetError(DescripciontextBox,
                    "Debes escribir una Decripción para el artículo");
                HayErrores = true;
            }

            if (CostonumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(CostonumericUpDown, "No debe dejar el campo en 0");
                HayErrores = false;
            }

            if (PrecionumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(PrecionumericUpDown, "No debe dejar el campo en 0");
                HayErrores = false;
            }

            if (GanancianumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(GanancianumericUpDown, "No debe dejar el campo en 0");
                HayErrores = false;
            }

            return HayErrores;
        }


        private void RegistroArticulos_Load(object sender, EventArgs e)
        {

        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CostonumericUpDown.Value != 0)
            {
                PrecionumericUpDown.Value = CostonumericUpDown.Value + GanancianumericUpDown.Value;
            }
        }

        private void GanancianumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (GanancianumericUpDown.Value != 0)
            {
                PrecionumericUpDown.Value = CostonumericUpDown.Value + GanancianumericUpDown.Value;
            }
        }

        
        private void InventariotextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
        
}
