namespace CarritoDeCompra.Tests;
using CarritoDeCompra.Base;
using CarritoDeCompra.Base.Interfaces;
using CarritoDeCompra.Base.Models;
using CarritoDeCompra.Base.Servicios;
using CarritoDeCompra.Tests.Fixtures;
using ShoppingCart.Tests.Doubles;

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
        _carritoTest.EliminarItem("ABC123");// item que no existe
        _carritoTest.AgregarItem(_fixture.Manzana);
        _carritoTest.EliminarItem(_fixture.Manzana.Codigo);        
        _carritoTest.AgregarItem(_fixture.Pan,5);
        _carritoTest.EliminarItem(_fixture.Pan.Codigo,10);
        Assert.Empty(_carritoTest.Items);
    }

    [Fact]
    public void _DeberiaUsarElStubImpuestos()
    {
        var StubImpuesto = new ServiciosImpuestosStub();
        var Carrito = new Carrito(servicioImpuesto: StubImpuesto); // Constructor no acepta argumentos aún
        Carrito.AgregarItem(_fixture.Manzana); // 100

        // 100 + 10 (Stub) = 110
        Assert.Equal(110m, Carrito.CalcularTotalFinal()); // Método no existe
    }

    [Fact]
    public void CalcularTotal_DeberiaAplicarDescuento()
    {
        var descuentoMock = new ServicioDescuentoMock(50m); // Descuenta 50
        var carrito = new Carrito(null, descuentoMock);
        carrito.AgregarItem(_fixture.Manzana); // Vale 100
        //aplicando descuento deberia devolver 100 - 50 = 50
        Assert.Equal(50m, carrito.CalcularTotalFinal());
    }

    [Fact]
    public void CalcularTotal_DeberiaAplicarDescuentoEImpuesto()
    {
        var StubImpuesto = new ServiciosImpuestosStub(); // Impuesto por defecto 10
        var descuentoMock = new ServicioDescuentoMock(37m); // Descuenta 60
        var carrito = new Carrito(StubImpuesto, descuentoMock);
        carrito.AgregarItem(_fixture.Manzana); // Vale 100
        //aplicando descuento deberia devolver 100 - 37 + 10 = 73
        Assert.Equal(73m, carrito.CalcularTotalFinal());
    }


    [Fact]
    public void Control_EscenarioReal_DeberiaCalcularElTotalFinalConImpuestosYDescuentos()
    {
        var ServicioDeImpuestoReal = new ServicioDeImpuestoEstandar();
        var ServicioDeDescuentoReal = new ServicioDeDescuento3por2();

        var carrito = new Carrito(ServicioDeImpuestoReal, ServicioDeDescuentoReal);

        carrito.AgregarItem(_fixture.Manzana, 3); 
        var finalTotal = carrito.CalcularTotalFinal();
        Assert.Equal(242m, finalTotal);
    }

}
