﻿using CapaPresentacion.Impresiones;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class CantidadEtiquetasImprimir : Form
    {
        private string descripcion, codigoBarra;
        private int numeroEntero;
        Thread hilo;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public CantidadEtiquetasImprimir(string descripcion, string codigoBarra)
        {
            InitializeComponent();
            this.descripcion = descripcion;
            this.codigoBarra = codigoBarra;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidarTextBox())
                {
                    hilo = new Thread(() =>
                    {
                        ImpresionEtiquetaProducto impresionEtiquetaProducto = new ImpresionEtiquetaProducto(descripcion, codigoBarra, numeroEntero);
                        impresionEtiquetaProducto.Visible = false;
                        impresionEtiquetaProducto.ImprimirLabel();
                    });
                    hilo.Start();
                    this.Close();
                } else
                {
                    MessageBox.Show("Debe de introducir un numero valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private bool ValidarTextBox()
        {            
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out numeroEntero))
                return false;

            return true;
        }      

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}