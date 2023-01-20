namespace GezdimGordum.Areas.Admin.Models
{
    public class KullaniciGezmeGorme
    {
        public string KullaniciAdi { get; set; } = string.Empty;

        public List<string> YerAdlari { get; set; } = new(); // boş liste
    }
}
