using CarritoDeCompra.Base.Interfaces;
using CarritoDeCompra.Base.Models;

namespace ShoppingCart.Tests.Doubles
{
    // Clase pública para que pueda ser usada por cualquier Test
    public class ServicioDescuentoMock : IServiciosDescuentos
    {
        private readonly decimal _cantidadRetornar;

        // Configuramos cuánto queremos que devuelva al instanciarla
        public ServicioDescuentoMock(decimal cantidadRetornar)
        {
            _cantidadRetornar = cantidadRetornar;
        }

        public decimal CalculateDiscount(IEnumerable<CarritoItem> items)
        {
            // Devuelve siempre el valor fijo que le configuramos
            return _cantidadRetornar;
        }
    }
}