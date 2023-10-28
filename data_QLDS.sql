CREATE DATABASE QLDS
GO
USE QLDS
GO


CREATE TABLE [LoaiCoSo] (
  [MaLoaiCS] char(10) PRIMARY KEY,
  [TenLoaiCS] nvarchar(20)
)
GO

CREATE TABLE [CoSo] (
  [MaCS] char(10) PRIMARY KEY,
  [TenCS] nvarchar(100),
  [HinhAnh] varchar(50),
  [DiaChi] nvarchar(100),
  [LinkMap] varchar(500),
  [MucGia] nvarchar(50),
  [MaLoaiCS] char(10),
  
  FOREIGN KEY (MaLoaiCS) REFERENCES LoaiCoSo(MaLoaiCS)
)
GO

CREATE TABLE [DanhMucSan] (
  [MaDanhMuc] char(20) PRIMARY KEY,
  [LoaiSan] nvarchar(30),
  [MaCS] char(10),
  
  FOREIGN KEY (MaCS) REFERENCES CoSo(MaCS)
)
GO

CREATE TABLE [San] (
  [MaSan] char(10) PRIMARY KEY,
  [SoSan] int,
  [GiaSan] nvarchar(50),
  [MaDanhMuc] char(20),

  FOREIGN KEY (MaDanhMuc) REFERENCES DanhMucSan(MaDanhMuc)
)
GO

CREATE TABLE [user_KhachHang] (
  [MaKH] char(10) PRIMARY KEY,
  [username] varchar(12) NOT NULL UNIQUE,
  [password] varchar(12) NOT NULL,
  [HoTen] nvarchar(50),
  [SoDienThoai] varchar(12),
  [Email] varchar(50)
)
GO

CREATE TABLE [LichDat] (
  [MaLichDat] char(10) PRIMARY KEY,
  [MaKhachHang] char(10),
  [MaSan] char(10),
  [ThoiGianBatDau] datetime,
  [ThoiGianKetThuc] datetime,
  [TrangThai] nvarchar(50),
  
  FOREIGN KEY (MaKhachHang) REFERENCES user_KhachHang(MaKH),
  FOREIGN KEY (MaSan) REFERENCES San(MaSan)

)
GO

CREATE TABLE [QuanTriVien] (
  [MaQTV] char(20) PRIMARY KEY,
  [LoaiQTV] nvarchar(20),
  [TenDangNhap] varchar(50) NOT NULL UNIQUE,
  [MatKhau] varchar(50) NOT NULL,
 
)
GO

CREATE TABLE [NhanVien] (
  [MaNV] char(10) PRIMARY KEY,
  [HoTen] nvarchar(50),
  [NgaySinh] Date,
  [GioiTinh] nvarchar(10),
  [SDT] varchar(12),
  [Email] varchar(50),
  [CCCD] varchar(15),

   [MaQTV] char(20),

  FOREIGN KEY (MaQTV) REFERENCES QuanTriVien(MaQTV)
)
GO

CREATE TABLE [HoaDon] (
  [MaHoaDon] char(10) PRIMARY KEY,
  [MaLichDat] char(10),
  [MaKhachHang] char(10),
  [MaNV] char(10),
  [NgayTao] date,

  FOREIGN KEY (MaLichDat) REFERENCES LichDat(MaLichDat),
  FOREIGN KEY (MaKhachHang) REFERENCES user_KhachHang(MaKH),
  FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
  
)
GO

CREATE TABLE [CTHD] (
  [MaCTHD] char(10) PRIMARY KEY,
  [MaHoaDon] char(10),
  [NgayDat] date,
  [LoaiSan] nvarchar(10),
  [SoSan] int,
  [SoGioDat] float,
  [SoLuongDat] int,
  [TongTien] decimal(18, 2),

  FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
)
GO

CREATE TABLE [PhanCong] (
  [MaNV] char(10),
  [MaCS] char(10),
  GhiChu nvarchar(100),

  PRIMARY KEY (MaNV, MaCS)
)
GO



CREATE TABLE [Quyen] (
  [MaQuyen] char(50) PRIMARY KEY,
  [TenQuyen] nvarchar(50)
)
GO

CREATE TABLE [PhanQuyen] (
  [MaQTV] char(20),
  [MaQuyen] char(50),
  [GhiChu] nvarchar(50),

  PRIMARY KEY ([MaQTV], [MaQuyen])
)
GO

CREATE TABLE [TaiKhoan] (
  [MaTK] char(10) PRIMARY KEY,
  [MaKH] char(10),
  [username] varchar(12),
  [password] varchar(12),

)
GO

