namespace CarritoDeCompra.Base;
using CarritoDeCompra.Base.Models;
public class Carrito
{
    //tener cuidado porque pueden salir requerimientos futuros, ej lista de solo lectura
    public List<Producto> Items { get; } = new List<Producto>();
    public void AgregarItem(Producto producto)
    {
        Items.Add(producto);
    }

}
