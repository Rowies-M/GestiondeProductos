
IProductoRepository productoRepository = new ProductoRepository();                     //Declaramos una variable de tipo IProductoRepository y le asignamos un objeto ProductoRepository. La interfaz define las operaciones disponibles y la clase concreta las implementa.

bool ejecutando = true;                                                                //Variable booleana que indica al menu que debe continuar funcionando.

while (ejecutando)                                                                     //Mientras ejecutando sea true, repetimos las instrucciones que están dentro de las llaves del while.
{
    Console.WriteLine();                                                               //Línea vacía en la consola para separar visualmente el contenido. 
    Console.WriteLine("Gestion de Productos");                                         //Muestra el nombre del programa.
    Console.WriteLine("1. Ver todos los productos");                                   //Muestra la opción para buscar en todos los productos. 
    Console.WriteLine("2. Buscar producto por ID");                                    //Buscar un producto por su identificador.
    Console.WriteLine("3. Buscar productos por categoria");                            //Filtrar productos por categoría.
    Console.WriteLine("4. Agregar producto");                                          //Ingresar un producto nuevo.
    Console.WriteLine("5. Salir");                                                     //Finaliza el programa.
    Console.Write("Seleccione una opcion: ");                                          //Console.write: Muestra un mensaje sin saltar a la línea siguiente, para que el usuario escriba su respuesta en la misma línea.

    string opcion = Console.ReadLine() ?? "";                                          //Readline: Lee lo que escribe el usuario como texto. El resultado se guarda en la variable opcion. Si ReadLine devuelve null, el operador ?? asigna una cadena vacía.

    switch (opcion)                                                                    //Switch: estructura de control que permite evaluar una expresión y ejecutar diferentes bloques de código según el valor que esta adopta.
    {
        case "1":                                                                      //Inicialización del repositorio y menú principal.  case: Si opcion contiene exactamente el texto "1", ejecuta el bloque correspondiente.
        {
            List<Producto> lista = productoRepository.ObtenerProductos();              //Declaramos una lista de objetos Producto y guardamos en ella los productos devueltos por el método ObtenerProductos del repositorio.

            foreach (Producto producto in lista)                                       //Foreach: Recorre cada objeto Producto que contiene la lista. En cada repetición, la variable producto representa el elemento actual.
            {
                Console.WriteLine(                                                     //El contenido que se va a imprimir se construye con varias cadenas de texto.
                    $"ID: {producto.Id} | " +                                          //Interpolamos el valor de la propiedad Id del producto actual y concatenamos esta cadena con la siguiente.
                    $"Nombre: {producto.Nombre} | " +                                  //Interpolamos la propiedad Nombre para mostrar el nombre del producto.
                    $"Precio: ${producto.Precio} | " +                                 //Interpolamos la propiedad Precio y agregamos el símbolo $ como texto para representar el precio.
                    $"Categoria: {producto.Categoria} | " +                            //Interpolamos la propiedad Categoria para mostrar a qué categoría pertenece el producto.
                    $"Activo: {producto.Activo}"                                       //Interpolamos la propiedad Activo para mostrar true o false según el estado del producto.
                );
            }                                                                          //Interpolacion de cadenas: insertar variables o expresiones directamente dentro de un texto. Se debe anteponer el símbolo $ antes de abrir las comillas dobles de tu cadena de texto. Dentro del texto, colocas las variables o expresiones entre llaves {}.

            break;                                                                     //Finaliza el bloque del case "1" y sale del switch. No termina el while principal.  
        }

        case "2":                                                                      //Buscar un producto por ID. Si se ingreso "2", ejecutamos el bloque para buscar un producto por su ID.
        {
            Console.Write("Ingrese el ID del producto: ");                             //Solicita al usuario el identificador del producto que quiere buscar.
            string entradaId = Console.ReadLine() ?? "";                               //Lee el ID ingresado como texto

            if (int.TryParse(entradaId, out int id))                                   //TryParse: Intenta convertir entradaId en un número entero. Si la conversión funciona, guarda el número en id y devuelve true; si falla, devuelve false.
            {
                try                                                                    //Try: Bloque en el que intentaremos ejecutar una operación que podría generar una excepción. 
                {
                    Producto producto = productoRepository.ObtenerProductoPorId(id);   //Busca el producto con el ID ingresado y guarda el objeto encontrado en la variable producto.

                    Console.WriteLine($"Nombre: {producto.Nombre}");                   //Muestra el nombre del producto encontrado.
                    Console.WriteLine($"Precio: ${producto.Precio}");                  //Precio del producto.
                    Console.WriteLine($"Categoria: {producto.Categoria}");             //Categoria del producto.
                    Console.WriteLine($"Activo: {producto.Activo}");                   //Muestra si el producto está activo o inactivo.
                }
                catch (KeyNotFoundException ex)                                        //Catch: Captura una excepción de tipo KeyNotFoundException si el repositorio no encuentra el ID. La variable ex contiene información sobre el error.
                {
                    Console.WriteLine(ex.Message);                                     //Muestra el mensaje de error guardado en la excepción.
                }
            }
            else                                                                       //Se ejecuta cuando int.TryParse no puede convertir la entrada en un número entero.
            {
                Console.WriteLine("Debe ingresar un ID numerico.");                    //Informa al usuario que debe ingresar un ID numérico válido.
            }

            break;                                                                     //Termina el case "2" y sale del switch.
        }

        case "3":                                                                      //Buscar productos por categoría. Si el usuario selecciona "3", ejecutamos la búsqueda por categoría.
        {
            Console.Write("Ingrese la categoria: ");                                   //Solicita la categoría que se utilizará para filtrar los productos.
            string categoria = Console.ReadLine() ?? "";                               //Lee el texto ingresado y lo guarda en la variable categoria.              

            List<Producto> resultados =                                                //Declara una variable de tipo List<Producto> llamada resultados.
                productoRepository.ObtenerProductosPorCategoria(categoria);            //productoRepository Llama al método obtenerProductosPorCategoria del repositorio y le entrega la categoría para obtener los productos.

            if (resultados.Count == 0)                                                 //Comprueba si la cantidad de elementos de la lista resultados es igual a cero.
            {
                Console.WriteLine("No se encontraron productos.");                     //Informa que la búsqueda no encontró productos para esa categoría.
            }
            else                                                                       //Se ejecuta si la lista contiene uno o más productos.
            {
                foreach (Producto producto in resultados)                              //Recorre cada producto encontrado y lo guarda temporalmente en la variable producto durante cada repetición.
                {
                    Console.WriteLine(                                                 //Imprime los datos resumidos de cada producto encontrado.
                        $"{producto.Id} - {producto.Nombre} - ${producto.Precio}"
                    );                                                                 //Interpola el ID, el nombre y el precio del producto actual, separándolos con guiones.
                }
            }

            break;                                                                     //Termina el case "3" y sale del switch.
        }

        case "4":                                                                      //Si el usuario selecciona "4", ejecutamos el proceso para agregar un producto.
        {
            Console.Write("Ingrese el ID: ");                                          //Solicita el identificador del nuevo producto
            string entradaId = Console.ReadLine() ?? "";                               //Lee el ID como texto y guarda la entrada en entradaId.     

            Console.Write("Ingrese el nombre: ");                                      //Solicita el nombre del producto.
            string nombre = Console.ReadLine() ?? "";                                  //Lee el nombre y lo guarda en nombre.

            Console.Write("Ingrese el precio: ");                                      //Solicita el precio del producto.
            string entradaPrecio = Console.ReadLine() ?? "";                           //Lee el precio como texto; todavía no lo convierte en un número decimal.

            Console.Write("Ingrese la categoria: ");                                   //Solicita la categoría del nuevo producto.     
            string categoria = Console.ReadLine() ?? "";                               //Lee la categoría y la guarda como texto.

            Console.Write("¿Esta activo? (true/false): ");                             //Solicita un valor que indique si el producto estará activo. Se espera true o false.
            string entradaActivo = Console.ReadLine() ?? "";                           //Lee la respuesta como texto para convertirla a bool posteriormente.

            bool idValido = int.TryParse(entradaId, out int nuevoId);                  //idValido: Nombre de la variable tipo bool creada, guardará el resultado de la operación: un true si el texto es un número válido, o un false si contene algo que no se requiere. El operador = toma el resultado final de todo lo que se ejecute a su derecha y lo asigna dentro de la variable de la izquierda (idValido).
            bool precioValido = decimal.TryParse(                                      //Intenta convertir la entrada del precio en un número decimal.
                entradaPrecio,                                                         //Es el texto que contiene el precio ingresado por el usuario
                out decimal nuevoPrecio                                                //Declara la variable nuevoPrecio para recibir el número convertido y precioValido dice si la conversión funcionó.
            );
            bool activoValido = bool.TryParse(                                         //Intenta convertir el texto ingresado en un valor booleano.
                entradaActivo,                                                         //Es el texto que escribió el usuario: por ejemplo, "true" o "false".
                out bool nuevoActivo                                                   //Declara nuevoActivo para recibir el valor booleano convertido.
            );

            if (idValido &&                                                            //Comprueba que el ID se haya convertido correctamente. && significa AND: todas las condiciones deben ser verdaderas.
                precioValido &&                                                        //Comprueba que el precio se haya convertido correctamente.
                activoValido &&                                                        //Comprueba que el estado activo/inactivo sea un booleano válido.
                !string.IsNullOrWhiteSpace(nombre) &&                                  //Comprueba que nombre no sea null, vacío ni contenga solamente espacios. ! invierte el resultado.
                !string.IsNullOrWhiteSpace(categoria))                                 //Comprueba que categoria tampoco sea null, vacía ni contenga solamente espacios.
            {
                Producto nuevoProducto = new Producto                                  //Crea un objeto nuevo de tipo Producto y lo guarda en la variable nuevoProducto.
                {
                    Id = nuevoId,                                                      //Asigna al Id del producto el número que se convirtió correctamente desde la entrada del usuario.
                    Nombre = nombre,                                                   //Asigna al Nombre del producto el texto ingresado.
                    Precio = nuevoPrecio,                                              //Asigna al Precio del producto el número decimal convertido.
                    Categoria = categoria,                                             //Asigna al producto la categoría ingresada.
                    Activo = nuevoActivo                                               //Asigna el valor true o false que se convirtió desde la entrada del usuario.
                };

                productoRepository.Agregar(nuevoProducto);                             //Llama al método Agregar del repositorio y le entrega el nuevo objeto para incorporarlo a la lista.

                Console.WriteLine("Producto agregado correctamente.");                 //Informa al usuario que el producto fue agregado.
            }
            else                                                                       //Se ejecuta si al menos una de las condiciones anteriores es falsa.
            {
                Console.WriteLine(
                    "Datos invalidos. Verifique los valores ingresados."               //Imprime un mensaje de error. Explica que uno o más valores ingresados no son válidos.
                );
            }

            break;                                                                     //Termina el case "4" y sale del switch.
        }

        case "5":                                                                      //Si el usuario selecciona "5", ejecutamos las instrucciones para salir.
        {
            ejecutando = false;                                                        //Cambia ejecutando a false. Cuando el programa vuelva a comprobar la condición del while, el bucle terminará. 
            Console.WriteLine("Muchas gracias por su visita, vuelva pronto!.");        // Muestra el mensaje de despedida.
            break;
        }

        default:                                                                        //Se ejecuta si opcion no coincide con ninguno de los casos definidos.
        {
            Console.WriteLine("Opcion no valida. Intente nuevamente por favor.");       //Informa que la opción ingresada no existe en el menú.
            break;                                                                      //Sale del switch, pero como ejecutando sigue siendo true, el menú vuelve a mostrarse.
        }
    }
}