using CarritoDeCompra.Base.Models;

namespace CarritoDeCompra.Base.Interfaces
{
     public interface IServiciosDescuentos
    {
       decimal CalcularDescuento(IEnumerable<CarritoItem> items); 
    }
}