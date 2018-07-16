namespace SegundoParcial.UI.Registro
{
    partial class RegistroMantenimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MantenimientoIdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FechadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ProximoMantenimientodateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.VehiculocomboBox = new System.Windows.Forms.ComboBox();
            this.TallercomboBox = new System.Windows.Forms.ComboBox();
            this.ArticulocomboBox = new System.Windows.Forms.ComboBox();
            this.MyerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CantidadnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DetalledataGridView = new System.Windows.Forms.DataGridView();
            this.ImportenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PrecionumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ItbisnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SubTotalnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TotalnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Removerbutton = new System.Windows.Forms.Button();
            this.Agregarbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MantenimientoIdnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyerrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalledataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecionumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItbisnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotalnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "MantenimientoID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Fecha";
            // 
            // MantenimientoIdnumericUpDown
            // 
            this.MantenimientoIdnumericUpDown.Location = new System.Drawing.Point(117, 23);
            this.MantenimientoIdnumericUpDown.Name = "MantenimientoIdnumericUpDown";
            this.MantenimientoIdnumericUpDown.Size = new System.Drawing.Size(164, 20);
            this.MantenimientoIdnumericUpDown.TabIndex = 0;
            this.MantenimientoIdnumericUpDown.ValueChanged += new System.EventHandler(this.IdnumericUpDown_ValueChanged);
            // 
            // FechadateTimePicker
            // 
            this.FechadateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechadateTimePicker.Location = new System.Drawing.Point(70, 68);
            this.FechadateTimePicker.Name = "FechadateTimePicker";
            this.FechadateTimePicker.Size = new System.Drawing.Size(96, 20);
            this.FechadateTimePicker.TabIndex = 2;
            this.FechadateTimePicker.ValueChanged += new System.EventHandler(this.FechadateTimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Proximo Mantenimiento";
            // 
            // ProximoMantenimientodateTimePicker
            // 
            this.ProximoMantenimientodateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.ProximoMantenimientodateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ProximoMantenimientodateTimePicker.Location = new System.Drawing.Point(315, 68);
            this.ProximoMantenimientodateTimePicker.Name = "ProximoMantenimientodateTimePicker";
            this.ProximoMantenimientodateTimePicker.Size = new System.Drawing.Size(111, 20);
            this.ProximoMantenimientodateTimePicker.TabIndex = 3;
            this.ProximoMantenimientodateTimePicker.ValueChanged += new System.EventHandler(this.ProximoMantenimientodateTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Vehiculo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Taller";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Articulo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Cantidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Precio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Importe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(324, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(302, 449);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "ITBIS 18%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(302, 423);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Sub-Total";
            // 
            // VehiculocomboBox
            // 
            this.VehiculocomboBox.FormattingEnabled = true;
            this.VehiculocomboBox.Location = new System.Drawing.Point(70, 103);
            this.VehiculocomboBox.Name = "VehiculocomboBox";
            this.VehiculocomboBox.Size = new System.Drawing.Size(356, 21);
            this.VehiculocomboBox.TabIndex = 4;
            // 
            // TallercomboBox
            // 
            this.TallercomboBox.FormattingEnabled = true;
            this.TallercomboBox.Location = new System.Drawing.Point(70, 137);
            this.TallercomboBox.Name = "TallercomboBox";
            this.TallercomboBox.Size = new System.Drawing.Size(356, 21);
            this.TallercomboBox.TabIndex = 5;
            // 
            // ArticulocomboBox
            // 
            this.ArticulocomboBox.FormattingEnabled = true;
            this.ArticulocomboBox.Location = new System.Drawing.Point(70, 179);
            this.ArticulocomboBox.Name = "ArticulocomboBox";
            this.ArticulocomboBox.Size = new System.Drawing.Size(245, 21);
            this.ArticulocomboBox.TabIndex = 6;
            this.ArticulocomboBox.SelectedIndexChanged += new System.EventHandler(this.ArticulocomboBox_SelectedIndexChanged);
            // 
            // MyerrorProvider
            // 
            this.MyerrorProvider.ContainerControl = this;
            // 
            // CantidadnumericUpDown
            // 
            this.CantidadnumericUpDown.Location = new System.Drawing.Point(15, 225);
            this.CantidadnumericUpDown.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.CantidadnumericUpDown.Name = "CantidadnumericUpDown";
            this.CantidadnumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.CantidadnumericUpDown.TabIndex = 7;
            this.CantidadnumericUpDown.ValueChanged += new System.EventHandler(this.CantidadnumericUpDown_ValueChanged);
            // 
            // DetalledataGridView
            // 
            this.DetalledataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetalledataGridView.Location = new System.Drawing.Point(15, 262);
            this.DetalledataGridView.Name = "DetalledataGridView";
            this.DetalledataGridView.Size = new System.Drawing.Size(450, 139);
            this.DetalledataGridView.TabIndex = 21;
            // 
            // ImportenumericUpDown
            // 
            this.ImportenumericUpDown.Location = new System.Drawing.Point(219, 225);
            this.ImportenumericUpDown.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.ImportenumericUpDown.Name = "ImportenumericUpDown";
            this.ImportenumericUpDown.ReadOnly = true;
            this.ImportenumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.ImportenumericUpDown.TabIndex = 9;
            // 
            // PrecionumericUpDown
            // 
            this.PrecionumericUpDown.Location = new System.Drawing.Point(117, 225);
            this.PrecionumericUpDown.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.PrecionumericUpDown.Name = "PrecionumericUpDown";
            this.PrecionumericUpDown.ReadOnly = true;
            this.PrecionumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.PrecionumericUpDown.TabIndex = 8;
            // 
            // ItbisnumericUpDown
            // 
            this.ItbisnumericUpDown.Location = new System.Drawing.Point(369, 449);
            this.ItbisnumericUpDown.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.ItbisnumericUpDown.Name = "ItbisnumericUpDown";
            this.ItbisnumericUpDown.ReadOnly = true;
            this.ItbisnumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.ItbisnumericUpDown.TabIndex = 19;
            // 
            // SubTotalnumericUpDown
            // 
            this.SubTotalnumericUpDown.Location = new System.Drawing.Point(369, 423);
            this.SubTotalnumericUpDown.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.SubTotalnumericUpDown.Name = "SubTotalnumericUpDown";
            this.SubTotalnumericUpDown.ReadOnly = true;
            this.SubTotalnumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.SubTotalnumericUpDown.TabIndex = 18;
            // 
            // TotalnumericUpDown
            // 
            this.TotalnumericUpDown.Location = new System.Drawing.Point(369, 475);
            this.TotalnumericUpDown.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.TotalnumericUpDown.Name = "TotalnumericUpDown";
            this.TotalnumericUpDown.ReadOnly = true;
            this.TotalnumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.TotalnumericUpDown.TabIndex = 20;
            this.TotalnumericUpDown.ValueChanged += new System.EventHandler(this.TotalnumericUpDown_ValueChanged);
            // 
            // Removerbutton
            // 
            this.Removerbutton.Image = global::SegundoParcial.Properties.Resources.icons8_Delete_32;
            this.Removerbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Removerbutton.Location = new System.Drawing.Point(341, 221);
            this.Removerbutton.Name = "Removerbutton";
            this.Removerbutton.Size = new System.Drawing.Size(85, 35);
            this.Removerbutton.TabIndex = 11;
            this.Removerbutton.Text = "Remover";
            this.Removerbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Removerbutton.UseVisualStyleBackColor = true;
            this.Removerbutton.Click += new System.EventHandler(this.Removerbutton_Click);
            // 
            // Agregarbutton
            // 
            this.Agregarbutton.Image = global::SegundoParcial.Properties.Resources.icons8_Add_New_32;
            this.Agregarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Agregarbutton.Location = new System.Drawing.Point(341, 177);
            this.Agregarbutton.Name = "Agregarbutton";
            this.Agregarbutton.Size = new System.Drawing.Size(85, 38);
            this.Agregarbutton.TabIndex = 10;
            this.Agregarbutton.Text = "Agregar";
            this.Agregarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Agregarbutton.UseVisualStyleBackColor = true;
            this.Agregarbutton.Click += new System.EventHandler(this.Agregarbutton_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::SegundoParcial.Properties.Resources.icons8_Delete_File_32;
            this.Eliminarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Eliminarbutton.Location = new System.Drawing.Point(183, 459);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(87, 48);
            this.Eliminarbutton.TabIndex = 14;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click_1);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::SegundoParcial.Properties.Resources.icons8_Save_All_32;
            this.Guardarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Guardarbutton.Location = new System.Drawing.Point(90, 459);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(87, 48);
            this.Guardarbutton.TabIndex = 13;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::SegundoParcial.Properties.Resources.icons8_Create_32;
            this.Nuevobutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Nuevobutton.Location = new System.Drawing.Point(12, 459);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(72, 48);
            this.Nuevobutton.TabIndex = 12;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::SegundoParcial.Properties.Resources.icons8_Search_Property_32;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(341, 9);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(85, 45);
            this.Buscarbutton.TabIndex = 1;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // RegistroMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 515);
            this.Controls.Add(this.TotalnumericUpDown);
            this.Controls.Add(this.SubTotalnumericUpDown);
            this.Controls.Add(this.ItbisnumericUpDown);
            this.Controls.Add(this.PrecionumericUpDown);
            this.Controls.Add(this.ImportenumericUpDown);
            this.Controls.Add(this.DetalledataGridView);
            this.Controls.Add(this.CantidadnumericUpDown);
            this.Controls.Add(this.ArticulocomboBox);
            this.Controls.Add(this.TallercomboBox);
            this.Controls.Add(this.VehiculocomboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Removerbutton);
            this.Controls.Add(this.Agregarbutton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProximoMantenimientodateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FechadateTimePicker);
            this.Controls.Add(this.MantenimientoIdnumericUpDown);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistroMantenimiento";
            this.Text = "Registro de Mantenimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistroMantenimiento_FormClosing);
            this.Load += new System.EventHandler(this.RegistroMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MantenimientoIdnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyerrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalledataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecionumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItbisnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotalnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.NumericUpDown MantenimientoIdnumericUpDown;
        private System.Windows.Forms.DateTimePicker FechadateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ProximoMantenimientodateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Agregarbutton;
        private System.Windows.Forms.Button Removerbutton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox VehiculocomboBox;
        private System.Windows.Forms.ComboBox TallercomboBox;
        private System.Windows.Forms.ComboBox ArticulocomboBox;
        private System.Windows.Forms.ErrorProvider MyerrorProvider;
        private System.Windows.Forms.NumericUpDown CantidadnumericUpDown;
        private System.Windows.Forms.DataGridView DetalledataGridView;
        private System.Windows.Forms.NumericUpDown TotalnumericUpDown;
        private System.Windows.Forms.NumericUpDown SubTotalnumericUpDown;
        private System.Windows.Forms.NumericUpDown ItbisnumericUpDown;
        private System.Windows.Forms.NumericUpDown PrecionumericUpDown;
        private System.Windows.Forms.NumericUpDown ImportenumericUpDown;
    }
}