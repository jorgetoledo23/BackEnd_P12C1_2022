namespace ConsoleAppEntityFramework.Model
{
    public class Venta
    {
        public Guid Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Total { get; set; }
        public int IVA { get; set; }

        //FK
        public string ClienteRut { get; set; }
        //Propiedad de Navegacion
        public Cliente Cliente { get; set; }



    }
}
