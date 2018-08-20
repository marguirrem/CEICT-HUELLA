using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;




namespace CeictHuella
{
    public partial class Form2 : Form
    {
        public static string strConexion = ConfigurationManager.ConnectionStrings["conex"].ConnectionString;
        public SqlConnection conexion = new SqlConnection(strConexion);
        public SqlCommand cmd;
        public DataTable dt;
        public SqlDataAdapter da;
       

        public Form2()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportarExcel(dataGridView1);
        }

        private void FrmIngresos_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                dt = new System.Data.DataTable();
                cmd = new SqlCommand("sp_listarIngresos", conexion);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error " + exc.Message);
            }
            finally
            {
                conexion.Close();
            }

    
        }

        public void exportarExcel(DataGridView table)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add(true);

            int indiceColumna = 0;
            foreach (DataGridViewColumn col in table.Columns)
            {
                indiceColumna++;
                excel.Cells[1, indiceColumna] = col.Name;
            }

            int indiceFila = 0;
            foreach (DataGridViewRow row in table.Rows)
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn col in table.Columns)
                {
                    indiceColumna++;
                    excel.Cells[indiceFila + 1, indiceColumna] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;
        }
    }
}
