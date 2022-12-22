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
    public partial class Dept_Publicidad : Form
    {
        private Departamentos menu;
        DialogResult oDlgRes;
        private string IDcodigo = null;
        Procedimientos funciones = new Procedimientos();
        private bool EJECUTAR = false;
        public Dept_Publicidad(Departamentos _menu)
        {
            menu = _menu;
            InitializeComponent();
        }
        private void MostrarPublicidad()
        {
            Gridview_Publicidad.DataSource = funciones.Mostrar_Publicidad();   /*Creacion del metodo que muestra los datos de la tabla inventario de la base de datos en el datagridview*/
        }
        public void Sucursal()
        {
            comboBoxSuc.DataSource = funciones.Sucursal();
            comboBoxSuc.DisplayMember = "T_Sucursal";                      /*Creacion del metodo para desplegar las opciones del campo area de la tabla t_area de la DB, las cuales se despliegan en el primer combobox*/
            comboBoxSuc.ValueMember = "Nombre";
        }
        private void clear()
        {
            this.cmbTipopublicidad.SelectedIndex = -1;
            this.TB_P1.Clear();
            this.TB_P2.Clear();
            this.TB_P3.Clear();
            this.comboBoxSuc.SelectedIndex = -1;
        }
        public void ELIMINACION()
        {
            oDlgRes = MessageBox.Show("¿Desea continuar con la Eliminacion del registro?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);           //Ventana de mensaje de confirmacion, aqui la utilizamos para confirmar si desea o no eliminar un registro
            if (oDlgRes == DialogResult.Yes)
            {
                if (Gridview_Publicidad.SelectedRows.Count > 0)                  /*sentencia de control para eliminar los datos de la bd por el id*/
                {
                    funciones.Eliminar_Publicidad(Convert.ToInt32(Gridview_Publicidad.CurrentRow.Cells[0].Value));    /*Funcion del objeto Eliminar los datos de una fila seleccionada atraves de la tabla correspondencia 
                                                                                                                    funcion localizado en la clase (procedimiento)*/
                    MessageBox.Show("Se Elimino Satisfactoriamente");      /*Mensaje que nos muestra que se realizo la eliminacion Correctamente*/
                    MostrarPublicidad();                             /*LLamada del procedimiento que muestra la tabla correspondencia en el datagridview. Lo utilizamos para que nos muestre que los cambios se han producidos correctamente*/
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
                if (Gridview_Publicidad.SelectedRows.Count > 0)
                {
                    EJECUTAR = true;
                    cmbTipopublicidad.Text = Gridview_Publicidad.CurrentRow.Cells["TipoPublicidad"].Value.ToString();
                    TB_P1.Text = Gridview_Publicidad.CurrentRow.Cells["NombreArticulo"].Value.ToString();
                    TB_P2.Text = Gridview_Publicidad.CurrentRow.Cells["Costo"].Value.ToString();
                    DTP1.Text = Gridview_Publicidad.CurrentRow.Cells["FechaInicio"].Value.ToString();
                    DTP2.Text = Gridview_Publicidad.CurrentRow.Cells["FechaFinal"].Value.ToString();
                    comboBoxSuc.Text = Gridview_Publicidad.CurrentRow.Cells["Nombre_Sucursal"].Value.ToString();
                    IDcodigo = Gridview_Publicidad.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una Fila");
            }
        }

        private void Dept_Publicidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
        public void coloresdatagridview(DataGridView dtg)
        {
            dtg.RowsDefaultCellStyle.BackColor = Color.LightGray;          /*Creacion del procedimiento que realiza la alternacion de colores del datagridview*/
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        private void Dept_Publicidad_Load(object sender, EventArgs e)
        {
            coloresdatagridview(Gridview_Publicidad);
            MostrarPublicidad();
            Sucursal();
            DTP1.Value = DateTime.Now;
            DTP2.Value = DateTime.Now;
        }

        private void BTP2_Click(object sender, EventArgs e)
        {
            ELIMINACION();
        }

        private void BTP3_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BTP4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BTP1_Click(object sender, EventArgs e)
        {
            if (EJECUTAR == false)
            {
                try
                {
                    if (cmbTipopublicidad.Text.Trim() == "" || TB_P1.Text.Trim() == "" || TB_P2.Text.Trim() == "" || comboBoxSuc.Text.Trim() == "") //Control de campos obligatorios vacios del formulario de Inventario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Insertar_publicidad(                 /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        cmbTipopublicidad.SelectedItem.ToString(),
                        TB_P1.Text,
                        Convert.ToDouble(TB_P2.Text),
                        DTP1.Value = DateTime.Now,
                        DTP2.Value = DateTime.Now,
                        Convert.ToInt32(comboBoxSuc.SelectedIndex + 1));

                        MostrarPublicidad();
                        clear();
                        DTP1.Value = DateTime.Now;
                        DTP2.Value = DateTime.Now;                    
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
                    if (cmbTipopublicidad.Text.Trim() == "" || TB_P1.Text.Trim() == "" || TB_P2.Text.Trim() == "" || comboBoxSuc.Text.Trim() == "") //Control de campos obligatorios vacios del formulario 
                    {
                        MessageBox.Show("Debe Completar Todos los Campos");            /*Control de validacion de los campos obligatorios del formulario*/
                    }
                    else
                    {
                        funciones.Editar_Publicidad(Convert.ToInt32(IDcodigo),                  /*Creacion del objeto Guardar para la insercion de los datos del formulario, en los campos correspondientes. Con el llamado de la funcion insertar de la clase (Procedimientos)*/
                        cmbTipopublicidad.SelectedItem.ToString(),
                        TB_P1.Text,
                        Convert.ToDouble(TB_P2.Text),
                        DTP1.Value = DateTime.Now,
                        DTP2.Value = DateTime.Now,
                        Convert.ToInt32(comboBoxSuc.SelectedIndex + 1));
                        MostrarPublicidad();
                        clear();
                        DTP1.Value = DateTime.Now;
                        DTP2.Value = DateTime.Now;
                        EJECUTAR = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Pudo Editar los Datos por:" + ex);         /*Mensaje de error de control por si no se realiza la insercion Correctamente*/
                }
            }
        }
        private void TB_P3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_P3.Text == "")    /*Condicion de la textbox buscar, nos indica que nos muestre la tabla de la bd si no se introduce ningun texto o si se introduce alguna codififcacion que haga la busqueda*/
                {
                    MostrarPublicidad(); //Llamada del procedimiento que muestra los registros de la tabla corespondencia en el datagridview
                }
                else
                    Gridview_Publicidad.DataSource = funciones.Buscar("SELECT IDPublicidad AS ID, TipoPublicidad, NombreArticulo, Costo, FechaInicio, FechaFinal, IDSucursal AS Nombre_Sucursal FROM T_Publicidad INNER JOIN T_Sucursal ON T_Publicidad.IDSucursal = T_Sucursal.IDSucursal WHERE TipoPublicidad LIKE '%" + TB_P3.Text + "%' or NombreArticulo LIKE '%" + TB_P3.Text + "%'");   /*Evento de busqueda de datos atraves de la DB en el datagridview*/
                if (Gridview_Publicidad.SelectedRows.Count > 0)  /*sentencia de control para que al seleccionar una fila del datagridview se ejecute uno de los procesos*/
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
