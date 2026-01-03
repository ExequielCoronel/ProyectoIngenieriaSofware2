namespace CarritoDeCompra.Tests;
using CarritoDeCompra.Base;
using CarritoDeCompra.Base.Models;
using CarritoDeCompra.Tests.Fixtures;

public class CarritoTests : IClassFixture<ProductoFixture>, IDisposable
{

    private readonly ProductoFixture _fixture;
    private Carrito _carritoTest;

    public CarritoTests(ProductoFixture fixture)
    {
        _fixture = fixture;
        _carritoTest = new Carrito(); 
    }

    //Teardown mediante Dispose
    public void Dispose()
    {
        _carritoTest= null;
    }

    [Fact]
    public void AgregarItem_DeberiaAgregar()
    {
        _carritoTest.AgregarItem(_fixture.Manzana);
        Assert.Single(_carritoTest.Items);
        Assert.Equal("Manzana", _carritoTest.Items[0].Product.Nombre);
    }

    [Fact]
    public void Subtotal_DeberiaSumarPrecioItems()
    {
        _carritoTest.AgregarItem(_fixture.Manzana);
        _carritoTest.AgregarItem(_fixture.Pan);
        Assert.Equal(150m, _carritoTest.Subtotal);
}    


    [Fact]
    public void AgregarItem_ProductoExistente_DeberiaIncrementarCantidad()
    {
        // Usando el Fixture
        _carritoTest.AgregarItem(_fixture.Manzana);
        _carritoTest.AgregarItem(_fixture.Manzana);

        Assert.Single(_carritoTest.Items);
        Assert.Equal(2, _carritoTest.Items[0].Cantidad); // carrito no tiene un campo que permita saber la cantidad, deberia tirar error de compilacion en red
    }

    [Fact]
    public void EliminarItem_DeberiaEliminarItem()
    {
        _carritoTest.AgregarItem(_fixture.Manzana);
        _carritoTest.EliminarItem(_fixture.Manzana.Codigo); // Método no existe
        Assert.Empty(_carritoTest.Items);
    }

}
