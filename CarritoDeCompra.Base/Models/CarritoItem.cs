namespace CarritoDeCompra.Base.Models
{
    // Iteración 3: Clase para agrupar ítems por cantidad.
    public class CarritoItem
    {
        public Producto Product { get; }
        public int Cantidad { get; private set; }

        public CarritoItem(Producto product, int cantidad)
        {
            Product = product;
            Cantidad = cantidad;
        }

        public void AgregarCantidad(int cant) => Cantidad += cant;

        public decimal PrecioTotal => Product.Precio * Cantidad;

        public void EliminarCantindad(int cant)
        {
            Cantidad = Math.Max(0, Cantidad - cant);
        }

    }
}