using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaRegistros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            string cs = "Data Source=Intel;Initial Catalog=AdventureWorks2017;User Id=sa;Password=12345678;MultipleActiveResultSets=true;";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spgetTeste", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvDados.DataSource = dt;
                    MessageBox.Show(dt.Rows[0][0].ToString());
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
                SqlCommand cmd = new SqlCommand("spInsereTeste", con.GetConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@texto", txtTexto.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("inserido com sucesso!");

            con.FechaConexao();

            }

        } 
    }

