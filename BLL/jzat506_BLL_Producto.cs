using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class jzat506_BLL_Producto
    {
        private readonly jzat506_DAL_Producto jzat506_dalProducto = new jzat506_DAL_Producto();

        public List<jzat506_Producto> jzat506_ListarProductos()
        {
            return jzat506_dalProducto.jzat506_ListarProductos();
        }

        public jzat506_DetalleFactura jzat506_ArmarDetalle(jzat506_Producto producto, int cantidad)
        {
            if (producto == null)
                throw new Exception("Debe seleccionarse un producto.");

            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser un numero entero mayor a cero.");

            if (cantidad > 100)
                throw new Exception("La cantidad por producto no puede superar las 100 unidades.");

            return new jzat506_DetalleFactura
            {
                jzat506_Producto = producto,
                jzat506_Cantidad = cantidad,
                jzat506_PrecioUnitario = producto.jzat506_Precio
            };
        }
    }
}
