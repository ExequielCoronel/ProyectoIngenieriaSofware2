namespace CarritoDeCompra.Tests;
using CarritoDeCompra.Base;
using CarritoDeCompra.Base.Models;

public class UnitTest1
{
    [Fact]
    public void AgregarItem_DeberiaAgregar()
    {
        var carrito=new Carrito();
        var producto = new Producto("A001", "Manzana", 100m);

        carrito.AgregarItem(producto);
        Assert.Single(carrito.Items);
        Assert.Equal("Manzana", carrito.Items[0].Nombre);
    }
}
