using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Jugueteria_Chavodel8
{
    public partial class Dept_Ventas : Form
    {
        private Departamentos menu;
        DialogResult oDlgRes;
        private string IDcodigo = null;
        Procedimientos funciones = new Procedimientos();
        private bool EJECUTAR = false;
        public Dept_Ventas(Departamentos _menu)
        {
            menu = _menu;
            InitializeComponent();
        }

        private void L_F_TDF_Click(object sender, EventArgs e){}

        private void MostrarCliente()
        {
            Gridview_Clientela.DataSource = funciones.Mostrar_Clientes();   /*Creacion del metodo que muestra los datos de la tabla inventario de la base de datos en el datagridview*/
        }
        private void clear()
        {
            this.TB_Cli1.Clear();
            this.TB_Cli2.Clear();
            this.TB_Cli4.Clear();
            this.TB_Cli.Clear();
            this.TB_Cli7.Clear();
            this.TB_Cli8.Clear();
            this.TB_Cli9.Clear();
            this.TB_Cli5.Clear();
            this.TB_Cli6.Clear();
        }
        public void ELIMINACION()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Eliminacion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Clientela.SelectedRows.Count > 0)                  /*sentencia de control para eliminar los datos de la bd por el id*/
                {
                    funciones.Eliminar_Cliente(Convert.ToInt32(Gridview_Clientela.CurrentRow.Cells[0].Value));    /*Funcion del objeto Eliminar los datos de una fila seleccionada atraves de la tabla correspondencia 
                                                                                                                    funcion localizado en la clase (procedimiento)*/
                    MessageBox.Show("Se Elimino Satisfactoriamente");      /*Mensaje que nos muestra que se realizo la eliminacion Correctamente*/
                    MostrarCliente();                             /*LLamada del procedimiento que muestra la tabla correspondencia en el datagridview. Lo utilizamos para que nos muestre que los cambios se han producidos correctamente*/
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
                if (Gridview_Clientela.SelectedRows.Count > 0)
                {
                    EJECUTAR = true;
                    TB_Cli1.Text = Gridview_Clientela.CurrentRow.Cells["Cuenta"].Value.ToString();
                    TB_Cli2.Text = Gridview_Clientela.CurrentRow.Cells["Nombre"].Value.ToString();
                    TB_Cli4.Text = Gridview_Clientela.CurrentRow.Cells["Pais"].Value.ToString();
                    TB_Cli.Text = Gridview_Clientela.CurrentRow.Cells["Region"].Value.ToString();
                    TB_Cli7.Text = Gridview_Clientela.CurrentRow.Cells["Provincia"].Value.ToString();
                    TB_Cli8.Text = Gridview_Clientela.CurrentRow.Cells["Ciudad"].Value.ToString();
                    TB_Cli9.Text = Gridview_Clientela.CurrentRow.Cells["Calle"].Value.ToString();
                    TB_Cli5.Text = Gridview_Clientela.CurrentRow.Cells["Telefono"].Value.ToString();
                    IDcodigo = Gridview_Clientela.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
        }
        public void coloresdatagridview(DataGridView dtg)
        {
            dtg.RowsDefaultCellStyle.BackColor = Color.LightGray;          /*Creacion del procedimiento que realiza la alternacion de colores del datagridview*/
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        private void Dept_Ventas_Load(object sender, EventArgs e)
        {
            coloresdatagridview(Gridview_Clientela);
            MostrarCliente();
        }

        private void BTC4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BTC2_Click(object sender, EventArgs e)
        {
            ELIMINACION();
        }

        private void BTC3_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BTC1_Click(object sender, EventArgs e)
        {
            if (EJECUTAR == false)
            {
                try
                {
                    if (TB_Cli1.Text.Trim() == "" || TB_Cli2.Text.Trim() == "" || TB_Cli4.Text.Trim() == "" || TB_Cli.Text.Trim() == "" || TB_Cli7.Text.Trim() == "" || TB_Cli8.Text.Trim() == "" || TB_Cli9.Text.Trim() == "" || TB_Cli5.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Insertar_Cliente(                 /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        Convert.ToInt32(TB_Cli1.Text),
                        TB_Cli2.Text,
                        TB_Cli4.Text,
                        TB_Cli.Text,
                        TB_Cli7.Text,
                        TB_Cli8.Text,
                        TB_Cli9.Text,
                        Convert.ToInt64(TB_Cli5.Text));
                        MostrarCliente();
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
                    if (TB_Cli1.Text.Trim() == "" || TB_Cli2.Text.Trim() == "" || TB_Cli4.Text.Trim() == "" || TB_Cli.Text.Trim() == "" || TB_Cli7.Text.Trim() == "" || TB_Cli8.Text.Trim() == "" || TB_Cli9.Text.Trim() == "" || TB_Cli5.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Editar_Cliente(Convert.ToInt32(IDcodigo),                  /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        Convert.ToInt32(TB_Cli1.Text),
                        TB_Cli2.Text,
                        TB_Cli4.Text,
                        TB_Cli.Text,
                        TB_Cli7.Text,
                        TB_Cli8.Text,
                        TB_Cli9.Text,
                        Convert.ToInt64(TB_Cli5.Text));
                        MostrarCliente();
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
        private void Dept_Ventas_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
        private void TB_Cli6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_Cli6.Text == "")    /*Condicion de la textbox buscar, nos indica que nos muestre la tabla de la bd si no se introduce ningun texto o si se introduce alguna codififcacion que haga la busqueda*/
                {
                    MostrarCliente(); //Llamada del procedimiento que muestra los registros de la tabla corespondencia en el datagridview
                }
                else
                    Gridview_Clientela.DataSource = funciones.Buscar("SELECT IDCliente AS ID, Cuenta, NombreCompleto, Pais, Region, Provincia, Ciudad, Calle, Telefono  FROM T_Cliente WHERE Cuenta LIKE '%" + TB_Cli6.Text + "%' or Nombre LIKE '%" + TB_Cli6.Text + "%'");   /*Evento de busqueda de datos atraves de la DB en el datagridview*/
                if (Gridview_Clientela.SelectedRows.Count > 0)  /*sentencia de control para que al seleccionar una fila del datagridview se ejecute uno de los procesos*/
                {
                    editar();   /*llamada de la funcion editar*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Buscar los Datos por:" + ex);   /*Mensaje de error de control por si no se realiza el procedimiento Correctamente*/
            }
        }
    }
}
