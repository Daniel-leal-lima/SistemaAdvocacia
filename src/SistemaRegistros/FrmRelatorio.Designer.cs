
namespace SistemaRegistros
{
    partial class FrmRelatorio
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
            this.cbNomeCaptadores = new System.Windows.Forms.ComboBox();
            this.lblCaptadores = new System.Windows.Forms.Label();
            this.btnGeraRelatorio = new System.Windows.Forms.Button();
            this.DtpData = new System.Windows.Forms.DateTimePicker();
            this.lblMesEAno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbNomeCaptadores
            // 
            this.cbNomeCaptadores.FormattingEnabled = true;
            this.cbNomeCaptadores.Location = new System.Drawing.Point(121, 27);
            this.cbNomeCaptadores.Name = "cbNomeCaptadores";
            this.cbNomeCaptadores.Size = new System.Drawing.Size(223, 23);
            this.cbNomeCaptadores.TabIndex = 0;
            // 
            // lblCaptadores
            // 
            this.lblCaptadores.AutoSize = true;
            this.lblCaptadores.Location = new System.Drawing.Point(45, 30);
            this.lblCaptadores.Name = "lblCaptadores";
            this.lblCaptadores.Size = new System.Drawing.Size(70, 15);
            this.lblCaptadores.TabIndex = 1;
            this.lblCaptadores.Text = "Captadores:";
            // 
            // btnGeraRelatorio
            // 
            this.btnGeraRelatorio.Location = new System.Drawing.Point(410, 27);
            this.btnGeraRelatorio.Name = "btnGeraRelatorio";
            this.btnGeraRelatorio.Size = new System.Drawing.Size(94, 45);
            this.btnGeraRelatorio.TabIndex = 2;
            this.btnGeraRelatorio.Text = "Gerar Relatorio";
            this.btnGeraRelatorio.UseVisualStyleBackColor = true;
            this.btnGeraRelatorio.Click += new System.EventHandler(this.btnGeraRelatorio_Click);
            // 
            // DtpData
            // 
            this.DtpData.CustomFormat = "MM/yyyy";
            this.DtpData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpData.Location = new System.Drawing.Point(119, 88);
            this.DtpData.Name = "DtpData";
            this.DtpData.Size = new System.Drawing.Size(70, 23);
            this.DtpData.TabIndex = 3;
            // 
            // lblMesEAno
            // 
            this.lblMesEAno.AutoSize = true;
            this.lblMesEAno.Location = new System.Drawing.Point(82, 91);
            this.lblMesEAno.Name = "lblMesEAno";
            this.lblMesEAno.Size = new System.Drawing.Size(32, 15);
            this.lblMesEAno.TabIndex = 4;
            this.lblMesEAno.Text = "Mês:";
            // 
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 123);
            this.Controls.Add(this.lblMesEAno);
            this.Controls.Add(this.DtpData);
            this.Controls.Add(this.btnGeraRelatorio);
            this.Controls.Add(this.lblCaptadores);
            this.Controls.Add(this.cbNomeCaptadores);
            this.Name = "FrmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelatorio";
            this.Load += new System.EventHandler(this.FrmRelatorio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNomeCaptadores;
        private System.Windows.Forms.Label lblCaptadores;
        private System.Windows.Forms.Button btnGeraRelatorio;
        private System.Windows.Forms.DateTimePicker DtpData;
        private System.Windows.Forms.Label lblMesEAno;
    }
}