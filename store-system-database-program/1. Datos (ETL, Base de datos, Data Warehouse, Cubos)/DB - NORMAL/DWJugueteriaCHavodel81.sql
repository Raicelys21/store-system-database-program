CREATE DATABASE DWJugueteriaCHavodel81

USE DWJugueteriaCHavodel81

CREATE TABLE Dim_Tiempo
(
	TiempoID INT IDENTITY(1,1) PRIMARY KEY,
	Ano varchar(20),
	Trimestre varchar(20),
	Mensual varchar(20),
	Semanal varchar(20),
	Dia varchar(20)
);

CREATE TABLE Dim_Suplidor
(
	SuplidorID int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(100),
	Pais varchar(100),
	Region varchar(100),
	Provincia varchar(100),
	Ciudad varchar(100),
	Calle varchar(100)
);

CREATE TABLE Dim_Producto
(
	ProductoID int IDENTITY(1,1) PRIMARY KEY,
	Marca varchar(100),
	Categoria varchar(100),
	Descripcion varchar(100),
	PrecioUnidad money,
	CantidadExistencia int,
	IDSuplidor int FOREIGN KEY REFERENCES Dim_Suplidor(SuplidorID)
);

CREATE TABLE Dim_Ubicacion
(
	UbicacionID int IDENTITY(1,1) PRIMARY KEY,
	Pais varchar(100),
	Region varchar(100),
	Provincia varchar(100),
	Ciudad varchar(100),
	Calle varchar(100)
);

CREATE TABLE Dim_Cliente
(
	ClienteID int IDENTITY(1,1) PRIMARY KEY,
	Cuenta varchar(100),
	NombreCompleto varchar(100),
	Pais varchar(100),
	Region varchar(100),
	Provincia varchar(100),
	Ciudad varchar(100),
	Calle varchar(100)
);

CREATE TABLE Dim_Factura
(
	FacturaID int IDENTITY(1,1) PRIMARY KEY,
	ProductoID int FOREIGN KEY REFERENCES Dim_Producto(ProductoID),
	MontoFinal money,
	FechaFactura date
);

CREATE TABLE Dim_Pago
(
	PagoID int IDENTITY(1,1) PRIMARY KEY,
	Salario money,
	Incentivo money
);

CREATE TABLE Dim_Publicidad
(
	PublicidadID int IDENTITY(1,1) PRIMARY KEY,
	TipoPublicidad varchar(100),
	Costo money,
	TiempoDuracion date
);

CREATE TABLE Dim_Empleado
(
	EmpleadoID int IDENTITY(1,1) PRIMARY KEY,
	NombreCompleto varchar(100),
	Horario varchar(100),
	Sexo varchar(100),
	Salario money,
	Departamento varchar(100)
);

CREATE TABLE Fact_Ventas
(
	FC_VentasID int IDENTITY(1,1) PRIMARY KEY,
	TiempoID int FOREIGN KEY REFERENCES Dim_Tiempo(TiempoID),
	FacturaID int FOREIGN KEY REFERENCES Dim_Factura(FacturaID),
	EmpleadoID int FOREIGN KEY REFERENCES Dim_Empleado(EmpleadoID),
	UbicacionID int FOREIGN KEY REFERENCES Dim_Ubicacion(UbicacionID),
	SuplidorID int FOREIGN KEY REFERENCES Dim_Suplidor(SuplidorID),
	ClienteID int FOREIGN KEY REFERENCES Dim_Cliente(ClienteID),
	ProductoID int FOREIGN KEY REFERENCES Dim_Producto(ProductoID),
	PronosticoDeVentas INT,
	MargenDeVentas INT,
	CantidadDeFacturacion INT,
	VentasActuales INT
);

