
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
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCaptadores);
            this.Controls.Add(this.cbNomeCaptadores);
            this.Name = "FrmRelatorio";
            this.Text = "FrmRelatorio";
            this.Load += new System.EventHandler(this.FrmRelatorio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNomeCaptadores;
        private System.Windows.Forms.Label lblCaptadores;
    }
}