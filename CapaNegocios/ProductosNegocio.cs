﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.Entity.Core.Objects;

namespace CapaNegocios
{
     public class ProductosNegocio
     {
        ProductosDatos productosDatos = new ProductosDatos();
        public Tuple<bool, int> AgregarProducto(Producto producto)
        {

            return productosDatos.AgregarProducto(producto);
        }

        public ObjectResult<proc_CargarTodosProductos_Result> CargarTodosProductos()
        {
            return productosDatos.CargarTodosProductos();
        }
        public ObjectResult<proc_CargarProductosExistBaja_Result> CargarProductosExistBaja()
        {
            return productosDatos.CargarProductosExistBaja();
        }

        public ObjectResult<proc_CargarProductosExistBajaPorProveedor_Result> CargarProductosExistBajaPorProveedor(int proveedorID)
        {
            return productosDatos.CargarProductosExistBajaPorProveedor(proveedorID);
        }


        public ObjectResult<proc_CargarProductosPorProveedor_Result> CargarProductosPorProveedor(int proveedorID)
        {
            return productosDatos.CargarProductosPorProveedor(proveedorID);
        }


        public bool EditarProducto(Producto producto)
        {
            return productosDatos.EditarProducto(producto);
        }
        
        public bool BorrarProducto(int productoID)
        {
            return productosDatos.BorrarProducto(productoID);
        }

        public ObjectResult<proc_CargarProductosMasVendidos_Result> CargarProductosMasVendidos()
        {
            return productosDatos.CargarProductosMasVendidos();
        }
        public ObjectResult<proc_BuscarProductosPorCodigoBarra_Result> BuscarProductosPorCodigoBarra(string codigoBarra)
        {
            return productosDatos.BuscarProductosPorCodigoBarra(codigoBarra);
        }
        public bool ActualizarCantidadProducto(Producto producto)
        {
            return productosDatos.ActualizarCantidadProducto(producto);
        }
        public bool ActualizarCantidadProductoPorID(Producto producto)
        {
            return productosDatos.ActualizarCantidadProductoPorID(producto);
        }
    }
}
