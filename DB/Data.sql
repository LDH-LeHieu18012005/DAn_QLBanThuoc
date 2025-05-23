INSERT INTO Medicine_Type (name_type, description)
VALUES
(N'Thuốc kháng sinh', N'Dùng để điều trị nhiễm khuẩn'),
(N'Thuốc giảm đau', N'Dùng để giảm đau tạm thời'),
(N'Thuốc cảm cúm', N'Dùng để điều trị cảm cúm'),
(N'Thuốc bổ', N'Tăng cường sức khỏe'),
(N'Thuốc hạ sốt', N'Giúp giảm thân nhiệt khi bị sốt'),
(N'Thuốc chống dị ứng', N'Điều trị các triệu chứng dị ứng'),
(N'Thuốc an thần', N'Giúp thư giãn và dễ ngủ'),
(N'Thuốc tim mạch', N'Dùng để điều trị bệnh liên quan đến tim mạch'),
(N'Thuốc dạ dày', N'Điều trị các bệnh liên quan đến dạ dày'),
(N'Thuốc hô hấp', N'Điều trị các bệnh về đường hô hấp'),
(N'Thuốc điều trị tiểu đường', N'Giúp kiểm soát lượng đường huyết'),
(N'Thuốc trị nấm', N'Diệt nấm và ngăn ngừa nấm tái phát');

INSERT INTO Medicine (id_type, name_medicine, total_quantity, active_ingredient, contraindication, side_effects, unit, price, images)
VALUES
(1, N'Amoxicillin', 0, N'Amoxicillin trihydrate', N'Dị ứng penicillin', N'Buồn nôn, tiêu chảy', N'Viên', 10000, N''),
(2, N'Paracetamol', 0, N'Paracetamol', N'Bệnh gan nặng', N'Nổi mẩn, đau đầu', N'Viên', 5000, N''),
(3, N'Tiffy', 0, N'Chlorpheniramine + Paracetamol', N'Suy gan nặng', N'Buồn ngủ', N'Viên', 7000, N''),
(4, N'Vitamin C', 0, N'Axit ascorbic', N'Sỏi thận', N'Buồn nôn', N'Viên sủi', 3000, N'');
select * from Medicine
INSERT INTO Supplier (name_supplier, phone, gmail, address)
VALUES
(N'Công ty Dược Hậu Giang', '0901234567', 'haugiangpharma@gmail.com', N'Cần Thơ'),
(N'Công ty Traphaco', '0912345678', 'traphaco@gmail.com', N'Hà Nội'),
(N'Công ty Dược OPC', '0902345678', 'opcpharma@gmail.com', N'Hồ Chí Minh'),
(N'Công ty Dược Mediplantex', '0934567890', 'mediplantex@gmail.com', N'Hà Nội'),
(N'Công ty Dược Domesco', '0945678901', 'domesco@gmail.com', N'Đồng Tháp'),
(N'Công ty Dược Savi', '0956789012', 'savipharma@gmail.com', N'TP. Hồ Chí Minh'),
(N'Công ty Dược Imexpharm', '0967890123', 'imexpharm@gmail.com', N'Đồng Tháp'),
(N'Công ty Dược Phano', '0978901234', 'phano@gmail.com', N'TP. Hồ Chí Minh'),
(N'Công ty Dược Pymepharco', '0989012345', 'pymepharco@gmail.com', N'Phú Yên'),
(N'Công ty Dược Mekophar', '0990123456', 'mekophar@gmail.com', N'TP. Hồ Chí Minh');
select * from Medicine
INSERT INTO Staff (name_staff, gender, address, gmail, phone, start_date, username, password, type_staff)
VALUES
(N'Lê Văn An', N'Nam', N'Hà Nội', 'lean@pharmacy.com', '0908888888', '2023-01-01', 'lean', '123456', N'Quản lý'),
(N'Nguyễn Thị B', N'Nữ', N'HCM', 'nguyenthib@pharmacy.com', '0919999999', '2023-02-01', 'nguyenthib', '123456', N'Nhân viên'),
(N'Phạm Minh Cường', N'Nam', N'Đà Nẵng', 'cuongpm@pharmacy.com', '0921111222', '2023-03-01', 'cuongpm', '123456', N'Nhân viên'),
(N'Lý Thị Duyên', N'Nữ', N'Hải Phòng', 'duyenlt@pharmacy.com', '0932222333', '2023-04-01', 'duyenlt', '123456', N'Nhân viên'),
(N'Trần Văn Dũng', N'Nam', N'Cần Thơ', 'dungtv@pharmacy.com', '0943333444', '2023-05-01', 'dungtv', '123456', N'Nhân viên'),
(N'Hoàng Thị Hạnh', N'Nữ', N'Nghệ An', 'hanhht@pharmacy.com', '0954444555', '2023-06-01', 'hanhht', '123456', N'Nhân viên'),
(N'Lê Quốc Huy', N'Nam', N'TP.HCM', 'huylq@pharmacy.com', '0965555666', '2023-07-01', 'huylq', '123456', N'Quản lý'),
(N'Ngô Thị Kim', N'Nữ', N'Bình Dương', 'kimnt@pharmacy.com', '0976666777', '2023-08-01', 'kimnt', '123456', N'Nhân viên');

