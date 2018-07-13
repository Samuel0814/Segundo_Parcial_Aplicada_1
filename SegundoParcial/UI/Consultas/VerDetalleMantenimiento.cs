using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SegundoParcial.Entidades;
using SegundoParcial.DAL;

namespace SegundoParcial.UI.Consultas
{
    public partial class VerDetalleMantenimiento : Form
    {
        
        public VerDetalleMantenimiento(int id  )
        {
            InitializeComponent();
            Contexto db = new Contexto();
            var tmp = from mantenimeinto in db.Mantenimientos
                      where mantenimeinto.MantenimientoID == id
                      select mantenimeinto;
            dataGridView1.DataSource = tmp.First().Detalle ;
            dataGridView1.Columns[6].Visible = false;
        }

        private void VerDetalleMantenimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
