INSERT INTO Medicine_Type (name_type, description)
VALUES
(N'Thuốc kháng sinh', N'Dùng để điều trị nhiễm khuẩn'),
(N'Thuốc giảm đau', N'Dùng để giảm đau tạm thời'),
(N'Thuốc cảm cúm', N'Dùng để điều trị cảm cúm'),
(N'Thuốc bổ', N'Tăng cường sức khỏe');

INSERT INTO Medicine (id_type, name_medicine, total_quantity, active_ingredient, contraindication, side_effects, unit, price, images)
VALUES
(1, N'Amoxicillin', 0, N'Amoxicillin trihydrate', N'Dị ứng penicillin', N'Buồn nôn, tiêu chảy', N'Viên', 10000, N''),
(2, N'Paracetamol', 0, N'Paracetamol', N'Bệnh gan nặng', N'Nổi mẩn, đau đầu', N'Viên', 5000, N''),
(3, N'Tiffy', 0, N'Chlorpheniramine + Paracetamol', N'Suy gan nặng', N'Buồn ngủ', N'Viên', 7000, N''),
(4, N'Vitamin C', 0, N'Axit ascorbic', N'Sỏi thận', N'Buồn nôn', N'Viên sủi', 3000, N'');

INSERT INTO Supplier (name_supplier, phone, gmail, address)
VALUES
(N'Công ty Dược Hậu Giang', '0901234567', 'haugiangpharma@gmail.com', N'Cần Thơ'),
(N'Công ty Traphaco', '0912345678', 'traphaco@gmail.com', N'Hà Nội');

INSERT INTO Staff (name_staff, gender, address, gmail, phone, start_date, username, password, type_staff)
VALUES
(N'Lê Văn An', N'Nam', N'Hà Nội', 'lean@pharmacy.com', '0908888888', '2023-01-01', 'lean', '123456', N'Quản lý'),
(N'Nguyễn Thị B', N'Nữ', N'HCM', 'nguyenthib@pharmacy.com', '0919999999', '2023-02-01', 'nguyenthib', '123456', N'Nhân viên');

INSERT INTO Customer (name_customer, age, gender, phone, address)
VALUES
(N'Nguyễn Văn C', 30, N'Nam', '0901111222', N'Hải Phòng'),
(N'Trần Thị D', 25, N'Nữ', '0903333444', N'Đà Nẵng');

INSERT INTO Purchase_Invoice (date_create, id_supplier, id_staff, total_amount)
VALUES
('2024-01-10', 1, 1, 0),
('2024-02-15', 2, 2, 0);

-- Lô 1: Còn hạn
INSERT INTO Batch (id_medicine, quantity_in_batch, entry_price, manufacturing_date, expiry_date, status, quantity_shortage, note)
VALUES
(1, 100, 9000, '2024-01-01', '2026-01-01', 'Active', 0, N'Đợt 1 nhập');

-- Lô 2: Sắp hết hạn
INSERT INTO Batch (id_medicine, quantity_in_batch, entry_price, manufacturing_date, expiry_date, status, quantity_shortage, note)
VALUES
(2, 50, 4500, '2023-01-01', '2024-06-01', 'Active', 0, N'Gần hết hạn');

-- Lô 3: Hết hạn
INSERT INTO Batch (id_medicine, quantity_in_batch, entry_price, manufacturing_date, expiry_date, status, quantity_shortage, note)
VALUES
(3, 20, 6500, '2022-01-01', '2023-01-01', 'Active', 0, N'Hết hạn');

-- Lô 4: Đã bán hết
INSERT INTO Batch (id_medicine, quantity_in_batch, entry_price, manufacturing_date, expiry_date, status, quantity_shortage, note)
VALUES
(4, 50, 2800, '2024-01-01', '2025-12-01', 'Active', 50, N'Hết hàng');

INSERT INTO Purchase_details (id_purchase, id_batch)
VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4);

INSERT INTO Sale_Invoice (id_staff, id_customer, date_create, status)
VALUES
(1, 1, '2024-04-01', 'Đã thanh toán'),
(2, 2, '2024-05-01', 'Đã thanh toán');

-- Bán Amoxicillin từ lô 1
INSERT INTO Sale_details (id_sale, id_medicine, quantity_sale, price)
VALUES
(1, 1, 10, 10000);

-- Bán Paracetamol từ lô 2
INSERT INTO Sale_details (id_sale, id_medicine, quantity_sale, price)
VALUES
(2, 2, 5, 5000);
SELECT * FROM Staff;