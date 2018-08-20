namespace CeictHuella
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerIngresos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "CEICT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnVerIngresos
            // 
            this.btnVerIngresos.BackColor = System.Drawing.Color.Green;
            this.btnVerIngresos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerIngresos.Location = new System.Drawing.Point(442, 198);
            this.btnVerIngresos.Name = "btnVerIngresos";
            this.btnVerIngresos.Size = new System.Drawing.Size(161, 49);
            this.btnVerIngresos.TabIndex = 1;
            this.btnVerIngresos.Text = "Ver Ingresos";
            this.btnVerIngresos.UseVisualStyleBackColor = false;
            this.btnVerIngresos.Click += new System.EventHandler(this.btnVerIngresos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.ForeColor = System.Drawing.Color.Azure;
            this.button1.Location = new System.Drawing.Point(77, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crear Usuario";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerIngresos);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "CEICT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerIngresos;
        private System.Windows.Forms.Button button1;
    }
}

