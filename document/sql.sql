create database QuanLyKhachSan
use QuanLyKhachSan

drop database QuanLyKhachSan

CREATE TABLE [User] (
    uid INT PRIMARY KEY IDENTITY(1,1),
    fullName NVARCHAR(255),
    userName NVARCHAR(255) UNIQUE,
    passWord NVARCHAR(255),
    last_pwd_change DATETIME,
    isGroup BIT DEFAULT 0,
    disable BIT DEFAULT 0
);

CREATE TABLE KhachHang (
    idKH INT PRIMARY KEY IDENTITY(1,1),
    hoTen NVARCHAR(255) NOT NULL,
    gioiTinh NVARCHAR(10),
    cccd NVARCHAR(50),
    dienThoai NVARCHAR(20),
    email NVARCHAR(255),
    diaChi NVARCHAR(255),
    disable BIT DEFAULT 0
);

CREATE TABLE Tang (
    idTang INT PRIMARY KEY IDENTITY(1,1),
    tenTang NVARCHAR(50),
    disable BIT DEFAULT 0
);

CREATE TABLE LoaiPhong (
    idLoaiPhong INT PRIMARY KEY IDENTITY(1,1),
    tenLoaiPhong NVARCHAR(255) NOT NULL,
    donGia DECIMAL(10, 2) NOT NULL,
    soNguoi INT,
    soGiuong INT,
    disable BIT DEFAULT 0
);

CREATE TABLE Phong (
    idPhong INT PRIMARY KEY IDENTITY(1,1),
    tenPhong NVARCHAR(255) NOT NULL,
    trangThai BIT DEFAULT 0,
    idTang INT,
    idLoaiPhong INT,
    disable BIT DEFAULT 0,
    FOREIGN KEY (idTang) REFERENCES Tang(idTang),
    FOREIGN KEY (idLoaiPhong) REFERENCES LoaiPhong(idLoaiPhong)
);

CREATE TABLE ThietBi (
    idTB INT PRIMARY KEY IDENTITY(1,1),
    tenTB NVARCHAR(255),
    donGia DECIMAL(10, 2),
    disable BIT DEFAULT 0
);

CREATE TABLE Phong_TB (
    idPhong INT,
    idTB INT,
    soLuong INT,
    PRIMARY KEY (idPhong, idTB),
    FOREIGN KEY (idPhong) REFERENCES Phong(idPhong),
    FOREIGN KEY (idTB) REFERENCES ThietBi(idTB)
);

CREATE TABLE SanPham (
    idSP INT PRIMARY KEY IDENTITY(1,1),
    tenSP NVARCHAR(255),
    donGia DECIMAL(10, 2),
    disable BIT DEFAULT 0
);

CREATE TABLE DatPhong (
    idDP INT PRIMARY KEY IDENTITY(1,1),
    idKH INT,
    ngayDat DATE,
    ngayTra DATE,
    soTien DECIMAL(10, 2),
    soNguoiO INT,
    idUser INT,
    status NVARCHAR(50),
    disable BIT DEFAULT 0,
    theoDoan BIT,
    ghiChu TEXT,
    create_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    update_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    update_by INT,
    FOREIGN KEY (idKH) REFERENCES KhachHang(idKH),
    FOREIGN KEY (idUser) REFERENCES [User](uid)
);

CREATE TABLE DatPhong_CT (
    idDPCT INT PRIMARY KEY IDENTITY(1,1),
    idDP INT,
    idPhong INT,
    soNgayO INT,
    donGia DECIMAL(10, 2),
    thanhTien DECIMAL(10, 2),
    ngay DATE,
    FOREIGN KEY (idDP) REFERENCES DatPhong(idDP),
    FOREIGN KEY (idPhong) REFERENCES Phong(idPhong)
);

CREATE TABLE DatPhong_SP (
    idDPSP INT PRIMARY KEY IDENTITY(1,1),
    idDP INT,
    idSP INT,
    soLuong INT,
    donGia DECIMAL(10, 2),
    thanhTien DECIMAL(10, 2),
    ngay DATE,
    FOREIGN KEY (idDP) REFERENCES DatPhong(idDP),
    FOREIGN KEY (idSP) REFERENCES SanPham(idSP)
);

CREATE TABLE Rights (
    fund_code NVARCHAR(50),
    idUser INT,
    userRight NVARCHAR(50),
    PRIMARY KEY (fund_code, idUser),
    FOREIGN KEY (idUser) REFERENCES [User](uid),
    FOREIGN KEY (fund_code) REFERENCES Func(fund_code) 
);

CREATE TABLE Func (
    fund_code NVARCHAR(50) PRIMARY KEY,
    description NVARCHAR(255),
    tips NVARCHAR(255)
);

ALTER TABLE Func
DROP COLUMN sort;

select * from Tang

--Insert dữ liệu
insert into Tang(tenTang) values
(N'Tầng 1'),
(N'Tầng 2'),
(N'Tầng 3');




select * from Phong

