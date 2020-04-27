using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaLogicaNegocio;

namespace Capa_de_Presentacion
{
    public partial class FrmRegistrarCategoria : Form
    {
        private clsCategoria C = new clsCategoria();

        public FrmRegistrarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsCategoria C = new clsCategoria();
            String Mensaje = "";
            try{
                if (txtCategoria.Text.Trim() != "")
                {
                    if (Program.Evento == 0){
                        C.Descripcion = txtCategoria.Text;
                        Mensaje = C.RegistrarCategoria();
                        if (Mensaje == "Categoria ya se encuentra Registrada."){
                            MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }else {
                            MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }

                    }else{
                        C.IdC = Convert.ToInt32(IdC.Text);
                        C.Descripcion = txtCategoria.Text;
                        MessageBox.Show(C.ActualizarCategoria(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                }else {
                    MessageBox.Show("Por Favor Digíte Datos.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtCategoria.Focus();
                }
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }


        private void Limpiar() {
            txtCategoria.Clear();
            txtCategoria.Focus();
        }
    }
}
