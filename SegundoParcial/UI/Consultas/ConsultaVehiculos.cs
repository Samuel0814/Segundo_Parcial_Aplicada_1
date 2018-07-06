using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial.UI.Consultas
{
    public partial class ConsultaVehiculos : Form
    {
        public ConsultaVehiculos()
        {
            InitializeComponent();
        }

        private void Buscatbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Vehiculos, bool>> filtro = a => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del vehiculo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.VehiculoID == id;
                    break;
                case 1://Filtrando por Descripcion del vehiculo.
                    filtro = a => a.Descripcion.Contains(CriteriotextBox.Text);
                    break;
                case 2://Filtrando por Total Mantenimiento del Vehiculo.
                    filtro = a => a.TotalMantenimiento.Equals(CriteriotextBox.Text);
                    break;
            }

            ConsultadataGridView.DataSource = BLL.VehiculosBLL.GetList(filtro);
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrocomboBox.SelectedIndex == 1)
            {
                CriteriotextBox.Visible = false;
                Criteriolabel.Visible = false;
            }
            else
            {
                CriteriotextBox.Visible = true;
                Criteriolabel.Visible = true;
            }
        }
    }
}
