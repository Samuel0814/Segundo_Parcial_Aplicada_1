using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial.UI.Registro
{
    public partial class RegistroMantenimiento : Form
    {


        public RegistroMantenimiento()
        {
            InitializeComponent();
            LlenarComboBox();
            Fecha();
        }

        private void Fecha ()
        {
            ProximoMantenimientodateTimePicker.Value = FechadateTimePicker.Value.AddMonths(3);
        }

        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            MantenimientoIdnumericUpDown.Value = mantenimiento.MantenimientoID;
            FechadateTimePicker.Value = mantenimiento.Fecha;
            ProximoMantenimientodateTimePicker.Value = mantenimiento.ProximoMantenimiento;
            SubTotalnumericUpDown.Value = Convert.ToInt32(mantenimiento.SubTotal);
            ItbisnumericUpDown.Value = Convert.ToInt32(mantenimiento.Itbis);
            TotalnumericUpDown.Value = Convert.ToInt32(mantenimiento.Total);

            DetalledataGridView.DataSource = mantenimiento.Detalle;

           
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }



        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoID = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);
            mantenimiento.Fecha = FechadateTimePicker.Value;
            mantenimiento.ProximoMantenimiento = ProximoMantenimientodateTimePicker.Value;

            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["id"].Value),
                    ToInt(item.Cells["mantenimientoId"].Value),
                    ToInt(item.Cells["vehiculoId"].Value),
                    ToInt(item.Cells["talleresId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value), "NombreArticulo",
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                );
            }

            

            return mantenimiento;
        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> ArticuloRepositorio = new Repositorio<Articulos>(new Contexto());
            Repositorio<Talleres> TallerRepositorio = new Repositorio<Talleres>(new Contexto());
            Repositorio<Vehiculos> VehiculoRepositorio = new Repositorio<Vehiculos>(new Contexto());

            ArticulocomboBox.DataSource = ArticuloRepositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticulosID";
            ArticulocomboBox.DisplayMember = "Descripcion";

            VehiculocomboBox.DataSource = VehiculoRepositorio.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoID";
            VehiculocomboBox.DisplayMember = "Descripcion";

            TallercomboBox.DataSource = TallerRepositorio.GetList(c => true);
            TallercomboBox.ValueMember = "TalleresId";
            TallercomboBox.DisplayMember = "Nombre";
        }

        private void MostrarPrecio()
        {
            List<Articulos> lArticulos = BLL.ArticulosBLL.GetList(c => c.Descripcion == ArticulocomboBox.Text);
            foreach (var item in lArticulos)
            {
                PrecionumericUpDown.Text = item.Precio.ToString();
            }
        }

        private void Total()
        {
            List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)DetalledataGridView.DataSource;

            float Total = 0;

            decimal IteB;

            IteB = 0.18M;

            foreach (var item in detalle)
            {
                Total += item.Importe;
            }
            TotalnumericUpDown.Text = Total.ToString();

            ItbisnumericUpDown.Value = TotalnumericUpDown.Value * IteB;

            SubTotalnumericUpDown.Value = TotalnumericUpDown.Value - ItbisnumericUpDown.Value;


        }

        private void RestandoTotal()
        {
            List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)DetalledataGridView.DataSource;

            float Total = 0;
            decimal IteB;

            IteB = 0.18M;


            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }

            Total *= (-1);

            TotalnumericUpDown.Text = Total.ToString();

            ItbisnumericUpDown.Value = TotalnumericUpDown.Value * IteB;

            SubTotalnumericUpDown.Value = TotalnumericUpDown.Value - ItbisnumericUpDown.Value;

        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (DetalledataGridView.RowCount == 0)
            {
                MyerrorProvider.SetError(DetalledataGridView,
                    "Es obligatorio seleccionar los articulos ");
                HayErrores = true;
            }

            if (CantidadnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(CantidadnumericUpDown,
                    "Digite una cantidad");
                HayErrores = true;
            }

            return HayErrores;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);
            Mantenimiento mantenimiento = BLL.MantenimientosBLL.Buscar(id);

            if (mantenimiento != null)
            {
                LlenarCampos(mantenimiento);
            }
            else
                MessageBox.Show("No encontrado!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RegistroMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)DetalledataGridView.DataSource;
            }

            detalle.Add(
                new MantenimientoDetalle(
                    id: 0,
                    mantenimientoId: (int)MantenimientoIdnumericUpDown.Value,
                    ArticuloId: (int)ArticulocomboBox.SelectedValue,
                    talleresId: (int)TallercomboBox.SelectedValue,
                    vehiculoId: (int)VehiculocomboBox.SelectedValue,
                    nombreArticulo: ArticulocomboBox.Text,
                    cantidad: (float)Convert.ToInt32(CantidadnumericUpDown.Value),
                    precio: (float)Convert.ToInt32(PrecionumericUpDown.Text),
                    importe: (float)Convert.ToInt32(ImportenumericUpDown.Text)
                ));

            
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = detalle;

            


            Total();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {

                List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)DetalledataGridView.DataSource;


                detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);


                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = detalle;

                RestandoTotal();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            MantenimientoIdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            PrecionumericUpDown.Value = 0;
            ImportenumericUpDown.Value = 0; ;
            TotalnumericUpDown.Value = 0;
            DetalledataGridView.DataSource = null;
            SubTotalnumericUpDown.Value = 0;
            ItbisnumericUpDown.Value = 0;
            MyerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimientos;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            mantenimientos = LlenaClase();

            if (MantenimientoIdnumericUpDown.Value == 0)
            {

                Paso = BLL.MantenimientosBLL.Guardar(mantenimientos);
                Vehiculos a = (Vehiculos)VehiculocomboBox.SelectedItem;
                a.TotalMantenimiento += (int)TotalnumericUpDown.Value;
                BLL.VehiculosBLL.Modificar(a);

            }
            else
            {
                Paso = BLL.MantenimientosBLL.Modificar(mantenimientos);
                Articulos a = (Articulos)ArticulocomboBox.SelectedItem;

                if (CantidadnumericUpDown.Value <= CantidadnumericUpDown.Value)
                {
                    a.Inventario += (float)CantidadnumericUpDown.Value;
                }
                else
                {
                    a.Inventario -= (float)CantidadnumericUpDown.Value;
                }
                BLL.ArticulosBLL.Modificar(a);
            }

            if (Paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);

            if (BLL.MantenimientosBLL.Eliminar(id))
            {
                Vehiculos a = (Vehiculos)VehiculocomboBox.SelectedItem;
                a.TotalMantenimiento += (int)TotalnumericUpDown.Value;
                BLL.VehiculosBLL.Modificar(a);
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            MostrarPrecio();
            if (CantidadnumericUpDown.Value != 0)
            {
                ImportenumericUpDown.Value = CantidadnumericUpDown.Value * PrecionumericUpDown.Value;
            }
        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarPrecio();
        }


        private void ProximoMantenimientodateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FechadateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Fecha();
        }

        private void IdnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void TotalnumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
        