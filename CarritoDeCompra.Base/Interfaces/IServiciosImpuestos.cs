namespace CarritoDeCompra.Base.Interfaces
{
    // Interfaz para desacoplar el cálculo de impuestos (Permite Mocking)
    public interface IServiciosImpuestos
    {
        decimal CalcularImpuesto(decimal subtotal);
    }
}