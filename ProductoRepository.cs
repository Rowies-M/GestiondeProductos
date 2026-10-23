
using System.Linq;

public class ProductoRepository : IProductoRepository
{
    private readonly List<Producto> productos;

    public ProductoRepository()
    {
        productos = new List<Producto>
        {
            new Producto
            {
                Id = 1,
                Nombre = "Mouse",
                Precio = 25000m,
                Categoria = "Tecnología",
                Activo = true
            },

            new Producto
            {
                Id = 2,
                Nombre = "Teclado",
                Precio = 12000m,
                Categoria = "Tecnología",
                Activo = true
            },

            new Producto
            {
                Id = 3,
                Nombre = "Monitor",
                Precio = 85000m,
                Categoria = "Tecnología",
                Activo = true
            },

            new Producto
            {
                Id = 4,
                Nombre = "Escritorio",
                Precio = 120000m,
                Categoria = "Muebles",
                Activo = false
            }
        };
    }

    public void Agregar(Producto producto)
    {
        productos.Add(producto);
    }

    public List<Producto> ObtenerProductos()
    {
        return productos.ToList();
    }

    public Producto ObtenerProductoPorId(int id)
    {
        return productos.FirstOrDefault(p => p.Id == id)
            ?? throw new KeyNotFoundException(
                $"No se encontro un producto con el ID {id}."
            );
    }

    public List<Producto> ObtenerProductosPorCategoria(string categoria)
    {
        return productos
            .Where(p => string.Equals(
                p.Categoria,
                categoria,
                StringComparison.OrdinalIgnoreCase
            ))
            .ToList();
    }
}