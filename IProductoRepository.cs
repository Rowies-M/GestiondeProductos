//En nuestro proyecto, la interfaz establece que el repositorio debe permitir agregar productos, obtener todos, buscar por ID y buscar por categoría.
public interface IProductoRepository                                //Definimos la interface, es como un contrato: establece qué operaciones debe ofrecer una clase, pero no define cómo se realizan.
{
    public void Agregar(Producto producto);                         //void: indica que el método no devuelve ningún valor. Producto producto: recibe un objeto de tipo Producto, al que dentro del método llamaremos producto.

    //Se declara una operación que devuelve una lista de productos.
    List<Producto> ObtenerProductos();                              // List<Producto>: El resultado será una lista y elementos son objetos de tipo Producto.

    //Declara búsqueda por identificador.
    Producto ObtenerProductoPorId(int id);                          //Producto es el tipo de dato que se espera devolucion. int id: recibe el identificador del producto que queremos buscar.

    //Declara una búsqueda por categoría.
    List<Producto> ObtenerProductosPorCategoria(string categoria);  //String categoria: recibe el nombre de la categoría que queremos consultar.
}

//DatoI: En una interfaz de C# no es necesario escribir public delante de cada método: los miembros de una interfaz como estos son públicos por defecto.