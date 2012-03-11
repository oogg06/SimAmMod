namespace Digitalizador
{
    partial class FormularioPrincipal
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCurvaAnalogica = new System.Windows.Forms.Panel();
            this.panelCurvaDigital = new System.Windows.Forms.Panel();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.spnBitsMuestreo = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnBitsMuestreo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelCurvaAnalogica, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelCurvaDigital, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblInformacion, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.spnBitsMuestreo, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(810, 97);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(48, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "Generar curva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelCurvaAnalogica
            // 
            this.panelCurvaAnalogica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCurvaAnalogica.Location = new System.Drawing.Point(3, 106);
            this.panelCurvaAnalogica.Name = "panelCurvaAnalogica";
            this.panelCurvaAnalogica.Size = new System.Drawing.Size(810, 200);
            this.panelCurvaAnalogica.TabIndex = 2;
            // 
            // panelCurvaDigital
            // 
            this.panelCurvaDigital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCurvaDigital.Location = new System.Drawing.Point(3, 312);
            this.panelCurvaDigital.Name = "panelCurvaDigital";
            this.panelCurvaDigital.Size = new System.Drawing.Size(810, 201);
            this.panelCurvaDigital.TabIndex = 3;
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Location = new System.Drawing.Point(378, 37);
            this.lblInformacion.Margin = new System.Windows.Forms.Padding(0, 22, 22, 22);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(35, 13);
            this.lblInformacion.TabIndex = 15;
            this.lblInformacion.Text = "label1";
            // 
            // spnBitsMuestreo
            // 
            this.spnBitsMuestreo.Location = new System.Drawing.Point(193, 37);
            this.spnBitsMuestreo.Margin = new System.Windows.Forms.Padding(22);
            this.spnBitsMuestreo.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.spnBitsMuestreo.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spnBitsMuestreo.Name = "spnBitsMuestreo";
            this.spnBitsMuestreo.Size = new System.Drawing.Size(120, 20);
            this.spnBitsMuestreo.TabIndex = 16;
            this.spnBitsMuestreo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spnBitsMuestreo.ValueChanged += new System.EventHandler(this.spnBitsMuestreo_ValueChanged);
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "FormularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitalización de señales";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormularioPrincipal_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnBitsMuestreo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCurvaDigital;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelCurvaAnalogica;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.NumericUpDown spnBitsMuestreo;

    }
}