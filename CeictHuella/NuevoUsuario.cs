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
using System.Configuration;

namespace CeictHuella
{
    public partial class NuevoUsuario : Form

    {
        public static string strConexion = ConfigurationManager.ConnectionStrings["conex"].ConnectionString;
        public static SqlConnection conexion = new SqlConnection(strConexion);



        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrearusuario_Click(object sender, EventArgs e)
        {
            int tipoUsuario = 0;
            if (cmbxUsuarios.SelectedItem.Equals("Administrador"))
            {
                tipoUsuario = 1;
            }
            if (cmbxUsuarios.SelectedItem.Equals("Maestro"))
            {
                tipoUsuario = 2;
            }
            if (cmbxUsuarios.SelectedItem.Equals("Alumno"))
            {
                tipoUsuario = 3;
            }
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexion;
                cmd.CommandText = "sp_insertarUsuario";
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Convert.ToInt16(txtCodigo.Text);
                cmd.Parameters.AddWithValue("@pNombre", SqlDbType.Text).Value = txtPrimerNombre.Text;
                cmd.Parameters.AddWithValue("@sNombre", SqlDbType.Text).Value = txtSegundoNombre.Text;
                cmd.Parameters.AddWithValue("@pApellido", SqlDbType.Text).Value = txtPrimerApellido.Text;
                cmd.Parameters.AddWithValue("@sApellido", SqlDbType.Text).Value = txtSegundoApellido.Text;
                cmd.Parameters.AddWithValue("@rol", SqlDbType.Int).Value = tipoUsuario;
                SqlDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("Exito");
                txtPrimerNombre.Text = "";
                txtSegundoNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void cmbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}