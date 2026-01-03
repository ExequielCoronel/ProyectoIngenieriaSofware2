using CarritoDeCompra.Base.Interfaces;
namespace CarritoDeCompra.Base.Servicios
{
    public class ServicioDeImpuestoEstandar : IServiciosImpuestos
    {
        // IVA = 21%
        private const decimal Impuesto = 0.21m;

        public decimal CalcularImpuesto(decimal subtotal)
        {
            // redondeamos a 2 cifras
            return Math.Round(subtotal * Impuesto, 2);
        }
    }
}