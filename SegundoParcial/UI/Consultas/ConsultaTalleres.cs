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
    public partial class ConsultaTalleres : Form
    {
        public ConsultaTalleres()
        {
            InitializeComponent();
        }

        private void Buscatbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Talleres, bool>> filtro = a => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Artículo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.TalleresID == id;
                    break;
                
                case 2://Filtrando por Descripcion del Artículo.
                    filtro = a => a.Nombre.Contains(CriteriotextBox.Text);
                    break;
            }

            ConsultadataGridView.DataSource = BLL.TalleresBLL.GetList(filtro);
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
