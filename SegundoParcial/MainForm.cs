using SegundoParcial.UI.Consultas;
using SegundoParcial.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void registroDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroArticulos r = new RegistroArticulos();
            r.Show();
        }

        private void entradaDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroEntradaArticulos r = new RegistroEntradaArticulos();
            r.Show();
        }

        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroMantenimiento r = new RegistroMantenimiento();
            r.Show();
        }

        private void talleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroTalleres r = new RegistroTalleres();
            r.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroVehiculos r = new RegistroVehiculos();
            r.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaArticulos c = new ConsultaArticulos();
            c.Show();
        }

        private void entradaDeArticulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaEntradaArticulos c = new ConsultaEntradaArticulos();
            c.Show();
        }

        private void mantenimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaMantenimiento c = new ConsultaMantenimiento();
            c.Show();
        }

        private void mantenimientosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ConsultaTalleres c = new ConsultaTalleres();
            c.Show();
        }

        private void vehiculosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaVehiculos c = new ConsultaVehiculos();
            c.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir de la aplicacion?",
                       "Consulta",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true; //Cancela el cerrado del formulario
            }
        }
    }
}
