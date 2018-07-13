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
    public partial class ConsultaMantenimiento : Form
    {
        public ConsultaMantenimiento()
        {
            InitializeComponent();
        }

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscatbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Mantenimiento, bool>> filtro = a => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Artículo.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = a => a.MantenimientoID == id;
                    break;
                case 1://Filtrando por la Fecha de mantenimiento.
                    filtro = a => a.Fecha >= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value;
                    break;
                case 2://Filtrando por la Fecha proxima de mantenimiento.
                    filtro = a => a.ProximoMantenimiento >= DesdedateTimePicker.Value && a.ProximoMantenimiento <= HastadateTimePicker.Value;
                    break;
            }

            ConsultadataGridView.DataSource = BLL.MantenimientosBLL.GetList(filtro);
            ConsultadataGridView.Columns[6].Visible = false;
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

        private void ConsultaMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           if( ConsultadataGridView.SelectedRows!=null)
            {
                int mantenimientoId =int.Parse( ConsultadataGridView.SelectedRows[0].Cells[0].Value.ToString());
                
                new VerDetalleMantenimiento(mantenimientoId).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos selecionado, favor Seleccione una fila ante de continuar.");
            }

        }

        private void ConsultadataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            if (ConsultadataGridView.DataSource==null)
            {
                Verbutton.Enabled = false;
            }
            else
            {
                Verbutton.Enabled = true;
            }

        }
    }
}
