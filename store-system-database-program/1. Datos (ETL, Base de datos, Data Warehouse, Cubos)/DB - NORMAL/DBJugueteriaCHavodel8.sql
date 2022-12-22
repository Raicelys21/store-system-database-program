CREATE DATABASE DBJugueteriaCHavodel8

USE DBJugueteriaCHavodel8

CREATE TABLE loginapp(
	id int IDENTITY(1,1) PRIMARY KEY,
	usuario varchar(25),
	contrasena varchar(20)
);

insert into loginapp values ('lcruz@ndv.com','123456789')
insert into loginapp values ('rsuero@ndv.com','123456789')
insert into loginapp values ('fchalas@ndv.com','123456789')
insert into loginapp values ('cjorge@ndv.com','123456789')

create table loguin(
Usuario nvarchar(25),
contrasena nvarchar(50),
tipo_usuario nvarchar(50))

select * from loguin 

insert into loguin values ('Lcruz','1234','usuario')
insert into loguin values ('Fcordero','1234','usuario')
insert into loguin values ('admin','uaf*1234','superusuario')


CREATE TABLE T_Suplidor
(
    IDSuplidor int IDENTITY(1,1) PRIMARY KEY,
    Nombre varchar(100),
    Telefono bigint,
    Pais varchar(100),
    Region varchar(100),
    Provincia varchar(100),
    Ciudad varchar(100),
    Calle varchar(100),
    No_Asociado int,
    Email varchar(100)
);

CREATE TABLE T_Sucursal
(
    IDSucursal int IDENTITY(1,1) PRIMARY KEY,
    Nombre varchar(100),
    Region varchar(100),
    Provincia varchar(100),
    Ciudad varchar(100),
    Calle varchar(100),
    Pais varchar(100)
);

CREATE TABLE T_Publicidad
(
    IDPublicidad int IDENTITY(1,1) PRIMARY KEY,
    TipoPublicidad varchar(100),
    NombreArticulo varchar(100),
    Costo money,
    FechaInicio date,
    FechaFinal date,
    IDSucursal int FOREIGN KEY REFERENCES T_Sucursal(IDSucursal)
);

CREATE TABLE T_Producto
(
    IDProducto int IDENTITY(1,1) PRIMARY KEY,
    Marca varchar(100),
    Categoria varchar(100),
    Descripcion varchar(100),
    PrecioUnidad money,
    CantidadExistencia int,
    IDSuplidor int FOREIGN KEY REFERENCES T_Suplidor(IDSuplidor),
    IDSucursal int FOREIGN KEY REFERENCES T_Sucursal(IDSucursal),
    IDPublicidad int FOREIGN KEY REFERENCES T_Publicidad(IDPublicidad)
);

CREATE TABLE T_Cliente
(
    IDCliente int IDENTITY(1,1) PRIMARY KEY,
    Cuenta varchar(100),
    NombreCompleto varchar(100),
    Pais varchar(100),
    Region varchar(100),
    Provincia varchar(100),
    Ciudad varchar(100),
    Calle varchar(100),
    Telefono bigint,
);

CREATE TABLE T_Facturacion
(
    IDFacturacion int IDENTITY(1,1) PRIMARY KEY,
    IDCliente int FOREIGN KEY REFERENCES T_Cliente(IDCliente),
    IDProducto int FOREIGN KEY REFERENCES T_Producto(IDProducto),
    CantidadArt int,
    TipoFactura varchar(100),
    NumVenta int,
    FechaFactura date,
    Descuento int,
    MontoFinal money
);

CREATE TABLE T_CarritoCompras
(
    IDFacturacion int IDENTITY(1,1) PRIMARY KEY,
    IDCliente int FOREIGN KEY REFERENCES T_Cliente(IDCliente),
    IDProducto int FOREIGN KEY REFERENCES T_Producto(IDProducto),
    CantidadArt int,
    TipoFactura varchar(100),
    NumVenta int,
    FechaFactura smalldatetime,
    Descuento int,
    MontoFinal money
);

CREATE TABLE T_Empleado
(
    IDEmpleado int IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto varchar(100),
    Telefono bigint,
    Horario varchar(100),
    Sexo varchar(100),
    Salario money,
    FechaDeIngreso DATETIME,
    Departamento varchar(100),
    IDSucursal int FOREIGN KEY REFERENCES T_Sucursal(IDSucursal)
);

CREATE TABLE T_Compras
(
    IDCompras int IDENTITY(1,1) PRIMARY KEY,
    IDSuplidor int FOREIGN KEY REFERENCES T_Suplidor(IDSuplidor),
    IDProducto int FOREIGN KEY REFERENCES T_Producto(IDProducto),
    PrecioCompra money,
    FechaCompra date,
    IDSucursal int FOREIGN KEY REFERENCES T_Sucursal(IDSucursal)
);

INSERT INTO T_Suplidor
    (Nombre, Telefono, Pais, Region, Provincia, Ciudad, Calle, No_Asociado, Email)
