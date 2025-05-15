CREATE DATABASE DAn_1_QLBanThuoc
GO
USE DAn_1_QlBanThuoc


--
CREATE TABLE Medicine_Type
(
	id_type INT IDENTITY(1,1) PRIMARY KEY,
	name_type NVARCHAR(50),
	description NVARCHAR(100)
);

CREATE TABLE Medicine 
(
	id_medicine INT IDENTITY(1,1) PRIMARY KEY,
	id_type INT,
	name_medicine NVARCHAR(100),
	total_quantity INT,
	active_ingredient NVARCHAR(255),
	contraindication NVARCHAR(255),
	side_effects NVARCHAR(255),
	unit NVARCHAR(30),
	price DECIMAL(18, 0),
	is_active BIT DEFAULT 1,
	images NVARCHAR(500),
	FOREIGN KEY (id_type) REFERENCES Medicine_Type(id_type) ON DELETE SET NULL
);

CREATE TABLE Supplier
(
	id_supplier INT IDENTITY(1,1) PRIMARY KEY,
	name_supplier NVARCHAR(50),
	phone VARCHAR(20) UNIQUE,
	gmail VARCHAR(100) UNIQUE,
	address NVARCHAR(255)
);

CREATE TABLE Staff
(
	id_staff INT IDENTITY(1,1) PRIMARY KEY,
	name_staff NVARCHAR(100),
	gender NVARCHAR(5),
	address NVARCHAR(255),
	gmail VARCHAR(255),
	phone VARCHAR(20) UNIQUE,
	start_date DATE,
	username VARCHAR(100) UNIQUE NOT NULL,
	password VARCHAR(255),
	type_staff NVARCHAR(30),
	is_active BIT DEFAULT 1
);

CREATE TABLE Customer 
(
	id_customer INT IDENTITY(1,1) PRIMARY KEY,
	name_customer NVARCHAR(50),
	age INT,
	gender NVARCHAR(5),
	phone VARCHAR(20) UNIQUE,
	address NVARCHAR(255)
);

select * from Staff
-----
CREATE TABLE Purchase_Invoice
(
	id_purchase INT IDENTITY(1,1) PRIMARY KEY,
	date_create DATE,
	id_supplier INT,
	id_staff INT,
	total_amount DECIMAL(18, 0) DEFAULT 0,
	FOREIGN KEY (id_supplier) REFERENCES Supplier(id_supplier) ON DELETE SET NULL,
	FOREIGN KEY (id_staff) REFERENCES Staff(id_staff) ON DELETE SET NULL
);

CREATE TABLE Batch
(
	id_batch INT IDENTITY(1,1) PRIMARY KEY,
	id_medicine INT,
	quantity_in_batch INT,
	entry_price DECIMAL(18, 0),
	manufacturing_date DATE,
	expiry_date DATE,
	status NVARCHAR(20),
	quantity_shortage INT DEFAULT 0,
	note NVARCHAR(255),
	FOREIGN KEY (id_medicine) REFERENCES Medicine(id_medicine) ON DELETE SET NULL
);

CREATE TABLE Purchase_details
(
	id_purchase INT,
	id_batch INT,
	PRIMARY KEY (id_purchase, id_batch),
	FOREIGN KEY (id_purchase) REFERENCES Purchase_Invoice(id_purchase),
	FOREIGN KEY (id_batch) REFERENCES Batch(id_batch)
);


----
CREATE TABLE Sale_Invoice
(
	id_sale INT IDENTITY(1,1) PRIMARY KEY,
	id_staff INT,
	id_customer INT,
	date_create DATE,
	status VARCHAR(20),
	FOREIGN KEY (id_staff) REFERENCES Staff(id_staff) ON DELETE SET NULL,
	FOREIGN KEY (id_customer) REFERENCES Customer(id_customer) ON DELETE SET NULL
);

CREATE TABLE Sale_details
(
	id_sale INT,
	id_detail INT IDENTITY(1,1),
	id_medicine INT,
	quantity_sale INT,
	price DECIMAL(18, 0),
	PRIMARY KEY (id_sale, id_detail),
	FOREIGN KEY (id_sale) REFERENCES Sale_Invoice (id_sale) ON DELETE CASCADE,
	FOREIGN KEY (id_medicine) REFERENCES Medicine (id_medicine)
);
