using ConsoleAppEntityFramework.Model;
using Microsoft.EntityFrameworkCore;

do
{
    Console.Clear();
    Console.WriteLine("[1] - Insertar Nuevo Producto");
    Console.WriteLine("[2] - Listar Productos");
    Console.WriteLine("[3] - Editar un Producto");
    Console.WriteLine("[4] - Eliminar un Producto");
    Console.WriteLine("[5] - Buscar un Producto");

    Console.WriteLine("-------------------------");

    Console.WriteLine("[6] - Crear Cliente");
    Console.WriteLine("[7] - Listar Clientes");

    Console.WriteLine("-------------------------");

    Console.WriteLine("[8] - Generar Venta");
    Console.WriteLine("[9] - Listar Ventas");



    Console.Write("\nElige una Opcion: ");

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
                if (ProductoBuscado2 != null)
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

        case "4":
            //Eliminar un Producto!
            ListarProductos();

            Console.Write("Ingresa Id del Producto que deseas Eliminar: ");
            var IdEliminar = Convert.ToInt32(Console.ReadLine());
            using (var context = new AppDbContext())
            {
                var ProductoEliminar = context.tblProductos.Find(IdEliminar);
                context.Remove(ProductoEliminar);
                context.SaveChanges();
            }
            Console.WriteLine($"Producto {IdEliminar} Eliminado Exitosamente!");
            Console.ReadLine();
            break;

        case "5":
            Console.Write("Que estas buscando?:");
            var Buscado = Console.ReadLine();

            using (var context = new AppDbContext())
            {
                //Buscar Producto por Nombre
                var ProductosEncontrados = context.tblProductos
                .Where(x => x.Name.Contains(Buscado)).ToList();

                if (ProductosEncontrados.Count > 0)
                {
                    Console.WriteLine("Productos Encontrados:");
                    foreach (var item in ProductosEncontrados)
                    {
                        Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontro Ningun producto!");

                }
                Console.ReadLine();
            }


            break;

        case "6": //Agregar un Cliente

            Cliente C = new Cliente();

            Console.Write("Rut: "); C.Rut = Console.ReadLine();
            Console.Write("Nombre: "); C.Nombre = Console.ReadLine();
            Console.Write("Apellido: "); C.Apellido = Console.ReadLine();
            Console.Write("Telefono: "); C.Telefono = Console.ReadLine();



            using (var context = new AppDbContext())
            {
                context.Add(C); //Insert Into
                context.SaveChanges(); // Guardar Cambios
            }

            Console.WriteLine("Cliente Agregado!");
            Console.ReadLine();

            break;

        case "7":
            Console.Clear();
            ListarClientes();

            Console.ReadLine();
            break;



        case "8":

            Venta V = new Venta();
            V.FechaVenta = DateTime.Now;
            Console.Write("Rut Cliente: "); V.ClienteRut = Console.ReadLine();
            Console.Write("Total Venta: "); V.Total = Convert.ToInt32(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                context.Add(V);
                context.SaveChanges();
            }

            break;

        case "9":

            using (var context = new AppDbContext())
            {
                var ventas = context.tblVentas.Include(x => x.Cliente).ToList();

                foreach (var venta in ventas)
                {
                    Console.WriteLine($"Id: {venta.Id}, Fecha: {venta.FechaVenta.ToString("f")}, " +
                        $"Rut Cliente: {venta.ClienteRut}, Nombre Cliente: {venta.Cliente.Nombre} " +
                        $"{venta.Cliente.Apellido}");
                }
                Console.ReadLine();
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

void ListarClientes()
{
    using (var context = new AppDbContext())
    {
        var clientes = context.tblClientes.ToList();
        foreach (var item in clientes)
        {
            Console.WriteLine($"Rut: {item.Rut}, Nombre: {item.Nombre}, Apellido: {item.Apellido}");
        }
    }
}














