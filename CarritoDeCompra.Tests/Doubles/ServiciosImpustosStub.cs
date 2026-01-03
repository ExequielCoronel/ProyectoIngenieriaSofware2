using CarritoDeCompra.Base.Interfaces;
namespace ShoppingCart.Tests.Doubles
{
    // STUB: Devuelve un valor predecible para aislar el test
    public class ServiciosImpuestosStub : IServiciosImpuestos
    {
        public decimal CalculateImpuesto(decimal subtotal)
        {
            return 10m; // Siempre cobra 10 pesos de impuesto, para facilitar sumas en tests
        }
    }
}