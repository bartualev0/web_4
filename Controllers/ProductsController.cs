using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UrunKatalog.Models; // Modelimizi kullanmak için ekliyoruz

namespace UrunKatalog.Controllers
{
    public class ProductsController : Controller
    {
        // Veritabanı yerine geçici olarak statik bir liste kullanalım.
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 25000, Description = "Yüksek performanslı oyuncu laptopu" },
            new Product { Id = 2, Name = "Klavye", Price = 750, Description = "Mekanik ve RGB aydınlatmalı klavye" },
            new Product { Id = 3, Name = "Monitör", Price = 4500, Description = "27 inç, 144Hz oyuncu monitörü" }
        };

        // /Products veya /Products/Index adresine gelen istekleri karşılar.
        public IActionResult Index()
        {
            // Tüm ürünleri View'a model olarak gönderiyoruz.
            return View(_products);
        }

        // Örnek bir Attribute Route kullanımı.
        // /urun/1, /urun/2 gibi adreslere gelen istekleri karşılar.
        [Route("urun/{id}")]
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Ürün bulunamazsa 404 hatası döner.
            }

            // Bulunan ürünü View'a model olarak gönderiyoruz.
            return View(product);
        }
    }
}