INSERT INTO Customer (name_customer, age, gender, phone, address)
VALUES
(N'Nguyễn Văn C', 30, N'Nam', '0901111222', N'Hải Phòng'),
(N'Trần Thị D', 25, N'Nữ', '0903333444', N'Đà Nẵng'),
(N'Lê Minh Tuấn', 40, N'Nam', '0912345678', N'Hà Nội'),
(N'Phạm Thị Hương', 28, N'Nữ', '0923456789', N'TP.HCM'),
(N'Đỗ Văn Bình', 35, N'Nam', '0934567890', N'Nghệ An'),
(N'Vũ Thị Lan', 22, N'Nữ', '0945678901', N'Cần Thơ'),
(N'Hồ Trung Kiên', 50, N'Nam', '0956789012', N'Hải Dương'),
(N'Nguyễn Thị Mai', 27, N'Nữ', '0967890123', N'Bình Dương'),
(N'Bùi Văn Long', 33, N'Nam', '0978901234', N'Thanh Hóa'),
(N'Lý Thị Hòa', 45, N'Nữ', '0989012345', N'Lào Cai'),
(N'Tạ Văn Lâm', 60, N'Nam', '0990123456', N'Nam Định'),
(N'Hoàng Thị Cúc', 38, N'Nữ', '0902222333', N'Quảng Bình'),
(N'Ngô Văn Hải', 29, N'Nam', '0913333444', N'Tuyên Quang'),
(N'Đặng Thị Vân', 31, N'Nữ', '0924444555', N'Vĩnh Phúc'),
(N'Phan Văn Dũng', 70, N'Nam', '0935555666', N'Tây Ninh'),
(N'Lê Thị Sen', 62, N'Nữ', '0946666777', N'Bến Tre'),
(N'Chu Văn Tuấn', 36, N'Nam', '0957777888', N'Phú Thọ'),
(N'Nguyễn Thị Ánh', 24, N'Nữ', '0968888999', N'Hà Nam'),
(N'Võ Văn Hùng', 48, N'Nam', '0979999000', N'Kon Tum'),
(N'Phạm Thị Thúy', 55, N'Nữ', '0980000111', N'Sóc Trăng');


INSERT INTO Purchase_Invoice (date_create, id_supplier, id_staff, total_amount)
VALUES
('2024-01-10', 1, 1, 0),
('2024-02-15', 2, 2, 0);
INSERT INTO Batch (id_medicine, quantity_in_batch, entry_price, manufacturing_date, expiry_date, status, quantity_shortage, note)
VALUES
-- Acefalgan (id_medicine = 26)
(26, 100, 9000, '2024-01-01', '2026-01-01', 'Active', 0, N'Đợt 1 nhập'),
(26, 150, 8500, '2024-04-01', '2026-04-01', 'Active', 0, N'Đợt 2 nhập'),

-- Acemuc (id_medicine = 27)
(27, 120, 9500, '2024-02-15', '2026-02-15', 'Active', 0, N'Đợt 1 nhập'),
(27, 100, 9200, '2024-05-10', '2026-05-10', 'Active', 0, N'Đợt 2 nhập'),

-- Acetab (id_medicine = 28)
(28, 130, 10000, '2024-03-10', '2026-03-10', 'Active', 0, N'Đợt 1 nhập'),
(28, 140, 9800, '2024-06-10', '2026-06-10', 'Active', 0, N'Đợt 2 nhập'),

-- Actadol (id_medicine = 29)
(29, 90, 8800, '2024-01-20', '2026-01-20', 'Active', 0, N'Đợt 1 nhập'),
(29, 110, 8700, '2024-05-20', '2026-05-20', 'Active', 0, N'Đợt 2 nhập'),


-- Lô 1: Còn hạn
-- Agiclovir (id_medicine = 31)
(31, 100, 8700, '2024-03-01', '2026-03-01', 'Active', 0, N'Đợt 1 nhập'),
(31, 130, 8600, '2024-06-01', '2026-06-01', 'Active', 0, N'Đợt 2 nhập'),

-- Alaxan (id_medicine = 32)
(32, 95, 9400, '2024-02-10', '2026-02-10', 'Active', 0, N'Đợt 1 nhập'),
(32, 105, 9100, '2024-05-10', '2026-05-10', 'Active', 0, N'Đợt 2 nhập'),

-- Allerphast (id_medicine = 33)
(33, 85, 9700, '2024-01-15', '2026-01-15', 'Active', 0, N'Đợt 1 nhập'),
(33, 115, 9600, '2024-04-15', '2026-04-15', 'Active', 0, N'Đợt 2 nhập'),