insert into Func(fund_code, description, tips)
values 
('DANHMUC', N'Danh mục', N'Danh mục dùng chung'),
('DATPHONG', N'Quản lý Đặt phòng', null),
('KHACHHANG', N'Quản lý Khách hàng', null),
('LOAIPHONG', N'Quản lý Loại phòng', null),
('PHONG', N'Quản lý Phòng', null),
('PHONG_THIETBI', N'Quản lý Thiết bị trong phòng', null),
('THIETBI', N'Quản lý Thiết bị', null),
('SANPHAM', N'Quản lý Sản phẩm', null),
('TANG', N'Quản lý Tầng', null);

select * from Phong

insert into LoaiPhong(tenLoaiPhong, donGia, soNguoi, soGiuong)
values 
('VIP', 3500000, 2, 1),
('DELUXE', 5700000, 2, 2),
('EXCLUSIVE', 9200000, 2, 1)


insert into Phong(tenPhong, idTang, idLoaiPhong)
values 
(N'Phòng 101', 1, 1),
(N'Phòng 102', 1, 2),
(N'Phòng 201', 2, 1),
(N'Phòng 202', 2, 2),
(N'Phòng 203', 2, 2),
(N'Phòng 301', 3, 3),
(N'Phòng 302', 3, 3);

select * from SanPham

insert into SanPham (tenSP, donGia)
values
(N'Coca Cola', 15000),
(N'Nước suối', 12000),
(N'Redbull', 20000),
(N'Fanta', 15000),
(N'Cam ép', 15000),
(N'Trà Ô long', 15000);

 

insert into ThietBi (tenTB, donGia)
values
(N'Remote máy lạnh 2HP Daikin', 150000),
(N'Máy lạnh Daikin 2HP', 12000000),
(N'Khăn tắm lớn', 50000),
(N'Khăn tắm nhỏ', 35000),
(N'Tivi 50inches LG', 8500000),
(N'Remote TV LG 50inches', 200000),
(N'Dép lào', 30000);

select * from Phong_TB
insert into Phong_TB
values
(1, 1, 1),
(1, 2, 1),
(1, 3, 1),
(1, 4, 2),
(1, 5, 1),
(1, 6, 1),
(1, 7, 2);

select * from KhachHang

insert into KhachHang(hoTen, gioiTinh, cccd, dienThoai, email, diaChi)
values
(N'Nguyễn Phúc Bảo Nhân', 1, '060203003432', '0948877502', 'npbaonhan18803@gmail.com', N'490/54 Lê Văn Sỹ'),
(N'Nguyễn Thanh Tuyền', 0, '060203003485', '0948478963', 'thanhtuyen@gmail.com', N'23 Bùi Thị Xuân'),
(N'Đặng Thị Kim Ngân', 0, '060203002222', '0941263549', 'kimngan@gmail.com', N'12/7 Tôn Thất Đạm');

select * from DatPhong

select p.idPhong, p.tenPhong, lp.donGia, p.idTang
from Phong p, Tang t, LoaiPhong lp
where p.idTang = t.idTang and p.trangThai = 0 and p.idLoaiPhong = lp.idLoaiPhong

select * from DatPhong

select * from DatPhong_CT
select * from DatPhong_SP

select * from [User]

INSERT INTO [User] (fullName, userName, passWord, last_pwd_change, isGroup, disable)
VALUES (N'Nguyễn Phúc Bảo Nhân', 'baronhan', '123456', GETDATE(), 0, 0);

delete from DatPhong
where idDP = 6

SELECT DISTINCT sp.idSP, sp.tenSP
FROM SanPham sp
JOIN DatPhong_SP ctsp ON sp.idSP = ctsp.idSP
WHERE ctsp.idDP = 7 AND ctsp.idPhong = 17;

select * from SanPham

--select * from DatPhong_SP
--where idDP = 7 and idSP = 5 and 

CREATE TABLE NhomNguoiDung (
    userType INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL
);

CREATE TABLE Form (
    formID INT IDENTITY(1,1) PRIMARY KEY,
    url NVARCHAR(255) NOT NULL
);


CREATE TABLE Permission (
    userType INT NOT NULL,
    formID INT NOT NULL,
	coQuyen BIT NOT NULL,
    PRIMARY KEY (userType, formID),
    FOREIGN KEY (userType) REFERENCES NhomNguoiDung(userType),
    FOREIGN KEY (formID) REFERENCES Form(formID)
);

ALTER TABLE [User]
ADD CONSTRAINT FK_User_UserType FOREIGN KEY (userType) 
REFERENCES NhomNguoiDung(userType);

INSERT INTO NhomNguoiDung(name)
VALUES 
    ('Admin'),
    (N'Lễ tân')
select * from Form

INSERT INTO Form (url)
VALUES 
    ('Form_BaoCao'),
    ('Form_DatPhongtheoDoan'),
    ('Form_GoiYPhong'),
    ('Form_KhachHang'),
    ('Form_Login'),
    ('Form_Main'),
    ('Form_Phong'),
    ('Form_DoiMatKhau'),
    ('Form_SanPham'),
    ('Form_Tang'),
    ('Form_ThietBi'),
    ('Form_ThietBiTrongPhong'),
    ('Form_LoaiPhong');

	SELECT p.*
FROM Permission p
INNER JOIN Form pg ON p.formID = pg.formID
WHERE p.userType = 2
  AND pg.url = 'Form_Main'
  AND p.CoQuyen = 1

