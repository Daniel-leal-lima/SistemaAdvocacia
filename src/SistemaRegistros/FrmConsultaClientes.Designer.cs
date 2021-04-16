
namespace SistemaRegistros
{
    partial class FrmConsultaClientes
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
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.cbFiltros = new System.Windows.Forms.ComboBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.brncadastrar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(44, 38);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(454, 23);
            this.txtPesquisa.TabIndex = 0;
            // 
            // cbFiltros
            // 
            this.cbFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltros.FormattingEnabled = true;
            this.cbFiltros.Items.AddRange(new object[] {
            "Nome",
            "CPF",
            "Telefone",
            "Nº Processo"});
            this.cbFiltros.Location = new System.Drawing.Point(111, 9);
            this.cbFiltros.Name = "cbFiltros";
            this.cbFiltros.Size = new System.Drawing.Size(107, 23);
            this.cbFiltros.TabIndex = 1;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(44, 75);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowTemplate.Height = 25;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(480, 312);
            this.dgvClientes.TabIndex = 2;
            // 
            // brncadastrar
            // 
            this.brncadastrar.Location = new System.Drawing.Point(86, 407);
            this.brncadastrar.Name = "brncadastrar";
            this.brncadastrar.Size = new System.Drawing.Size(121, 82);
            this.brncadastrar.TabIndex = 3;
            this.brncadastrar.Text = "Cadastrar";
            this.brncadastrar.UseVisualStyleBackColor = true;
            this.brncadastrar.Click += new System.EventHandler(this.brncadastrar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(377, 407);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(121, 82);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(234, 407);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(121, 82);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(504, 36);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(68, 25);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(44, 12);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(61, 15);
            this.lblFiltrar.TabIndex = 7;
            this.lblFiltrar.Text = "Filtrar por:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(530, 193);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 56);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Atualizar lista";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Location = new System.Drawing.Point(517, 393);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(76, 65);
            this.btnContratos.TabIndex = 9;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Visible = false;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // FrmConsultaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 508);
            this.Controls.Add(this.btnContratos);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.brncadastrar);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.cbFiltros);
            this.Controls.Add(this.txtPesquisa);
            this.MaximizeBox = false;
            this.Name = "FrmConsultaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaClientes";
            this.Activated += new System.EventHandler(this.FrmConsultaClientes_Activated);
            this.Load += new System.EventHandler(this.FrmConsultaClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.ComboBox cbFiltros;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button brncadastrar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnContratos;
    }
}