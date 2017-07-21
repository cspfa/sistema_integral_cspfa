using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class mainIngresos : Form
    {
        bo dlog = new bo();

        private int en;
        public int _en
        {
            get
            {
                return en;
            }
            set
            {
                en = value;
            }
        }

        public mainIngresos()
        {
            InitializeComponent();
            llenarComboNombre();
            button1.Visible = false;
        }

        public void llenarComboNombre()
        {
            cbNombre.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM PERSONAS WHERE ESTADO = 1 ORDER BY NOMBRE;";
            cbNombre.Items.Clear();
            cbNombre.DataSource = dlog.BO_EjecutoDataTable(query);
            cbNombre.DisplayMember = "NOMBRE";
            cbNombre.ValueMember = "ID";
            cbNombre.SelectedItem = null;
        }

        private void cbNombre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string queryP = "SELECT PERSONAS.NOMBRE, ESTADO.ESTADO, ESCALAFON.ESCALAFON, CARGO.CARGO FROM PERSONAS, ESTADO, ESCALAFON, CARGO WHERE PERSONAS.ESTADO = ESTADO.ID AND PERSONAS.ESCALAFON = ESCALAFON.ID AND PERSONAS.CARGO = CARGO.ID AND PERSONAS.ID = " + cbNombre.SelectedValue.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(queryP).Select();
            laCargo.Text = foundRows[0][3].ToString();
            laEscalafon.Text = foundRows[0][2].ToString();
            laEstado.Text = foundRows[0][1].ToString();

            string queryA = "SELECT FIRST 1 * FROM MOVIMIENTOS WHERE PERSONA = " + cbNombre.SelectedValue.ToString() + " ORDER BY ID DESC;";
            DataRow[] fRows;
            fRows = dlog.BO_EjecutoDataTable(queryA).Select();

            if (fRows.Length > 0)
            {
                if (int.Parse(string.Format("{0}", fRows[0][2])) == 1) // SE ENCUENTRA EN LA ENTIDAD
                {
                    en = 1;
                    enEntidad.ForeColor = Color.Green;
                    enEntidad.Text = "Se encuentra en la entidad";
                    button1.Text = "Salida";
                    lbSalidaEntrada.Text = "Ultima entrada:";
                    laFechaSalidaEntrada.Text = fRows[0][3].ToString();
                    button1.Visible = true;
                    laFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    mtbHora.Text = DateTime.Now.ToString("HH:mm:ss"); 
                }
                else if (int.Parse(string.Format("{0}", fRows[0][2])) == 2) // NO SE ENCUENTRA EN LA ENTIDAD
                {
                    en = 2;
                    enEntidad.ForeColor = Color.Red;
                    enEntidad.Text = "No se encuentra en la entidad";
                    button1.Text = "Entrada";
                    lbSalidaEntrada.Text = "Ultima salida:";
                    laFechaSalidaEntrada.Text = fRows[0][3].ToString();
                    button1.Visible = true;
                    laFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    mtbHora.Text = DateTime.Now.ToString("HH:mm:ss");
                }
            }
            else // NO HAY REGISTRO
            {
                en = 2;
                enEntidad.ForeColor = Color.Red;
                enEntidad.Text = "No se encuentra en la entidad";
                button1.Text = "Entrada";
                lbSalidaEntrada.Text = "Ultima salida:";
                laFechaSalidaEntrada.Text = "No se encontraron datos";
                button1.Visible = true;
                laFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                mtbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            
            if (en == 1) //LE DOY SALIDA
            {
                if (MessageBox.Show("¿CONFIRMA DARLE SALIDA A " + cbNombre.Text.ToUpper() + "?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string fecha_hora = laFecha.Text + " " + mtbHora.Text;
                        checkHour ch = new checkHour();

                        if (ch.checkH(fecha_hora, (int.Parse(string.Format("{0}", cbNombre.SelectedValue)))) == false)
                        {
                            dlog.guardarMovimiento(int.Parse(string.Format("{0}", cbNombre.SelectedValue)), 2, fecha_hora, VGlobales.vp_username);
                            dlog.modificarPA(int.Parse(string.Format("{0}", cbNombre.SelectedValue)), 2);
                            en = 2;
                            enEntidad.ForeColor = Color.Red;
                            enEntidad.Text = "No se encuentra en la entidad";
                            button1.Text = "Entrada";
                            lbSalidaEntrada.Text = "Ultima salida:";
                            string queryA = "SELECT FIRST 1 FECHA_HORA FROM MOVIMIENTOS WHERE PERSONA = " + cbNombre.SelectedValue.ToString() + " ORDER BY FECHA_HORA DESC;";
                            DataRow[] fRows;
                            fRows = dlog.BO_EjecutoDataTable(queryA).Select();
                            laFechaSalidaEntrada.Text = fRows[0][0].ToString();
                            MessageBox.Show("Salida registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("La hora ingresada no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("No se pudo registrar la salida\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (en == 2) //LE DOY ENTRADA
            {
                if (MessageBox.Show("¿CONFIRMA DARLE ENTRADA A " + cbNombre.Text.ToUpper() + "?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string fecha_hora = laFecha.Text + " " + mtbHora.Text;
                        checkHour ch = new checkHour();

                        if (ch.checkH(fecha_hora, (int.Parse(string.Format("{0}", cbNombre.SelectedValue)))) == false)
                        {
                            dlog.guardarMovimiento(int.Parse(string.Format("{0}", cbNombre.SelectedValue)), 1, fecha_hora, VGlobales.vp_username);
                            dlog.modificarPA(int.Parse(string.Format("{0}", cbNombre.SelectedValue)), 1);
                            en = 1;
                            enEntidad.ForeColor = Color.Green;
                            enEntidad.Text = "Se encuentra en la entidad";
                            button1.Text = "Salida";
                            lbSalidaEntrada.Text = "Ultima entrada:";
                            string queryA = "SELECT FIRST 1 FECHA_HORA FROM MOVIMIENTOS WHERE PERSONA = " + cbNombre.SelectedValue.ToString() + " ORDER BY FECHA_HORA DESC;";
                            DataRow[] fRows;
                            fRows = dlog.BO_EjecutoDataTable(queryA).Select();
                            laFechaSalidaEntrada.Text = fRows[0][0].ToString();
                            MessageBox.Show("Ingreso registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("La hora ingresada no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("No se pudo registrar la entrada\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            button1.Enabled = true;
        }
    }
}
