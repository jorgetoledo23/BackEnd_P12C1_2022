using ConsoleAppEntityFramework.Model;

do
{
    Console.Clear();
    Console.WriteLine("[1] - Insertar Nuevo Producto");
    Console.WriteLine("[2] - Listar Productos");
    Console.WriteLine("[3] - Editar un Producto");
    Console.WriteLine("[4] - Eliminar un Producto");

    Console.Write("Elige una Opcion: ");

    var Opcion = Console.ReadLine();


    switch (Opcion)
    {
        case "1": //Agregar un Producto

            Producto P = new Producto();

            Console.Write("Nombre: ");
            P.Name = Console.ReadLine();

            Console.Write("Precio: ");
            P.Precio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Stock: ");
            P.Stock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Url Imagen: ");
            P.UrlImagen = Console.ReadLine();

            using (var context = new AppDbContext())
            {
                context.Add(P); //Insert Into
                context.SaveChanges(); // Guardar Cambios
            }

            Console.WriteLine("Producto Agregado!");
            Console.ReadLine();

            break;

        case "2":
            ListarProductos();
            Console.ReadLine();
            break;

        case "3":
            ListarProductos();

            Console.Write("Ingresa Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                var ProductoBuscado = context.tblProductos.Where(x => x.Id == Id).FirstOrDefault();
                var ProductoBuscado2 = context.tblProductos.Find(Id);
                if(ProductoBuscado2 != null)
                {
                    Console.Write("Nombre: ");
                    ProductoBuscado2.Name = Console.ReadLine();

                    Console.Write("Precio: ");
                    ProductoBuscado2.Precio = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Stock: ");
                    ProductoBuscado2.Stock = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Url Imagen: ");
                    ProductoBuscado2.UrlImagen = Console.ReadLine();

                    context.Update(ProductoBuscado2);
                    context.SaveChanges();
                }
            }

            



            break;
    }
} while (true);


    void ListarProductos()
    {
        using (var context = new AppDbContext())
        {
            var productos = context.tblProductos.ToList();
            foreach (var item in productos)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
            }
        }
    }