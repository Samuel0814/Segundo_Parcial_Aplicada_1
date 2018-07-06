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
    public partial class ConsultaArticulos : Form
    {
        public ConsultaArticulos()
        {
            InitializeComponent();
        }

        private void ConsultadataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ConsultaArticulos_Load(object sender, EventArgs e)
        {

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

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscatbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = a => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Artículo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.ArticulosId == id;
                    break;
                case 1://Filtrando por el % de ganancia del Artículo.
                    filtro = a => a.PorcientoGanancia.Equals(CriteriotextBox.Text);
                    break;
                case 2://Filtrando por Descripcion del Artículo.
                    filtro = a => a.Descripcion.Contains(CriteriotextBox.Text);
                    break;
                case 3://Filtrando por Precio del Artículo.
                    filtro = a => a.Precio.Equals(CriteriotextBox.Text);
                    break;
                case 4://Filtrando por el Inventario del Artículo.
                    filtro = a => a.Inventario.Equals(CriteriotextBox.Text);
                    break;
                case 5://Filtrando por el Costo del Artículo.
                    filtro = a => a.Costo.Equals(CriteriotextBox.Text);
                    break;
            }

            ConsultadataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);
        }
    }
}
