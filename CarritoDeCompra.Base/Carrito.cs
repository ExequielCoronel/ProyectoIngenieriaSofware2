namespace CarritoDeCompra.Base;

using CarritoDeCompra.Base.Interfaces;
using CarritoDeCompra.Base.Models;



public class Carrito
{
    
    //public List<Producto> Items { get; } = new List<Producto>();
    private readonly List<CarritoItem> _items = new();
    private readonly IServiciosImpuestos? _servicioImpuesto;
    public Carrito(IServiciosImpuestos? servicioImpuesto = null)
    {
        _servicioImpuesto = servicioImpuesto;
    }
    public IReadOnlyList<CarritoItem> Items => _items.AsReadOnly();
public void AgregarItem(Producto product, int cantidad = 1)
    {
        var itemExistente = _items.FirstOrDefault(i => i.Product.Codigo == product.Codigo);
        if (itemExistente != null)
        {
            itemExistente.AgregarCantidad(cantidad);
        }
        else
        {
            _items.Add(new CarritoItem(product, cantidad));
        }
    }
    public decimal Subtotal => _items.Sum(i => i.PrecioTotal);

    public void EliminarItem(string codigo, int cantidad = 1)
    {
        var itemExistente = _items.FirstOrDefault(i => i.Product.Codigo == codigo);
        if (itemExistente == null) return;

        itemExistente.EliminarCantindad(cantidad);
        if (itemExistente.Cantidad <= 0)
        {
            _items.Remove(itemExistente);
        }
    }
}
