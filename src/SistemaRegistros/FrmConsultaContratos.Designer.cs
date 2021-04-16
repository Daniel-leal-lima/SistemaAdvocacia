
namespace SistemaRegistros
{
    partial class FrmConsultaContratos
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
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cbFiltros = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(508, 52);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(68, 25);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dgvContratos
            // 
            this.dgvContratos.AllowUserToAddRows = false;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Location = new System.Drawing.Point(48, 91);
            this.dgvContratos.MultiSelect = false;
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.RowHeadersVisible = false;
            this.dgvContratos.RowTemplate.Height = 25;
            this.dgvContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratos.Size = new System.Drawing.Size(480, 312);
            this.dgvContratos.TabIndex = 8;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(48, 54);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(454, 23);
            this.txtPesquisa.TabIndex = 7;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(48, 28);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(61, 15);
            this.lblFiltrar.TabIndex = 11;
            this.lblFiltrar.Text = "Filtrar por:";
            // 
            // cbFiltros
            // 
            this.cbFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltros.FormattingEnabled = true;
            this.cbFiltros.Items.AddRange(new object[] {
            "Nome",
            "CPF",
            "Telefone",
            "Nº Processo",
            "Data de Pagamento",
            "Processos Não Registrados"});
            this.cbFiltros.Location = new System.Drawing.Point(113, 25);
            this.cbFiltros.Name = "cbFiltros";
            this.cbFiltros.Size = new System.Drawing.Size(161, 23);
            this.cbFiltros.TabIndex = 10;
            this.cbFiltros.SelectedIndexChanged += new System.EventHandler(this.cbFiltros_SelectedIndexChanged);
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(232, 429);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(121, 82);
            this.btnVer.TabIndex = 12;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(105, 429);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(121, 82);
            this.btnCadastrar.TabIndex = 14;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(534, 194);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 56);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Atualizar lista";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(359, 429);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(121, 82);
            this.btnAlterar.TabIndex = 16;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(534, 372);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 61);
            this.btnVoltar.TabIndex = 17;
            this.btnVoltar.Text = "VOLTAR P/ CLIENTES";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(534, 272);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(65, 72);
            this.btnRelatorio.TabIndex = 18;
            this.btnRelatorio.Text = "Relatorio Captação";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // FrmConsultaContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 523);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.cbFiltros);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dgvContratos);
            this.Controls.Add(this.txtPesquisa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConsultaContratos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaContratos";
            this.Activated += new System.EventHandler(this.FrmConsultaContratos_Activated);
            this.Load += new System.EventHandler(this.FrmConsultaContratos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.ComboBox cbFiltros;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnRelatorio;
    }
}