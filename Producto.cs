public class Producto                         // Public: permite que otras partes del projecto accedan a esta clase. Class: define una clase, que es un plano para crear objetos. Producto: nombre de la clase, funciona como un modelo o plantilla para representar productos en el sistema.
{
                                              // get; set; : Se utiliza en las propiedades para poder consultar y asignar valores.
    public int Id { get; set; }               // Identificador único del producto. Permite distinguirlo de los demás. 
    public string ?Nombre { get; set; }       // Nombre del producto. El signo ? indica que puede ser null (no tener valor).

    public decimal Precio { get; set; }       // Precio del producto. Utilizando buenas practicas, Decimal: se usa para representar valores monetarios. Ejemplos practicos: [decimal precio = 0.1m + 0.2m; = 0.3m.] - [double precio = 0.1 + 0.2; = 0.30---004] - [float precio = 0.1f + 0.2f; = 0.30---001f].

    public string ?Categoria { get; set; }    // Categoría a la que pertenece el producto, por ejemplo: Tecnología o Muebles.

    public bool Activo { get; set; }          // Indica si el producto está activo (true) o inactivo (false).
}