CREATE TABLE Fact_Compras
(
	FC_ComprasID int IDENTITY(1,1) PRIMARY KEY,
	TiempoID int FOREIGN KEY REFERENCES Dim_Tiempo(TiempoID),
	FacturaID int FOREIGN KEY REFERENCES Dim_Factura(FacturaID),	
	SuplidorID int FOREIGN KEY REFERENCES Dim_Suplidor(SuplidorID),
	ProductoID int FOREIGN KEY REFERENCES Dim_Producto(ProductoID),
	UbicacionID int FOREIGN KEY REFERENCES Dim_Ubicacion(UbicacionID),
	ProyeccionDeCompras INT,
	PresupuestoDeCompras INT,
	ComprasActuales INT
);

CREATE TABLE Fact_RRHH
(
	FC_RRHHID int IDENTITY(1,1) PRIMARY KEY,
	EmpleadoID int FOREIGN KEY REFERENCES Dim_Empleado(EmpleadoID),
	PagoID int FOREIGN KEY REFERENCES Dim_Pago(PagoID),
	UbicacionID int FOREIGN KEY REFERENCES Dim_Ubicacion(UbicacionID),
	CantidadDeEmpleomania INT,
	MontoSalarial MONEY,
	PresupuestoDeBonificaciones INT
);

CREATE TABLE Fact_Publicidad
(
	FC_PublicidadID int IDENTITY(1,1) PRIMARY KEY,
	TiempoID int FOREIGN KEY REFERENCES Dim_Tiempo(TiempoID),
	ProductoID int FOREIGN KEY REFERENCES Dim_Producto(ProductoID),
	SuplidorID int FOREIGN KEY REFERENCES Dim_Suplidor(SuplidorID),
	PublicidadID int FOREIGN KEY REFERENCES Dim_Publicidad(PublicidadID),
	PresupuestoDePublicidad INT,
	MediosDeLosProductosPublicitados varchar(100),
	ComprasPublicaciones INT,
	CantidadDePublicidad INT
);

CREATE TABLE Fact_ServicioAlCliente
(
	FC_ServicioAlClienteID int IDENTITY(1,1) PRIMARY KEY,
	TiempoID int FOREIGN KEY REFERENCES Dim_Tiempo(TiempoID),
	EmpleadoID int FOREIGN KEY REFERENCES Dim_Empleado(EmpleadoID),
	ClienteID int FOREIGN KEY REFERENCES Dim_Cliente(ClienteID),
	FacturaID int FOREIGN KEY REFERENCES Dim_Factura(FacturaID),
	UbicacionID int FOREIGN KEY REFERENCES Dim_Ubicacion(UbicacionID),
	CantidadDeClientesAfiliados INT,
	ClientesActuales INT,
	TasaDeRetencionDeClientes INT
);

CREATE TABLE Fact_Inventario
(
	FC_InventarioID int IDENTITY(1,1) PRIMARY KEY,
	TiempoID int FOREIGN KEY REFERENCES Dim_Tiempo(TiempoID),
	FacturaID int FOREIGN KEY REFERENCES Dim_Factura(FacturaID),
	ProductoID int FOREIGN KEY REFERENCES Dim_Producto(ProductoID),
	UbicacionID int FOREIGN KEY REFERENCES Dim_Ubicacion(UbicacionID),
	SuplidorID int FOREIGN KEY REFERENCES Dim_Suplidor(SuplidorID),
	PresupuestoDeInventario money,
	CantidadDeInventario INT,
	--ReporteDeRendimiento varchar(100),
	InventarioActual INT,
	CostoDeInventario money
);

CREATE TABLE Fact_Facturacion
(
	FC_FacturacionID int IDENTITY(1,1) PRIMARY KEY,
	TiempoID int FOREIGN KEY REFERENCES Dim_Tiempo(TiempoID),
	EmpleadoID int FOREIGN KEY REFERENCES Dim_Empleado(EmpleadoID),
	UbicacionID int FOREIGN KEY REFERENCES Dim_Ubicacion(UbicacionID),
	FacturaID int FOREIGN KEY REFERENCES Dim_Factura(FacturaID),
	ProductoID int FOREIGN KEY REFERENCES Dim_Producto(ProductoID),
	ClienteID int FOREIGN KEY REFERENCES Dim_Cliente(ClienteID),
	ControlDeActividad varchar(100),
	ReportesDeIngresos Varchar(100),
	GastosFacturados INT
);