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
            //DataTable table = new DataTable();
            //table.Columns.Add("Articulo");
            //table.Columns.Add("Cantidad");
            //table.Columns.Add("Precio");
            //table.Columns.Add("Importe");
            //foreach (var item in mantenimiento.Detalle)
            //{
            //    object[] tmp= new object[4];
            //    tmp[0] = item.Articulos.Descripcion;
            //    tmp[1] = item.Cantidad;
            //    tmp[2] = item.Precio;
            //    tmp[3] = item.Importe;
            //    table.Rows.Add(tmp);
            //}


            DetalledataGridView.DataSource = mantenimiento.Detalle.ToList();
            int c = 0;
            foreach (var item in DetalledataGridView.Columns)
            {
                c++;

            }
            for (int i = 0; i < c; i++)
            {
                if (i > 8)
                {
                    DetalledataGridView.Columns[i].Visible = false;
                }
            }





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
            mantenimiento.Total =Convert.ToSingle( TotalnumericUpDown.Value);
            mantenimiento.SubTotal = Convert.ToSingle(SubTotalnumericUpDown.Value);
            mantenimiento.Itbis = Convert.ToSingle(ItbisnumericUpDown.Value);
            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["ID"].Value),
                    ToInt(item.Cells["MantenimientoId"].Value),
                    ToInt(item.Cells["VehiculosId"].Value),
                    ToInt(item.Cells["TalleresId"].Value),
                    ToInt(item.Cells["ArticulosID"].Value), "NombreArticulo",
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
                Vehiculos v = (Vehiculos)VehiculocomboBox.SelectedItem;
                v.TotalMantenimiento += (int)TotalnumericUpDown.Value;
                BLL.VehiculosBLL.Modificar(v);

            }
            else
            {
                Paso = BLL.MantenimientosBLL.Modificar(mantenimientos);
                Vehiculos v = (Vehiculos)VehiculocomboBox.SelectedItem;

                if (TotalnumericUpDown.Value <= TotalnumericUpDown.Value)
                {
                    v.TotalMantenimiento += (int)TotalnumericUpDown.Value;
                }
                else
                {
                    v.TotalMantenimiento -= (int)TotalnumericUpDown.Value;
                }
                BLL.VehiculosBLL.Modificar(v);
                ModificarCantidadInventario(mantenimientos);
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

        private void ModificarCantidadInventario(Mantenimiento mantenimiento)
        { 

            Contexto db = new Contexto();
            float  sum = 0;
            int sumTotal = 0;
            var detalles = mantenimiento.Detalle.ToList();
            
            foreach (var item in detalles)
            {
                sum += item.Cantidad;
                sumTotal+=Convert.ToInt32( item.Importe);

            }
            db.articulos.Find(detalles.First().ArticulosID).Inventario -= sum;
            db.Vehiculos.Find(detalles.First().VehiculosId).TotalMantenimiento = int.Parse(sumTotal.ToString());
            db.SaveChanges();

        }

        private void Eliminarbutton_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdnumericUpDown.Value);

            if (BLL.MantenimientosBLL.Eliminar(id))
            {
                Vehiculos a = (Vehiculos)VehiculocomboBox.SelectedItem;
                a.TotalMantenimiento -= (int)TotalnumericUpDown.Value;
                BLL.VehiculosBLL.Modificar(a);
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Contexto db = new Contexto();
            var articulo = db.articulos.Find(ArticulocomboBox.SelectedValue);

            if (CantidadnumericUpDown.Value>decimal.Parse(articulo.Inventario.ToString()))
            {
                MessageBox.Show("la cantidad no debe exceder el inventario.");
                CantidadnumericUpDown.Value = 0;
            }
            else
            {
                MostrarPrecio();
            if (CantidadnumericUpDown.Value != 0)
            {
                ImportenumericUpDown.Value = CantidadnumericUpDown.Value * PrecionumericUpDown.Value;
            }

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
        