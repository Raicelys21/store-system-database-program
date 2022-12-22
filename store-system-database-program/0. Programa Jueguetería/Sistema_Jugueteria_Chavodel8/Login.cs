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
using System.Data.Sql;

namespace Sistema_Jugueteria_Chavodel8
{
    public partial class Login : Form
    {
        private Departamentos menu;
        private DataBase Conexion = new DataBase();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataAdapter dt = new SqlDataAdapter();
        private DataTable ta;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e){}
        public void Loguin(string usu, string contra)
        {
            using (SqlConnection cn = new SqlConnection(DataBase.Conexion))//"Data source= LAPTOP-JEGJF9UU\\SQLEXPRESS01; database= DBJugueteriaCHavodel8; integrated security = true;"))  /*conexion db*/
            {
                Conexion.AbrirConexion();                               /*punto de conexion abierto*/
                Comando = new SqlCommand("select * from loguin where Usuario = @usuario and contrasena = @contrasena", cn);     /*comando para ejecucion*/
                Comando.Parameters.AddWithValue("usuario", usu);
                Comando.Parameters.AddWithValue("contrasena", contra);
                dt = new SqlDataAdapter(Comando);
                ta = new DataTable();
                dt.Fill(ta);                                      /*Llenado de la tabla creada*/
                if (ta.Rows.Count == 1)  /*setencia de control para logueo de usuarios de la aplicacion*/
                {
                    this.Hide();
                    if (ta.Rows[0][2].ToString() == "usuario")  //Control de usuarios.
                    {
                        menu = new Departamentos(this);
                       
                        menu.Show();  //Metodo para mostrar el Form principal.
                    }
                    else if (ta.Rows[0][2].ToString() == "superusuario")  //Control de superusuarios o administrador.
                    {

                    }
                    else if (ta.Rows[0][2].ToString() == "admin")  //Control de superusuarios o administrador.
                    {
 
                    }
                }
                else
                    MessageBox.Show("Usuario o Contraseña Incorrecto");     /*Mensaje de error para el control de usuario y contraseña*/
            }
        }

        private void btloguin_Click(object sender, EventArgs e)
        {
            Loguin(this.tbusu.Text, this.tbcontra.Text);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();         /*Componente para detener la ejecucuoon de la app al presionar la x*/
        }

        private void tbusu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbcontra.Focus();        /*Evento (keydown) al presionar Enter la posicion del puntero baja al siguiente objeto*/
            }
        }

        private void tbcontra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btloguin.Focus();         /*Evento (keypress) al presionar Enter la posicion del puntero baja al siguiente objeto*/
            }
        }
        private void tbusu_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
