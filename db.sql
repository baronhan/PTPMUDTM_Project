create database DatPhongKhachSan
use DatPhongKhachSan

drop database DatPhongKhachSan

CREATE TABLE Loai_Phong (
    maLoaiPhong INT IDENTITY(1,1) PRIMARY KEY,
    tenLoaiPhong VARCHAR(100),
    moTa VARCHAR(250)
);

CREATE TABLE DM_Man_Hinh (
    maManHinh INT IDENTITY(1,1) PRIMARY KEY,
    tenManHinh VARCHAR(100)
);

CREATE TABLE Phong (
    maPhong INT IDENTITY(1,1) PRIMARY KEY,
    tenPhong VARCHAR(100),
    soLuongNguoi INT,
    donGia DECIMAL(10, 2),
    moTa TEXT,
    maLoaiPhong int,
    trangThai INT,
	FOREIGN KEY (maLoaiPhong) REFERENCES Loai_Phong(maLoaiPhong)
);

CREATE TABLE Hinh_Anh_Phong (
    maHinhAnh INT IDENTITY(1,1) PRIMARY KEY,
    url VARCHAR(255),
    maPhong INT,
    FOREIGN KEY (maPhong) REFERENCES Phong(maPhong)
);

CREATE TABLE Dich_Vu (
    maDichVu INT IDENTITY(1,1) PRIMARY KEY,
    tenDich VARCHAR(100),
    acronym VARCHAR(10),
    donGia DECIMAL(10, 2)
);

CREATE TABLE Nhom_Nguoi_Dung (
    maNhom INT IDENTITY(1,1) PRIMARY KEY,
    tenNhom VARCHAR(50),
    ghiChu TEXT
);

CREATE TABLE Khach_Hang (
    maKH INT IDENTITY(1,1) PRIMARY KEY,
    userName VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    hoTen VARCHAR(100),
    email VARCHAR(100),
    diaChi VARCHAR(255),
    soDienThoai VARCHAR(20),
    maNhomNguoiDung INT,
    FOREIGN KEY (maNhomNguoiDung) REFERENCES Nhom_Nguoi_Dung(maNhom)
);

CREATE TABLE Phieu_Dat_Phong (
    maDatPhong INT IDENTITY(1,1) PRIMARY KEY,
    maKH INT,
    maPhong INT,
    checkIn DATE,
    checkOut DATE,
    soTaiKhoan VARCHAR(50),
    tongTien DECIMAL(10, 2),
    FOREIGN KEY (maKH) REFERENCES Khach_Hang(maKH),
    FOREIGN KEY (maPhong) REFERENCES Phong(maPhong)
);

CREATE TABLE CT_PDP_DV (
    maDatPhong INT,
    maDichVu INT,
    soLuong INT,
    tongTien DECIMAL(10, 2),
    PRIMARY KEY (maDatPhong, maDichVu),
    FOREIGN KEY (maDatPhong) REFERENCES Phieu_Dat_Phong(maDatPhong),
    FOREIGN KEY (maDichVu) REFERENCES Dich_Vu(maDichVu)
);

CREATE TABLE Phan_Quyen (
    maNhomNguoiDung INT,
    maManHinh INT,
    coQuyen BIT,
    PRIMARY KEY (maNhomNguoiDung, maManHinh),
    FOREIGN KEY (maNhomNguoiDung) REFERENCES Nhom_Nguoi_Dung(maNhom),
    FOREIGN KEY (maManHinh) REFERENCES DM_Man_Hinh(maManHinh)
);

-- Dữ liệu cho bảng Loai_Phong
INSERT INTO Loai_Phong (tenLoaiPhong, moTa)
VALUES 
('Phòng đơn', 'Phòng dành cho 1 người với 1 giường đơn.'),
('Phòng đôi', 'Phòng dành cho 2 người với 1 giường đôi.'),
('Phòng gia đình', 'Phòng dành cho gia đình với 2 giường đôi.'),
('Phòng VIP', 'Phòng cao cấp với nhiều tiện nghi sang trọng.');

