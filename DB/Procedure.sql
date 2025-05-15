USE DAn_1_QLBanThuoc
GO

-- Prc (Add-Edit/ Delete) --
																-- Customer --
CREATE OR ALTER PROCEDURE Proc_AddCustomer
(
    @Name NVARCHAR(50),
    @Age INT,
    @Gender NVARCHAR(5),
    @Phone VARCHAR(20),
    @Address NVARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Customer WHERE phone = @Phone)
    BEGIN
        RAISERROR('Phone number already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO Customer (name_customer, age, gender, phone, address)
    VALUES (@Name, @Age, @Gender, @Phone, @Address);
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateCustomer
(
    @IdCustomer INT,
    @Name NVARCHAR(50),
    @Age INT,
    @Gender NVARCHAR(5),
    @Phone VARCHAR(20),
    @Address NVARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Customer WHERE id_customer = @IdCustomer)
    BEGIN
        RAISERROR('Customer does not exist.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Customer WHERE phone = @Phone AND id_customer != @IdCustomer)
    BEGIN
        RAISERROR('Phone number already exists.', 16, 1);
        RETURN;
    END
    UPDATE Customer
    SET name_customer = @Name,
        age = @Age,
        gender = @Gender,
        phone = @Phone,
        address = @Address
    WHERE id_customer = @IdCustomer;
END;
GO

CREATE OR ALTER PROCEDURE Proc_rmCustomer
    @IdCustomer INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Sale_Invoice
    SET id_customer = NULL
    WHERE id_customer = @IdCustomer;

    DELETE FROM Customer
    WHERE id_customer = @IdCustomer;
END;
GO

											-- Supplier --
CREATE OR ALTER PROCEDURE Proc_AddSupplier
(
    @Name NVARCHAR(50),
    @Phone VARCHAR(20),
    @Gmail VARCHAR(100),
    @Address NVARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Supplier WHERE phone = @Phone)
    BEGIN
        RAISERROR('Phone number already exists.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Supplier WHERE gmail = @Gmail)
    BEGIN
        RAISERROR('Email already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO Supplier (name_supplier, phone, gmail, address)
    VALUES (@Name, @Phone, @Gmail, @Address);
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateSupplier
(
    @IdSupplier INT,
    @Name NVARCHAR(50),
    @Phone VARCHAR(20),
    @Gmail VARCHAR(100),
    @Address NVARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Supplier WHERE id_supplier = @IdSupplier)
    BEGIN
        RAISERROR('Supplier does not exist.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Supplier WHERE phone = @Phone AND id_supplier != @IdSupplier)
    BEGIN
        RAISERROR('Phone number already exists.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Supplier WHERE gmail = @Gmail AND id_supplier != @IdSupplier)
    BEGIN
        RAISERROR('Email already exists.', 16, 1);
        RETURN;
    END
    UPDATE Supplier
    SET name_supplier = @Name,
        phone = @Phone,
        gmail = @Gmail,
        address = @Address
    WHERE id_supplier = @IdSupplier;
END;
GO

CREATE OR ALTER PROCEDURE Proc_DeleteSupplier
    @IdSupplier INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Purchase_Invoice
    SET id_supplier = NULL
    WHERE id_supplier = @IdSupplier;

    DELETE FROM Supplier
    WHERE id_supplier = @IdSupplier;
END;
GO

										-- Staff --
CREATE OR ALTER PROCEDURE Proc_AddStaff
(
    @Name NVARCHAR(100),
    @Gender NVARCHAR(5),
    @Address NVARCHAR(255),
    @Gmail VARCHAR(255),
    @Phone VARCHAR(20),
    @StartDate DATE,
    @Username VARCHAR(100),
    @Password VARCHAR(255),
    @TypeStaff NVARCHAR(30),
    @IsActive BIT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Staff WHERE phone = @Phone)
    BEGIN
        RAISERROR('Phone number already exists.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Staff WHERE gmail = @Gmail)
    BEGIN
        RAISERROR('Email already exists.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Staff WHERE username = @Username)
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO Staff (name_staff, gender, address, gmail, phone, start_date, username, password, type_staff, is_active)
    VALUES (@Name, @Gender, @Address, @Gmail, @Phone, @StartDate, @Username, @Password, @TypeStaff, @IsActive);
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateStaff
(
    @IdStaff INT,
    @Name NVARCHAR(100),
    @Gender NVARCHAR(5),
    @Address NVARCHAR(255),
    @Gmail VARCHAR(255),
    @Phone VARCHAR(20),
    @StartDate DATE,
    @Username VARCHAR(100),
    @Password VARCHAR(255),
    @TypeStaff NVARCHAR(30),
    @IsActive BIT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Staff WHERE id_staff = @IdStaff)
    BEGIN
        RAISERROR('Staff does not exist.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Staff WHERE phone = @Phone AND id_staff != @IdStaff)
    BEGIN
        RAISERROR('Phone number already exists.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Staff WHERE gmail = @Gmail AND id_staff != @IdStaff)
    BEGIN
        RAISERROR('Email already exists.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Staff WHERE username = @Username AND id_staff != @IdStaff)
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN;
    END
    UPDATE Staff
    SET name_staff = @Name,
        gender = @Gender,
        address = @Address,
        gmail = @Gmail,
        phone = @Phone,
        start_date = @StartDate,
        username = @Username,
        password = @Password,
        type_staff = @TypeStaff,
        is_active = @IsActive
    WHERE id_staff = @IdStaff;
END;
GO

CREATE OR ALTER PROCEDURE Proc_DeleteStaff
    @IdStaff INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Sale_Invoice
    SET id_staff = NULL
    WHERE id_staff = @IdStaff;

    UPDATE Purchase_Invoice
    SET id_staff = NULL
    WHERE id_staff = @IdStaff;

    DELETE FROM Staff
    WHERE id_staff = @IdStaff;
END;
GO

													-- type/ Medicine --
CREATE OR ALTER PROCEDURE Proc_AddMedicineType
(
    @NameType NVARCHAR(50),
    @Description NVARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Medicine_Type WHERE name_type = @NameType)
    BEGIN
        RAISERROR('Medicine type name already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO Medicine_Type (name_type, description)
    VALUES (@NameType, @Description);
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateMedicineType
(
    @IdType INT,
    @NameType NVARCHAR(50),
    @Description NVARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Medicine_Type WHERE id_type = @IdType)
    BEGIN
        RAISERROR('Medicine type does not exist.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Medicine_Type WHERE name_type = @NameType AND id_type != @IdType)
    BEGIN
        RAISERROR('Medicine type name already exists.', 16, 1);
        RETURN;
    END
    UPDATE Medicine_Type
    SET name_type = @NameType,
        description = @Description
    WHERE id_type = @IdType;
END;
GO

CREATE OR ALTER PROCEDURE Proc_DeleteType
    @IdType INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Medicine
    SET id_type = NULL
    WHERE id_type = @IdType;
    DELETE FROM Medicine_Type
    WHERE id_type = @IdType;
END;
GO

--
CREATE OR ALTER PROCEDURE Proc_AddMedicine
(
    @IdType INT,
    @NameMedicine NVARCHAR(100),
    @ActiveIngredient NVARCHAR(255),
    @Contraindication NVARCHAR(255),
    @SideEffects NVARCHAR(255),
    @Unit NVARCHAR(30),
    @IsActive BIT,
    @Images NVARCHAR(500)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Medicine WHERE name_medicine = @NameMedicine)
    BEGIN
        RAISERROR('Medicine name already exists.', 16, 1);
        RETURN;
    END
    IF @IdType IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Medicine_Type WHERE id_type = @IdType)
    BEGIN
        RAISERROR('Medicine type does not exist.', 16, 1);
        RETURN;
    END
    INSERT INTO Medicine (id_type, name_medicine, active_ingredient, contraindication, side_effects, unit, is_active, images)
    VALUES (@IdType, @NameMedicine, @ActiveIngredient, @Contraindication, @SideEffects, @Unit, @IsActive, @Images);
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateMedicine
(
    @IdMedicine INT,
    @IdType INT,
    @NameMedicine NVARCHAR(100),
    @ActiveIngredient NVARCHAR(255),
    @Contraindication NVARCHAR(255),
    @SideEffects NVARCHAR(255),
    @Unit NVARCHAR(30),
    @Price DECIMAL(18, 0),
    @IsActive BIT,
    @Images NVARCHAR(500)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Medicine WHERE id_medicine = @IdMedicine)
    BEGIN
        RAISERROR('Medicine does not exist.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM Medicine WHERE name_medicine = @NameMedicine AND id_medicine != @IdMedicine)
    BEGIN
        RAISERROR('Medicine name already exists.', 16, 1);
        RETURN;
    END
    IF @IdType IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Medicine_Type WHERE id_type = @IdType)
    BEGIN
        RAISERROR('Medicine type does not exist.', 16, 1);
        RETURN;
    END
    UPDATE Medicine
    SET id_type = @IdType,
        name_medicine = @NameMedicine,
        active_ingredient = @ActiveIngredient,
        contraindication = @Contraindication,
        side_effects = @SideEffects,
        unit = @Unit,
        price = @Price,
        is_active = @IsActive,
        images = @Images
    WHERE id_medicine = @IdMedicine;
END;
GO

CREATE OR ALTER PROCEDURE Proc_DeleteMedicine
    @IdMedicine INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Batch
    SET id_medicine = NULL
    WHERE id_medicine = @IdMedicine;

    UPDATE Sale_details
    SET id_medicine = NULL
	WHERE id_medicine = @IdMedicine;

    DELETE FROM Medicine
    WHERE id_medicine = @IdMedicine;
END;
GO


											-- Batch --
CREATE OR ALTER PROCEDURE Proc_AddBatch
(
    @IdMedicine INT,
    @QuantityInBatch INT,
    @EntryPrice DECIMAL(18, 0),
    @ManufacturingDate DATE,
    @ExpiryDate DATE,
    @Status NVARCHAR(20),
    @IdBatch INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Medicine WHERE id_medicine = @IdMedicine)
    BEGIN
        RAISERROR('Medicine does not exist.', 16, 1);
        RETURN;
    END
    IF @ExpiryDate <= @ManufacturingDate
    BEGIN
        RAISERROR('Expiry date must be greater than manufacturing date.', 16, 1);
        RETURN;
    END
    INSERT INTO Batch (id_medicine, quantity_in_batch, entry_price, manufacturing_date, expiry_date, status)
    VALUES (@IdMedicine, @QuantityInBatch, @EntryPrice, @ManufacturingDate, @ExpiryDate, @Status);

    SET @IdBatch = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateBatch
(
    @IdBatch INT,
    @QuantityInBatch INT,
    @EntryPrice DECIMAL(18, 0),
    @ManufacturingDate DATE,
    @ExpiryDate DATE,
    @Status NVARCHAR(20),
    @QuantityShortage INT,
    @Note NVARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF @ExpiryDate <= @ManufacturingDate
    BEGIN
        RAISERROR('Expiry date must be greater than manufacturing date.', 16, 1);
        RETURN;
    END
	IF @QuantityShortage > @QuantityInBatch
    BEGIN
        RAISERROR('Quantity shortage must be less than or equal to quantity in batch.', 16, 1);
        RETURN;
    END
    UPDATE Batch
    SET 
        quantity_in_batch = @QuantityInBatch,
        entry_price = @EntryPrice,
        manufacturing_date = @ManufacturingDate,
        expiry_date = @ExpiryDate,
        status = @Status,
        quantity_shortage = @QuantityShortage,
        note = @Note
    WHERE id_batch = @IdBatch;
END;
GO


CREATE OR ALTER PROCEDURE Proc_DeleteBatch
    @IdBatch INT
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM Purchase_details
    WHERE id_batch = @IdBatch
    DELETE FROM Batch
    WHERE id_batch = @IdBatch;
END;
GO

													-- Purchase Invoice --
CREATE OR ALTER PROCEDURE Proc_AddPurchaseInvoice
    @IdStaff INT,
    @IdSupplier INT,
    @DateCreate DATE,
    @total_amount DECIMAL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Purchase_Invoice (id_staff, id_supplier, date_create, total_amount)
    VALUES (@IdStaff, @IdSupplier, @DateCreate, @total_amount);
END;
GO

CREATE PROCEDURE Insert_Purchase_Details
    @id_purchase INT,
    @id_batch INT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Purchase_details (id_purchase, id_batch)
            VALUES (@id_purchase, @id_batch);
END;
GO

CREATE OR ALTER PROCEDURE Proc_DeletePurchaseInvoice
    @IdPurchase INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Purchase_Invoice WHERE id_purchase = @IdPurchase)
    BEGIN
        RAISERROR('Purchase invoice does not exist.', 16, 1);
        RETURN;
    END

    DELETE FROM Purchase_details
    WHERE id_purchase = @IdPurchase;

    DELETE FROM Batch
    WHERE id_batch IN (
        SELECT b.id_batch 
        FROM Purchase_details pd
        RIGHT JOIN Batch b ON pd.id_batch = b.id_batch
        WHERE pd.id_purchase = @IdPurchase OR pd.id_purchase IS NULL
    );
    DELETE FROM Purchase_Invoice
    WHERE id_purchase = @IdPurchase;
END;
GO


													-- Sale Invoice --
CREATE OR ALTER PROCEDURE Proc_AddSaleInvoice
    @IdStaff INT,
    @IdCustomer INT,
    @DateCreate DATE,
    @Status VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF @DateCreate > CAST(GETDATE() AS DATE)
    BEGIN
        RAISERROR('Date created cannot be in the future.', 16, 1);
        RETURN;
    END

    IF @Status NOT IN ('Pending', 'Completed')
    BEGIN
        RAISERROR('Status must be Pending or Completed.', 16, 1);
        RETURN;
    END
    INSERT INTO Sale_Invoice (id_staff, id_customer, date_create, status)
    VALUES (@IdStaff, @IdCustomer, @DateCreate, @Status);

END;
GO

CREATE OR ALTER PROCEDURE Proc_AddSaleDetail
    @IdSale INT,
    @IdMedicine INT,
    @QuantitySale INT,
    @Price DECIMAL(18, 0)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TotalQuantity INT;
    SELECT @TotalQuantity = total_quantity
    FROM Medicine
    WHERE id_medicine = @IdMedicine;

    IF @QuantitySale > @TotalQuantity
    BEGIN
        RAISERROR('Not enough stock for this medicine.', 16, 1);
        RETURN;
    END

    INSERT INTO Sale_details (id_sale, id_medicine, quantity_sale, price)
    VALUES (@IdSale, @IdMedicine, @QuantitySale, @Price);
END;
GO

CREATE OR ALTER PROCEDURE Proc_DeleteSaleInvoice
    @IdSale INT
AS
BEGIN
    SET NOCOUNT ON;
    IF (SELECT status FROM Sale_Invoice WHERE id_sale = @IdSale) NOT IN ('Pending')
    BEGIN
        RAISERROR('Only invoices with status "Pending" can be deleted.', 16, 1);
        RETURN;
    END
    DELETE FROM Sale_Invoice
    WHERE id_sale = @IdSale;
END;
GO

CREATE OR ALTER PROCEDURE Proc_UpdateSaleInvoiceStatus
    @IdSale INT,
    @NewStatus VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Sale_Invoice
    SET status = @NewStatus
    WHERE id_sale = @IdSale;
END;
GO

CREATE OR ALTER PROCEDURE ThongKeDoanhThuTheoThangNam
    @Month INT = NULL,  
    @Year INT
AS
BEGIN
    DECLARE @StartDate DATE;
    DECLARE @EndDate DATE;
    IF @Month IS NULL
    BEGIN
        -- Trường hợp chỉ có @Year: Lấy doanh thu từng tháng của năm đó
        DECLARE @MonthCounter INT = 1;
        CREATE TABLE #MonthlyRevenue (
            MonthNumber INT,
            Revenue DECIMAL(18, 0)
        );
        WHILE @MonthCounter <= 12
        BEGIN
            SET @StartDate = DATEFROMPARTS(@Year, @MonthCounter, 1);
            SET @EndDate = EOMONTH(@StartDate);
            INSERT INTO #MonthlyRevenue (MonthNumber, Revenue)
            SELECT 
                @MonthCounter AS MonthNumber,
                ISNULL(SUM(SD.price * SD.quantity_sale), 0) AS Revenue
            FROM Sale_details SD
            INNER JOIN Sale_Invoice SI ON SD.id_sale = SI.id_sale
            WHERE SI.date_create >= @StartDate AND SI.date_create <= @EndDate
                AND SI.status = 'Completed'  -- Trạng thái hóa đơn hoàn tất
            SET @MonthCounter = @MonthCounter + 1;
        END
        -- Trả về dữ liệu doanh thu cho đủ 12 tháng
        SELECT MonthNumber, Revenue FROM #MonthlyRevenue ORDER BY MonthNumber;
        DROP TABLE #MonthlyRevenue;
    END
    ELSE
    BEGIN
        -- Trường hợp có cả @Month và @Year: Lấy doanh thu cho tháng cụ thể
        SET @StartDate = DATEFROMPARTS(@Year, @Month, 1);
        SET @EndDate = EOMONTH(@StartDate);
        SELECT 
            @Month AS MonthNumber,
            ISNULL(SUM(SD.price * SD.quantity_sale), 0) AS Revenue
        FROM Sale_details SD
        INNER JOIN Sale_Invoice SI ON SD.id_sale = SI.id_sale
        WHERE SI.date_create >= @StartDate AND SI.date_create <= @EndDate
            AND SI.status = 'Completed'  -- Trạng thái hóa đơn hoàn tất
    END
END;
GO


CREATE OR ALTER PROCEDURE ThongKeDoanhThuTheoQuy
    @Quarter INT = NULL,
    @Year INT
AS
BEGIN
    CREATE TABLE #QuarterInfo (
        QuarterNumber INT,
        StartMonth INT,
        EndMonth INT
    );

    INSERT INTO #QuarterInfo (QuarterNumber, StartMonth, EndMonth)
    VALUES 
        (1, 1, 3),
        (2, 4, 6),
        (3, 7, 9),
        (4, 10, 12);

    IF @Quarter IS NULL
    BEGIN
        CREATE TABLE #QuarterlyRevenue (
            QuarterNumber INT,
            Revenue DECIMAL(18, 0)
        );
        
        INSERT INTO #QuarterlyRevenue (QuarterNumber, Revenue)
        SELECT 
            QI.QuarterNumber,
            ISNULL(
                (SELECT SUM(SD.price * SD.quantity_sale)
                 FROM Sale_details SD
                 INNER JOIN Sale_Invoice SI ON SD.id_sale = SI.id_sale
                 WHERE SI.date_create >= DATEFROMPARTS(@Year, QI.StartMonth, 1)
                   AND SI.date_create <= EOMONTH(DATEFROMPARTS(@Year, QI.EndMonth, 1))
                   AND SI.status = 'Completed'), 0) AS Revenue
        FROM #QuarterInfo QI;
        
        SELECT 
            QuarterNumber AS [Quý],
            Revenue AS [Doanh Thu]
        FROM #QuarterlyRevenue
        ORDER BY QuarterNumber;

        DROP TABLE #QuarterlyRevenue;
    END
    ELSE
    BEGIN
        DECLARE @StartMonth INT, @EndMonth INT;
        
        SELECT @StartMonth = StartMonth, @EndMonth = EndMonth
        FROM #QuarterInfo
        WHERE QuarterNumber = @Quarter;
        SELECT 
            @Quarter AS [Quý],
            ISNULL(SUM(SD.price * SD.quantity_sale), 0) AS [Doanh Thu]
        FROM Sale_details SD
        INNER JOIN Sale_Invoice SI ON SD.id_sale = SI.id_sale
        WHERE SI.date_create >= DATEFROMPARTS(@Year, @StartMonth, 1)
          AND SI.date_create <= EOMONTH(DATEFROMPARTS(@Year, @EndMonth, 1))
          AND SI.status = 'Completed';
    END
    DROP TABLE #QuarterInfo;
END;
GO
