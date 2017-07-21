using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class sect_act_abm : Form
    {
        bo dlog = new bo();

        private string ID;
        public string _ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        private int ESTADO;
        public int _ESTADO
        {
            get
            {
                return ESTADO;
            }
            set
            {
                ESTADO = value;
            }
        }

        public sect_act_abm()
        {
            InitializeComponent();
            comboRoles();
            comboRolesMod();
        }

        public void comboRoles()
        {
            cbRoles.DataSource = null;
            string query = "SELECT DISTINCT ROL FROM SECTACT ORDER BY ROL";
            cbRoles.Items.Clear();
            cbRoles.DataSource = dlog.BO_EjecutoDataTable(query);
            cbRoles.DisplayMember = "ROL";
            cbRoles.ValueMember = "ROL";
            cbRoles.SelectedIndex = 0;
        }

        public void comboRolesMod()
        {
            cbRoleMod.DataSource = null;
            string query = "SELECT DISTINCT ROL FROM SECTACT ORDER BY ROL";
            cbRoleMod.Items.Clear();
            cbRoleMod.DataSource = dlog.BO_EjecutoDataTable(query);
            cbRoleMod.DisplayMember = "ROL";
            cbRoleMod.ValueMember = "ROL";
            cbRoleMod.SelectedIndex = -1;
        }

        public void comboSectAct(string ROL)
        {
            cbSectActMod.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + ROL + "' ORDER BY DETALLE ASC;";
            cbSectActMod.Items.Clear();
            cbSectActMod.DataSource = dlog.BO_EjecutoDataTable(query);
            cbSectActMod.DisplayMember = "DETALLE";
            cbSectActMod.ValueMember = "ID";
            cbSectActMod.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbSectAct.Text == "")
            {
                MessageBox.Show("INGRESAR NOMBRE");
            }
            else
            {
                try
                {
                    string ROLE = cbRoles.SelectedValue.ToString();
                    string SECTACT = tbSectAct.Text;
                    int CODINT = Convert.ToInt32(tbCodint.Text);
                    int CODCP = Convert.ToInt32(tbCodcp.Text);
                    dlog.nuevaEspecialidad(ROLE, SECTACT, CODINT, CODCP);
                    MessageBox.Show("DATOS GUARDADOS");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO COMPLETAR LA OPERACION\n"+error);
                }
            }
        }

        private void cbRoleMod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ID = cbRoleMod.SelectedValue.ToString();
            comboSectAct(ID);
        }

        private void btnModificarSectAct_Click(object sender, EventArgs e)
        {
            if (tbNuevoNombre.Text == "")
            {
                MessageBox.Show("INGRESAR NOMBRE Y PISO");
            }
            else
            {
                try
                {
                    dlog.modificarEspecialidad(int.Parse(cbSectActMod.SelectedValue.ToString()), tbNuevoNombre.Text);
                 
                    MessageBox.Show("DATOS MODIFICADOS");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO COMPLETAR LA OPERACION\n" + error);
                }
            }
        }

        public void cargarValores(string ID)
        {
            string query = "SELECT DETALLE, PISO, ESTADO FROM SECTACT WHERE ID = '" + ID + "'";

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            tbNuevoNombre.Text = foundRows[0][0].ToString().Trim();

            if (foundRows[0][2].ToString() == "1")
            {
                ESTADO = 1;
                btnEstado.Text = "Suspender";
            }
            else
            {
                ESTADO = 0;
                btnEstado.Text = "Activar";
            }
        }

        private void cbSectActMod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarValores(cbSectActMod.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbNuevoRole.Text == "")
            {
                MessageBox.Show("INGRESAR NOMBRE DEL ROLE");
            }
            else if (tbDetalleRole.Text == "")
            {
                MessageBox.Show("INGRESAR DETALLE PARA EL ROLE");
            }
            else
            {
                try
                {
                    dlog.nuevoRoleSectAct(tbNuevoRole.Text.Trim(), tbDetalleRole.Text.Trim());
                    comboRoles();
                    comboRolesMod();
                    MessageBox.Show("DATOS GUARDADOS");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO COMPLETAR LA OPERACION\n" + error);
                }
            }
         }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO == 1)
                {
                    dlog.modificarEstadoSectAct(int.Parse(cbSectActMod.SelectedValue.ToString()), 0);
                    MessageBox.Show("ESTADO MODIFICADO");
                }

                else
                {
                    dlog.modificarEstadoSectAct(int.Parse(cbSectActMod.SelectedValue.ToString()), 1);
                    MessageBox.Show("ESTADO MODIFICADO");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO COMPLETAR LA OPERACION\n" + error);
            }
        }
    }
}
