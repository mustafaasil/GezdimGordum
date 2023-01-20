using GezdimGordum.Data;
using GezdimGordum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace GezdimGordum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            var vm = new HomeViewModel()
            {
                Yerler = _db.Yerler.Where(x => x.KullaniciId == UserId).ToList()
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(HomeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var yer = new Yer()
                {
                    Ad = vm.Ad,
                    KullaniciId = UserId //giriş yapan kullanıcının ıd si
                };

                _db.Add(yer);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            vm.Yerler = _db.Yerler.Where(x => x.KullaniciId == UserId).ToList();

            return View(vm);
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult GezmeDurumunuGuncelle(int[]? gezdigiYerler)
        {
            // null değilse kendini null sa sagındakini ata
            gezdigiYerler ??= Array.Empty<int>();

            var yerler = _db.Yerler.Where(x => x.KullaniciId == UserId);

            foreach (var yer in yerler)
            {
                yer.Gidildi = gezdigiYerler.Contains(yer.Id);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));



        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}