using CarritoDeCompra.Base.Interfaces;
using CarritoDeCompra.Base.Models;

namespace CarritoDeCompra.Base.Servicios
{
    public class ServicioDeDescuento3por2 : IServiciosDescuentos
    {
        public decimal CalcularDescuento(IEnumerable<CarritoItem> items)
        {
            decimal DescuentoTotal = 0;

            foreach (var item in items)
            {
                // La lógica: Por cada 3 unidades, 1 es gratis.
                // Ejemplo: Si llevas 7, pagas 5 (2 gratis).
                if (item.Cantidad >= 3)
                {
                    var ItemLibre = item.Cantidad / 3; // División entera (7 / 3 = 2)
                    DescuentoTotal += ItemLibre * item.Product.Precio;
                }
            }
            
            return DescuentoTotal;
        }
    }
}