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
    public partial class Dept_Compras : Form
    {
        private Departamentos menu;
        DialogResult oDlgRes;
        private string IDcodigo = null;
        Procedimientos funciones = new Procedimientos();
        private bool EJECUTAR = false;
        public Dept_Compras(Departamentos _menu)
        {
            menu = _menu;
            InitializeComponent();
        }

        private void Volver6_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }
        private void MostrarSuplidor()
        {
            Gridview_Compras.DataSource = funciones.Mostrar_Suplidores();   /*Creacion del metodo que muestra los datos de la tabla inventario de la base de datos en el datagridview*/
        }
        private void clear()
        {
            this.TB_Com1.Clear();
            this.TB_Com2.Clear();
            this.TB_Com3.Clear();
            this.TB_Com6.Clear();
            this.TB_Com7.Clear();
            this.TB_Com8.Clear();
            this.TB_Com9.Clear();
            this.TB_Com10.Clear();
            this.TB_Com4.Clear();
            this.TB_Com5.Clear();
        }
        public void ELIMINACION()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Eliminacion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Compras.SelectedRows.Count > 0)                  /*sentencia de control para eliminar los datos de la bd por el id*/
                {
                    funciones.Eliminar_Suplidor(Convert.ToInt32(Gridview_Compras.CurrentRow.Cells[0].Value));    /*Funcion del objeto Eliminar los datos de una fila seleccionada atraves de la tabla correspondencia 
                                                                                                                    funcion localizado en la clase (procedimiento)*/
                    MessageBox.Show("Se Elimino Satisfactoriamente");      /*Mensaje que nos muestra que se realizo la eliminacion Correctamente*/
                    MostrarSuplidor();                             /*LLamada del procedimiento que muestra la tabla correspondencia en el datagridview. Lo utilizamos para que nos muestre que los cambios se han producidos correctamente*/
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
                if (Gridview_Compras.SelectedRows.Count > 0)
                {
                    EJECUTAR = true;
                    TB_Com1.Text = Gridview_Compras.CurrentRow.Cells["Nombre"].Value.ToString();
                    TB_Com2.Text = Gridview_Compras.CurrentRow.Cells["Telefono"].Value.ToString();
                    TB_Com3.Text = Gridview_Compras.CurrentRow.Cells["Pais"].Value.ToString();
                    TB_Com6.Text = Gridview_Compras.CurrentRow.Cells["Region"].Value.ToString();
                    TB_Com7.Text = Gridview_Compras.CurrentRow.Cells["Provincia"].Value.ToString();
                    TB_Com8.Text = Gridview_Compras.CurrentRow.Cells["Ciudad"].Value.ToString();
                    TB_Com9.Text = Gridview_Compras.CurrentRow.Cells["Calle"].Value.ToString();
                    TB_Com10.Text = Gridview_Compras.CurrentRow.Cells["No_Asociado"].Value.ToString();
                    TB_Com4.Text = Gridview_Compras.CurrentRow.Cells["Email"].Value.ToString();
                    IDcodigo = Gridview_Compras.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
        }
        private void Dept_Compras_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
        public void coloresdatagridview(DataGridView dtg)
        {
            dtg.RowsDefaultCellStyle.BackColor = Color.LightGray;          /*Creacion del procedimiento que realiza la alternacion de colores del datagridview*/
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        private void Dept_Compras_Load(object sender, EventArgs e)
        {
            coloresdatagridview(Gridview_Compras);
            MostrarSuplidor();
        }

        private void BTCO1_Click(object sender, EventArgs e)
        {
            if (EJECUTAR == false)
            {
                try
                {
                    if (TB_Com1.Text.Trim() == "" || TB_Com2.Text.Trim() == "" || TB_Com3.Text.Trim() == "" || TB_Com6.Text.Trim() == "" || TB_Com7.Text.Trim() == "" || TB_Com8.Text.Trim() == "" || TB_Com9.Text.Trim() == "" || TB_Com10.Text.Trim() == "" || TB_Com4.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Insertar_Proovedor(                 /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        TB_Com1.Text,
                        Convert.ToInt64(TB_Com2.Text),
                        TB_Com3.Text,
                        TB_Com6.Text,
                        TB_Com7.Text,
                        TB_Com8.Text,
                        TB_Com9.Text,
                        Convert.ToInt32(TB_Com10.Text),
                        TB_Com4.Text);
                        MostrarSuplidor();
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
                    if (TB_Com1.Text.Trim() == "" || TB_Com2.Text.Trim() == "" || TB_Com3.Text.Trim() == "" || TB_Com6.Text.Trim() == "" || TB_Com7.Text.Trim() == "" || TB_Com8.Text.Trim() == "" || TB_Com9.Text.Trim() == "" || TB_Com10.Text.Trim() == "" || TB_Com4.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Editar_Suplidores(Convert.ToInt32(IDcodigo),                  /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        TB_Com1.Text,
                        Convert.ToInt64(TB_Com2.Text),
                        TB_Com3.Text,
                        TB_Com6.Text,
                        TB_Com7.Text,
                        TB_Com8.Text,
                        TB_Com9.Text,
                        Convert.ToInt32(TB_Com10.Text),
                        TB_Com4.Text);
                        MostrarSuplidor();
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

        private void BTCO2_Click(object sender, EventArgs e)
        {
            ELIMINACION();
        }

        private void BTCO3_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BTCO4_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void TB_Com5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_Com5.Text == "")    /*Condicion de la textbox buscar, nos indica que nos muestre la tabla de la bd si no se introduce ningun texto o si se introduce alguna codififcacion que haga la busqueda*/
                {
                    MostrarSuplidor(); //Llamada del procedimiento que muestra los registros de la tabla corespondencia en el datagridview
                }
                else
                    Gridview_Compras.DataSource = funciones.Buscar("SELECT IDSuplidor AS ID, Nombre, Telefono, Pais, Region, Provincia, Ciudad, Calle, No_Asociado, Email FROM T_Suplidor WHERE Nombre LIKE '%" + TB_Com5.Text + "%'");   /*Evento de busqueda de datos atraves de la DB en el datagridview*/
                if (Gridview_Compras.SelectedRows.Count > 0)  /*sentencia de control para que al seleccionar una fila del datagridview se ejecute uno de los procesos*/
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
