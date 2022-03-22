using App.BL.BC;
using App.BL.BE;
using App.UI.WF.UTIL;
using App.UI.WF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.WF
{
    public partial class Form1 : Form
    {
        private ProductoBC productoBC = new ProductoBC();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProducto frmProducto = frmProducto.GetFrm;
            frmProducto.frm = this;
            frmProducto.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducto.SelectedCells.Count > 0)
                {
                    int index = dgvProducto.SelectedCells[0].RowIndex;
                    var obj = dgvProducto.Rows[index].DataBoundItem as ProductoViewModel;
                    var oProducto = Util_Cast.ConvertirFromViewModelToBE(obj);

                    frmProducto frmProducto = frmProducto.GetFrm;
                    frmProducto.productoBE = productoBC.Get(oProducto.ProductoId);
                    frmProducto.frm = this;
                    frmProducto.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducto.SelectedCells.Count> 0)
                {
                    int index = dgvProducto.SelectedCells[0].RowIndex;
                    var obj = dgvProducto.Rows[index].DataBoundItem as ProductoViewModel;
                    var oProducto = Util_Cast.ConvertirFromViewModelToBE(obj);
                    DialogResult dialog = MessageBox.Show("Desea eliminar este producto?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        productoBC.Delete(oProducto);
                        UpdateDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            dgvProducto.DataSource = productoBC.List()
                .Select(p => new ProductoViewModel
                {
                    ProductoId = p.ProductoId,
                    Categoria = p.Categoria_Nombre,
                    Descripcion = p.Descripcion,
                    Nombre = p.Nombre,
                    Precio = p.Precio
                }).ToList();
            dgvProducto.Refresh();
            dgvProducto.Update();
        }
    }
}
