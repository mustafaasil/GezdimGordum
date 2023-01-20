using GezdimGordum.Areas.Admin.Models;
using GezdimGordum.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GezdimGordum.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var vm = _db.Users.Select(u => new KullaniciGezmeGorme()
            {
                KullaniciAdi = u.UserName,
                YerAdlari = _db.Yerler.Where(y => y.KullaniciId == u.Id).Select(y => y.Ad).ToList()
            }).ToList();

            return View(vm);
        }
    }
}
