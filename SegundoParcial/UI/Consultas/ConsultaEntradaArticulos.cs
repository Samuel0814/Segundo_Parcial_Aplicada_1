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
    public partial class ConsultaEntradaArticulos : Form
    {
        public ConsultaEntradaArticulos()
        {
            InitializeComponent();
        }

        private void Buscatbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<EntradaArticulos, bool>> filtro = a => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Filtrando por ID de la Entrada.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.EntradaID == id;
                    break;
                case 1://Filtrando por la Fecha de Entrada.
                    filtro = a => a.Fecha >= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value;
                    break;
                case 2://Filtrando por Cantidad  de Entrada.
                    filtro = a => a.CantidadArticulo.Equals(CriteriotextBox.Text) && a.Fecha >= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value;
                    break;
            }

            ConsultadataGridView.DataSource = BLL.EntradaArticulosBLL.GetList(filtro);
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

        private void ConsultaEntradaArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
