var builder = WebApplication.CreateBuilder(args);

// 1. Servislerin Konteynera Eklenmesi (Dependency Injection)
// MVC servislerini ekliyoruz. Bu, Controller, View ve diğer MVC bileşenlerini kullanabilmemizi sağlar.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. HTTP Request Pipeline (Middleware'lerin Yapılandırılması)
// Buradaki her bir "app.Use..." satırı bir ara katman (middleware) ekler.
// İstekler bu katmanlardan sırayla geçer.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// KENDİ ÖZEL MIDDLEWARE'İMİZİ EKLEYELİM
// Bu middleware, her isteğin yolunu konsola yazdıracak.
app.Use(async (context, next) =>
{
    Console.WriteLine($"Gelen istek: {context.Request.Path}");
    await next.Invoke(); // Bir sonraki middleware'e geçişi sağlar.
});


app.UseHttpsRedirection(); // HTTP isteklerini HTTPS'e yönlendirir.
app.UseStaticFiles();      // wwwroot klasöründeki statik dosyaların (css, js) sunulmasını sağlar.

app.UseRouting();          // Yönlendirme mekanizmasını aktif eder. Controller ve Action'ların bulunmasını sağlar.

app.UseAuthorization();    // Yetkilendirme katmanını ekler (bu projede detaya girmiyoruz).

// 3. Yönlendirme (Routing) Kurallarının Tanımlanması
// Varsayılan yönlendirme kuralı.
// URL: /{controller}/{action}/{id?}
// Örnek: /Home/Index, /Products/Index, /Products/Details/1
// Varsayılan değerler: controller=Home, action=Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Uygulamayı çalıştırır.