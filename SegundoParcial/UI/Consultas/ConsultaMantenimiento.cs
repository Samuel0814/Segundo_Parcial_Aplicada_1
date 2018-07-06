﻿using SegundoParcial.Entidades;
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
    }
}
