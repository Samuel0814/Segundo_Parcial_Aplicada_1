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
    public partial class RegistroVehiculos : Form
    {
        public RegistroVehiculos()
        {
            InitializeComponent();
        }

        private void RegistroVehiculos_Load(object sender, EventArgs e)
        {

        }
        private Vehiculos LlenaClase()
        {
            Vehiculos vehiculos = new Vehiculos();

            vehiculos.VehiculoID = Convert.ToInt32(VehiculoIDnumericUpDown.Value);
            vehiculos.Descripcion = DescripciontextBox.Text;
            return vehiculos;
        }

        private bool HayErrores()
        {

            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyerrorProvider.SetError(DescripciontextBox,
                    "Debes digitar la descripcion del vehiculo");
                HayErrores = true;
            }
            return HayErrores;

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoIDnumericUpDown.Value);

            Vehiculos vehiculos = BLL.VehiculosBLL.Buscar(id);

            if (vehiculos != null)
            {
                DescripciontextBox.Text = vehiculos.Descripcion;
                TotalMantenimientotextBox.Text = vehiculos.TotalMantenimiento.ToString();
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            VehiculoIDnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            TotalMantenimientotextBox.Clear();
            MyerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Vehiculos vehiculos;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vehiculos = LlenaClase();

            if (VehiculoIDnumericUpDown.Value == 0)
                Paso = BLL.VehiculosBLL.Guardar(vehiculos);
            else
                Paso = BLL.VehiculosBLL.Modificar(LlenaClase());

            if (Paso)
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoIDnumericUpDown.Value);

            if (BLL.VehiculosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
