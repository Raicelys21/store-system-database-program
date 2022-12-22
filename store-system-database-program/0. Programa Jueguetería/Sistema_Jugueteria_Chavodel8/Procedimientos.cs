using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Sistema_Jugueteria_Chavodel8
{
    class Procedimientos
    {
        //conexion db
        public DataBase Conexion = new DataBase();
        private SqlCommand Comando = new SqlCommand();                     //Conexion de la clase (database)
        private SqlDataReader LeerFilas;
        private SqlDataAdapter dt;
        private DataTable ta;

        //METODOS/FUNCIONES
        public DataTable cliente()
        {
            DataTable Table = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarCliente";
            Comando.CommandType = CommandType.StoredProcedure;             //Creacion de la funcion que genera los datos de la tabla (Areas) desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Table.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Table;
        }
        public DataTable producto()
        {
            DataTable Table = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarProducto";
            Comando.CommandType = CommandType.StoredProcedure;             //Creacion de la funcion que genera los datos de la tabla (Areas) desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Table.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Table;
        }
        public DataTable suplidor()
        {
            DataTable Table = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarProveedor";                      //Creacion de la funcion que genera los datos de la tabla (Documentos) desde la base de datos atraves de un procedimiento almacenado
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Table.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Table;
        }
        public DataTable Sucursal()
        {
            DataTable Table = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarSucursal";
            Comando.CommandType = CommandType.StoredProcedure;             //Creacion de la funcion que genera los datos de la tabla (Areas) desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Table.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Table;
        }

        public void InsertarProducto(string Descripcion, string Marca, string Categoria, double Precio, int Cantidad_Existencia, int IDSuplidor, int Id_Sucursal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Marca", Marca);
            Comando.Parameters.AddWithValue("@Categoria", Categoria);
            Comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            Comando.Parameters.AddWithValue("@PrecioUnidad", Precio);
            Comando.Parameters.AddWithValue("@CantidadExistencia", Cantidad_Existencia);
            Comando.Parameters.AddWithValue("@IDSuplidor", IDSuplidor);
            Comando.Parameters.AddWithValue("@IDSucursal", Id_Sucursal);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void Insertar_Carrito_Compras(int Id_Cliente, int Id_Producto, int Cantidad_Articulos, string tipo_factura, int Numero_ventas, DateTime Fecha_Factura, int Descuento, double Monto_Final)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarCarritoCompras";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@IDCliente", Id_Cliente);
            Comando.Parameters.AddWithValue("@IDProducto", Id_Producto);
            Comando.Parameters.AddWithValue("@CantidadArt", Cantidad_Articulos);
            Comando.Parameters.AddWithValue("@TipoFactura", tipo_factura);
            Comando.Parameters.AddWithValue("@NumVenta", Numero_ventas);
            Comando.Parameters.AddWithValue("@FechaFactura", Fecha_Factura);                //Creacion de la funcion que Realiza la insercion de la tabla (Correspondencia) desde la base de datos atraves de un procedimiento almacenado
            Comando.Parameters.AddWithValue("@Descuento", Descuento);
            Comando.Parameters.AddWithValue("@MontoFinal", Monto_Final);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void Insertar_Facturacion(int Id_Cliente, int Id_Producto, int Cantidad_Articulos, string tipo_factura, int Numero_ventas, DateTime Fecha_Factura, int Descuento, double Monto_Final)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarFacturacion";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@IDCliente", Id_Cliente);
            Comando.Parameters.AddWithValue("@IDProducto", Id_Producto);
            Comando.Parameters.AddWithValue("@CantidadArt", Cantidad_Articulos);
            Comando.Parameters.AddWithValue("@TipoFactura", tipo_factura);
            Comando.Parameters.AddWithValue("@NumVenta", Numero_ventas);
            Comando.Parameters.AddWithValue("@FechaFactura", Fecha_Factura);                //Creacion de la funcion que Realiza la insercion de la tabla (Correspondencia) desde la base de datos atraves de un procedimiento almacenado
            Comando.Parameters.AddWithValue("@Descuento", Descuento);
            Comando.Parameters.AddWithValue("@MontoFinal", Monto_Final);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void Insertar_Proovedor(string Nombre, long Telefono, string Pais, string Region, string Provincia, string Ciudad, string Calle, int No_Asociado, string Email)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarSuplidor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Nombre", Nombre);
            Comando.Parameters.AddWithValue("@Telefono", Telefono);
            Comando.Parameters.AddWithValue("@Pais", Pais);
            Comando.Parameters.AddWithValue("@Region", Region);
            Comando.Parameters.AddWithValue("@Provincia", Provincia);
            Comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            Comando.Parameters.AddWithValue("@Calle", Calle);
            Comando.Parameters.AddWithValue("@No_Asociado", No_Asociado);
            Comando.Parameters.AddWithValue("@Email", Email);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void Insertar_Venta(string Fecha)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Agregarventa";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Fecha", Fecha);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void Insertar_Empleado(string Nombre_Completo, long Telefono, string Horario, string Sexo, double Salario, DateTime Fecha_Ingreso, string Departamento, int Id_Sucursal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarEmpleado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@NombreCompleto", Nombre_Completo);
            Comando.Parameters.AddWithValue("@Telefono", Telefono);
            Comando.Parameters.AddWithValue("@Horario", Horario);
            Comando.Parameters.AddWithValue("@Sexo", Sexo);
            Comando.Parameters.AddWithValue("@Salario", Salario);
            Comando.Parameters.AddWithValue("@FechaIngreso", Fecha_Ingreso);
            Comando.Parameters.AddWithValue("@Departamento", Departamento);
            Comando.Parameters.AddWithValue("@IDSucursal", Id_Sucursal);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void Insertar_Cliente(int Cuenta, string Nombre_Completo, string Pais, string Region, string Provincia, string Ciudad, string Calle, long Telefono)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Cuenta", Cuenta);
            Comando.Parameters.AddWithValue("@NombreCompleto", Nombre_Completo);
            Comando.Parameters.AddWithValue("@Pais", Pais);
            Comando.Parameters.AddWithValue("@Region", Region);
            Comando.Parameters.AddWithValue("@Provincia", Provincia);
            Comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            Comando.Parameters.AddWithValue("@Calle", Calle);
            Comando.Parameters.AddWithValue("@Telefono", Telefono);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void Insertar_publicidad(string TipoPublicidad, string NombreArticulo, double Costo, DateTime FechaInicio, DateTime FechaFinal, int Id_Sucursal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarPublicidad";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@TipoPublicidad", TipoPublicidad);
            Comando.Parameters.AddWithValue("@NombreArticulo", NombreArticulo);
            Comando.Parameters.AddWithValue("@Costo", Costo);
            Comando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            Comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            Comando.Parameters.AddWithValue("IDSucursal", Id_Sucursal);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public DataTable Mostrar_Productos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarProducto";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Mostrar_CarritoCompras()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarCarritoCompras";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable Mostrar_Historial_Facturacion()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarFacturacion";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Mostrar_Empleados()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarEmpleado";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        
        public DataTable Mostrar_Ventas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Mostrar_Documento";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Mostrar_Suplidores()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarSuplidor";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Mostrar_Clientes()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarCliente";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Mostrar_Publicidad()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarPublicidad";
            Comando.CommandType = CommandType.StoredProcedure;       //Creacion de la funcion que Realiza la vista de la tabla Correspondencia en el datagridview desde la base de datos atraves de un procedimiento almacenado
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void Editar_Producto(int ID, string Marca,  string Categoria, string Descripcion, double Precio, int Cantidad_Existencia, int ID_Suplidor, int Id_Sucursal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update T_Producto set Marca='" + Marca + "',Categoria='" + Categoria + "', Descripcion='" + Descripcion + "', PrecioUnidad=" + Precio + ",CantidadExistencia=" + Cantidad_Existencia + ",IDSuplidor=" + ID_Suplidor + ",IDSucursal=" + Id_Sucursal + " WHERE  IDProducto=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }
        public void Editar_Empleado(int ID, string NombreCompleto, long Telefono, string Horario, string Sexo, double Salario, DateTime Fecha_Ingreso, string Departamento, int Id_Sucursal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update T_Empleado set NombreCompleto='" + NombreCompleto + "',Telefono=" + Telefono + ",Horario='" + Horario + "',Sexo='" + Sexo + "',Salario=" + Salario + ",FechaIngreso='" + Fecha_Ingreso + "', Departamento='" + Departamento + "',IDSucursal=" + Id_Sucursal + " WHERE IDEmpleado=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }
        public void Editar_Suplidores(int ID, string Nombre, long Telefono, string Pais, string Region, string Provincia, string Ciudad, string Calle, int No_Asociado, string Email )
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update T_Suplidor set Nombre='" + Nombre + "',Telefono=" + Telefono + ",Pais='" + Pais + "',Region='" + Region + "',Provincia='" + Provincia + "',Ciudad='" + Ciudad + "',Calle='" + Calle + "',No_Asociado=" + No_Asociado + ",Email='" + Email + "' WHERE IDSuplidor=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }
        public void Editar_Ventas(int ID, string Fecha) //este esta modificado LUIS CRUZ
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update t_Venta set Fecha='" + Fecha + " WHERE Idcodigo=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }

        public void Editar_inventario(int valor, int ID) //este esta modificado LUIS CRUZ
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "UPDATE T_Producto SET CantidadExistencia = CantidadExistencia - " + valor + " WHERE IDProducto=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }

        public void Descuento_Factura(double valor, int ID) //este esta modificado LUIS CRUZ
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "UPDATE T_Facturacion SET MontoFinal = MontoFinal - " + valor + " WHERE NumVenta=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }

        public void Editar_CarritoCompras(int ID, int IDCliente, int IDProducto, int Cantidad_Articulos, string Tipo_Factura, int Numero_Venta, DateTime Fecha_Factura, int Descuento, double Monto_Final)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update T_CarritoCompras set IDCliente =" + IDCliente + ",IDProducto =" + IDProducto + " ,CantidadArt=" + Cantidad_Articulos + ",TipoFactura='" + Tipo_Factura + "',NumVenta=" + Numero_Venta + ",FechaFactura='" + Fecha_Factura + "',Descuento=" + Descuento  + ",MontoFinal=" + Monto_Final + " WHERE IDFacturacion=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }

        public void Editar_Cliente(int ID, int Cuenta, string NombreCompleto, string Pais, string Region, string Provincia, string Ciudad, string Calle, long Telefono)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update T_Cliente set Cuenta =" + Cuenta + ",NombreCompleto='" + NombreCompleto + "',Telefono=" + Telefono + ",Pais='" + Pais + "',Region='" + Region + "',Provincia='" + Provincia + "',Ciudad='" + Ciudad + "',Calle='" + Calle + "',Telefono=" + Telefono + " WHERE IDCliente=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }

        public void Editar_Publicidad(int ID, string Tipo_Publicidad, string Nombre_Articulo, double Costo, DateTime Fecha_Inicio, DateTime Fecha_Final, int Id_Sucursal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update T_Publicidad set TipoPublicidad ='" + Tipo_Publicidad + "',NombreArticulo='" + Nombre_Articulo + "',Costo=" + Costo + ",FechaInicio='" + Fecha_Inicio + "',FechaFinal='" + Fecha_Final + "',IDSucursal=" + Id_Sucursal + " WHERE IDPublicidad=" + ID;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                   //Creacion de la funcion que Realiza la edicion de la tabla de una fila seleccionada de la tabla correspondencia
            Conexion.CerrarConexion();
        }

        public void Eliminar_Producto(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete T_Producto where IDProducto=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }
        public void Eliminar_Cliente(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete T_Cliente where IDCliente=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }
        public void Eliminar_Suplidor(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete T_Suplidor where IDSuplidor=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }

        public void Eliminar_Publicidad(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete T_Publicidad where IDPublicidad=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }

        public void Eliminar_Venta(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete t_Venta where Idcodigo=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }

        public void Eliminar_CarritoCompras(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete T_CarritoCompras where IDFacturacion=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }

        public void Eliminar_Empleado(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Delete T_Empleado where IDEmpleado=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }

        public void Eliminar_DATACarritoCompras(int Id_Item)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DELETE FROM T_CarritoCompras WHERE IDCliente=" + Id_Item;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();                                                  //Creacion de la funcion que Realiza la eliminacion de los datos de una fila seleccionada de la tabla correspondencia del db
            Conexion.CerrarConexion();
        }
        public DataTable Buscar(string Codificacion)
        {
            using (SqlConnection cn = new SqlConnection(DataBase.Conexion))       /*conexion db*/
            {
                Conexion.AbrirConexion();                               /*punto de conexion abierto*/
                Comando = new SqlCommand(Codificacion, cn);             /*comando para ejecucion*/
                dt = new SqlDataAdapter(Comando);                       /**/
                ta = new DataTable();
                dt.Fill(ta);                                          /*llenado de la tabla creada*/
                Conexion.CerrarConexion();                            /*punto de conexion cerrado*/
                return ta;                                            /*valor devuelto del procedimiento*/
            }
        }
    }
}
