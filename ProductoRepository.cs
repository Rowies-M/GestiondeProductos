
using System.Linq;                                     //Permite utilizar métodos de LINQ para consultar y filtrar colecciones.

public class ProductoRepository : IProductoRepository  //Aca creamos la clase que implementa el contrato definido en IProductoRepository.
{
    private readonly List<Producto> productos;         //Creamos una lista privada para almacenar los productos. readonly: permite asignar la lista durante la inicialización, pero impide reemplazarla por otra lista después. No impide agregar o quitar elementos internos.


    public ProductoRepository()                                                  
    {
        productos = new List<Producto>                 //Inicializamos la lista con cuatro productos de ejemplo para tener datos disponibles al iniciar el programa.
        {
            new Producto                               //Creamos el primer objeto de tipo Producto.
            {
                Id = 1,                                //Asignamos el identificador del producto
                Nombre = "Mouse",                      //Asignamos el nombre del producto.
                Precio = 25000m,                       //Asignamos el precio como decimal; la m indica el tipo decimal.
                Categoria = "Tecnología",              //Indicamos la categoría a la que pertenece.
                Activo = true                          //Indicamos que el producto está activo.
            },

            new Producto                               //Creamos el segundo objeto de tipo Producto.
            {
                Id = 2,
                Nombre = "Teclado",
                Precio = 12000m,
                Categoria = "Tecnología",
                Activo = true
            },

            new Producto                               //Creamos el tercer objeto de tipo Producto.
            {
                Id = 3,
                Nombre = "Monitor",
                Precio = 85000m,
                Categoria = "Tecnología",
                Activo = true
            },

            new Producto                               //Creamos el cuarto objeto de tipo Producto.
            {
                Id = 4,
                Nombre = "Escritorio",
                Precio = 120000m,
                Categoria = "Muebles",
                Activo = false
            }
        };
    }

    public void Agregar(Producto producto)             //Agregar un producto nuevo a la lista.
    {
        productos.Add(producto);                       //Add agrega el objeto recibido al final de la lista.
    }

    public List<Producto> ObtenerProductos()           //Devuelve una copia de la lista actual de productos.
    {
        return productos.ToList();                     //ToList crea una nueva lista con los elementos actuales.
    }

    public Producto ObtenerProductoPorId(int id)       //Busca un producto utilizando su identificador.
    {
        return productos.FirstOrDefault(p => p.Id == id)      //FirstOrDefault busca el primer producto cuyo ID coincida con el ID recibido.
            ?? throw new KeyNotFoundException(                //Si no encuentra ninguno, devuelve null; el operador ?? permite lanzar una excepción en ese caso.
                $"No se encontro un producto con el ID {id}." //Interpolamos el ID buscado dentro del mensaje de error.
            );
    }

    public List<Producto> ObtenerProductosPorCategoria(string categoria)   //Busca y devuelve todos los productos que pertenecen a una categoría determinada.
    {
        return productos
            .Where(p => string.Equals(                                     //Where filtra la lista y conserva los productos que cumplen la condición.
                p.Categoria,                                               //Primer valor que se compara: la categoría del producto.
                categoria,                                                 //Segundo valor que se compara: la categoría recibida como parámetro.
                StringComparison.OrdinalIgnoreCase                         //Compara los textos sin distinguir mayúsculas de minúsculas.
            ))
            .ToList();                                                     //Convierte el resultado filtrado en una nueva lista.
    }
}