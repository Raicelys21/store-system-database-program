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
    public partial class Departamentos : Form
    {
        private Dept_Facturacion factura;
        private Dept_Inventario producto;
        private Dept_Compras supli;
        private Login loguin;
        private Dept_RecursosHumanos empleado;
        private Dept_Ventas cliente;
        private Dept_Publicidad publicidad;
        public Departamentos(Login _log)
        {
            loguin = _log;
            InitializeComponent();
        }

        private void Departamentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            loguin.Show();
        }

        private void BTN_Facturación_Click(object sender, EventArgs e)
        {
            this.Hide();
            factura = new Dept_Facturacion(this);
            factura.Show();
        }

        private void BTN_Recursos_Click(object sender, EventArgs e)
        {
            this.Hide();
            empleado = new Dept_RecursosHumanos(this);
            empleado.Show();
        }

        private void BTN_Inventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            producto = new Dept_Inventario(this);
            producto.Show();
        }

        private void BTN_Servicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            cliente = new Dept_Ventas(this);
            cliente.Show();
        }

        private void BTN_Compras_Click(object sender, EventArgs e)
        {
            this.Hide();
            supli = new Dept_Compras(this);
            supli.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            publicidad = new Dept_Publicidad(this);
            publicidad.Show();
        }

        private void Volver1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            loguin.Show();
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {

        }
    }
}