-- Dữ liệu cho bảng DM_Man_Hinh
INSERT INTO DM_Man_Hinh (tenManHinh)
VALUES 
('Trang chủ'),
('Quản lý phòng'),
('Quản lý khách hàng'),
('Quản lý dịch vụ'),
('Quản lý đặt phòng'),
('Quản lý phân quyền');

-- Dữ liệu cho bảng Phong
INSERT INTO Phong (tenPhong, soLuongNguoi, donGia, moTa, maLoaiPhong, trangThai)
VALUES 
('Phòng 101', 2, 500000, 'Phòng có giường đôi, máy lạnh, TV.', 2, 0),
('Phòng 102', 4, 1200000, 'Phòng gia đình, 2 giường đôi, máy lạnh, TV, minibar.', 3, 1),
('Phòng 103', 1, 300000, 'Phòng đơn, 1 giường đơn, máy lạnh, TV.', 1, 0),
('Phòng VIP 201', 2, 2000000, 'Phòng VIP, giường king-size, phòng tắm riêng, TV, minibar, view đẹp.', 4, 0);

-- Dữ liệu cho bảng Hinh_Anh_Phong
INSERT INTO Hinh_Anh_Phong (url, maPhong)
VALUES 
('http://example.com/room101.jpg', 1),
('http://example.com/room102.jpg', 2),
('http://example.com/room103.jpg', 3),
('http://example.com/vip201.jpg', 4);

-- Dữ liệu cho bảng Dich_Vu
INSERT INTO Dich_Vu (tenDich, acronym, donGia)
VALUES 
('Giặt ủi', 'GU', 50000),
('Thuê xe', 'TX', 200000),
('Đưa đón sân bay', 'DDSB', 500000),
('Bữa sáng', 'BS', 100000);

-- Dữ liệu cho bảng Nhom_Nguoi_Dung
INSERT INTO Nhom_Nguoi_Dung (tenNhom, ghiChu)
VALUES 
('Khách hàng', 'Người sử dụng dịch vụ phòng.'),
('Quản trị viên', 'Quản lý toàn bộ hệ thống.'),
('Nhân viên lễ tân', 'Quản lý đặt phòng và dịch vụ.');

-- Dữ liệu cho bảng Khach_Hang
INSERT INTO Khach_Hang (userName, password, hoTen, email, diaChi, soDienThoai, maNhomNguoiDung)
VALUES 
('baro_nhan', '123', N'Nguyễn Phúc Bảo Nhân', 'npbaonhan18803@gmail.com', '490/54 Lê Văn Sỹ', '0948877502', 1);

-- Dữ liệu cho bảng Phieu_Dat_Phong
INSERT INTO Phieu_Dat_Phong (maKH, maPhong, checkIn, checkOut, soTaiKhoan, tongTien)
VALUES 
(1, 1, '2024-09-20', '2024-09-25', '1234567890', 2500000),
(2, 2, '2024-09-18', '2024-09-20', '0987654321', 2400000);

-- Dữ liệu cho bảng CT_PDP_DV
INSERT INTO CT_PDP_DV (maDatPhong, maDichVu, soLuong, tongTien)
VALUES 
(1, 1, 2, 100000), -- John sử dụng 2 lần dịch vụ giặt ủi
(1, 4, 5, 500000), -- John sử dụng 5 lần bữa sáng
(2, 3, 1, 500000); -- Jane sử dụng 1 lần đưa đón sân bay

-- Dữ liệu cho bảng Phan_Quyen
INSERT INTO Phan_Quyen (maNhomNguoiDung, maManHinh, coQuyen)
VALUES 
(1, 1, 1), -- Khách hàng có quyền xem trang chủ
(2, 2, 1), -- Quản trị viên có quyền quản lý phòng
(2, 3, 1), -- Quản trị viên có quyền quản lý khách hàng
(3, 5, 1), -- Nhân viên lễ tân có quyền quản lý đặt phòng
(2, 6, 1); -- Quản trị viên có quyền quản lý phân quyền




