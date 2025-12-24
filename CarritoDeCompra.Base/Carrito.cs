namespace CarritoDeCompra.Base;
using CarritoDeCompra.Base.Models;
public class Carrito
{
    
    //public List<Producto> Items { get; } = new List<Producto>();
    private readonly List<Producto> _items = new();
    public IReadOnlyList<Producto> Items => _items.AsReadOnly();
    public void AgregarItem(Producto producto)
    {
        _items.Add(producto);
    }

}
