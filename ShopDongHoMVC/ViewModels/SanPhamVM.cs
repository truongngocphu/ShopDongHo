namespace ShopDongHoMVC.ViewModels
{
    public class SanPhamVM
    {
        public int MaSp {  get; set; }
        public string TenSp {  get; set; }
        public string HinhAnh { get; set; }
        public double DonGia {  get; set; }
        public string MoTaNgan {  get; set; }
        public string Tenloai {  get; set; }
    }

    public class ChiTietSanPhamVM
    {
        public int MaHh { get; set; }
        public string TenHH { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public string MoTaNgan { get; set; }
        public string TenLoai { get; set; }
        public string ChiTiet { get; set; }
        public int DiemDanhGia { get; set; }
        public int SoLuongTon { get; set; }
    }
}
