using CarritoDeCompra.Base.Models;

namespace CarritoDeCompra.Tests.Fixtures
{
    //Fixture para compartir datos de prueba.
    public class ProductoFixture : IDisposable
    {
        public Producto Manzana { get; private set; }
        public Producto Pan { get; private set; }

        public ProductoFixture()
        {
            Manzana = new Producto("A100", "Manzana", 100m);
            Pan = new Producto("B001", "Pan", 50m);
        }

        public void Dispose()
        {
            // Requisito: Teardown (limpieza de recursos si fuera necesario)
        }
    }
}