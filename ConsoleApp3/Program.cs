using ConsoleApp.Model;

//Instancia => Objeto
Personaje Player1 = new Personaje("Player 1");
Personaje Player2 = new Personaje("Player 2");


Item Espadon = new Item("Espadon", 120, 0, 450);
Item EscudoDoran = new Item("Escudo Doran", 0, 100, 300);

string Opcion;
int Turno = 1;
Personaje PersonajeDeTurno;

do
{
    //Primero Ejecuta y Luego pregunta
    Console.Clear();

    Console.WriteLine("Welcome !");
    Console.WriteLine("==================");

    Console.WriteLine($"Turno : Player {Turno}");
    

    Console.WriteLine($"Estadisticas Actuales Player 1: Vida: {Player1.Vida}, Fuerza: {Player1.Fuerza}");
    Console.WriteLine($"Estadisticas Actuales Player 2: Vida: {Player2.Vida}, Fuerza: {Player2.Fuerza}");

    Console.WriteLine("1-Golpear");
    Console.WriteLine("2-Comprar");

    Opcion = Console.ReadLine();

    switch (Opcion)
    {
        case "1":
            if(Turno == 1) Player1.Golpear(Player2);
            else Player2.Golpear(Player1);

            break;

        case "2":
            Console.WriteLine($"Item 1: {Espadon.Nombre}, Fuerza: {Espadon.Fuerza}, Vida: {Espadon.Vida}");
            Console.WriteLine($"Item 2: {EscudoDoran.Nombre}, Fuerza: {EscudoDoran.Fuerza}, Vida: {EscudoDoran.Vida}");

            Console.WriteLine("Elige el Item: ");
            string itemComprado = Console.ReadLine();
            if (itemComprado == "1")
            {
               if(Turno == 1) Player1.Comprar(Espadon);
               else Player2.Comprar(Espadon);
            }
            if (itemComprado == "2")
            {
                if (Turno == 1) Player1.Comprar(EscudoDoran);
                else Player2.Comprar(EscudoDoran);
            }
            break;


    }
    if (Turno == 1) { Turno = 2; PersonajeDeTurno = Player1; }
    else { Turno = 1; PersonajeDeTurno = Player2; }


} while (Opcion != "0");









