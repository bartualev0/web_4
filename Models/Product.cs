namespace UrunKatalog.Models // veya projenizin adı web4.Models
{
    public class Product
    {
        public int Id { get; set; }
        // string yerine string? kullanarak bu özelliğin null olabileceğini belirtiyoruz.
        public string? Name { get; set; } 
        public decimal Price { get; set; }
        // string yerine string? kullanarak bu özelliğin null olabileceğini belirtiyoruz.
        public string? Description { get; set; }
    }
}