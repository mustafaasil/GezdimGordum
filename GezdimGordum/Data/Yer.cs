using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace GezdimGordum.Data
{
    public class Yer
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Ad { get; set; } = null!;
        public bool Gidildi { get; set; }

        public string KullaniciId { get; set; } = null!;

        
        public IdentityUser Kullanici { get; set; } = null!;
    }
}
