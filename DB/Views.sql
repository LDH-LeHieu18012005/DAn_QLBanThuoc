USE DAn_1_QLBanThuoc
GO

CREATE OR ALTER VIEW View_Full_Medicine_Info AS
SELECT 
    m.id_medicine [id],
    m.name_medicine [name],
    ISNULL(mt.name_type, N'') [type_name],
    m.active_ingredient [ac_i],
    m.contraindication [con],
    m.side_effects [si],
    b.manufacturing_date [manu],
    b.expiry_date [ex],
    m.total_quantity [to],
    m.price [p],
    m.is_active [is],
    m.images [ima],
    (SELECT ISNULL(SUM(quantity_in_batch), 0)
     FROM Batch b2
     WHERE b2.id_medicine = m.id_medicine 
       AND b2.status = 'True') [total_batch_quantity]
FROM 
    Medicine m
LEFT JOIN 
    Medicine_Type mt ON m.id_type = mt.id_type
LEFT JOIN 
    (SELECT id_medicine, manufacturing_date, expiry_date,
            ROW_NUMBER() OVER (PARTITION BY id_medicine ORDER BY manufacturing_date DESC) AS rn
     FROM Batch) b ON m.id_medicine = b.id_medicine AND b.rn = 1;

GO
CREATE OR ALTER VIEW View_Batch_Details
AS
SELECT 
    b.id_batch AS id,
    pd.id_purchase AS id_purchase,
    m.name_medicine AS name_medicine,
    b.quantity_in_batch AS q_i_b,
    b.entry_price AS price,
    b.manufacturing_date AS manu,
    b.expiry_date AS exp,
    b.quantity_shortage AS q_s,
    b.note AS note,
    b.status AS sta,
    m.is_active AS medicine_is_active 
FROM 
    Batch b
LEFT JOIN 
    Medicine m ON b.id_medicine = m.id_medicine
LEFT JOIN 
    Purchase_details pd ON b.id_batch = pd.id_batch; 
GO

GO
CREATE OR ALTER VIEW View_Purchase_Invoice_Details
AS
SELECT 
    pi.id_purchase AS id,
    pi.date_create AS date,
    pi.total_amount AS total,
    s.name_supplier AS name_supplier,
    st.name_staff AS name_staff
FROM 
    Purchase_Invoice pi
LEFT JOIN 
    Supplier s ON pi.id_supplier = s.id_supplier
LEFT JOIN 
    Staff st ON pi.id_staff = st.id_staff

GO
CREATE OR ALTER VIEW View_Batch_Purchase_Details
AS
SELECT 
    b.id_batch AS id_batch,
    b.id_medicine AS id_medicine,
    m.name_medicine AS name_medicine,
    b.quantity_in_batch AS quantity_in_batch,
    b.entry_price AS entry_price,
    b.manufacturing_date AS manufacturing_date,
    b.expiry_date AS expiry_date,
    b.status AS status,
    pd.id_purchase AS id_purchase,
    pi.total_amount AS total_amount 
FROM 
    Batch b
LEFT JOIN 
    Medicine m ON b.id_medicine = m.id_medicine
LEFT JOIN 
    Purchase_details pd ON b.id_batch = pd.id_batch
LEFT JOIN 
    Purchase_Invoice pi ON pd.id_purchase = pi.id_purchase; 
GO

CREATE OR ALTER VIEW View_Batch_With_Medicine
AS
SELECT 
    b.id_batch,
    b.id_medicine,
    m.name_medicine,
    b.quantity_in_batch,
    b.entry_price,
    b.manufacturing_date,
    b.expiry_date,
    b.status,
    b.quantity_shortage,
    b.note
FROM 
    Batch b
LEFT JOIN 
    Medicine m ON b.id_medicine = m.id_medicine;
GO

CREATE OR ALTER VIEW View_Sale_Invoice_Details
AS
SELECT 
    si.id_sale AS id_sale,
    s.name_staff AS name_staff,
    c.name_customer AS name_customer,
    si.date_create AS date_create,
    si.status AS status,
    sd.price AS Price,
    sd.quantity_sale AS quantity,
    m.name_medicine AS name_medicine,
	(sd.quantity_sale * sd.price) AS total_amount
FROM 
    Sale_Invoice si
LEFT JOIN 
    Staff s ON si.id_staff = s.id_staff
LEFT JOIN 
    Customer c ON si.id_customer = c.id_customer
LEFT JOIN 
    Sale_details sd ON si.id_sale = sd.id_sale
LEFT JOIN 
    Medicine m ON sd.id_medicine = m.id_medicine
GO

 
CREATE OR ALTER VIEW View_Counts
AS
SELECT 
    (SELECT COUNT(*) FROM Customer) AS TotalCustomers,
    (SELECT COUNT(*) FROM Medicine) AS TotalMedicines,
    (SELECT COUNT(*) FROM Staff) AS TotalStaff,

    (SELECT ISNULL(SUM(quantity_sale * price), 0) 
     FROM Sale_details) AS TotalRevenue,
    (SELECT ISNULL((
        (SELECT ISNULL(SUM(quantity_sale * price), 0) FROM Sale_details) -- Total Revenue
        - 
        (SELECT ISNULL(SUM(quantity_in_batch * entry_price), 0) FROM Batch) -- Total Cost
    ), 0)) AS TotalProfit;


CREATE VIEW View_TopSale
AS
SELECT 
    M.name_medicine AS MedicineName,
    SUM(SD.quantity_sale) AS TotalQuantitySold,
    SUM(SD.quantity_sale * SD.price) AS TotalRevenue
FROM 
    Sale_details SD
JOIN 
    Medicine M ON SD.id_medicine = M.id_medicine
GROUP BY 
    M.name_medicine;
GO


CREATE OR ALTER VIEW View_BatchExpiryStatus
AS
SELECT 
    B.id_batch,
    M.name_medicine,
    B.quantity_in_batch,
    B.manufacturing_date,
    B.expiry_date,
    B.quantity_shortage,
    B.note,
	B.status
FROM 
    Batch B
JOIN 
    Medicine M ON B.id_medicine = M.id_medicine
WHERE 
    B.quantity_shortage > 0
    OR (
        B.expiry_date <= DATEADD(MONTH, 3, GETDATE()) -- Expiring within 3 months
        OR B.expiry_date < GETDATE() -- Already expired
    );
GO
