namespace ConsoleAppEntityFramework.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
        public string? UrlImagen { get; set; }

    }
}
