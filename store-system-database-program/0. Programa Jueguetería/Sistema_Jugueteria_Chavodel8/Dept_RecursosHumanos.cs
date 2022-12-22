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
    public partial class Dept_RecursosHumanos : Form
    {
        private Departamentos menu;
        DialogResult oDlgRes;
        private string IDcodigo = null;
        Procedimientos funciones = new Procedimientos();
        private bool EJECUTAR = false;
        public Dept_RecursosHumanos(Departamentos _menu)
        {
            menu = _menu;
            InitializeComponent();
        }
        private void L_F_FDF_Click(object sender, EventArgs e)
        {

        }
        private void L_F_MF_Click(object sender, EventArgs e)
        {

        }
        private void TB_F6_TextChanged(object sender, EventArgs e)
        {

        }
        private void BTR1_Click(object sender, EventArgs e)
        {
            if (EJECUTAR == false)
            {
                try
                {
                    if (TB_R1.Text.Trim() == "" || TB_R3.Text.Trim() == "" || TB_R4.Text.Trim() == "" || TB_R5.Text.Trim() == "" || comboBoxSuc.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Insertar_Empleado(                 /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        TB_R1.Text,
                        Convert.ToInt64(TB_R3.Text),
                        TB_R4.Text,
                        TB_R5.Text,
                        Convert.ToDouble(TB_R6.Text),
                        dateTimePickerEmpleIngreso.Value = DateTime.Now,
                        TB_R7.Text,
                        Convert.ToInt32(comboBoxSuc.SelectedIndex + 1));
                        MostrarEmpleado();
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
                    if (TB_R1.Text.Trim() == "" || TB_R3.Text.Trim() == "" || TB_R4.Text.Trim() == "" || TB_R5.Text.Trim() == "" || TB_R6.Text.Trim() == "" || TB_R7.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Editar_Empleado(Convert.ToInt32(IDcodigo),                  /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        TB_R1.Text,
                        Convert.ToInt64(TB_R3.Text),
                        TB_R4.Text,
                        TB_R5.Text,
                        Convert.ToDouble(TB_R6.Text),
                        dateTimePickerEmpleIngreso.Value = DateTime.Now,
                        TB_R7.Text,
                        Convert.ToInt32(comboBoxSuc.SelectedIndex + 1));
                        MostrarEmpleado();
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

        private void BTR2_Click(object sender, EventArgs e)
        {
            ELIMINACION();
        }

        private void BTR3_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BTR4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Dept_RecursosHumanos_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
        private void MostrarEmpleado()
        {
            Gridview_Recursos.DataSource = funciones.Mostrar_Empleados();   /*Creacion del metodo que muestra los datos de la tabla inventario de la base de datos en el datagridview*/
        }
        private void clear()
        {
            this.TB_R1.Clear();
            this.TB_R3.Clear();
            this.TB_R4.Clear();
            this.TB_R5.Clear();
            this.TB_R6.Clear();
            this.TB_R7.Clear();
            this.comboBoxSuc.SelectedIndex = -1;
        }
        public void ELIMINACION()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Eliminacion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Recursos.SelectedRows.Count > 0)                  /*sentencia de control para eliminar los datos de la bd por el id*/
                {
                    funciones.Eliminar_Empleado(Convert.ToInt32(Gridview_Recursos.CurrentRow.Cells[0].Value));    /*Funcion del objeto Eliminar los datos de una fila seleccionada atraves de la tabla correspondencia 
                                                                                                                    funcion localizado en la clase (procedimiento)*/
                    MessageBox.Show("Se Elimino Satisfactoriamente");      /*Mensaje que nos muestra que se realizo la eliminacion Correctamente*/
                    MostrarEmpleado();                             /*LLamada del procedimiento que muestra la tabla correspondencia en el datagridview. Lo utilizamos para que nos muestre que los cambios se han producidos correctamente*/
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
                if (Gridview_Recursos.SelectedRows.Count > 0)
                {
                    EJECUTAR = true;
                    TB_R1.Text = Gridview_Recursos.CurrentRow.Cells["Nombre"].Value.ToString();
                    TB_R3.Text = Gridview_Recursos.CurrentRow.Cells["Telefono"].Value.ToString();
                    TB_R4.Text = Gridview_Recursos.CurrentRow.Cells["Horario"].Value.ToString();
                    TB_R5.Text = Gridview_Recursos.CurrentRow.Cells["Sexo"].Value.ToString();
                    TB_R6.Text = Gridview_Recursos.CurrentRow.Cells["Salario"].Value.ToString();
                    dateTimePickerEmpleIngreso.Text = Gridview_Recursos.CurrentRow.Cells["FechaIngreso"].Value.ToString();
                    TB_R7.Text = Gridview_Recursos.CurrentRow.Cells["Departamento"].Value.ToString();
                    comboBoxSuc.Text = Gridview_Recursos.CurrentRow.Cells["Sucursal"].Value.ToString();
                    IDcodigo = Gridview_Recursos.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
        }
        private void TB_R8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_R8.Text == "")    /*Condicion de la textbox buscar, nos indica que nos muestre la tabla de la bd si no se introduce ningun texto o si se introduce alguna codififcacion que haga la busqueda*/
                {
                    MostrarEmpleado(); //Llamada del procedimiento que muestra los registros de la tabla corespondencia en el datagridview
                }
                else
                    Gridview_Recursos.DataSource = funciones.Buscar("SELECT IDEmpleado AS ID, NombreCompleto, Telefono, Horario, Sexo, Salario, FechaIngreso, Departamento, IDSucursal as Sucursal FROM T_Empleado INNER JOIN T_Sucursal ON T_Empleado.IDSucursal = T_Sucursal.IDSucursal WHERE Nombre LIKE '%" + TB_R8.Text + "%'");   /*Evento de busqueda de datos atraves de la DB en el datagridview*/
                if (Gridview_Recursos.SelectedRows.Count > 0)  /*sentencia de control para que al seleccionar una fila del datagridview se ejecute uno de los procesos*/
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
        private void Dept_RecursosHumanos_Load(object sender, EventArgs e)
        {
            coloresdatagridview(Gridview_Recursos);
            MostrarEmpleado();
        }
    }
}
