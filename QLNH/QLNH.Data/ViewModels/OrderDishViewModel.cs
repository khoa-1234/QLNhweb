﻿namespace QLNH.Admin.ViewModels
{
    public class OrderDishViewModel
    {
        public int? DonHangId { get; set; } // ID của Đơn Hàng
        public int TableId { get; set; }  // ID của bàn
        public int DatBanId { get; set; }  // ID của DatBan
        public int? KhachHangId { get; set; }  // ID khách hàng
        public int? NhanVienId { get; set; }  // ID nhân viên
        public decimal TongTien { get; set; } // Tổng tiền của đơn hàng
        public List<DishGroupViewModel> DishGroups { get; set; }  // Nhóm món ăn
        public List<DishViewModel> Dishes { get; set; }  // Món ăn
        public List<ChiTietDonHangViewModel> ChiTietDonHangs { get; set; }  // Danh sách chi tiết đơn hàng
        public List<ThanhToanViewModel> ThanhToans { get; set; } = new List<ThanhToanViewModel>();
        public List<MonDaDatModel> OrderHistory { get; set; }  // Add this line
        public string? ImageBaseUrl { get; set; }  

    }
    public class MonDaDatModel
    {
        public string TenMonAn { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public string hinhAnhDaiDien { get; set; }  // Ensure this is populated with the correct filename like 'pho.png'
        public string TrangThai { get; set; }
    }


    public class DishGroupViewModel
    {
        public int NhomMonAnId { get; set; } // ID nhóm món ăn
        public string TenNhom { get; set; } // Tên nhóm món ăn
        public List<DishViewModel> Dishes { get; set; } // Danh sách món ăn thuộc nhóm
    }

    public class DishViewModel
    {
        public int MonAnId { get; set; } // ID món ăn
        public string TenMonAn { get; set; } // Tên món ăn
        public string MoTa { get; set; } // Mô tả món ăn
        public decimal Gia { get; set; } // Giá món ăn
        public int NhomMonAnId { get; set; } // ID nhóm món ăn (foreign key)
        public string HinhAnh { get; set; } // Đường dẫn hình ảnh món ăn
    }

    // Thêm class ChiTietDonHangViewModel
    public class ChiTietDonHangViewModel
    {
        public int? ChiTietDonHangId { get; set; } // ID chi tiết đơn hàng
        public int? DonHangId { get; set; } // ID đơn hàng
        public int? MonAnId { get; set; } // ID món ăn
        public int? SoLuong { get; set; } // Số lượng món ăn
        public decimal? Gia { get; set; } // Giá của món ăn
        public string? TrangThai { get; set; } // Trạng thái của món ăn
        public DateTime? ThoiGianBatDau { get; set; } // Thời gian bắt đầu món ăn
        public DateTime? ThoiGianKetThuc { get; set; } // Thời gian kết thúc món ăn
    }
    public class ThanhToanViewModel
    {
        public int ThanhToanId { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayThanhToan { get; set; }
    }
}
