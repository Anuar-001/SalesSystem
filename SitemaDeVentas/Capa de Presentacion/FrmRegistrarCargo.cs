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
    public partial class FrmRegistrarCargo : Form
    {
        private clsCargo C = new clsCargo();

        public FrmRegistrarCargo()
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
            String Mensaje = "";
            try{
                if (txtCargo.Text.Trim() != ""){
                    if (Program.Evento == 0){
                        C.Descripcion = txtCargo.Text;
                        Mensaje = C.RegistrarCargo();
                        if (Mensaje == "El Cargo ya se Encuentra Registrado."){
                            MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else{
                            MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        }else{
                        C.IdCargo = Convert.ToInt32(txtIdC.Text);
                        C.Descripcion = txtCargo.Text;
                        MessageBox.Show(C.ActualizarCargo(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                }
                else {
                    MessageBox.Show("Por Favor Ingrese el Cargo a Registrar.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtCargo.Focus();
                }
                }catch (Exception ex){
                    MessageBox.Show(ex.Message);
            }
            
        }

        private void Limpiar() {
            txtCargo.Text = "";
            txtIdC.Clear();
            txtCargo.Focus();
        }
    }
}
