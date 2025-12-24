namespace CarritoDeCompra.Base;
using CarritoDeCompra.Base.Models;
public class Carrito
{
    public List<Producto> Items { get; } = new List<Producto>();
    public void AgregarItem(Producto producto)
    {
        throw new NotImplementedException(); 
    }

}
