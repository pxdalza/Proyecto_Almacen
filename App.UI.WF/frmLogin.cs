using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ITextSharp.html;

namespace App.UI.WF
{
    public partial class frmLogin : Form
    {
        private string main_path = @"../../files";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(main_path);

            if (directoryInfo.Exists)
            {

                if (File.Exists(main_path + "/log.xyz"))
                {
                    StreamReader reader = new StreamReader(main_path + "/log.xyz");

                    int i = 0;
                    string user = "", pwd = "";
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        switch (i)
                        {
                            case 0:
                                user = line;
                                break;
                            default:
                                pwd = line;

                                break;
                        }
                        i++;
                    }

                    reader.Dispose();
                    //llamar al bc para hacer login y redirigir a al frm principal
                    txtContrasenia.Text = pwd;
                    txtUsuario.Text = user;
                    //si el usuario existe
                    //te redirijo al Form1
                    //de no existir te dejo pasar al login
                }

            }
            else
            {
                directoryInfo.Create();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Length > 3 && txtContrasenia.Text.Length>6)
                {

                    //Modificar la validacion con un usuario de BD
                    if (txtUsuario.Text.Equals("admin") && txtContrasenia.Text.Equals("1234567"))
                    {

                        if (cbxRecuerdame.Checked)
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(main_path);

                            if (directoryInfo.Exists)
                            {

                                if (File.Exists(main_path+"/log.xyz"))
                                {
                                    File.Delete(main_path + "/log.xyz");
                                }
                                 
                                StreamWriter writer = new StreamWriter(main_path + "/log.xyz",true);
                                writer.WriteLine("admin");
                                writer.WriteLine("1234567");
                                writer.Dispose();

                            }
                            else
                            {
                                directoryInfo.Create();
                            }
                        }

                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña no validos.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el sistema.");
            }
        }
    }
}
