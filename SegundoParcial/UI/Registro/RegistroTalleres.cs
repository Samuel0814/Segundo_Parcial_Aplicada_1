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
    public partial class RegistroTalleres : Form
    {
        public RegistroTalleres()
        {
            InitializeComponent();
        }

        private Talleres LlenaClase()
        {
            Talleres talleres = new Talleres();

            talleres.TalleresID = Convert.ToInt32(TallerIDnumericUpDown.Value);
            talleres.Nombre = NombretextBox.Text;
            return talleres;
        }

        private bool HayErrores()
        {

            bool HayErrores = false;

            if(String.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MyerrorProvider.SetError(NombretextBox,
                    "Debes digitar el nombre del artículo");
                HayErrores = true;
            }
            return HayErrores;

        }

        private void RegistroTalleres_Load(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerIDnumericUpDown.Value);
            Talleres talleres = BLL.TalleresBLL.Buscar(id);

            if (talleres != null)
            {
                NombretextBox.Text = talleres.Nombre;
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            TallerIDnumericUpDown.Value = 0;
            NombretextBox.Clear();
            MyerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Talleres taller;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            taller = LlenaClase();

            
            if (TallerIDnumericUpDown.Value == 0)
                Paso = BLL.TalleresBLL.Guardar(taller);
            else
                Paso = BLL.TalleresBLL.Modificar(LlenaClase());

            
            if (Paso)
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerIDnumericUpDown.Value);

            if (BLL.TalleresBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