-- Atilene (id_medicine = 34)
(34, 100, 8900, '2024-03-05', '2026-03-05', 'Active', 0, N'Đợt 1 nhập'),
(34, 110, 8800, '2024-06-05', '2026-06-05', 'Active', 0, N'Đợt 2 nhập'),

-- Bivinadol (id_medicine = 35)
(35, 120, 8500, '2024-01-20', '2026-01-20', 'Active', 0, N'Đợt 1 nhập'),
(35, 130, 8300, '2024-04-20', '2026-04-20', 'Active', 0, N'Đợt 2 nhập'),

-- Bogan (id_medicine = 36)
(36, 90, 8200, '2024-02-28', '2026-02-28', 'Active', 0, N'Đợt 1 nhập'),
(36, 110, 8000, '2024-05-28', '2026-05-28', 'Active', 0, N'Đợt 2 nhập'),

-- Boganic (id_medicine = 37)
(37, 100, 9300, '2024-03-10', '2026-03-10', 'Active', 0, N'Đợt 1 nhập'),
(37, 100, 9100, '2024-06-10', '2026-06-10', 'Active', 0, N'Đợt 2 nhập'),

-- Bophe (id_medicine = 38)
(38, 80, 9600, '2024-01-25', '2026-01-25', 'Active', 0, N'Đợt 1 nhập'),
(38, 120, 9400, '2024-04-25', '2026-04-25', 'Active', 0, N'Đợt 2 nhập'),

-- Brufen (id_medicine = 39)
(39, 110, 9700, '2024-02-05', '2026-02-05', 'Active', 0, N'Đợt 1 nhập'),
(39, 90, 9500, '2024-05-05', '2026-05-05', 'Active', 0, N'Đợt 2 nhập'),

-- Cholapan (id_medicine = 40)
(40, 100, 8800, '2024-03-15', '2026-03-15', 'Active', 0, N'Đợt 1 nhập'),
(40, 120, 8600, '2024-06-15', '2026-06-15', 'Active', 0, N'Đợt 2 nhập'),

-- Cufo (id_medicine = 41)
(41, 130, 9100, '2024-01-30', '2026-01-30', 'Active', 0, N'Đợt 1 nhập'),
(41, 100, 8900, '2024-04-30', '2026-04-30', 'Active', 0, N'Đợt 2 nhập'),

-- Dầu gió (id_medicine = 42)
(42, 95, 8200, '2024-02-20', '2026-02-20', 'Active', 0, N'Đợt 1 nhập'),
(42, 105, 8000, '2024-05-20', '2026-05-20', 'Active', 0, N'Đợt 2 nhập'),

-- Hapacol (id_medicine = 43)
(43, 140, 9300, '2024-03-25', '2026-03-25', 'Active', 0, N'Đợt 1 nhập'),
(43, 130, 9100, '2024-06-25', '2026-06-25', 'Active', 0, N'Đợt 2 nhập'),

-- Hasot (id_medicine = 44)
(44, 120, 9500, '2024-02-10', '2026-02-10', 'Active', 0, N'Đợt 1 nhập'),
(44, 110, 9300, '2024-05-10', '2026-05-10', 'Active', 0, N'Đợt 2 nhập');
select * FROM Staff
select * from Supplier
select * from Purchase_Invoice
INSERT INTO Purchase_Invoice (date_create, id_supplier, id_staff, total_amount)
VALUES
('2024-01-05', 13, 3, 0),
('2024-01-10', 14, 4, 0),
('2024-01-15', 15, 5, 0),
('2024-01-20', 16, 6, 0),
('2024-01-25', 17, 7, 0),
('2024-02-01', 18, 8, 0),
('2024-02-05', 19, 9, 0),
('2024-02-10', 20, 10, 0),
('2024-02-15', 21, 3, 0),
('2024-02-20', 22, 4, 0),
('2024-02-25', 13, 5, 0),
('2024-03-01', 14, 6, 0),
('2024-03-05', 15, 7, 0),
('2024-03-10', 16, 8, 0),
('2024-03-15', 17, 9, 0),
('2024-03-20', 18, 10, 0),
('2024-03-25', 19, 3, 0),
('2024-04-01', 20, 4, 0),
('2024-04-05', 21, 5, 0),
('2024-04-10', 22, 6, 0);
select * from Batch
INSERT INTO Purchase_details (id_purchase, id_batch)
VALUES
(4, 6),
(4, 7),
(5, 8),
(5, 9),
(6, 10),
(6, 11),
(7, 12),
(7, 13),
(8, 14),
(8, 15),
(9, 16),
(9, 17),
(10, 18),
(10, 19),
(11, 20),
(11, 21),
(12, 22),
(12, 23),
(13, 24),
(13, 25),
(14, 26),
(14, 27),
(15, 28),
(15, 29),
(16, 30),
(16, 31),
(17, 32),
(17, 33),
(18, 34),
(18, 35),
(19, 36),
(19, 37),
(20, 38),
(20, 39),
(21, 40),
(21, 41),
(22, 6),  -- quay vòng id_batch từ đầu nếu muốn
(22, 7),
(23, 8),
(23, 9);


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