using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SistemaRegistros
{
    class FabricaConexao
    {
        private string cs = "Data Source=INTEL;Initial Catalog=BDAdvocacia;User Id=sa;Password=12345678;MultipleActiveResultSets=true;";
        private SqlConnection con = null;
        private string erro = string.Empty;

        public void AbreConexao()
        {
            
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                this.con = con;
            }
            catch(Exception e)
            {
                erro = e.Message;
                MessageBox.Show(erro);
            }
        }

        public void FechaConexao()
        {
            if (con != null)
            {
                con.Close();
            }
        }
        public string GetErro()
        { 
            return erro;
        }
        public SqlConnection GetConexao()
        {
            return this.con;
        }
    }
}
