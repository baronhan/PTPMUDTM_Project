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
(N'Phòng Deluxe', N'Phong danh cho 2 nguoi voi 1 giuong doi'),
(N'Phòng Deluxe Suite', N'Phong danh cho 2 nguoi voi 2 giuong don'),
(N'Phòng Executive', N'Phong danh cho 2 nguoi voi 1 giuong doi'),
('Phòng President Suite', 'Phong danh cho 3 nguoi voi 1 giuong don va 1 giuong doi');

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
insert into Phong values 
(N'Phòng Deluxe', 2, 2500000, N'Phòng Deluxe (Huong Thanh pho)', 1, 1),
(N'Phòng Deluxe', 2, 3000000, N'Phòng Deluxe (Huong Song)', 1, 1),
(N'Phòng Executive', 2, 3500000, N'Phòng Executive (Huong Thanh pho)', 4, 1),
(N'Phòng Executive', 2, 4000000, N'Phòng Executive (Huong Song)', 4, 1),
(N'Phòng Deluxe Suite', 2, 3250000, N'Phòng Deluxe Suite (Huong Thanh pho)', 2, 1),
(N'Phòng Deluxe Suite', 2, 3750000, N'Phòng Deluxe Suite (Huong Song)', 2, 1),
(N'Phòng President Suite', 3, 4950000, N'Phòng President Suite', 3, 1);

-- Dữ liệu cho bảng Hinh_Anh_Phong
INSERT INTO Hinh_Anh_Phong (url, maPhong)
VALUES 
  (N'..\..\Images\room_001.jpeg', 1),
  (N'..\..\Images\room_002.jpeg', 1),

  (N'..\..\Images\room_003.jpeg', 2),
  (N'..\..\Images\room_004.jpeg', 2),

  (N'..\..\Images\room_005.jpeg', 3),
  (N'..\..\Images\room_006.jpeg', 3),

  (N'..\..\Images\room_007.jpeg', 4),
  (N'..\..\Images\room_008.jpeg', 4),

  (N'..\..\Images\room_009.jpeg', 5),
  (N'..\..\Images\room_010.jpeg', 5),

  (N'..\..\Images\room_011.jpeg', 6),
  (N'..\..\Images\room_012.jpeg', 6),

  (N'..\..\Images\room_013.jpeg', 7),
  (N'..\..\Images\room_014.jpeg', 7);

-- Dữ liệu cho bảng Dich_Vu
INSERT INTO Dich_Vu (TenDich, Acronym, DonGia) VALUES
(N'Dich vu giat la', 'DVGL', 50000.00),
(N'Dich vu don phong', 'DVDP', 70000.00),
(N'Dich vu dua don', 'DVDD', 200000.00),
(N'Dich vu an uong', 'DVAU', 150000.00),
(N'Dich vu spa', 'DVSP', 300000.00);

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




