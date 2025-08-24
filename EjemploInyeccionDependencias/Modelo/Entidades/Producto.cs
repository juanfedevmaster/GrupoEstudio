using Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Producto : IProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; private set; }
        public int Stock { get; set; }
        public int Descuento { get; set; }

        public Producto()
        {
            this.Nombre = "Producto de prueba";
            this.Descripcion = "Descripcion de prueba";
            this.Precio = 175;
            this.Stock = 10;
            this.Descuento = 15;
        }

        public Producto(int id, string nombre, string descripcion, decimal precio, int stock, int descuento)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Descuento = descuento;
        }

        #region [Metodos implementados de la Interface]
        public void ObtenerDescuentoProducto()
        {
            Console.WriteLine("Obteniendo descuento del producto");
            this.Precio = this.Precio - (this.Precio * (this.Descuento)/100);
            Console.WriteLine("Descuento del producto obtenido");
        }

        public void ObtenerStockProducto()
        {
            Console.WriteLine("Obteniendo stock del producto");
            Console.WriteLine($"Stock del producto {this.Nombre} es de: {this.Stock}");
        }
        #endregion
    }
}