VALUES
    ('MosciskiFunk', 9088608911, 'Serbia', 'Phillipsburg', 'Utah', 'Dimitrovgrad', '93 Victoria Center', 364257039, 'omcallaster@nytimes.com'),
    ('Reilly, Anderson and Jacobi', 7969997503, 'Peru', 'Loretto Road', 'District of Columbia', 'Huasahuasi', '55240 Cherokee Plaza', 543071344, 'mchalfain1@rambler.ru'),
    ('Fadel, Johnston and Ziemann', 8819045189, 'Thailand', 'Georgetown', 'Georgia', 'Plaeng Yao', '1 Lerdahl Park', 19427996, 'hkeld2@sphinn.com'),
    ('Rempel LLC', 9975246770, 'China', 'Village Of Mingo', 'Arkansas', 'Baziqiao', '4 American Parkway', 299068636, 'cpley3@about.me'),
    ('BuckridgeHansen', 1614056754, 'China', 'South Excello', 'Ontario', 'Huaminglou', '68 Oneill Place', 308245943, 'bpeter4@php.net'),
    ('RippinWilkinson', 4738656100, 'China', 'Messines', 'Prince Edward Island', 'Yuguan', '4 Weeping Birch Point', 431543829, 'tkerrich5@howstuffworks.com'),
    ('HamillRyan', 4362632819, 'United States', 'Quantico', 'District of Columbia', 'San Francisco', '879 Loeprich Circle', 927196680, 'clygo6@japanpost.jp'),
    ('BechtelarWilliamson', 4497725487, 'Japan', 'Teton Village', 'Arkansas', 'Naha-shi', '49657 Eagle Crest Trail', 497629019, 'mdielhenn7@businessweek.com'),
    ('Ondricka LLC', 9836225117, 'Slovenia', 'Cornwell', 'Prince Edward Island', 'Slovenski Javornik', '8 Cardinal Terrace', 55211151, 'sburel8@pcworld.com'),
    ('Weimann, Mills and Luettgen', 4304355664, 'China', 'Sandy Hill Acres', 'Newfoundland', 'Dongdai', '4 Weeping Birch Pass', 85281312, 'awinston9@sphinn.com'),
    ('Upton, Baumbach and Kozey', 5547579893, 'Peru', 'Old Sycamore Estates', 'Nevada', 'Piura', '4223 Marcy Plaza', 919044458, 'acramphorna@google.co.uk'),
    ('Kshlerin LLC', 2362891960, 'China', 'South Waverly', 'Idaho', 'Xiangying', '47156 Golf Drive', 246822685, 'mbrackleyb@independent.co.uk'),
    ('Krajcik Inc', 3915786928, 'China', 'Coldbrook', 'Oklahoma', 'Tonggu', '5553 Carberry Trail', 548423792, 'aleckenbyc@adobe.com'),
    ('Collier and Sons', 6028930272, 'Indonesia', 'Mcdonald', 'Texas', 'Pekalongan', '9 Moose Terrace', 4384301, 'etrenemand@gnu.org'),
    ('Schulist Inc', 2363442608, 'Canada', 'Newfield', 'North Carolina', 'Lumby', '207 Mallory Road', 835808229, 'mrummerye@edublogs.org'),
    ('Senger, Kohler and Botsford', 7369358737, 'Portugal', 'Bellevue', 'New York', 'Rio Covo', '4221 Crowley Alley', 661158553, 'astrodderf@twitter.com'),
    ('Satterfield, Champlin and Feil', 9383262959, 'Poland', 'Downingtown', 'Utah', 'Bogus-Gorce', '40720 Forest Park', 314507669, 'nghidinig@wisc.edu'),
    ('Goyette LLC', 8711460990, 'Peru', 'Elm Tree', 'Tennessee', 'Chambara', '0 Amoth Park', 922731955, 'ieaggerh@ocn.ne.jp'),
    ('Zulauf Inc', 3817676824, 'Democratic Republic of the Congo', 'Hickory Tree', 'Georgia', 'Tshela', '4 Susan Place', 521576977, 'bfoystonei@columbia.edu'),
    ('WhiteStoltenberg', 2239846316, 'Indonesia', 'Forest Chapel', 'Michigan', 'Sampangan', '9137 Annamark Way', 813166046, 'cdionisj@naver.com'),
    ('West LLC', 3661822942, 'Russia', 'Granville Center', 'California', 'Tetyushi', '0 Oak Valley Point', 845464328, 'swoolaghank@networkadvertising.org'),
    ('JohnstonAnkunding', 7685849835, 'China', 'Navina', 'Kansas', 'Dogarmo', '6 Fairfield Point', 799734436, 'dpaddockl@alexa.com'),
    ('SchimmelKoepp', 5144415530, 'China', 'Branch', 'Kansas', 'Dayuan', '8824 Doe Crossing Junction', 557626026, 'nheatheringtonm@disqus.com'),
    ('West, Marks and Buckridge', 1358688131, 'Slovenia', 'East Orwell', 'Nevada', 'Slovenska Bistrica', '5 Bayside Drive', 41249547, 'wgrzelczakn@listmanage.com'),
    ('GerholdGaylord', 6926050961, 'Serbia', 'Lakonta', 'Wisconsin', 'Jazovo', '6 Cardinal Pass', 47637548, 'vizzetto@infoseek.co.jp'),
    ('JacobsonMohr', 3031312785, 'China', 'Denmark', 'Texas', 'Shuangshi', '43 Grover Drive', 213524231, 'smoscop@naver.com'),
    ('Reichel, Marquardt and Walsh', 2499951162, 'Indonesia', 'Stewart', 'Washington', 'Orong', '9 Eastwood Plaza', 877168276, 'zblackburnq@google.cn'),
    ('Lindgren and Sons', 2489419629, 'China', 'Queen Anne', 'Tennessee', 'Yitang', '2100 Bartillon Parkway', 882621517, 'zgostickr@yelp.com'),
    ('Howell, Pfeffer and Bernier', 6404056299, 'Indonesia', 'Princetown', 'New Jersey', 'Banjar Medura', '56898 Morrow Hill', 791431061, 'averns@twitter.com'),
    ('HauckSchneider', 4189776352, 'Serbia', 'Houston', 'Georgia', 'Samo≈°', '15 Brown Parkway', 934879309, 'jmcgaugheyt@yelp.com'),
    ('BlockDavis', 8296530895, 'Peru', 'West Caldwell', 'North Dakota', 'Malvas', '7 Tony Crossing', 860161121, 'rdoolyu@nsw.gov.au'),
    ('Muller LLC', 1402790998, 'Liberia', 'Tresend', 'Florida', 'Buutuo', '1936 Rowland Lane', 714441252, 'dvockinsv@alexa.com'),
    ('Medhurst Inc', 3233484985, 'China', 'Shrum', 'Kentucky', 'Baiyang', '429 Dahle Avenue', 626612821, 'krogisterw@timesonline.co.uk'),
    ('Satterfield, Champlin and Littel', 7738690380, 'Ukraine', 'Lake Lindsey', 'Kentucky', 'Bilhorod-DnistrovsÄôkyy', '1914 Autumn Leaf Crossing', 489130286, 'moutrightx@xrea.com'),
    ('Kub, Fritsch and Runolfsdottir', 4473537799, 'Malawi', 'Rienze', 'District of Columbia', 'Mulanje', '0257 Hayes Hill', 526637377, 'edressery@quantcast.com'),
    ('MarvinRolfson', 4169301619, 'United States', 'Centura West', 'Colorado', 'Orlando', '00132 Basil Crossing', 242510840, 'srosebothamz@adobe.com'),
    ('SchillerBeatty', 2692058082, 'Nigeria', 'Kittys Corner', 'Oregon', 'Wawa', '96 Waywood Lane', 825483230, 'kgeraghty10@woothemes.com'),
    ('MoenAltenwerth', 6096626506, 'China', 'Higden', 'Nova Scotia', 'Tuqiao', '30207 Spenser Parkway', 586090635, 'isterricker11@1und1.de'),
    ('Zemlak, Metz and Harvey', 3953305776, 'Sweden', 'Willow Springs', 'Tennessee', 'Alings', '9 3rd Way', 341458868, 'sasee12@google.it'),
    ('Altenwerth, Kunze and Hauck', 7358742504, 'United States', 'Wilmot', 'Oregon', 'El Paso', '476 Duke Avenue', 775439415, 'lgurden13@cafepress.com'),
    ('Murphy Inc', 2174383617, 'Poland', 'Bidwell', 'Wyoming', 'Grojec', '43 Pawling Lane', 220800450, 'hsarsons14@nymag.com'),
    ('Grady, Langosh and Reynolds', 4817121041, 'Slovenia', 'Mechanicsburg', 'California', 'Hodo≈°', '3 Spaight Lane', 863850908, 'llimeburn15@squidoo.com'),
    ('KuhicCrooks', 5663047798, 'Nigeria', 'Lupine Village', 'Arkansas', 'Boju', '51740 Orin Hill', 645482618, 'ncrowcroft16@canalblog.com'),
    ('Predovic, Christiansen and Bogisich', 2719505024, 'Macedonia', 'Donnellson', 'Vermont', 'Bogovinje', '73 Eagan Drive', 666422806, 'fimloch17@blogtalkradio.com'),
    ('Armstrong Inc', 8335245021, 'Luxembourg', 'Gilead', 'New York', 'Waldbillig', '248 Dapin Parkway', 763679560, 'ghelks18@lulu.com'),
    ('Blanda, Wisozk and Corwin', 5756455774, 'China', 'Horsegall', 'Washington', 'Laotai', '9308 Melrose Point', 995128128, 'tsindell19@foxnews.com'),
    ('O''''Hara and Sons', 6456261687, 'Croatia', 'Pierce Crossing', 'Nevada', 'Biograd na Moru', '52 orway Maple Parkway', 59477124, 'tsprott1a@umn.edu'),
    ('Bernier Inc', 5062525484, 'China', 'Deer Creek', 'Quebec', 'Haiyan', '2 Almo Pass', 891023959, 'ccuer1b@imdb.com'),
    ('Feest LLC', 2728270677, 'Azerbaijan', 'Hyde Park', 'Utah', 'Amirdzhan', '0 Bellgrove Center', 373460499, 'tcallum1c@blogs.com'),
    ('Altenwerth, Nikolaus and Rosenbaum', 8679612723, 'Cuba', 'Swift', 'Prince Edward Island', 'La Salud', '828 Grayhawk Junction', 874521272, 'tralph1f@squarespace.com');

INSERT INTO T_Sucursal
    (Nombre, Region, Provincia, Ciudad, Calle, Pais)
VALUES
    ('Tienda Lope de Vega', 'Este', 'Distrito Nacional', 'Santo Domingo', 'Avenida Roberto Pastoriza no.5 Esquina', 'Republica Dominicana'),
    ('Tienda Megacentro', 'Este', 'Santo Domingo Este', 'Santo Domingo Este', 'Av San Vicente de Paú', 'Republica Dominicana'),
    ('Tienda Sambil', 'Este', 'Distrito Nacional', 'Santo Domingo', 'Sambil Nivel Galería Frente a la Pescera', 'Republica Dominicana'),
    ('Tienda Galería 360', 'Este', 'Distrito Nacional', 'Santo Domingo', 'Galeria 360, Av. John F. Kennedy', 'Republica Dominicana'),
    ('Tienda Downtown Mall', 'Este', 'Altagracia', 'Punta Cana', 'Avenida Barcelo Km 8', 'Republica Dominicana'),
    ('Show Room y Ventas al Por Mayor', 'Este', 'Distrito Nacional', 'Santo Domingo', 'Prolongación Rómulo Betancourt No. 5 (Casi esq. Luperón) Zona Industrial de Herrera', 'Republica Dominicana');

INSERT INTO T_Publicidad
    (TipoPublicidad, NombreArticulo, Costo, FechaInicio, FechaFinal, IDSucursal)
VALUES
    ('Publicidad online', 'Tragabolas', 8765, '2021-04-06', '2022-04-10', 1),
    ('Publicidad online', 'Hot Wheels', 1712, '2021-07-20', '2022-01-23', 1),
    ('Publicidad online', 'Barbie', 2841, '2021-10-19', '2022-06-28', 1),
    ('Publicidad online', 'Action Man', 2599, '2021-06-16', '2022-08-30', 1),
    ('Publicidad online', 'Risk', 5181, '2021-05-07', '2022-03-11', 1),
    ('Publicidad online', 'Pictionary', 1938, '2021-07-30', '2022-05-24', 1),
    ('Publicidad online', 'Parchís', 7165, '2021-03-05', '2022-05-10', 1),
    ('Publicidad online', 'HeroQuest', 8506, '2021-03-11', '2022-08-03', 1),
    ('Publicidad online', 'Conecta Cuatro', 2740, '2021-09-25', '2022-04-08', 2),
    ('Publicidad online', 'Operación', 5592, '2021-06-02', '2022-01-05', 2),
    ('Publicidad online', 'UNO', 9958, '2021-09-28', '2022-09-21', 2),
    ('Publicidad online', 'Monopoly', 6567, '2021-07-21', '2022-10-07', 2),
    ('Publicidad online', 'Torre de entrenamiento SuperThings', 3119, '2021-08-14', '2022-01-21', 2),
    ('Publicidad online', 'Laboratorio para crear y decorar globos de Bubiloons', 173, '2021-08-05', '2022-09-24', 2),
    ('Publicidad online', 'Bebés llorones, Dressy Coney el conejo', 3075, '2021-03-21', '2022-10-03', 2),
    ('Publicidad online', 'Paquete de seis bolas Pokémon', 200, '2021-09-09', '2022-08-02', 2),
    ('Publicidad online', 'Muñecas mini perritas Vip Pets', 2601, '2021-05-28', '2022-01-31', 3),
    ('Publicidad online', 'Vehículo Ballon Boxer de Superthings', 8130, '2021-02-10', '2022-03-28', 3),
    ('Publicidad online', 'Castillo del baile real, Royal Enchantimals', 162, '2021-06-05', '2022-03-04', 3),
    ('Publicidad online', 'Play-Doh Ultimate Color Collection', 6349, '2021-03-15', '2022-08-06', 3),
    ('Anuncios de televisión', 'Heladería Melissa Doug', 6281, '2021-08-07', '2022-09-01', 3),
    ('Anuncios de televisión', 'Bluey Mega Bundle Home, juego de barbacoa', 8823, '2021-10-05', '2022-06-09', 3),
    ('Anuncios de televisión', 'Atmosfear', 2668, '2021-05-17', '2022-01-11', 3),
    ('Anuncios de televisión', 'Cranium', 4619, '2021-01-01', '2022-01-03', 3),
    ('Anuncios de televisión', 'Subbuteo', 3154, '2021-07-13', '2022-07-01', 4),
    ('Anuncios de televisión', 'Trivial Pursuit', 4436, '2021-06-01', '2022-07-19', 4),
    ('Anuncios de televisión', 'Hundir la Flota', 4235, '2021-03-12', '2022-07-10', 4),
    ('Anuncios de televisión', 'Scrabble', 9280, '2021-03-02', '2022-09-27', 4),
    ('Anuncios de televisión', 'Cubo de Rubik', 2362, '2021-02-09', '2022-07-11', 4),
    ('Anuncios de televisión', 'Magna Doodle', 4231, '2021-05-16', '2022-02-11', 4),
    ('Anuncios de televisión', 'Nerf', 3070, '2021-01-14', '2022-03-15', 4),
    ('Anuncios de televisión', 'Twister', 6407, '2021-07-01', '2022-05-11', 4),
    ('Anuncios de televisión', 'Truck Mack 12 Volt con Luces y Sonidos', 2804, '2021-03-10', '2022-07-07', 5),
    ('Anuncios de televisión', 'Bicicleta Aro 20 - Spectre', 790, '2021-09-01', '2022-03-10', 5),
    ('Anuncios de televisión', 'Beyblade - Un Slingshock Tops Surtido', 9350, '2021-04-29', '2022-05-21', 5),
    ('Anuncios de televisión', 'Create a Bot Insectos Hormiga', 4586, '2021-05-04', '2022-06-09', 5),
    ('Anuncios de televisión', 'Spiderman', 6205, '2021-04-10', '2022-03-05', 2),
    ('Anuncios de televisión', 'Bocinas Portátil', 120, '2021-01-17', '2022-05-19', 2),
    ('Anuncios de televisión', 'Trampolín', 9662, '2021-04-21', '2022-07-30', 1),
    ('Anuncios de televisión', 'Skateboard', 2875, '2021-02-06', '2022-09-11', 2),
    ('Telemarketing', 'Piscina', 8274, '2021-06-30', '2022-06-18', 3),
    ('Telemarketing', 'Tubo Flotador', 850, '2021-08-09', '2022-03-22', 4),
    ('Telemarketing', 'Piscina Estructura', 9967, '2021-10-05', '2022-10-10', 5),
    ('Telemarketing', 'Fisher Price', 1193, '2021-02-25', '2022-03-18', 6),
    ('Telemarketing', 'Pj Mask', 3754, '2021-08-26', '2022-05-26', 6),
    ('Telemarketing', 'Air Hogs Gravitor', 2961, '2021-07-02', '2022-04-19', 6),
    ('Telemarketing', 'Disfraz para Niño', 743, '2021-04-14', '2022-08-09', 6),
    ('Telemarketing', 'Disfraz para Niño', 743, '2021-04-01', '2022-05-12', 6),
    ('Telemarketing', 'Baby Alive', 4781, '2021-09-28', '2022-08-26', 6),
    ('Telemarketing', 'Muñeca 18 pulgadas', 1745, '2021-01-04', '2022-06-09', 6);

INSERT INTO T_Producto
    (Marca, Categoria, Descripcion, PrecioUnidad, CantidadExistencia, IDSuplidor, IDSucursal, IDPublicidad)
VALUES
    ('Tragabolas','Estrategia','Cuatro jugadores y cuatro hambrientos, hambrientos hipopótamos.',8765,733,1,1,1),
    ('Hot Wheels','Carros','Set de carros + pista de carreras',1712,114,2,1,2),
    ('Barbie','Muñecas','Juguete Barbie rubia con accesorios',2841,404,3,1,3),
    ('Action Man','Muñecos','Juguete ActionMan moreno con accesorios',2599,770,4,1,4),
    ('Risk','Estrategia','Para tardes de lluvia',5181,917,5,1,5),
    ('Pictionary','Dibujar','Adivinar una palabra a través de un dibujo',1938,6,6,1,6),
    ('Parchís','Estrategia','Siempre van juntos',7165,18,7,1,7),
    ('HeroQuest','Cartas','Dragones & Mazmorras',8506,141,8,1,8),
    ('Conecta Cuatro','Estrategia','Consiste en enganchar cuatro del mismo color.',2740,535,9,1,9),
    ('Operación','Estrategia','Operar sin matar al paciente',5592,827,10,1,10),
    ('UNO','Cartas','Nuevas reglas',9958,39,11,2,11),
    ('Monopoly','Estrategia','Aplastar a la competencia hasta la bancarrota',6567,674,1,2,12),
    ('Torre de entrenamiento SuperThings','muñecos','set héroe o villano ',3119,43,13,2,13),
    ('Laboratorio para crear y decorar globos de Bubiloons','animales coleccionables','Inflar distintos globos y decorarlos.',173,350,14,2,14),
    ('Bebés llorones, Dressy Coney el conejo','muñeca','capaz de llorar cuando pierde su chupete',3075,727,15,2,15),
    ('Paquete de seis bolas Pokémon','Muñecos','kit de seis figuras',200,342,16,2,16),
    ('Muñecas mini perritas Vip Pets','Muñecas','Juguete con accesorios',2601,1000,17,2,17),
    ('Vehículo Ballon Boxer de Superthings','Carros','vehículo que ofrece múltiples acciones',8130,564,18,2,18),
    ('Castillo del baile real, Royal Enchantimals','muñecas','El kit incluye también la muñeca de Felicity Fox',162,746,19,2,19),
    ('PlayDoh Ultimate Color Collection','masilla','un paquete con 65 masitas',6349,942,20,2,20),
    ('Heladería Melissa Doug','educativo','Incluye ocho sabores de helado, seis cubiertas, dos conos, un vasito y dos cucharas',6281,523,21,3,21),
    ('Bluey Mega Bundle Home, juego de barbacoa','educativo','Las cuatro figuras incluidas está Bluey, Bingo, Chilli (la mamá) y Bandit (el papá)',8823,602,22,3,22),
    ('Atmosfear','tablero','Recolectar llaves',2668,767,23,3,23),
    ('Cranium','juegos de mesa','Práctica diferentes habilidades cerebrales',4619,457,24,3,24),
    ('Subbuteo','juegos de mesa','Llevar a tus once muchachos hasta la victoria a base de toquecitos con los dedos.',3154,818,25,3,25),
    ('Trivial Pursuit','Cartas','Cultura general',4436,877,26,3,26),
    ('Hundir la Flota','Estrategia','Con lápiz y papel.',4235,31,27,3,27),
    ('Scrabble','Estrategia','Un tablero de 15x15',9280,33,28,4,28),
    ('Cubo de Rubik','Estrategia','Intentar resolverlo',2362,410,29,4,29),
    ('Magna Doodle','Dibujar','Pizarra magnética',4231,308,30,4,30),
    ('Nerf','accion','Armas de plástico',3070,982,31,4,31),
    ('Twister','juego de habilidad','Tocar todos los colores',6407,957,32,4,32),
    ('Truck Mack 12 Volt con Luces y Sonidos','Carro Batería','Con Luces y Sonidos',2804,126,33,4,33),
    ('Bicicleta Aro 20  Spectre','Bicicletas','Bicicleta Aro 20  Spectre',790,12,34,5,34),
    ('Beyblade  Un Slingshock Tops Surtido','Figuras Acción','Beyblade  Un Slingshock Tops Surtido',9350,66,35,5,35),
    ('Create a Bot Insectos Hormiga','Figuras Acción','Diviértete montando tu insectorobot Build a Bot',4586,741,36,5,36),
    ('Spiderman','Figuras Acción','Figura Pelicula 6 Pulgadas.',6205,626,37,5,37),
    ('Bocinas Portátil','Juegos Electrónicos','Bocinas Portátil Bluetooth Pequeñas',120,617,38,5,38),
    ('Trampolín','Deportivos','Trampolín 6 pies con Malla de Seguridad',9662,704,39,6,39),
    ('Skateboard','Deportivos','Skateboard Ripstick Caster  Azul Ffp',2875,751,40,6,40),
    ('Piscina','Piscina','Piscina lateral Suave 74 Pulgadas X 18 Pulgadas 3+',8274,116,41,6,41),
    ('Tubo Flotador','Piscina','Monster Fun Noodle, Colores surtidos.',850,723,42,6,42),
    ('Piscina Estructura','Piscina','Piscina Estructura Prisma 15px48pul 6+',9967,738,43,6,43),
    ('Fisher Price','Musicales','Da vida a los sueños de estrellato de tu pequeño con el Ríe',1193,183,44,6,44),
    ('Pj Mask','Musicales','Con figuras movibles',3754,952,45,6,45),
    ('Air Hogs Gravitor','Aviones','Realiza movimientos de vuelo en gravedad cero con el poder de tus manos',2961,381,46,6,46),
    ('Disfraz para Niño','Disfraces','Disfraz para Niño  Chef de Lujo',743,86,47,6,47),
    ('Vestido Kruselings ','Disfraces','Vestido Kruselings Magico Joy.',255,574,48,6,48),
    ('Baby Alive','muñeca','Da vida a tus historias con Littles by Baby Alive',4781,455,49,6,49),
    ('Muñeca 18 pulgadas','muñeca','Muñeca 18 pulgadas  EMT Pro Kaylin',1745,437,50,6,50);

INSERT INTO T_Cliente
    (Cuenta, NombreCompleto, Pais, Region, Provincia, Ciudad, Calle, Telefono)
VALUES
    (234214578, 'Abraham Fraschetti', 'República Dominicana', 'Cibao Central', 'La Vega', 'Concepcion de La Vega', 'Mz 21 No 21, Caobas', 8095616427),
    (235145643, 'Iolande Beaver', 'República Dominicana', 'Cibao Central', 'Monseñor Nouel', 'Monseñor Nouel', 'N Heredia 6', 8093802415),
    (233213245, 'Blakelee Gwynne', 'República Dominicana', 'Cibao Central', 'Sánchez Ramírez', 'Sánchez Ramírez', 'Florencia 2', 8092890345),
    (982470656, 'Jackqueline Kurton', 'República Dominicana', 'Del Valle', 'Azua', 'Azua', ' F Villaespesa 2', 8092961162),
    (735149457, 'Inger Demann', 'República Dominicana', 'Del Valle', 'Elías Piña', 'Elías Piña', 'A Larancuent 63', 8098139999),
    (955923010, 'Casie Lehr', 'República Dominicana', 'Del Valle', 'San Juan', 'San Juan', 'Resp M Montés 9', 8096210295),
    (448325117, 'Rowland Sabben', 'República Dominicana', 'Distrito Nacional', 'Nuevo Distrito Nacional', 'Santo Domingo', 'Prol Independencia Km 10', 8092870113),
    (660600987, 'Corny Blest', 'República Dominicana', 'Distrito Nacional', 'Santo Domingo Este', 'Santo Domingo Este', 'Carr Mella 83  San Pedro de Macorís', 8092469742),
    (315291238, 'Marley Burkhill', 'República Dominicana', 'Distrito Nacional', 'Santo Domingo Norte', 'Santo Domingo Norte', 'J Erazo 2', 8092387418),
    (721933950, 'Benn Andrichak', 'República Dominicana', 'Distrito Nacional', 'Santo Domingo Oeste', 'Santo Domingo Oeste', 'San Cristóbal 7A', 8095365159),
    (632172703, 'Evelyn Mance', 'República Dominicana', 'Enriquillo', 'Bahoruco', 'Bahoruco', 'J Incháustegui 29', 8093801632),
    (325734476, 'Mendel Batts', 'República Dominicana', 'Enriquillo', 'Barahona', 'Barahona', 'Mcdo Público  San Pedro de Macorís', 8095295856),
    (609674041, 'Judd Berceros', 'República Dominicana', 'Enriquillo', 'Independencia', 'Independencia', 'C Bona 100', 8092385013),
    (228352478, 'Urbano Wathall', 'República Dominicana', 'Enriquillo', 'Pedernales', 'Pedernales', 'Av P L Cedeño 41', 8095387813),
    (702749673, 'Irving Lydall', 'República Dominicana', 'Este', 'El Seibo', 'El Seibo', 'Duarte 1', 8095384283),
    (959565754, 'Marc Freeborne', 'República Dominicana', 'Este', 'Hato Mayor', 'Hato Mayor', '16 De Agosto 59', 8295822712),
    (7993607606, 'Zenia Pedri', 'República Dominicana', 'Este', 'La Altagracia', 'La Altagracia', 'M T Sánchez 3', 8095997441),
    (235323812, 'Arielle Thyer', 'República Dominicana', 'Este', 'La Romana', 'La Romana', 'Carr Luperón 3', 8095819020),
    (622983081, 'Konstanze MacLachlan', 'República Dominicana', 'Este', 'San Pedro de Macorís', 'San Pedro de Macoris', 'Carr. Sanchez Km.7 1/2', 8095327343),
    (182319516, 'Edith Breeton', 'República Dominicana', 'Norcentral', 'Espaillat', 'Espaillat', 'E P Homme 43', 8092430043),
    (181055688, 'Crissy Blueman', 'República Dominicana', 'Norcentral', 'Puerto Plata', 'Puerto Plata', 'L Ginebra 32', 8092444045),
    (122850667, 'Sibbie Merdew', 'República Dominicana', 'Norcentral', 'Santiago', 'Santiago', 'Av Sarasota 72', 8095327936),
    (868007709, 'Jennica Bonavia', 'República Dominicana', 'Noroeste', 'Dajabón', 'Dajabón', 'Moca 76', 8096881110),
    (759436895, 'Dalt Gaskall', 'República Dominicana', 'Noroeste', 'Monte Cristi', 'Monte Cristi', 'F Marcano', 8095621551),
    (151040732, 'Roselin Seaman', 'República Dominicana', 'Noroeste', 'Santiago Rodríguez', 'Santiago Rodríguez', 'P Fantino 59', 8092964026),
    (373008089, 'Shanda Vasyuchov', 'República Dominicana', 'Noroeste', 'Valverde', 'Valverde', 'Jarines del Edén 1', 8095410957),
    (984865424, 'Emelita Hydes', 'República Dominicana', 'Norte', 'Duarte', 'Duarte', 'D No 9, V Olga', 8095825572),
    (998766830, 'Siusan Crop', 'República Dominicana', 'Norte', 'Hermanas Mirabal', 'Hermanas Mirabal', 'Espaillat 59', 8095561485),
    (680158274, 'Myrle Wince', 'República Dominicana', 'Norte', 'María Trinidad Sánchez', 'María Trinidad Sánchez', 'Av Independencia 200', 8095321840),
    (506854941, 'Melva Nowell', 'República Dominicana', 'Norte', 'Samaná', 'Samaná', 'M H Ureña 86', 8096836147),
    (270720132, 'Bartram Hansed', 'República Dominicana', 'Valdesia', 'Monte Plata', 'Monte Plata', 'Av Helios', 8095347492),
    (326883466, 'Sisely Warfield', 'República Dominicana', 'Valdesia', 'Peravia', 'Peravia', 'J Saltitopa 89', 8093335911),
    (496944980, 'Corbet Laible', 'República Dominicana', 'Valdesia', 'San Cristóbal', 'San Cristóbal', 'Av Los Jazmines', 8092331280),
    (283028431, 'Augustina Beaudry', 'República Dominicana', 'Valdesia', 'San José de Ocoa', 'San José de Ocoa', 'El Bronx 23', 8095832670),
    (307448559, 'Luella Pridham', 'República Dominicana', 'Enriquillo', 'Bahoruco', 'Bahoruco', 'Av M T Sánchez 8', 8092400752),
    (310259755, 'Marcela Quittonden', 'República Dominicana', 'Cibao Central', 'La Vega', 'La Vega', 'Santiago 250', 8096853586),
    (306511177, 'Wynn Tolliday', 'República Dominicana', 'Enriquillo', 'Bahoruco', 'Bahoruco', 'Prol Venezuela 10', 8095956573),
    (491744026, 'Amerigo Gosneye', 'República Dominicana', 'Cibao Central', 'La Vega', 'Concepcion de La Vega', 'Av 27 de Febrero 481', 8094825639),
    (114974007, 'Karney Trickey', 'República Dominicana', 'Noroeste', 'Dajabón', 'Dajabon', '2da 33, Ens Ozama', 8093884031),
    (926838979, 'Kimberlyn McBeth', 'República Dominicana', 'Noroeste', 'Dajabón', 'Dajabon', '3 No 1, Landia', 8095452485),
    (657130393, 'Neddy McVie', 'República Dominicana', 'Norcentral', 'Santiago', 'Santiago', 'J Saltitopa 16', 8095739390),
    (340838435, 'Annabel Ranns', 'República Dominicana', 'Norcentral', 'Santiago', 'Santiago', 'Pte Vásquez No 256', 8095967420),
    (400154073, 'Deanna Harrill', 'República Dominicana', 'Este', 'El Seibo', 'El Seibo', 'Carr. Manoguayabo 26 Sd', 8093792152),
    (551172404, 'Kristian Siegertsz', 'República Dominicana', 'Este', 'El Seibo', 'El Seibo', 'Rep del Líbano 3', 8099717786),
    (652723014, 'Carlos Arran', 'República Dominicana', 'Distrito Nacional', 'Nuevo Distrito Nacional', 'Nuevo Distrito Nacional', 'San Miguel 89', 8095607135),
    (104860321, 'Rowney Garrod', 'República Dominicana', 'Distrito Nacional', 'Nuevo Distrito Nacional', 'Nuevo Distrito Nacional', '1ra 3, La Cienaga', 8096213141),
    (542141278, 'Jada Winfred', 'República Dominicana', 'Distrito Nacional', 'Nuevo Distrito Nacional', 'Nuevo Distrito Nacional', 'M Del Rosario 161', 8095920280),
    (707611113, 'Krishnah Bentke', 'República Dominicana', 'Noroeste', 'Santiago Rodríguez', 'Santiago Rodríguez', 'Independencia 951', 8096207979),
    (534030498, 'Werner Barday', 'República Dominicana', 'Noroeste', 'Santiago Rodríguez', 'Santiago Rodríguez', 'J. Marti 180 Santo Domingo', 8095844886),
    (467918238, 'Hettie Labone', 'República Dominicana', 'Noroeste', 'Santiago Rodríguez', 'Santiago Rodríguez', '1ra No 69, V Aura', 8093792217);

INSERT INTO T_Facturacion
    (IDCliente, IDProducto, CantidadArt, TipoFactura, NumVenta, FechaFactura, Descuento, MontoFinal)
VALUES
    (1, 1, 3, 'Pago en efectivo', 968, '2020-05-22', 22, 2504),
    (2, 2, 4, 'Pago en efectivo', 435, '2020-08-21', 33, 2725),
    (3, 3, 9, 'Pago en efectivo', 411, '2021-07-26', 6, 569),
    (4, 4, 5, 'Pago en efectivo', 307, '2021-01-09', 24, 6335),
    (5, 5, 6, 'Pago en efectivo', 811, '2020-09-10', 24, 2804),
    (6, 6, 2, 'Pago en efectivo', 794, '2021-03-18', 12, 6687),
    (7, 7, 10, 'Pago en efectivo', 368, '2020-05-16', 33, 8645),
    (8, 8, 10, 'Pago en efectivo', 286, '2021-01-27', 32, 5964),
    (9, 9, 8, 'Pago en efectivo', 375, '2021-02-17', 1, 6604),
    (10, 10, 3, 'Pago en efectivo', 341, '2021-06-11', 9, 9171),
    (11, 11, 10, 'Tarjeta de crédito o débito', 139, '2021-07-27', 36, 4159),
    (12, 12, 9, 'Tarjeta de crédito o débito', 753, '2021-12-02', 11, 9769),
    (13, 13, 2, 'Tarjeta de crédito o débito', 519, '2020-05-18', 43, 2968),
    (14, 14, 4, 'Tarjeta de crédito o débito', 973, '2020-04-17', 2, 6301),
    (15, 15, 9, 'Tarjeta de crédito o débito', 153, '2021-01-30', 12, 6761),
    (16, 16, 5, 'Tarjeta de crédito o débito', 477, '2021-09-16', 37, 4415),
    (17, 17, 4, 'Tarjeta de crédito o débito', 673, '2020-04-07', 29, 3019),
    (18, 18, 10, 'Tarjeta de crédito o débito', 195, '2020-03-22', 43, 2306),
    (19, 19, 10, 'Tarjeta de crédito o débito', 139, '2021-06-02', 18, 3043),
    (20, 20, 4, 'Tarjeta de crédito o débito', 429, '2021-05-12', 18, 7067),
    (21, 21, 1, 'PayPal', 365, '2021-09-12', 31, 1177),
    (22, 22, 6, 'PayPal', 917, '2020-01-17', 10, 5363),
    (23, 23, 7, 'PayPal', 974, '2021-04-08', 18, 5117),
    (24, 24, 6, 'PayPal', 175, '2020-12-14', 45, 1781),
    (25, 25, 1, 'PayPal', 887, '2020-09-02', 3, 1387),
    (26, 26, 3, 'PayPal', 770, '2020-12-07', 7, 9490),
    (27, 27, 1, 'PayPal', 962, '2020-12-27', 28, 4476),
    (28, 28, 5, 'PayPal', 699, '2020-04-14', 35, 6165),
    (29, 29, 9, 'PayPal', 668, '2021-10-06 ', 40, 602),
    (30, 30, 7, 'PayPal', 606, '2021-08-18', 50, 5159),
    (31, 31, 7, 'Transferencia', 95, '2020-01-17', 44, 1863),
    (32, 32, 2, 'Transferencia', 816, '2020-06-20', 34, 7117),
    (33, 33, 4, 'Transferencia', 114, '2021-09-18', 32, 6535),
    (34, 34, 2, 'Transferencia', 509, '2021-03-26', 43, 943),
    (35, 35, 2, 'Transferencia', 55, '2021-02-08', 40, 1085),
    (36, 36, 9, 'Transferencia', 339, '2020-09-19', 5, 9696),
    (37, 37, 5, 'Transferencia', 922, '2020-12-27', 50, 6232),
    (38, 38, 5, 'Transferencia', 547, '2020-06-18', 39, 3805),
    (39, 39, 4, 'Transferencia', 811, '2021-12-26', 49, 3007),
    (40, 40, 4, 'Transferencia', 396, '2021-01-16', 3, 7572),
    (41, 41, 9, 'Pago en efectivo', 887, '2021-07-29', 34, 250),
    (42, 42, 6, 'Pago en efectivo', 200, '2021-05-24', 28, 9138),
    (43, 43, 5, 'Pago en efectivo', 999, '2020-07-17', 49, 5849),
    (44, 44, 5, 'Pago en efectivo', 498, '2021-04-19 ', 46, 8525),
    (45, 45, 10, 'Pago en efectivo', 674, '2020-02-12 ', 8, 8035),
    (46, 46, 6, 'Pago en efectivo', 174, '2021-07-11', 39, 9563),
    (47, 47, 2, 'Pago en efectivo', 561, '2020-12-24', 37, 934),
    (48, 48, 8, 'Pago en efectivo', 415, '2020-05-21 ', 50, 5435),
    (49, 49, 9, 'Pago en efectivo', 381, '2021-09-28 ', 42, 1252),
    (50, 50, 2, 'Pago en efectivo', 992, '2021-02-19', 16, 2169);

INSERT INTO T_Empleado
    (NombreCompleto, Telefono, Horario, Sexo, Salario, FechaDeIngreso, Departamento, IDSucursal)
VALUES
    ('Giana Middlemiss', 8095548017, 'Jornada laboral completa', 'Mujer', 7201, '2023-10-21 23:58:18', 'Recursos humanos', 1),
    ('Carolus Medgewick', 8091181412, 'Jornada laboral completa', 'Mujer', 5181, '2022-09-21 09:42:56', 'Recursos humanos', 2),
    ('Ralf Alvar', 8093589059, 'Jornada laboral completa', 'Mujer', 4985, '2017-05-21 04:00:28', 'Recursos humanos', 3),
    ('Seamus Geyton', 8099402148, 'Jornada laboral completa', 'Masculino', 7773, '2010-04-21 15:35:31', 'Recursos humanos', 4),
    ('Gay Gajownik', 8090261334, 'Jornada laboral completa', 'Masculino', 7802, '2019-09-21 16:52:19', 'Recursos humanos', 5),
    ('Aylmer Matevushev', 8095370497, 'Jornada laboral completa', 'Mujer', 1962, '2005-12-21 22:24:51', 'Ventas', 1),
    ('Raddie Dewen', 8095576164, 'Jornada laboral completa', 'Masculino', 3196, '2014-08-21 12:32:26', 'Ventas', 2),
    ('Charyl Loffhead', 8091423811, 'Jornada laboral completa', 'Masculino', 8244, '2022-04-21 08:16:28', 'Ventas', 3),
    ('Joline Tubb', 8093707153, 'Jornada laboral completa', 'Mujer', 3041, '2004-01-21 04:52:36', 'Ventas', 4),
    ('Kermy Fawdrie', 8098172049, 'Jornada laboral completa', 'Mujer', 6690, '2008-06-21 20:28:12', 'Ventas', 5),
    ('Teodor Grimmer', 8092395316, 'Jornada laboral parcial por horas', 'Mujer', 7941, '2029-09-21 23:54:02', 'Marketing', 1),
    ('Killy Croix', 8095393314, 'Jornada laboral parcial por horas', 'Mujer', 1836, '2016-02-21 14:51:20', 'Marketing', 2),
    ('Jaclin Maharey', 8095252655, 'Jornada laboral parcial por horas', 'Masculino', 3605, '2012-01-21 14:50:40', 'Marketing', 3),
    ('Meghann Schuler', 8093174298, 'Jornada laboral parcial por horas', 'Mujer', 6639, '2024-01-21 22:41:44', 'Marketing', 4),
    ('Charlie Congreave', 8093706970, 'Jornada laboral parcial por horas', 'Masculino', 6066, '2031-12-21 00:50:33', 'Marketing', 5),
    ('Aurilia Manus', 8090983138, 'Jornada laboral parcial por horas', 'Masculino', 1526, '2008-10-21 11:05:06', 'Marketing', 6),
    ('Celestyna Spitaro', 8096493950, 'Jornada laboral parcial por horas', 'Mujer', 4867, '2010-12-21 20:54:43', 'Marketing', 1),
    ('Byron Ciccoloi', 8096879864, 'Jornada laboral parcial por horas', 'Mujer', 7791, '2027-01-21 01:50:41', 'Marketing', 2),
    ('Gussie Crossfield', 8093593298, 'Jornada laboral parcial por horas', 'Mujer', 8060, '2027-05-21 00:03:19', 'Marketing', 3),
    ('Prissie Binfield', 8099760157, 'Jornada laboral parcial por horas', 'Masculino', 5443, '2024-07-21 12:58:47', 'Marketing', 4),
    ('Eleanora Kellaway', 8099719222, 'Jornada laboral a tiempo parcial', 'Mujer', 467, '2011-07-21 09:43:38', 'Contabilidad y finanzas', 1),
    ('Dina McKinlay', 8091080632, 'Jornada laboral a tiempo parcial', 'Mujer', 1729, '2017-08-21 09:09:07', 'Contabilidad y finanzas', 2),
    ('Agace Deehan', 8099132125, 'Jornada laboral a tiempo parcial', 'Mujer', 1722, '2003-04-21 04:56:13', 'Contabilidad y finanzas', 3),
    ('Jesselyn Norcott', 8090211880, 'Jornada laboral a tiempo parcial', 'Masculino', 3822, '2022-01-21 22:55:31', 'Contabilidad y finanzas', 4),
    ('Lula Tomkys', 8096278498, 'Jornada laboral a tiempo parcial', 'Masculino', 6253, '2030-09-21 22:39:32', 'Contabilidad y finanzas', 5),
    ('Krissie Balharrie', 8099766096, 'Jornada laboral a tiempo parcial', 'Mujer', 9900, '2013-07-21 15:21:06', 'Contabilidad y finanzas', 6),
    ('Miltie Serrurier', 8090922283, 'Jornada laboral a tiempo parcial', 'Masculino', 6249, '2012-03-21 01:20:39', 'Contabilidad y finanzas', 1),
    ('Lucienne Cordingly', 8090448356, 'Jornada laboral a tiempo parcial', 'Mujer', 7197, '2002-08-21 19:53:37', 'Contabilidad y finanzas', 2),
    ('Bari Baraclough', 8097382368, 'Jornada laboral a tiempo parcial', 'Masculino', 3826, '2006-01-21 21:36:00', 'Contabilidad y finanzas', 3),
    ('Letty Shalloo', 8093584455, 'Jornada laboral a tiempo parcial', 'Masculino', 9684, '2011-10-21 13:44:12', 'Contabilidad y finanzas', 4),
    ('Kasper Shilliday', 8293175101, 'Jornada laboral a turnos', 'Mujer', 8126, '2012-05-21 01:48:34', 'Almacen', 5),
    ('Bronson Fallow', 8298711719, 'Jornada laboral a turnos', 'Masculino', 9810, '2020-10-21 15:16:06', 'Almacen', 6),
    ('Earvin Stuchburie', 8296038974, 'Jornada laboral a turnos', 'Mujer', 3845, '2009-06-21 23:52:50', 'Almacen', 1),
    ('Maighdiln Rodear', 8299982021, 'Jornada laboral a turnos', 'Masculino', 4015, '2001-04-21 03:39:40', 'Almacen', 2),
    ('Vincents Ridde', 8293895900, 'Jornada laboral a turnos', 'Masculino', 6191, '2011-11-21 08:02:56', 'Almacen', 3),
    ('Leticia Gettens', 8297285387, 'Jornada laboral a turnos', 'Masculino', 4527, '2015-08-21 03:39:09', 'Almacen', 4),
    ('Sherm Sopp', 8298088730, 'Jornada laboral a turnos', 'Mujer', 1867, '2012-04-21 12:22:31', 'Almacen', 5),
    ('Morgan Ashby', 8292992106, 'Jornada laboral a turnos', 'Mujer', 8716, '2022-08-21 14:49:55', 'Almacen', 6),
    ('Abigail Wisam', 8299608615, 'Jornada laboral a turnos', 'Masculino', 574, '2016-11-21 19:27:07', 'Almacen', 1),
    ('Ware Insole', 8293496376, 'Jornada laboral a turnos', 'Mujer', 7931, '2020-08-21 18:11:46', 'Almacen', 2),
    ('Darnell Dayborne', 8496479718, 'Jornada laboral completa', 'Mujer', 2667, '2003-03-21 16:05:35', 'Administracion', 1),
    ('Adlai Fanshaw', 8490324944, 'Jornada laboral completa', 'Masculino', 3412, '2003-06-21 05:56:05', 'Administracion', 2),
    ('Mead Grunwall', 8494326379, 'Jornada laboral completa', 'Mujer', 7164, '2018-07-21 13:31:51', 'Administracion', 3),
    ('Eugine Shattock', 8491668776, 'Jornada laboral completa', 'Mujer', 8380, '2003-09-21 17:54:04', 'Administracion', 4),
    ('Janean Rosbotham', 8491338524, 'Jornada laboral completa', 'Masculino', 2272, '2026-08-21 03:04:18', 'Administracion', 5),
    ('Brandyn Treher', 8495705251, 'Jornada laboral completa', 'Mujer', 7719, '2017-08-21 19:12:04', 'Administracion', 6),
    ('Calvin Gwyneth', 8498422120, 'Jornada laboral completa', 'Masculino', 1015, '2031-08-21 23:34:55', 'Administracion', 1),
    ('Evangelin Darley', 8498716489, 'Jornada laboral completa', 'Masculino', 4435, '2028-12-21 13:16:29', 'Administracion', 2),
    ('Vivian Luigi', 8492347593, 'Jornada laboral completa', 'Masculino', 212, '2023-06-21 23:10:49', 'Administracion', 3),
    ('Abbi Lembrick', 8497369975, 'Jornada laboral completa', 'Mujer', 4511, '2001-11-21 19:39:20', 'Administracion', 4);

INSERT INTO T_Compras
    (IDSuplidor, IDProducto, PrecioCompra, FechaCompra, IDSucursal)
VALUES
    (1, 1, 6765, '2021-07-19', 1),
    (2, 2, 1512, '2021-05-13', 1),
    (3, 3, 841, '2021-07-21', 1),
    (4, 4, 599, '2021-11-30', 1),
    (5, 5, 3181, '2021-04-30', 1),
    (6, 6, 1638, '2021-07-06', 1),
    (7, 7, 5165, '2021-05-28', 1),
    (8, 8, 6506, '2021-06-24', 1),
    (9, 9, 740, '2021-09-13', 2),
    (10, 10, 3592, '2021-03-06', 2),
    (11, 11, 7958, '2021-08-05', 2),
    (12, 12, 4567, '2021-05-30', 2),
    (13, 13, 1119, '2021-06-14', 2),
    (14, 14, 153, '2021-04-06', 2),
    (15, 15, 1075, '2021-08-06', 2),
    (16, 16, 100, '2021-05-13', 2),
    (17, 17, 601, '2021-07-24', 3),
    (18, 18, 6130, '2021-04-05', 3),
    (19, 19, 100, '2021-02-12', 3),
    (20, 20, 4349, '2021-07-30', 3),
    (21, 21, 4281, '2021-12-09', 3),
    (22, 22, 6823, '2021-10-10', 3),
    (23, 23, 668, '2021-09-01', 3),
    (24, 24, 2619, '2021-07-03', 3),
    (25, 25, 1154, '2021-01-30', 4),
    (26, 26, 2436, '2021-10-15', 4),
    (27, 27, 2235, '2021-08-09', 4),
    (28, 28, 7280, '2021-01-08', 4),
    (29, 29, 362, '2021-10-23', 4),
    (30, 30, 2231, '2021-03-24', 4),
    (31, 31, 1070, '2021-07-06', 4),
    (32, 32, 4407, '2021-10-27', 4),
    (33, 33, 804, '2021-04-04', 5),
    (34, 34, 540, '2021-08-16', 5),
    (35, 35, 7350, '2021-01-01', 5),
    (36, 36, 2586, '2021-09-16', 5),
    (37, 37, 4205, '2021-01-29', 2),
    (38, 38, 75, '2021-06-23', 2),
    (39, 39, 7662, '2021-08-01', 1),
    (40, 40, 875, '2021-05-28', 2),
    (41, 41, 6274, '2021-08-18', 3),
    (42, 42, 500, '2021-05-30', 4),
    (43, 43, 7967, '2021-06-21', 5),
    (44, 44, 793, '2021-12-29', 6),
    (45, 45, 1754, '2021-04-11', 6),
    (46, 46, 961, '2021-07-17', 6),
    (47, 47, 543, '2021-01-17', 6),
    (48, 48, 105, '2021-08-21', 6),
    (49, 49, 2781, '2021-09-17', 6),
    (50, 50, 1000, '2021-03-22', 6);
