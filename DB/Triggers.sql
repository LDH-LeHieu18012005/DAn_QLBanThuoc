USE DAn_1_QLBanThuoc
GO

CREATE OR ALTER TRIGGER Trigger_UpdateBatchStatus
ON Batch
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE b
    SET status = 'Inactive'
    FROM Batch b
    INNER JOIN inserted i ON b.id_batch = i.id_batch
    WHERE (i.quantity_shortage = i.quantity_in_batch AND i.quantity_shortage > 0)
       OR i.expiry_date <= CAST(GETDATE() AS DATE);
END;
GO

CREATE OR ALTER TRIGGER Trigger_UpdateMedicineFromBatch
ON Batch
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @AffectedMedicines TABLE (id_medicine INT);
    INSERT INTO @AffectedMedicines (id_medicine)
    SELECT id_medicine FROM inserted
    UNION
    SELECT id_medicine FROM deleted;
    UPDATE m
    SET total_quantity = ISNULL((
        SELECT SUM(b.quantity_in_batch - b.quantity_shortage)
        FROM Batch b
        WHERE b.id_medicine = m.id_medicine
          AND b.status = 'Active'
          AND b.quantity_in_batch >= b.quantity_shortage
          AND b.expiry_date > CAST(GETDATE() AS DATE)
    ), 0)
    FROM Medicine m
    WHERE m.id_medicine IN (SELECT id_medicine FROM @AffectedMedicines);
    UPDATE m
    SET price = (
        SELECT TOP 1 b.entry_price
        FROM Batch b
        WHERE b.id_medicine = m.id_medicine
          AND b.status = 'Active'
          AND b.expiry_date > CAST(GETDATE() AS DATE)
        ORDER BY b.id_batch DESC
    )
    FROM Medicine m
    WHERE m.id_medicine IN (SELECT id_medicine FROM @AffectedMedicines)
      AND EXISTS (
        SELECT 1
        FROM Batch b
        WHERE b.id_medicine = m.id_medicine
          AND b.status = 'Active'
          AND b.expiry_date > CAST(GETDATE() AS DATE)
    );

    UPDATE m
    SET is_active = CASE
        WHEN m.total_quantity = 0 THEN 0 
        WHEN EXISTS (
            SELECT 1
            FROM Batch b
            WHERE b.id_medicine = m.id_medicine
              AND b.expiry_date <= CAST(GETDATE() AS DATE)
        ) THEN 0 
        ELSE 1
    END
    FROM Medicine m
    WHERE m.id_medicine IN (SELECT id_medicine FROM @AffectedMedicines);
END;
GO

CREATE OR ALTER TRIGGER Trigger_UpdateStockAfterSale
ON Sale_details
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @SaleChanges TABLE (
        id_medicine INT,
        quantity_change INT
    );

    INSERT INTO @SaleChanges (id_medicine, quantity_change)
    SELECT 
        i.id_medicine,
        i.quantity_sale - ISNULL((SELECT d.quantity_sale FROM deleted d WHERE d.id_sale = i.id_sale AND d.id_medicine = i.id_medicine), 0) AS quantity_change
    FROM inserted i;

    UPDATE m
    SET total_quantity = m.total_quantity - sc.quantity_change
    FROM Medicine m
    INNER JOIN @SaleChanges sc ON m.id_medicine = sc.id_medicine
    WHERE sc.quantity_change > 0;

    DECLARE @id_medicine INT, @quantity_to_deduct INT;

    DECLARE sale_cursor CURSOR FOR
    SELECT id_medicine, quantity_change 
    FROM @SaleChanges 
    WHERE quantity_change > 0;

    OPEN sale_cursor;
    FETCH NEXT FROM sale_cursor INTO @id_medicine, @quantity_to_deduct;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        WHILE @quantity_to_deduct > 0
        BEGIN
            DECLARE @id_batch INT, @available_quantity INT;

            SELECT TOP 1 
                @id_batch = id_batch,
                @available_quantity = quantity_in_batch
            FROM Batch
            WHERE id_medicine = @id_medicine
              AND status = 'Active'
              AND expiry_date > CAST(GETDATE() AS DATE)
              AND quantity_in_batch > 0
            ORDER BY expiry_date ASC;

            IF @id_batch IS NULL
            BEGIN
                BREAK;
            END
            DECLARE @deduct_from_batch INT = CASE 
                WHEN @available_quantity >= @quantity_to_deduct THEN @quantity_to_deduct
                ELSE @available_quantity
            END;

            UPDATE Batch
            SET quantity_in_batch = quantity_in_batch - @deduct_from_batch
            WHERE id_batch = @id_batch;

            SET @quantity_to_deduct = @quantity_to_deduct - @deduct_from_batch;
        END

        FETCH NEXT FROM sale_cursor INTO @id_medicine, @quantity_to_deduct;
    END

    CLOSE sale_cursor;
    DEALLOCATE sale_cursor;
END;
GO

CREATE OR ALTER TRIGGER Trigger_RestoreStockAfterDeleteSale
ON Sale_details
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Medicine
    SET total_quantity = total_quantity + d.quantity_sale
    FROM Medicine m
    INNER JOIN deleted d ON m.id_medicine = d.id_medicine;
    UPDATE Batch
    SET quantity_in_batch = quantity_in_batch + d.quantity_sale
    FROM Batch b
    INNER JOIN deleted d ON b.id_medicine = d.id_medicine
    WHERE b.id_batch IN (
        SELECT TOP 1 id_batch
        FROM Batch b2
        WHERE b2.id_medicine = d.id_medicine
          AND b2.expiry_date >= CAST(GETDATE() AS DATE) 
          AND (b2.status IS NULL OR b2.status = 'Active') 
        ORDER BY b2.expiry_date ASC 
    );
END;
GO