--- INSERT LOẠI CƠ SỞ
insert into LoaiCoSo(MaLoaiCS,TenLoaiCS)
values ('cauLong',N'Cầu lông'),
		('bongDa',N'Bóng đá'),
		('quanVot',N'Quần vợt'),
		('bongRo', N'Bóng rổ');

--- INSERT CƠ SỞ TENNIS
insert into CoSo(MaCS,TenCS,HinhAnh,DiaChi,LinkMap,MucGia,MaLoaiCS)
			values ('P/S', N'Sân Tennis P/S','sTennis_PS.jpg',N'Phước Long A, Quận 9, Thành phố Hồ Chí Minh',
'https://maps.app.goo.gl/utFwKQvzTVYEinmL8',N'150.000đ - 200.000đ','quanVot'),
			
			('NVKB', N'Sân Tennis Trường Nghiệp Vụ Kho Bạc','sTennis_NVKB.jpg',N'Võ Văn Hát, Long Trường, Quận 9, Thành phố Hồ Chí Minh',
'https://maps.app.goo.gl/SMSqXo4MidqxzSXv7',N'150.000đ - 200.000đ','quanVot'),

			('LV',N'Sân tennis Lâm Viên','sTennis_LamVien.jpg',N'155 Linh Trung, Khu phố 1, Phường Linh Trung, quận Thủ Đức, TP Hồ Chí Minh.',
'https://maps.app.goo.gl/NqU5yyNgw885H9hT8',N'150.000đ - 200.000đ','quanVot'),

			('DHNH', N'Sân Tennis ĐH Ngân Hàng TPHCM','sTennis_DHNH.jpg',N'56 Đ. Hoàng Diệu 2, Linh Chiểu, Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam',
'https://maps.app.goo.gl/niY72YdrYoaPCFXPA',N'150.000đ - 200.000đ','quanVot'),

			('LT', N'Sân Tennis Linh Trung','sTennis_LT.jpg',N'Phường Linh Trung, Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam',
'https://maps.app.goo.gl/3bXaWy2jX9XTuN3DA',N'150.000đ - 200.000đ','quanVot'),

			('CDCN', N'Sân Tennis CĐ Công Nghệ Thủ Đức','sTennis_CDCN.jpg',N'Võ Văn Ngân, Linh Chiểu, Thủ Đức, Thành phố Hồ Chí Minh, Việt Nam',
'https://maps.app.goo.gl/wavw9NKiqzVSP5aC6',N'100.000đ - 180.000đ','quanVot')

