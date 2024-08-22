using Microsoft.AspNetCore.Mvc;
using ShopDongHoMVC.Data;
using ShopDongHoMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ShopDongHoMVC.Controllers
{
    public class HangHoaController : Controller
    {


        public readonly DongHoShopMvcContext db;
        public HangHoaController(DongHoShopMvcContext context)
        {
            db = context;
        }
        public IActionResult Index(int? loai)
        {

            var sanpham = db.HangHoas.AsQueryable();
            if (loai.HasValue) 
            {
                sanpham = sanpham.Where(p => p.MaLoai == loai.Value);
            }
            var result = sanpham.Select(p => new SanPhamVM
            {
                MaSp = p.MaHh,
                TenSp = p.TenHh,
                DonGia= p.DonGia ?? 0,
                HinhAnh=p.Hinh ?? "",
                MoTaNgan=p.MoTa ?? "",
                Tenloai=p.MaLoaiNavigation.TenLoai
            }) ;  
               
            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var sanpham=db.HangHoas.AsQueryable();
            if (query != null)
            {
                sanpham = sanpham.Where(p => p.TenHh.Contains(query));
            }

            var result = sanpham.Select(p => new SanPhamVM
            {
                MaSp = p.MaHh,
                TenSp = p.TenHh,
                DonGia = p.DonGia ?? 0,
                HinhAnh = p.Hinh ?? "",
                MoTaNgan = p.MoTa ?? "",
                Tenloai = p.MaLoaiNavigation.TenLoai
            });

            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .SingleOrDefault(p => p.MaHh == id);
            if (data == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }

            var result = new ChiTietSanPhamVM
            {
                MaHh = data.MaHh,
                TenHH = data.TenHh,
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                MoTaNgan = data.MoTaDonVi ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,
                DiemDanhGia = 5,
            };
            return View(result);
        }
    }
}
