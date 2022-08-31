using ConsoleApp.Model;

//Instancia => Objeto

//TODO: Crear tipos de Personajes
Personaje Player1 = new Personaje("Player 1");
Personaje Player2 = new Personaje("Player 2");

List<Item> Tienda = new List<Item>()
{
    new Item("Espadon", 120, 0, 450),
    new Item("Escudo Doran", 0, 100, 300),
    new Item("Acha", 100, 0, 300),
    new Item("Armadura", 50, 150, 400),
    new Item("Botas", 10, 10, 50),
    new Item("Casco", 0, 50, 150),
    new Item("Cuchillo", 20, 0, 30),
    new Item("Lanza", 50, 20, 120),
    new Item("Pocion", 0, 50, 50),
    new Item("Cota", -30, 300, 300),
};



string Opcion;

int Turno = 1;

Console.Write("Elige tu Personaje (1/2): ");
Turno = Convert.ToInt32(Console.ReadLine());

Personaje PersonajeDeTurno;
Personaje? Ganador = null;

do
{
    //Primero Ejecuta y Luego pregunta
    Console.Clear();

    Console.WriteLine("Welcome !");
    Console.WriteLine("==================");

    Console.WriteLine("");

    Console.WriteLine($"Turno : Player {Turno}");

    Console.WriteLine("");

    Console.WriteLine($"Estadisticas Actuales Player 1: Vida: {Player1.Vida}, Fuerza: {Player1.Fuerza}, Oro: {Player1.Oro}");
    //TODO: Hacer visible el Inventario de cada Jugador

    Console.WriteLine("Inventario Player 1: ");
    
    Console.WriteLine($"Estadisticas Actuales Player 2: Vida: {Player2.Vida}, Fuerza: {Player2.Fuerza}, Oro: {Player2.Oro}");
    Console.WriteLine("Inventario Player 1: ");



    Console.WriteLine("");
    Console.WriteLine("[1]-Golpear");
    Console.WriteLine("[2]-Comprar");
    //TODO: Opcion Vender el Item

    Console.Write("Opcion: ");
    Opcion = Console.ReadLine();

    switch (Opcion)
    {
        case "1":
            int vidaRestante;
            if (Turno == 1)
            {
                vidaRestante = Player1.Golpear(Player2);
                if (vidaRestante <= 0) Ganador = Player1;
            }
            else
            {
                vidaRestante = Player2.Golpear(Player1);
                if (vidaRestante <= 0) Ganador = Player2;
            }
            break;

        case "2":

            foreach (Item i in Tienda)
            {
                Console.WriteLine($"Valor {i.Coste} - Item 1: {i.Nombre}, Fuerza: {i.Fuerza}, Vida: {i.Vida}");
            }

            Console.WriteLine("Escribe el Nombre Item: ");
            string itemComprado = Console.ReadLine();

            Item? item = Tienda.Find(x => x.Nombre.Equals(itemComprado));
            
            if(Turno == 1) Player1.Comprar(item);
            else Player2.Comprar(item);

            break;




    }
    if (Turno == 1) { Turno = 2; PersonajeDeTurno = Player1; }
    else { Turno = 1; PersonajeDeTurno = Player2; }

    if (Ganador != null)
    {
        break;
    }


} while (Opcion != "0");

Console.WriteLine($"{Ganador.Nombre} gana la partida!");









