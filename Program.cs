
IProductoRepository productoRepository = new ProductoRepository();

bool ejecutando = true;

while (ejecutando)
{
    Console.WriteLine();
    Console.WriteLine("Gestion de Productos");
    Console.WriteLine("1. Ver todos los productos");
    Console.WriteLine("2. Buscar producto por ID");
    Console.WriteLine("3. Buscar productos por categoria");
    Console.WriteLine("4. Agregar producto");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opcion: ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
        {
            List<Producto> lista = productoRepository.ObtenerProductos();

            foreach (Producto producto in lista)
            {
                Console.WriteLine(
                    $"ID: {producto.Id} | " +
                    $"Nombre: {producto.Nombre} | " +
                    $"Precio: ${producto.Precio} | " +
                    $"Categoria: {producto.Categoria} | " +
                    $"Activo: {producto.Activo}"
                );
            }

            break;
        }

        case "2":
        {
            Console.Write("Ingrese el ID del producto: ");
            string entradaId = Console.ReadLine() ?? "";

            if (int.TryParse(entradaId, out int id))
            {
                try
                {
                    Producto producto = productoRepository.ObtenerProductoPorId(id);

                    Console.WriteLine($"Nombre: {producto.Nombre}");
                    Console.WriteLine($"Precio: ${producto.Precio}");
                    Console.WriteLine($"Categoria: {producto.Categoria}");
                    Console.WriteLine($"Activo: {producto.Activo}");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar un ID numerico.");
            }

            break;
        }

        case "3":
        {
            Console.Write("Ingrese la categoria: ");
            string categoria = Console.ReadLine() ?? "";

            List<Producto> resultados =
                productoRepository.ObtenerProductosPorCategoria(categoria);

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron productos.");
            }
            else
            {
                foreach (Producto producto in resultados)
                {
                    Console.WriteLine(
                        $"{producto.Id} - {producto.Nombre} - ${producto.Precio}"
                    );
                }
            }

            break;
        }

        case "4":
        {
            Console.Write("Ingrese el ID: ");
            string entradaId = Console.ReadLine() ?? "";

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Ingrese el precio: ");
            string entradaPrecio = Console.ReadLine() ?? "";

            Console.Write("Ingrese la categoria: ");
            string categoria = Console.ReadLine() ?? "";

            Console.Write("¿Esta activo? (true/false): ");
            string entradaActivo = Console.ReadLine() ?? "";

            bool idValido = int.TryParse(entradaId, out int nuevoId);
            bool precioValido = decimal.TryParse(
                entradaPrecio,
                out decimal nuevoPrecio
            );
            bool activoValido = bool.TryParse(
                entradaActivo,
                out bool nuevoActivo
            );

            if (idValido &&
                precioValido &&
                activoValido &&
                !string.IsNullOrWhiteSpace(nombre) &&
                !string.IsNullOrWhiteSpace(categoria))
            {
                Producto nuevoProducto = new Producto
                {
                    Id = nuevoId,
                    Nombre = nombre,
                    Precio = nuevoPrecio,
                    Categoria = categoria,
                    Activo = nuevoActivo
                };

                productoRepository.Agregar(nuevoProducto);

                Console.WriteLine("Producto agregado correctamente.");
            }
            else
            {
                Console.WriteLine(
                    "Datos invalidos. Verifique los valores ingresados."
                );
            }

            break;
        }

        case "5":
        {
            ejecutando = false;
            Console.WriteLine("Muchas gracias por su visita, vuelva pronto!.");
            break;
        }

        default:
        {
            Console.WriteLine("Opcion no valida. Intente nuevamente por favor.");
            break;
        }
    }
}