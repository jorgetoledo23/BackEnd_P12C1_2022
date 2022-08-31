//Forma en la que se organizan class de un mismo contexto
namespace ConsoleApp.Model
{
    public class Personaje
    {
        //Constructor __init__(nom)
        public Personaje(string nombre)
        {
            Nombre = nombre;
            Items = new List<Item>();
        }


        //Atributos => Props!
        public string Nombre { get; }
        public int Fuerza { get; set; } = 100; // 1...100
        public int Vida { get; set; } = 100; // 1...100
        public int Estamina { get; set; }
        public int Oro { get; set; } = 1000;

        //TODO: Evasion


        //public int Item1 { get; set; }
        // int Item2 { get; set; }
        public List<Item> Items { get; set; }


        //Metodos => Definen Comportamiento
        public void Comprar(Item item)
        {
            Items.Add(item);
            //Sumar Vida y Fuerza al Personaje
            Fuerza += item.Fuerza;
            Vida += item.Vida;
            Oro -= item.Coste;
        }

        public void Vender(Item item)
        {
            Fuerza -= item.Fuerza;
            Vida -= item.Vida;
            Items.Remove(item);
            Oro += Convert.ToInt32(item.Coste * 0.5); 
        }

        public int Golpear(Personaje objetivo)
        {
            objetivo.Vida -= this.Fuerza / 15 + 10;
            return objetivo.Vida;
        }

    }
}
