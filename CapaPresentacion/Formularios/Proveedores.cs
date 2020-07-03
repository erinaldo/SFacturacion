﻿using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Proveedores : Form
    {
        ProveedoresNegocio proveedoresNegocio = new ProveedoresNegocio();
        List<proc_CargarTodosProveedores_Result> proc_CargarTodosProveedores_Results;
        Proveedore proveedorEntidad = new Proveedore();
        bool resultado;
        public Proveedores()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MantenimientoProveedor frmMantProveedor = new MantenimientoProveedor();
            frmMantProveedor.Controls["btnAplicar"].Text = "Agregar";
            frmMantProveedor.ShowDialog();
            CargarProveedores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                MantenimientoProveedor frmMantProveedor = new MantenimientoProveedor(CargarParametrosProveedor());
                frmMantProveedor.Controls["btnAplicar"].Text = "Editar";
                frmMantProveedor.ShowDialog();
                CargarProveedores();
            }
            else
            {
                MessageBox.Show("Debe de seleccionar al menos un proveedor para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private Proveedore CargarParametrosProveedor()
        {
            proveedorEntidad.ProveedorID = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["ProveedorID"].Value);
            proveedorEntidad.Nombre = dgvProveedores.CurrentRow.Cells["Nombre"].Value.ToString();
            proveedorEntidad.CedulaORnc = dgvProveedores.CurrentRow.Cells["CedulaORnc"].Value.ToString();
            proveedorEntidad.Direccion = dgvProveedores.CurrentRow.Cells["Direccion"].Value.ToString();
            proveedorEntidad.Contacto_1 = dgvProveedores.CurrentRow.Cells["Contacto_1"].Value.ToString();
            proveedorEntidad.Contacto_2 = dgvProveedores.CurrentRow.Cells["Contacto_2"].Value.ToString();
            proveedorEntidad.DatoAdicional = dgvProveedores.CurrentRow.Cells["DatoAdicional"].Value.ToString();
            return proveedorEntidad;
        }

        private void CargarProveedores()
        {
            try
            {
                proc_CargarTodosProveedores_Results = proveedoresNegocio.CargarTodosProveedores().ToList();
                dgvProveedores.DataSource = proc_CargarTodosProveedores_Results;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedores.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format("Esta seguro que desea eliminar el proveedor {0}?", dgvProveedores.CurrentRow.Cells["Nombre"].Value), "Eliminar Proveedor", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        resultado = proveedoresNegocio.BorrarProveedor(Convert.ToInt32(dgvProveedores.CurrentRow.Cells["ProveedorID"].Value));
                        ValidarBorrarProveedor(resultado);
                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }
        private void ValidarBorrarProveedor(bool result)
        {
            if (result)
            {
                MessageBox.Show(string.Format("El proveedor ha sido borrado correctamente en la base de datos."), "Proveedor Borrado Correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El proveedor no pudo ser borrado, favor de verificar los requerimientros", "Ha Ocurrido un error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}