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
    public partial class RegistroEntradaArticulos : Form
    {
        public RegistroEntradaArticulos()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void LlenaComboBox()
        {
            Repositorio<Articulos> ArtRepositorio = new Repositorio<Articulos>(new Contexto());

            ArticulocomboBox.DataSource = ArtRepositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticulosId";
            ArticulocomboBox.DisplayMember = "Descripcion";
       
        }

        private EntradaArticulos LlenaClase()
        {
            EntradaArticulos entrada = new EntradaArticulos();

            entrada.EntradaID = Convert.ToInt32(EntradaIdnumericUpDown.Value);
            entrada.Fecha = FechadateTimePicker.Value;
            entrada.NombreArticulo = ArticulocomboBox.Text;
            entrada.CantidadArticulo = Convert.ToInt32(CantidadnumericUpDown.Value);
            entrada.ArticulosId = Convert.ToInt32(ArticulocomboBox.SelectedValue);
            return entrada;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdnumericUpDown.Value);

            EntradaArticulos entrada = BLL.EntradaArticulosBLL.Buscar(id);

            if (entrada != null)
            {
                FechadateTimePicker.Value = entrada.Fecha;
                CantidadnumericUpDown.Value = entrada.CantidadArticulo;
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            EntradaIdnumericUpDown.Value = 0;
            ArticulocomboBox.SelectedIndex = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            MyerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            EntradaArticulos entrada;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entrada = LlenaClase();

            if (EntradaIdnumericUpDown.Value == 0)
            {
                Paso = BLL.EntradaArticulosBLL.Guardar(entrada);

                Articulos a = (Articulos)ArticulocomboBox.SelectedItem;
                a.Inventario += (float)CantidadnumericUpDown.Value;
                BLL.ArticulosBLL.Modificar(a);
                
            }
            else
            {
                Paso = BLL.EntradaArticulosBLL.Modificar(entrada);

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
                ModificarCantidadInvitario(a.ArticulosId);
            }

            if (Paso)
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ModificarCantidadInvitario(int articulosId)
        {
            Contexto db = new Contexto();
            int sum=0;
            /*usando linq 
             * es lo mismo que un select de sql 
             * ejemplo
             * select * from entradaaArticulo where ArticuloId= articuloid
              */
            var entradas = from cust in db.entradaArticulos
                           where cust.ArticulosId == articulosId
                           select cust;

            foreach (var item in entradas)
            {
                sum += item.CantidadArticulo;

            }

            db.articulos.Find(articulosId).Inventario = sum;
            db.SaveChanges();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdnumericUpDown.Value);

            if (BLL.EntradaArticulosBLL.Eliminar(id))
            {
                Articulos a = (Articulos)ArticulocomboBox.SelectedItem;
                a.Inventario -= (float)CantidadnumericUpDown.Value;
                BLL.ArticulosBLL.Modificar(a);
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (CantidadnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(EntradaIdnumericUpDown,
                    "Debes ingresar una cantidad mayor a 0");
                HayErrores = true;
            }

            return HayErrores;
        }

        private void RegistroEntradaArticulos_Load(object sender, EventArgs e)
        {

        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
