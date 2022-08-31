namespace ConsoleApp.Model
{
    public class Item
    {
        public string Nombre { get; }
        public int Fuerza { get; }
        public int Vida { get; }
        public int Coste { get; }

        //Metodo Constructor
        public Item(string nombre, int fuerza, int vida, int coste)
        {
            this.Nombre = nombre;
            this.Fuerza = fuerza;
            this.Vida = vida;
            this.Coste = coste;
        }

    }
}
