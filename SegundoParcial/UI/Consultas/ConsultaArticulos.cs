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

        private void Llenar()
        {
            FiltrocomboBox.Items.Insert(0, "ID");
            FiltrocomboBox.Items.Insert(1, "Ganancia");
            FiltrocomboBox.Items.Insert(2, "Nombre Articulo");
            FiltrocomboBox.Items.Insert(3, "Precio");
            FiltrocomboBox.Items.Insert(4, "Inventario:");
            FiltrocomboBox.Items.Insert(5, "Costo");
            FiltrocomboBox.Items.Insert(6, "Todo");
        }

        private void ConsultadataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ConsultaArticulos_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrocomboBox.SelectedIndex == 6)
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
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.PorcientoGanancia == id;
                    break;
                case 2://Filtrando por Descripcion del Artículo.
                    filtro = a => a.Descripcion.Contains(CriteriotextBox.Text);
                    break;
                case 3://Filtrando por Precio del Artículo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.Precio == id;
                    break;
                case 4://Filtrando por el Inventario del Artículo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.Inventario== id ;
                    break;
                case 5://Filtrando por el Costo del Artículo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.Costo == id;
                    break;
                case 6: //filtrando todos
                    Expression<Func<Articulos, bool>> filtro2 = a => true;
                    break;
            }

            ConsultadataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);
        }
    }
}
