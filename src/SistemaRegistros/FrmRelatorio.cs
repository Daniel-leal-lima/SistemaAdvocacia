using SistemaRegistros.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaRegistros
{
    public partial class FrmRelatorio : Form
    {
        public FrmRelatorio()
        {
            InitializeComponent();
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.ListaCaptadores(cbNomeCaptadores);
        }

        private void btnGeraRelatorio_Click(object sender, EventArgs e)
        {
            string nomeCaptador = cbNomeCaptadores.Text;
            string mes = DtpData.Value.ToString("MM");
            string ano = DtpData.Value.ToString("yyyy");
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.GeraRelatorio(nomeCaptador,mes, ano);
        }
    }
}
