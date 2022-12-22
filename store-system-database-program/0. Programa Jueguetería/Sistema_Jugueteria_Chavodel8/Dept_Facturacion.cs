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
    public partial class Dept_Facturacion : Form
    {
        Departamentos menu;
        DialogResult oDlgRes;
        private string IDcodigo = null;
        Procedimientos funciones = new Procedimientos();
        private bool EJECUTAR = false;
        public Dept_Facturacion(Departamentos _menu)
        {
            menu = _menu;
            InitializeComponent();
        }
        public void coloresdatagridview(DataGridView dtg)
        {
            dtg.RowsDefaultCellStyle.BackColor = Color.LightGray;          /*Creacion del procedimiento que realiza la alternacion de colores del datagridview*/
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        public void Productos()
        {
            ComboBox1.DataSource = funciones.producto();
            ComboBox1.DisplayMember = "T_Producto";                      /*Creacion del metodo para desplegar las opciones del campo area de la tabla t_area de la DB, las cuales se despliegan en el primer combobox*/
            ComboBox1.ValueMember = "Marca";
        }
        public void Clientes()
        {
            comboBox4.DataSource = funciones.cliente();
            comboBox4.DisplayMember = "T_Cliente";                      /*Creacion del metodo para desplegar las opciones del campo area de la tabla t_area de la DB, las cuales se despliegan en el primer combobox*/
            comboBox4.ValueMember = "NombreCompleto";
        }
        private void Dept_Facturacion_Load(object sender, EventArgs e)
        {
            MostrarCarritoCompras();
            Productos();
            Clientes();
            coloresdatagridview(Gridview_Facturacion);
            coloresdatagridview(dataGridView1);
            coloresdatagridview(dataGridView2);
        }

        private void Volver2_Click(object sender, EventArgs e)
        {
            menu.Show();
        }

        private void MostrarCarritoCompras()
        {
            Gridview_Facturacion.DataSource = funciones.Mostrar_CarritoCompras();   /*Creacion del metodo que muestra los datos de la tabla inventario de la base de datos en el datagridview*/
            dataGridView1.DataSource = funciones.Mostrar_Productos();
            dataGridView2.DataSource = funciones.Mostrar_Historial_Facturacion();
        }
        private void clear()
        {
            this.TB_F1.Clear();
            this.ComboBox2.SelectedIndex = -1;
            this.TB_F2.Clear();
            this.ComboBox3.SelectedIndex = -1;
            this.lbmonto.Text = "0.00";
            this.ComboBox1.SelectedIndex = 0;
            this.comboBox4.SelectedIndex = 0;
        }
        public void editar()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Edicion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Facturacion.SelectedRows.Count > 0)
                {
                    EJECUTAR = true;
                    comboBox4.Text = Gridview_Facturacion.CurrentRow.Cells["Nombre"].Value.ToString();
                    ComboBox1.Text = Gridview_Facturacion.CurrentRow.Cells["Marca"].Value.ToString();
                    TB_F1.Text = Gridview_Facturacion.CurrentRow.Cells["Cantidad_Articulos"].Value.ToString();
                    ComboBox2.Text = Gridview_Facturacion.CurrentRow.Cells["TipoFactura"].Value.ToString();
                    TB_F2.Text = Gridview_Facturacion.CurrentRow.Cells["NumVenta"].Value.ToString();
                    DTP3.Text = Gridview_Facturacion.CurrentRow.Cells["FechaFactura"].Value.ToString();
                    ComboBox3.Text = Gridview_Facturacion.CurrentRow.Cells["Descuento"].Value.ToString();
                    lbmonto.Text = Gridview_Facturacion.CurrentRow.Cells["MontoFinal"].Value.ToString();
                    IDcodigo = Gridview_Facturacion.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
        }

        private void Dept_Facturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }

        private void BTF3_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BTF4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void TB_F4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_F4.Text == "")    /*Condicion de la textbox buscar, nos indica que nos muestre la tabla de la bd si no se introduce ningun texto o si se introduce alguna codififcacion que haga la busqueda*/
                {
                    MostrarCarritoCompras(); //Llamada del procedimiento que muestra los registros de la tabla corespondencia en el datagridview
                }
                else
                    Gridview_Facturacion.DataSource = funciones.Buscar("SELECT IDFacturacion AS ID, T_Producto.IDProducto, CantidadArt, TipoFactura, NumVenta, FechaFactura, Descuento, MontoFinal FROM T_CarritoCompras INNER JOIN T_Producto ON T_CarritoCompras.IDProducto = T_Producto.IDProducto WHERE NumVenta LIKE '%" + TB_F4.Text + "%' or TipoFactura LIKE '%" + TB_F4.Text + "%'");   /*Evento de busqueda de datos atraves de la DB en el datagridview*/
                if (Gridview_Facturacion.SelectedRows.Count > 0)  /*sentencia de control para que al seleccionar una fila del datagridview se ejecute uno de los procesos*/
                {
                    editar();   /*llamada de la funcion editar*/
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Buscar los Datos por:" + ex);   /*Mensaje de error de control por si no se realiza el procedimiento Correctamente*/
            }
        }
        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(DataBase.Conexion))      //Conexion de DB 
                {
                    SqlCommand cmd = new SqlCommand("SELECT PrecioUnidad FROM T_Producto WHERE Marca ='" + ComboBox1.Text + "'", cn);      //query que se ejecutara de la base de datos para la extraccion de la palabra clave de cada area

                    cn.Open();                              /*Codigo de abrir conexion*/
                    cmd.ExecuteNonQuery();                  /*Codigo para ejecutar el query de la bd*/

                    SqlDataReader LeerFilas = cmd.ExecuteReader();

                    while (LeerFilas.Read())                /*control de sentencia (while) para cuando se lea el datareader se ejecute el query y se imprime las iniciales del area seleccionada, en el label para configurar el codigo de correspondencia*/
                    {
                        string codigo2 = (string)LeerFilas["PrecioUnidad"].ToString();
                        lbmonto.Text = codigo2;
                    }
                    LeerFilas.Close();                       /*Lector de filas cerrado*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Insertar los Datos por:" + ex);            /*Mensaje de error de control por si no se realiza el procedimiento Correctamente*/
            }
        }
        private void BTF1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Gridview_Facturacion.SelectedRows.Count > 0)
                {
                    //dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString()
                    funciones.Insertar_Facturacion(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString()),
                    Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString()),                //Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)
                    Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString()),
                    dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString(),
                    Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[5].Value.ToString()),
                    DateTime.Now,
                    Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value.ToString()),
                    double.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[8].Value.ToString()));
                    DTP3.Value = DateTime.Now;
                    funciones.Eliminar_DATACarritoCompras(Convert.ToInt32(ComboBox1.SelectedIndex + 1));
                    MostrarCarritoCompras();
                    clear();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Insertar los Datos por:" + ex);         /*Mensaje de error de control por si no se realiza la insercion Correctamente*/
            }
        }
        private void Gridview_Facturacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BTNCC_Click(object sender, EventArgs e)
        {
            if (EJECUTAR == false)
            {
                try
                {
                    if (comboBox4.Text.Trim() == "" || ComboBox1.Text.Trim() == "" || TB_F1.Text.Trim() == "" || ComboBox2.Text.Trim() == "" || TB_F2.Text.Trim() == "" || ComboBox3.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        int monto = Convert.ToInt32(TB_F1.Text);
                        double precio = double.Parse(lbmonto.Text);
                        double preciofinal = monto * precio;
                        funciones.Insertar_Carrito_Compras(Convert.ToInt32(comboBox4.SelectedIndex + 1),
                        Convert.ToInt32(ComboBox1.SelectedIndex + 1),                //Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)
                        Convert.ToInt32(TB_F1.Text),
                        ComboBox2.SelectedItem.ToString(),
                        Convert.ToInt32(TB_F2.Text),
                        DTP3.Value = DateTime.Now,
                        Convert.ToInt32(ComboBox3.Text),preciofinal);

                        DTP3.Value = DateTime.Now;
                        funciones.Editar_inventario(Convert.ToInt32(TB_F1.Text), Convert.ToInt32(ComboBox1.SelectedIndex + 1));
                        funciones.Descuento_Factura(((Convert.ToInt32(ComboBox3.Text) / 100) * double.Parse(lbmonto.Text)), Convert.ToInt32(TB_F2.Text));
                        MostrarCarritoCompras();
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
                    if (ComboBox1.Text.Trim() == "" || TB_F1.Text.Trim() == "" || ComboBox2.Text.Trim() == "" || TB_F2.Text.Trim() == "" || ComboBox3.Text.Trim() == "") //Control de campos obligatorios vacios del formulario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        int monto = Convert.ToInt32(TB_F1.Text);
                        double precio = double.Parse(lbmonto.Text);
                        double preciofinal = monto * precio;
                        funciones.Editar_CarritoCompras(Convert.ToInt32(IDcodigo),
                        Convert.ToInt32(comboBox4.SelectedIndex + 1),    /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        Convert.ToInt32(ComboBox1.SelectedIndex + 1),
                        Convert.ToInt32(TB_F1.Text),
                        ComboBox2.SelectedItem.ToString(),
                        Convert.ToInt32(TB_F2.Text),
                        DTP3.Value = DateTime.Now,
                        Convert.ToInt32(ComboBox3.Text), preciofinal);
                        MostrarCarritoCompras();
                        clear();
                        DTP3.Value = DateTime.Now;
                        EJECUTAR = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Pudo Editar los Datos por:" + ex);         /*Mensaje de error de control por si no se realiza la insercion Correctamente*/
                }
            }
        }
    }
}
