using App.BL.BC;
using App.BL.BE;
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
    public partial class frmProducto : Form
    {
        public ProductoBE productoBE;
        public Form1 frm;

        private CategoriaBC categoriaBC = new CategoriaBC();
        private ProductoBC productoBC = new ProductoBC();

        //Aplicamos Singleton
        private static frmProducto inst;
        public static frmProducto GetFrm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frmProducto();
                }
                return inst;
            }
        }
        //fin de singleton
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

            cbCategoria.DataSource = categoriaBC.List();
            cbCategoria.ValueMember = "CategoriaId";
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

            if (productoBE != null)
            {
                lblProductoId.Visible = true;
                txtProductId.Visible = true;

                txtProductId.Text = productoBE.ProductoId.ToString();
                txtNombre.Text = productoBE.Nombre;
                txtDescripcion.Text = productoBE.Descripcion;
                txtPrecio.Text = productoBE.Precio.ToString();

                cbCategoria.SelectedIndex = cbCategoria.FindStringExact(productoBE.Categoria_Nombre);

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoBE != null)
                {
                    SetData();
                    productoBC.Update(productoBE);
                    MessageBox.Show("Registro actualizado satisfactoriamente.");

                }
                else
                {
                    productoBE = new ProductoBE();
                    SetData();
                    productoBC.Add(productoBE);
                    MessageBox.Show("Registro agregado satisfactoriamente.");
                }

                frm.UpdateDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un problema al ejecutar la aplicación.", ex.Message);

                throw;
            }
        }

        private void SetData()
        {
            var cbValue = cbCategoria.SelectedItem as CategoriaBE;
            productoBE.CategoriaId = cbValue.CategoriaId;
            productoBE.Nombre = txtNombre.Text;
            productoBE.Descripcion = txtDescripcion.Text;
            productoBE.Precio = Convert.ToDecimal(txtPrecio.Text);
        }
    }
}
