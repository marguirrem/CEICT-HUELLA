using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Configuration;

namespace CeictHuella
{
    public partial class frmMain : Form
    {
        public static string strConexion = ConfigurationManager.ConnectionStrings["conex"].ConnectionString;
        public static SqlConnection conexion = new SqlConnection(strConexion);
        

        public frmMain()
        {
            InitializeComponent();
            SerialPort sp = new SerialPort("COM8");
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.Handshake = Handshake.None; 
            try
            {
                //tmrSrial.Enabled = true;
                sp.DataReceived += new  SerialDataReceivedEventHandler(DataReceivedHandler);
    
                sp.Open();
                         }
            catch (Exception ex)
            {
                MessageBox.Show("Erro en Main: " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVerIngresos_Click(object sender, EventArgs e)
        {
            Form2 frmIngresos = new Form2();
            frmIngresos.Visible = true;
            this.Hide();
        }

        private static void DataReceivedHandler(
                      object sender,
                      SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
            
            try
            {

                DataTable dt = new DataTable();
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexion;
                cmd.CommandText = "sp_buscarUsuario";
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Convert.ToInt16( indata);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Nombre"].ToString());
                        sp.WriteLine(dr["Nombre"].ToString());
                        

                    }
                    
                    dr.Close();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Connection = conexion;
                    cmd2.CommandText = "sp_insertarIngreso";
                    cmd2.Parameters.AddWithValue("@usuario", SqlDbType.Int).Value = Convert.ToInt16(indata);
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                }
                else
                {
                    Console.WriteLine("Registro invalido");
                    sp.WriteLine("Registro invalido");
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("excepcion en catch " + ex.Message);
                
            }
            finally
            {
                conexion.Close();
                
            }

        }



        private void tmrSrial_Tick(object sender, EventArgs e)
        {   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoUsuario nu = new NuevoUsuario();
            nu.Show();
        }
    }
}
