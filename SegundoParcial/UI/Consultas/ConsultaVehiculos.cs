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

        private void Llenar()
        {

            FiltrocomboBox.Items.Insert(0, "ID");
            FiltrocomboBox.Items.Insert(1, "Descripcion");
            FiltrocomboBox.Items.Insert(2, "TotalMantenimiento");
            FiltrocomboBox.Items.Insert(3, "Todo");

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
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.TotalMantenimiento == id;
                    break;
                case 3: // Filtrando por todo
                    Expression<Func<Vehiculos, bool>> filtro2 = a => true;
                    break;
            }

            ConsultadataGridView.DataSource = BLL.VehiculosBLL.GetList(filtro);
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrocomboBox.SelectedIndex == 3)
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

        private void ConsultaVehiculos_Load(object sender, EventArgs e)
        {
            Llenar();
        }
    }
}
