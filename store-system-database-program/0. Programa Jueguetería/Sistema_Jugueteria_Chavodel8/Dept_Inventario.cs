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
    public partial class Dept_Inventario : Form
    {

        private Departamentos menu;
        DialogResult oDlgRes;
        private string IDcodigo = null;
        Procedimientos funciones = new Procedimientos();
        private bool EJECUTAR = false;
        public Dept_Inventario(Departamentos _menu)
        {
            menu = _menu;
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ELIMINACION();
        }

        private void Dept_Inventario_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            coloresdatagridview(Gridview_Inventario);
            Suplidor();
            Sucursal();
        }

        private void Dept_Inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
        private void MostrarProductos()
        {
            Gridview_Inventario.DataSource = funciones.Mostrar_Productos();   /*Creacion del metodo que muestra los datos de la tabla inventario de la base de datos en el datagridview*/
        }
        private void clear()
        {
            this.TB_i1.Clear();
            this.TB_i2.Clear();
            this.TB_i3.Clear();
            this.TB_i4.Clear();
            this.TB_i5.Clear();
            this.ComboBox4.SelectedIndex = 0;
            this.comboBox1.SelectedIndex = 0;
        }
        public void ELIMINACION()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Eliminacion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Inventario.SelectedRows.Count > 0)                  /*sentencia de control para eliminar los datos de la bd por el id*/
                {
                    funciones.Eliminar_Producto(Convert.ToInt32(Gridview_Inventario.CurrentRow.Cells[0].Value));    /*Funcion del objeto Eliminar los datos de una fila seleccionada atraves de la tabla correspondencia 
                                                                                                                    funcion localizado en la clase (procedimiento)*/
                    MessageBox.Show("Se Elimino Satisfactoriamente");      /*Mensaje que nos muestra que se realizo la eliminacion Correctamente*/
                    MostrarProductos();                             /*LLamada del procedimiento que muestra la tabla correspondencia en el datagridview. Lo utilizamos para que nos muestre que los cambios se han producidos correctamente*/
                }
                else
                    MessageBox.Show("Seleccione una Fila");                /*Mensaje que me muestra si no se ha selccionado una fila de la tabla para realizar la operacion*/
            }
        }
        public void editar()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Edicion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Inventario.SelectedRows.Count > 0)
                {
                    EJECUTAR = true;
                    TB_i1.Text = Gridview_Inventario.CurrentRow.Cells["Marca"].Value.ToString();
                    TB_i2.Text = Gridview_Inventario.CurrentRow.Cells["Categoria"].Value.ToString();
                    TB_i3.Text = Gridview_Inventario.CurrentRow.Cells["Descripcion"].Value.ToString();
                    TB_i4.Text = Gridview_Inventario.CurrentRow.Cells["PrecioUnidad"].Value.ToString();
                    TB_i5.Text = Gridview_Inventario.CurrentRow.Cells["CantidadExistencia"].Value.ToString();
                    ComboBox4.Text = Gridview_Inventario.CurrentRow.Cells["Nombre_Suplidor"].Value.ToString();
                    comboBox1.Text = Gridview_Inventario.CurrentRow.Cells["Sucursal"].Value.ToString();
                    IDcodigo = Gridview_Inventario.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
        }

        private void BTI1_Click(object sender, EventArgs e)
        {
            if (EJECUTAR == false)
            {
                try
                {
                    if (TB_i1.Text.Trim() == "" || TB_i2.Text.Trim() == "" || TB_i3.Text.Trim() == "" || TB_i4.Text.Trim() == "" || TB_i5.Text.Trim() == "" || ComboBox4.SelectedIndex == 0 || comboBox1.SelectedIndex == 0) //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.InsertarProducto(                 /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        TB_i1.Text,
                        TB_i2.Text,
                        TB_i3.Text,
                        Convert.ToDouble(TB_i4.Text),
                        Convert.ToInt32(TB_i5.Text),
                        Convert.ToInt32(ComboBox4.SelectedIndex + 1),
                        Convert.ToInt32(comboBox1.SelectedIndex + 1));
                        MostrarProductos();
                        clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Pudo Insertar los Datos por:" + ex);         /*Mensaje de error de control por si no se realiza la insercion Correctamente*/
                }
            }
            if (EJECUTAR == true)
            {
                try
                {
                    if (TB_i1.Text.Trim() == "" || TB_i2.Text.Trim() == "" || TB_i3.Text.Trim() == "" || TB_i4.Text.Trim() == "" || TB_i5.Text.Trim() == "" || ComboBox4.SelectedIndex == 0 || comboBox1.SelectedIndex == 0) //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Editar_Producto(Convert.ToInt32(IDcodigo),                  /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        TB_i1.Text,
                        TB_i2.Text,
                        TB_i3.Text,
                        Convert.ToDouble(TB_i4.Text),
                        Convert.ToInt32(TB_i5.Text),
                        Convert.ToInt32(ComboBox4.SelectedIndex + 1),
                        Convert.ToInt32(comboBox1.SelectedIndex + 1));
                        MostrarProductos();
                        clear();
                        EJECUTAR = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Pudo Editar los Datos por:" + ex);         /*Mensaje de error de control por si no se realiza la insercion Correctamente*/
                }
            }
        }

        private void BTI3_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BTI4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void TB_i6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_i6.Text == "")    /*Condicion de la textbox buscar, nos indica que nos muestre la tabla de la bd si no se introduce ningun texto o si se introduce alguna codififcacion que haga la busqueda*/
                {
                    MostrarProductos(); //Llamada del procedimiento que muestra los registros de la tabla corespondencia en el datagridview
                }
                else
                    Gridview_Inventario.DataSource = funciones.Buscar("SELECT IDProducto AS ID, Marca, Categoria, Descripcion, PrecioUnidad, CantidadExistencia,T_Suplidor.Nombre AS Nombre_Suplidor FROM T_Producto INNER JOIN T_Suplidor ON T_Producto.IDSuplidor = T_Suplidor.IDSuplidor INNER JOIN T_Sucursal ON T_Producto.IDSucursal = T_Sucursal.IDSucursal WHERE Marca LIKE '%" + TB_i6.Text + "%' or Categoria LIKE '%" + TB_i6.Text + "%'");   /*Evento de busqueda de datos atraves de la DB en el datagridview*/
                if (Gridview_Inventario.SelectedRows.Count > 0)  /*sentencia de control para que al seleccionar una fila del datagridview se ejecute uno de los procesos*/
                {
                    editar();   /*llamada de la funcion editar*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Buscar los Datos por:" + ex);   /*Mensaje de error de control por si no se realiza el procedimiento Correctamente*/
            }
        }
        public void coloresdatagridview(DataGridView dtg)
        {
            dtg.RowsDefaultCellStyle.BackColor = Color.LightGray;          /*Creacion del procedimiento que realiza la alternacion de colores del datagridview*/
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        public void Suplidor()
        {
            ComboBox4.DataSource = funciones.suplidor();
            ComboBox4.DisplayMember = "T_Suplidor";                      /*Creacion del metodo para desplegar las opciones del campo area de la tabla t_area de la DB, las cuales se despliegan en el primer combobox*/
            ComboBox4.ValueMember = "Nombre";
        }
        public void Sucursal()
        {
            ComboBox4.DataSource = funciones.Sucursal();
            ComboBox4.DisplayMember = "T_Sucursal";                      /*Creacion del metodo para desplegar las opciones del campo area de la tabla t_area de la DB, las cuales se despliegan en el primer combobox*/
            ComboBox4.ValueMember = "Nombre";
        }
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(DataBase.Conexion))      //Conexion de DB 
                {
                    SqlCommand cmd = new SqlCommand("SELECT IDSuplidor FROM T_Suplidor WHERE Nombre ='" + ComboBox4.Text + "'", cn);      //query que se ejecutara de la base de datos para la extraccion de la palabra clave de cada area

                    cn.Open();                              /*Codigo de abrir conexion*/
                    cmd.ExecuteNonQuery();                  /*Codigo para ejecutar el query de la bd*/

                    SqlDataReader LeerFilas = cmd.ExecuteReader();

                    while (LeerFilas.Read())                /*control de sentencia (while) para cuando se lea el datareader se ejecute el query y se imprime las iniciales del area seleccionada, en el label para configurar el codigo de correspondencia*/
                    {
                        string codigo2 = (string)LeerFilas["IDSuplidor"].ToString();
                        //lbDocumento.Text = codigo2;
                    }
                    LeerFilas.Close();                       /*Lector de filas cerrado*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Insertar los Datos por:" + ex);            /*Mensaje de error de control por si no se realiza el procedimiento Correctamente*/
            }
        }
    }
}
