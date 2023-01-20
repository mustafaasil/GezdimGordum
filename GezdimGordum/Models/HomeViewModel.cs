using GezdimGordum.Data;
using System.ComponentModel.DataAnnotations;

namespace GezdimGordum.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage ="Zorunlu")]
        [MaxLength(50, ErrorMessage ="En fazla {1} karakter.")]
        public string Ad { get; set; } = null!;

        public List<Yer> Yerler { get; set; } = new();
    }
}