--- INSERT CƠ SỞ CẦU LÔNG 
insert into CoSo(MaCS,TenCS,HinhAnh,DiaChi,LinkMap,MucGia,MaLoaiCS)
			values ('hvct',N'Sân cầu lông Học viện Chính trị','san-cau-long_hvct.jpg',N'Số 99 Man Thiện,
Phường Hiệp Phú, Quận 9','https://maps.app.goo.gl/4NnhqB933sAVUYrW6',N'50.000đ - 100.000đ','cauLong'),

			('rebell',N'Sân cầu lông Rebell','sCauLong_Rebell.jpg',N'Đường Đỗ Xuân Hợp, 
quận 9 (Gần ngã ba đường Dương Đình Hội, Đỗ Xuân Hợp)','https://maps.app.goo.gl/mBHNf3ECgknduELY6',N'60.000đ - 80.000đ','cauLong'),

			('bt',N'Sân cầu lông Bình Thái','sCauLong_BinhThai.jpg',N'18 Xa lộ Hà Nội, Phước Long B, Quận 9, Hồ Chí Minh',
			'https://maps.app.goo.gl/VxqzCRAfsBcMqh2R8',N'50.000đ - 80.000đ','cauLong'),

			('dp',N'Sân cầu lông Đông Phương','sCauLong_DongPhuong.jpg',N'837 Đường Nguyễn Duy Trinh, Phường Phú Hữu, Quận 9, Hồ Chí Minh',
			'https://maps.app.goo.gl/iVjyC5vYbyb2Zz4b9',N'50.000đ - 80.000đ','cauLong'),

			('tk',N'Sân cầu lông Tám Khỏe','sCauLong_TamKhoe.jpg',N'270 Bưng Ông Thoàn, Phường Tăng Nhơn Phú B, Quận 9, Hồ Chí Minh',
			'https://maps.app.goo.gl/B6hbK6PbJS2XzRHz8','40.000đ - 50.000đ','cauLong'),

			('hp',N'Sân cầu lông Hoài Phương','sCauLong_HoaiPhuong.jpg',N'146 Nam Hòa, Phước Long A, Quận 9, Hồ Chí Minh',
			'https://maps.app.goo.gl/qADvPnEppiQdUERU6',N'40.000đ - 80.000đ','cauLong')

--- INSERT CƠ SỞ BÓNG RỔ
insert into CoSo(MaCS,TenCS,HinhAnh,DiaChi,LinkMap,MucGia,MaLoaiCS) 
			values ('tdtttd',N'Sân bóng rổ tại Trung Tâm TDTT Quận 9','sBongRo_TDTT.jpg',N'Số 402A Lê Văn Việt, phường Tăng Nhơn Phú A, Quận 9, Hồ Chí Minh',
'https://maps.app.goo.gl/dLERyfpapshBvBUf8',N'200.000đ - 400.000đ','bongRo'),

			('or',N'Sân bóng rổ Nhà Thi Đấu Nguyễn Du','sBongRo_NguyenDu.jpg',N'Số 116 Nguyễn Du, phường Bến Thành, Quận 1, Hồ Chí Minh.',
'https://maps.app.goo.gl/XpH43vpBMP9Pxy358',N'250.000đ - 400.000đ','bongRo'),

			('cob',N'Sân vận động Hoa Lư','san-bong-ro-puzzle.jpg',N'Số 2 Đinh Tiên Hoàng, Đa Kao, Quận 1, Hồ Chí Minh',
'https://maps.app.goo.gl/zh8wVMa6No8JbNrC9',N'200.000đ - 600.000đ','bongRo'),
			
			('mnt',N'Sân bóng rổ khu Manhattan','sBongRo_Manhattan.jpg',N'Nguyễn Xiển, Long Thạnh Mỹ, Quận 9',
'https://maps.app.goo.gl/D5bvhzkoTFGU2C569',N'200.000đ - 350.000đ','bongRo'),

			('rmit',N'Sân bóng rổ trong Trường Đại học RMIT','sBongRo_RMIT.jpg',N'Số 702 Nguyễn Văn Linh, Tân Hưng, Quận 7',
'https://maps.app.goo.gl/yQ1uhPfiUE1sH43b9',N'300.000đ - 500.000đ','bongRo'),

			('cv',N'Sân bóng rổ tại Công viên Quận 9','sBongRo_CVQ9.jpg',N'Hồ Thị Tư, Hiệp Phú, Quận 9, Thành phố Hồ Chí Minh',
'https://maps.app.goo.gl/rwKBPgc5TU4viYU47',N'150.000đ - 300.000đ','bongRo')

--- INSERT CƠ SỞ BÓNG ĐÁ
insert into CoSo(MaCS,TenCS,HinhAnh,DiaChi,LinkMap,MucGia,MaLoaiCS) 
			values ('lt_f',N'Sân bóng đá Lâm Thịnh','sanbongda_LT.jpg',N'Đường số 2, P.Tăng Nhơn Phú B,Q.9',
			'https://maps.app.goo.gl/s11ibiq22m2ptxJbA',N'200.000đ - 500.000đ','bongDa'),

			('pd',N'Sân bóng đá Phù Đổng','san_phudong.jpg',N'255 Đỗ Xuân Hợp, Q.9,TP.HCM',
			'https://maps.app.goo.gl/DJQbkVzNifg7u9d18',N'200.000đ - 400.000đ','bongDa'),

			('nl',N'Sân bóng đá cầu Nam Lý','san_namly.jpg',N'Số 609, hẻm 445 đường Đỗ Xuân Hợp,P. Phước Long B, Quận 9',
			'https://maps.app.goo.gl/gch3AYMGiKtkNX8v5',N'300.000đ - 500.000đ','bongDa'),

			('ls',N'Sân bóng đá mini Lam Sơn','san_lamson.jpg',N'99 Lã Xuân Oai, quận 9, TP Hồ Chí Minh',
			'https://maps.app.goo.gl/sUMUMcupk2R33dxY7',N'200.000đ - 600.000đ','bongDa'),

			('gtvt',N'Sân KTX trường ĐH Giao thông vận tải','san_gtvt.jpg',N'Số 442, Đường Lê Văn Việt, P. Tăng Nhơn Phú A, Quận 9',
			'https://maps.app.goo.gl/GaNE9GvkmQTqTTLD7',N'100.000đ - 500.000đ','bongDa'),

			('tvt',N'Sân bóng Trương Văn Thành','san_tvt.jpg',N'Số 50/16, đường Trương Văn Thành, P. Hiệp Phú, Quận 9',
			'https://maps.app.goo.gl/f6haCkVqYxQUHhzXA',N'100.000đ - 400.000đ','bongDa')


--- INSERT DANH MỤC SÂN

--- DANH MỤC SÂN BÓNG ĐÁ
INSERT INTO DanhMucSan(MaDanhMuc, LoaiSan, MaCS)
			VALUES ('san_5_LT', N'Sân 5', 'lt_f'),
					('san_7_LT', N'Sân 7', 'lt_f'),

					('san_5_PD', N'Sân 5', 'pd'),
					('san_7_PD', N'Sân 7', 'pd'),

					('san_5_NL', N'Sân 5', 'nl'),
					('san_7_NL', N'Sân 7', 'nl'),

					('san_5_LS', N'Sân 5', 'ls'),
					('san_7_LS', N'Sân 7', 'ls'),

					('san_5_GT', N'Sân 5', 'gtvt'),
					('san_7_GT', N'Sân 7', 'gtvt'),

					('san_5_TVT', N'Sân 5', 'tvt'),
					('san_7_TVT', N'Sân 7', 'tvt'),
--- DANH MỤC SÂN CẦU LÔNG
					('CL_Don_HVCT', N'Đánh đơn', 'hvct'),
					('CL_Doi_HVCT', N'Đánh đôi', 'hvct'),

					('CL_Don_Rebell', N'Đánh đơn', 'rebell'),
					('CL_Doi_Rebell', N'Đánh đôi', 'rebell'),

					('CL_Don_BT', N'Đánh đơn', 'bt'),
					('CL_Doi_BT', N'Đánh đôi', 'bt'),

					('CL_Don_DP', N'Đánh đơn', 'dp'),
					('CL_Doi_DP', N'Đánh đôi', 'dp'),

					('CL_Don_TK', N'Đánh đơn', 'tk'),
					('CL_Doi_TK', N'Đánh đôi', 'tk'),

					('CL_Don_HP', N'Đánh đơn', 'hp'),
					('CL_Doi_HP', N'Đánh đôi', 'hp'),

--- DANH MỤC SÂN TENNIS
					('QV_Don_PS', N'Đánh đơn', 'P/S'),
					('QV_Doi_PS', N'Đánh đôi', 'P/S'),

					('QV_Don_NVKB', N'Đánh đơn', 'NVKB'),
					('QV_Doi_NVKB', N'Đánh đôi', 'NVKB'),

					('QV_Don_LV', N'Đánh đơn', 'LV'),
					('QV_Doi_LV', N'Đánh đôi', 'LV'),

					('QV_Don_DHNH', N'Đánh đơn', 'DHNH'),
					('QV_Doi_DHNH', N'Đánh đôi', 'DHNH'),

					('QV_Don_LT', N'Đánh đơn', 'LT'),
					('QV_Doi_LT', N'Đánh đôi', 'LT'),

					('QV_Don_CDCN', N'Đánh đơn', 'CDCN'),
					('QV_Doi_CDCN', N'Đánh đôi', 'CDCN'),

-- DANH MỤC SÂN BÓNG RỔ
					('BR_3X3_TDTT', N'3X3', 'tdtttd'),
					('BR_5X5_TDTT', N'5X5', 'tdtttd'),

					('BR_3X3_OR', N'3X3', 'or'),
					('BR_5X5_OR', N'5X5', 'or'),

					('BR_3X3_COB', N'3X3', 'cob'),
					('BR_5X5_COB', N'5X5', 'cob'),

					('BR_3X3_MNT', N'3X3', 'mnt'),
					('BR_5X5_MNT', N'5X5', 'mnt'),

					('BR_3X3_RMIT', N'3X3', 'rmit'),
					('BR_5X5_RMIT', N'5X5', 'rmit'),

					('BR_3X3_CV', N'3X3', 'cv'),
					('BR_5X5_CV', N'5X5', 'cv')


--- INSERT SÂN CƠ SỞ TENNIS
 --- INSERT SÂN P/S
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values ('P/S_1',1,N'180.000đ','QV_Don_PS'),
		('P/S_2',2,N'180.000đ','QV_Don_PS'),
		('P/S_3',3,N'250.000đ','QV_Doi_PS'),
		('P/S_4',4,N'250.000đ','QV_Doi_PS')

--- INSERT SÂN NVKB
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('NVKB_1',1,N'200.000đ','QV_Don_NVKB'),
		('NVKB_2',2,N'200.000đ','QV_Don_NVKB'),
		('NVKB_3',3,N'300.000đ','QV_Doi_NVKB'),
		('NVKB_4',4,N'300.000đ','QV_Doi_NVKB')

--- INSERT SÂN LV
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('LV_1',1,N'150.000đ','QV_Don_LV'),
		('LV_2',2,N'150.000đ','QV_Don_LV'),
		('LV_3',3,N'250.000đ','QV_Doi_LV'),
		('LV_4',4,N'250.000đ','QV_Doi_LV')

-- insert sân ĐH Ngân Hàng TPHCM
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values	('DHNH_1',1,N'150.000đ','QV_Don_DHNH'),
		('DHNH_2',2,N'150.000đ','QV_Don_DHNH'),
		('DHNH_3',3,N'150.000đ','QV_Doi_DHNH'),
		('DHNH_4',4,N'150.000đ','QV_Doi_DHNH')

-- - insert sân LT
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values	('LT_1',1,N'150.000đ','QV_Don_LT'),
		('LT_2',2,N'150.000đ','QV_Don_LT'),
		('LT_3',3,N'250.000đ','QV_Doi_LT'),
		('LT_4',4,N'250.000đ','QV_Doi_LT')

-- - insert sân CDCN
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values	('CDCN_1',1,N'150.000đ','QV_Don_CDCN'),
		('CDCN_2',2,N'150.000đ','QV_Don_CDCN'),
		('CDCN_3',3,N'250.000đ','QV_Doi_CDCN'),
		('CDCN_4',4,N'250.000đ','QV_Doi_CDCN')


--- INSERT SÂN CƠ SỞ BÓNG ĐÁ 
 --- INSERT SÂN Lâm Thịnh
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('lt_f1',1,N'300.000đ','san_5_LT'),
		('lt_f2',2,N'300.000đ','san_5_LT'),
		('lt_f3',3,N'500.000đ','san_7_LT'),
		('lt_f4',4,N'500.000đ','san_7_LT')
 --- INSERT SÂN Phù Đổng
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('pd_1',1,N'200.000đ','san_5_PD'),
		('pd_2',2,N'200.000đ','san_5_PD'),
		('pd_3',3,N'400.000đ','san_7_PD'),
		('pd_4',4,N'400.000đ','san_7_PD')
--- INSERT SÂN Nam Lý
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('nl_1',1,N'300.000đ','san_5_NL'),
		('nl_2',2,N'300.000đ','san_5_NL'),
		('nl_3',3,N'500.000đ','san_7_NL'),
		('nl_4',4,N'500.000đ','san_7_NL')
--- INSERT SÂN Lam Sơn
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('ls_1',1,N'350.000đ','san_5_LS'),
		('ls_2',2,N'350.000đ','san_5_LS'),
		('ls_3',3,N'600.000đ','san_7_LS'),
		('ls_4',4,N'600.000đ','san_7_LS')
--- INSERT SÂN KTX trường ĐH Giao thông vận tải
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('gtvt_1',1,N'300.000đ','san_5_GT'),
		('gtvt_2',2,N'300.000đ','san_5_GT'),
		('gtvt_3',3,N'300.000đ','san_5_GT'),
		('gtvt_4',4,N'300.000đ','san_5_GT')
--- INSERT SÂN Trương Văn Thành
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('tvt_1',1,N'200.000đ','san_5_TVT'),
		('tvt_2',2,N'200.000đ','san_5_TVT'),
		('tvt_3',3,N'400.000đ','san_7_TVT'),
		('tvt_4',4,N'400.000đ','san_7_TVT')


-- INSERT SAN CO SO CAU LONG
-- INSERT HVCT
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('HVCT_1',1,N'100.000đ','CL_Doi_HVCT'),
		('HVCT_2',2,N'100.000đ','CL_Doi_HVCT'),
		('HVCT_3',3,N'50.000đ','CL_Don_HVCT'),
		('HVCT_4',4,N'50.000đ','CL_Don_HVCT')

-- INSERT SAN REBELL
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('RB_1',1,N'60.000đ','CL_Don_Rebell'),
		('RB_2',2,N'60.000đ','CL_Don_Rebell'),
		('RB_3',3,N'60.000đ','CL_Don_Rebell'),
		('RB_4',4,N'80.000đ','CL_Doi_Rebell')

-- INSERT SAN BINH THAI
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('BT_1',1,N'50.000đ','CL_Don_BT'),
		('BT_2',2,N'80.000đ','CL_Doi_BT'),
		('BT_3',3,N'80.000đ','CL_Doi_BT'),
		('BT_4',4,N'50.000đ','CL_Don_BT')

--INSERT SAN DONG PHUONG
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('DP_1',1,N'80.000đ','CL_Doi_DP'),
		('DP_2',2,N'50.000đ','CL_Don_DP'),
		('DP_3',3,N'80.000đ','CL_Doi_DP'),
		('DP_4',4,N'80.000đ','CL_Doi_DP')

--INSERT SAN TAM KHOE
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('TK_1',1,N'50.000đ','CL_Doi_TK'),
		('TK_2',2,N'50.000đ','CL_Doi_TK'),
		('TK_3',3,N'40.000đ','CL_Don_TK'),
		('TK_4',4,N'50.000đ','CL_Doi_TK')

--INSERT SAN HOAI PHUONG
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('HP_1',1,N'80.000đ','CL_Doi_HP'),
		('HP_2',2,N'80.000đ','CL_Doi_HP'),
		('HP_3',3,N'50.000đ','CL_Don_HP'),
		('HP_4',4,N'50.000đ','CL_Don_HP')
		
		
-- INSERT SÂN BÓNG RỔ
	-- insert sân tdtttd
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values ('tdtttd1',1,N'300.000đ','BR_3X3_TDTT'),
		('tdtttd2',2,N'300.000đ','BR_3X3_TDTT'),
		('tdtttd3',3,N'300.000đ','BR_3X3_TDTT'),
		('tdtttd4',4,N'400.000đ','BR_5X5_TDTT')

-- insert sân or
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values ('or1',1,N'270.000đ','BR_3X3_OR'),
		('or2',2,N'270.000đ','BR_3X3_OR'),
		('or3',3,N'350.000đ','BR_5X5_OR'),
		('or4',4,N'350.000đ','BR_5X5_OR')

-- insert cob
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values  ('cob1',1,N'250.000đ','BR_3X3_COB'),
		('cob2',2,N'250.000đ','BR_3X3_COB'),
		('cob3',3,N'250.000đ','BR_3X3_COB'),
		('cob4',4,N'350.000đ','BR_5X5_COB')

-- insert sân mnt
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values ('mnt1',1,N'250.000đ','BR_3X3_MNT'),
		('mnt2',2,N'250.000đ','BR_3X3_MNT'),
		('mnt3',3,N'350.000đ','BR_5X5_MNT'),
		('mnt4',4,N'350.000đ','BR_5X5_MNT')

-- insert sân rmit
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values ('rmit1',1,N'400.000đ','BR_3X3_RMIT'),
		('rmit2',2,N'600.000đ','BR_5X5_RMIT'),
		('rmit3',3,N'400.000đ','BR_3X3_RMIT'),
		('rmit4',4,N'600.000đ','BR_5X5_RMIT')

-- insert sân cvq9
insert into San(MaSan,SoSan,GiaSan,MaDanhMuc)
values ('cv1',1,N'250.000đ','BR_3X3_CV'),
		('cv2',2,N'250.000đ','BR_3X3_CV'),
		('cv3',3,N'250.000đ','BR_3X3_CV'),
		('cv4',4,N'250.000đ','BR_3X3_CV')

---- INSERT DỮ LIỆU NHÂN VIÊN
insert into NhanVien(MaNV, HoTen, NgaySinh, GioiTinh, SDT, Email, CCCD)
			values 
			--- NHÂN VIÊN CƠ SỞ TENNIS
			('P/S_NV_1',N'Nguyễn Văn Long','2003-1-1',N'Nam','0123456789','longlo@gmail.com','001032145445'),
			('P/S_NV_2',N'Trần Quốc Thịnh','2003-2-1',N'Nam','0123456799','thinhtu@gmail.com','001122145445'),
		-- thay đổi mã nhân viên NVKB_1 => NVKB_NV_1
			('NVKB_NV_1',N'Nguyễn Đức Thắng','2003-3-1',N'Nam','0123456999','quangngo@gmail.com','001032145464'),
			('NVKB_NV_2',N'Nguyễn Phan Hoài Nam','2002-4-1',N'Nam','0903456789','anhlon@gmail.com','015032145433'),
		-- thay đổi mã nhân viên LV_1 => LV_NV_1	
			('LV_NV_1',N'Đỗ Khắc Trung','2003-5-1',N'Nam','0902333624 ','trung@gmail.com','012345678912'),
			('LV_NV_2',N'Công Tuấn','2003-6-1',N'Nữ','0903356789','nghien@gmail.com','011032145445'),

			('CDCN_NV_1',N'Võ Minh Kha','2003-6-3',N'Nam','0903654735','khavo0603@gmail.com','001234567899'),
			('CDCN_NV_2',N'Võ Kha','2003-6-3',N'Nam','0903654736','kha@gmail.com','001234567999'),

			('LT_NV_1',N'Nguyễn Thị Lại','2003-2-3',N'Nữ','0903654737','lai@gmail.com','001234569999'),
			('LT_NV_2',N'Nguyễn Anh','2003-2-4',N'Nam','0903654738','anh@gmail.com','001234599999'),

			('DHNH_NV_1',N'Lê Công Tuấn','2003-2-5',N'Nam','0903654739','tuan@gmail.com','001234999999'),
			('DHNH_NV_2',N'Trần Trọng Tín','2003-2-6',N'Nam','0903654740','tin@gmail.com','001239999999'),

			--- NHÂN VIÊN CƠ SỞ CẦU LÔNG
			('PH', N'Phan Hoàng', '2000-02-20', N'Nam', '0165562222', 'phanhoang@gmail.com', '077203005533'),
			('NNH', N'Nguyễn Ngọc Hiếu', '2000-07-1', N'Nam', '0833451777', 'ngochieu@gmail.com', '001082946357'),

			('TS', N'Trần Sương', '2002-08-11', N'Nữ', '0886447744', 'transuong@gmail.com', '087084000999'),
			('NTA', N'Nguyễn Thanh An', '2003-12-5', N'Nữ', '0971063773', 'thanhan@gmail.com', '015071000037'),

			('LTHV', N'Lê Thị Hồng Vương', '1999-12-18', N'Nữ', '0911951444', 'hongvuong@gmail.com', '001183000001'),
			('NTT', N'Nguyễn Tiến Tú', '1998-7-13', N'Nam', '0915347755', 'tientu@gmail.com', '001093005551'),

			('NXM', N'Nguyễn Xuân Mai', '2003-08-20', N'Nữ', '0785625780', 'xuanmai@gmail.com', '077203002589'),
			('TT', N'Trần Thảo', '2003-01-12', N'Nữ', '0859754777', 'tranthao@gmail.com', '015071007826'),

			('NMH', N'Nguyễn Mạnh Hùng', '1997-04-12', N'Nam', '0862838888', 'manhhung@gmail.com', '087084001425'),
			('NTP', N'Nguyễn Tấn Phát', '2000-06-01', N'Nam', '0333384222', 'tanphat@gmail.com', '001200223689'),

			('BDT', N'Bùi Đức Thắng', '1999-02-12', N'Nam', '0943211011', 'ducthang@gmail.com', '034099003616'),
			('NTL', N'Nguyễn Thị Linh', '2002-03-09', N'Nữ', '0794774888', 'linhka@gmail.com', '001302004651'),

			--- NHÂN VIÊN CƠ SỞ BÓNG RỔ
			('TNQ', N'Trần Ngọc Quang', '2001-05-17', N'Nam', '0261748888', 'tranquang@gmail.com', '066234145522'),
			('PNH', N'Phạm Ngọc Hương', '2000-06-22', N'Nữ', '0906452371', 'ngochuong@gmail.com', '002648691759'),

			('NHT', N'Nguyễn Hương Trang', '2001-07-12', N'Nữ', '0884573891', 'trangnguyen@gmail.com', '083957185629'),
			('LVT', N'Lê Văn Tùng', '2002-12-9', N'Nam', '0962856184', 'letung@gmail.com', '015749165927'),

			('TTD', N'Trần Trung Dũng', '1997-07-15', N'Nam', '0964726592', 'trungdung@gmail.com', '001285639488'),
			('LNQ', N'Lại Ngọc Quyên', '1998-11-27', N'Nữ', '0981857294', 'ngocquyen@gmail.com', '001487592736'),
                
            ('LQK', N'Lý Quốc Kiệt', '1996-04-13', N'Nam', '0984719576', 'quockiet@gmail.com', '001486295869'),
			('KNN', N'Kiều Ngọc Nữ', '1999-10-17', N'Nữ', '0947591729', 'ngocnu@gmail.com', '009591769395'),
                
            ('TQN', N'Trần Quốc Tiến', '1999-02-23', N'Nam', '0985925836', 'quoctien@gmail.com', '008571957285'),
		    ('NTQ', N'Ngô Thúy Quỳnh', '1999-09-25', N'Nữ', '0937592759', 'thuyquynh@gmail.com', '009471827592'),
                
            ('CTB', N'Cổ Thế Bảo', '2002-06-20', N'Nam', '0994817592', 'thebao@gmail.com', '003957281947'),
		    ('PQA', N'Phan Quỳnh Anh', '2000-05-30', N'Nữ', '0949285027', 'ngocquyen@gmail.com', '002049175823'),

			--- NHÂN VIÊN CƠ SỞ BÓNG ĐÁ

			 ('LGA', N'Lê Gia An', '2003-3-1', N'Nữ', '0886447470', 'giaan3103@gmail.com', '01103210322'),
	   		 ('PDD', N'Phạm Đức Duy', '1997-1-13', N'Nam', '0915345012', 'ducduy@gmail.com', '001093002020'),

			  ('PHD', N'Phạm Hữu Đạt', '1999-5-14', N'Nam', '0920217755', 'huudat@gmail.com', '012413004441'),
			  ('PDL', N'Phạm Diệu Linh', '2000-7-1', N'Nữ', '0915362455', 'phamdieulinh@gmail.com', '001093215451'),

			  ('LTA',N'Lê Tuấn Anh', '2002-5-13', N'Nam', '0915302134', 'letuananh@gmail.com', '001093645211'),
			  ('NHMC',N'Nguyễn Mạnh Cường', '1996-7-2', N'Nam', '0932561255', 'manhcuong207@gmail.com', '0000124551'),

			  ('HQH',N'Hồ Quang Hiếu', '1996-2-10', N'Nam', '0924361145', 'quanghieu7@gmail.com', '000562142'),
			  ('PDH',N'Phan	Minh Hy', '1997-4-22', N'Nam', '0756325155', 'phanminhhy@gmail.com', '000652141'),

			  ('CDC',N'Chu Chính Đình', '1995-5-14', N'Nam', '0932564155', 'chudinhchinh@gmail.com', '0011547551'),
			  ('HMK',N'Hà Minh Khôi', '1999-7-6', N'Nam', '0932561545', 'haminhkhoi@gmail.com', '0000132687'),

			  ('PHS',N'Phạm	Hoài Sơn', '1992-5-11', N'Nam', '0932522514', 'phamhoaison@gmail.com', '0011326511'),
			  ('LMH',N'Lê Minh Hùng', '2001-8-5', N'Nam', '0933126585', 'leminhhung@gmail.com', '0002415687');


--- INSERT PHÂN CÔNG
--- PHÂN CÔNG NHÂN VIÊN BÓNG ĐÁ
insert into PhanCong(MaNV, MaCS, GhiChu)
		values ('LGA', 'lt_f', ''),
		       ('PDD', 'lt_f', ''),
			   ('PHD', 'pd', ''),
		       ('PDL', 'pd', ''),
			   ('LTA', 'nl', ''),
		       ('NHMC','nl', ''),
			   ('HQH', 'ls', ''),
		       ('PDH', 'ls', ''),
			   ('CDC', 'gtvt', ''),
		       ('HMK', 'gtvt', ''),
			   ('PHS', 'tvt', ''),
		       ('LMH', 'tvt', '');


--- PHÂN CÔNG NHÂN VIÊN BÓNG RỔ
insert into PhanCong(MaNV, MaCS)
		values  ('TNQ', 'tdtttd'),
				('PNH', 'tdtttd'),

				('NHT', 'or'),
				('LVT', 'or'),

				('TTD', 'cob'),
				('LNQ', 'cob'),

				('LQK', 'mnt'),
				('KNN', 'mnt'),

				('TQN', 'rmit'),
				('NTQ', 'rmit'),

				('CTB', 'cv'),
				('PQA', 'cv')

--- PHÂN CÔNG NHÂN VIÊN TENNIS
insert into PhanCong(MaNV, MaCS, GhiChu)
		values ('P/S_NV_1','P/S',''),
		       ('P/S_NV_2','P/S',''),

		       ('NVKB_NV_1','NVKB',''),
		       ('NVKB_NV_2','NVKB',''),

		       ('LV_NV_1','LV',''),
		       ('LV_NV_2','LV',''),

		       ('CDCN_NV_1','CDCN',''),
		       ('CDCN_NV_2','CDCN',''),

		       ('DHNH_NV_1','DHNH',''),
		       ('DHNH_NV_2','DHNH','')

--- PHÂN CÔNG NHÂN VIÊN CẦU LÔNG
insert into PhanCong(MaNV, MaCS)
		values ('PH','hvct'),
				('NNH','hvct'),

				('TS','rebell'),
				('NTA','rebell'),

				('LTHV','bt'),
				('NTT','bt'),

				('NXM','dp'),
				('TT','dp'),

				('NMH','tk'),
				('NTP','tk'),

				('BDT','hp'),
				('NTL','hp');

--- INSERT QUYỀN
insert into Quyen(MaQuyen, TenQuyen)
		values  ('XemDanhSach', N'Xem danh sách'),
				('Them', N'Thêm'),
				('Sua', N'Sửa'),
				('Xoa', N'Xóa');

--- INSERT QUẢN TRỊ VIÊN
insert into QuanTriVien(MaQTV, LoaiQTV, TenDangNhap, MatKhau)
		values  ('Admin', 'Admin', 'admin', 'admin1234'),
				('NhanVien', N'Nhân viên', 'nhanvien', 'nhanvien123')

---	INSERT PHÂN QUYỀN
insert into PhanQuyen(MaQTV, MaQuyen)
		values  ('Admin', 'XemDanhSach'),
				('Admin', 'Them'),
				('Admin', 'Sua'),
				('Admin', 'Xoa'),

				('NhanVien', 'XemDanhSach');
