public interface IProductoRepository
{
    public void Agregar(Producto producto);

    List<Producto> ObtenerProductos();

    Producto ObtenerProductoPorId(int id);

    List<Producto> ObtenerProductosPorCategoria(string categoria);
}
