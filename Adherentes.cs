using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Mails;


namespace SOCIOS
{
    public partial class Adherentes : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public Adherentes()
        {
            InitializeComponent();
        }

        private string isadding = "NO";
        private string isediting = "NO";
        private bool protegido = true;
        private bool gpofamiliar;
        private int newpos = 0;
        private int rowpos = 0;
        private int lbxrow = 0;
        private byte[] img;
        DataTable adherentesDT = new DataTable("ADH");
        private int itemsobs = 0;
        private int lngObserv = 0;
        private string observ;
        private Image FotoIMG;
        public static int vp_id_adherente = 0;
        public bool v_semaforo_baja_adh;

        #region LIMPIAR/HABILITAR/DESHABILITAR
        public void limpio_botones()
        {
            bindingNavigator1.MoveFirstItem.Enabled = true;
            bindingNavigator1.MoveLastItem.Enabled = true;
            bindingNavigator1.MoveNextItem.Enabled = true;
            bindingNavigator1.MovePreviousItem.Enabled = true;
            cancelar.Enabled = false;
            grabar.Enabled = false;
            Ficha.Enabled = true;
            Habilitar_Botones();
            ADQUIRIR.Enabled = false;
        }

        public void limpio_campos()
        {
            maskedTextBox3.Text = "0";
            maskedTextBox13.Text = "0";
            maskedTextBox11.Text = "0";
            maskedTextbox14.Text = string.Empty; 
            maskedTextbox4.Text = string.Empty;
            maskedTextbox5.Text = string.Empty;
            maskedTextbox7.Text = string.Empty;
            maskedTextBox8.Text = string.Empty;
            maskedTextBox12.Text = string.Empty;
            maskedTextBox9.Text = "0";
            maskedTextBox10.Text = "0";
            textBox15.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textbox12.Text = string.Empty;
            listBox1.Items.Clear();
            label31.Text = "";
            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            v_semaforo_baja_adh = false;
        }

        private void Proteger()
        {
            protegido = true;
            tbEmailContacto.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;
            maskedTextBox13.ReadOnly = true;
            maskedTextBox11.ReadOnly = true;
            maskedTextbox14.ReadOnly = true;
            maskedTextbox4.ReadOnly = true;
            maskedTextbox5.ReadOnly = true;
            maskedTextbox7.ReadOnly = true;
            maskedTextBox8.ReadOnly = true;
            maskedTextBox12.ReadOnly = true;
            maskedTextBox9.ReadOnly = true;
            maskedTextBox10.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textbox12.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            comboBox1.PreventDropDown = true;
            comboBox2.PreventDropDown = true;
            comboBox3.PreventDropDown = true;
            comboBox5.PreventDropDown = true;
            comboBox6.PreventDropDown = true;
            comboBox1.BackColor = Color.FromName("Control");
            comboBox2.BackColor = Color.FromName("Control");
            comboBox3.BackColor = Color.FromName("Control");
            comboBox5.BackColor = Color.FromName("Control");
            comboBox6.BackColor = Color.FromName("Control");
            comboBox1.ForeColor = Color.FromName("Black");
            comboBox2.ForeColor = Color.FromName("Black");
            comboBox3.ForeColor = Color.FromName("Black");
            comboBox5.ForeColor = Color.FromName("Black");
            comboBox6.ForeColor = Color.FromName("Black");
            ADQUIRIR.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void Habilitar()
        {
            protegido = false;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;

            if (isediting == "SI")
            {
                 maskedTextBox3.ReadOnly = true;
                 textBox15.Focus();
                 maskedTextBox13.ReadOnly = true;
                 maskedTextBox11.ReadOnly = true;
            }
            else
            {
                 maskedTextBox3.ReadOnly = true;
             
                 if (gpofamiliar)
                 {
                     maskedTextBox13.ReadOnly = true;
                 }
                 else
                 {
                     maskedTextBox13.ReadOnly = false;
                 }

                 maskedTextBox11.ReadOnly = false;
            }

            tbEmailContacto.ReadOnly = false;
            maskedTextbox14.ReadOnly = false;
            maskedTextbox4.ReadOnly = false;
            maskedTextbox5.ReadOnly = false;
            maskedTextbox7.ReadOnly = false;
            //maskedTextbox6.ReadOnly = false;
            maskedTextBox8.ReadOnly = false;
            maskedTextBox12.ReadOnly = false;
            maskedTextBox9.ReadOnly = false;
            maskedTextBox10.ReadOnly = false;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textbox12.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox15.ReadOnly = false;

            comboBox1.PreventDropDown = true;  // nunca se habilita se setea por barra
            comboBox2.PreventDropDown = false;
            comboBox3.PreventDropDown = false;
            comboBox5.PreventDropDown = false;
            comboBox6.PreventDropDown = false;

            comboBox1.BackColor = Color.FromName("white");
            comboBox2.BackColor = Color.FromName("white");
            comboBox3.BackColor = Color.FromName("white");
            comboBox5.BackColor = Color.FromName("white");
            comboBox6.BackColor = Color.FromName("white");

            comboBox1.ForeColor = Color.FromName("Black");
            comboBox2.ForeColor = Color.FromName("Black");
            comboBox3.ForeColor = Color.FromName("Black");
            comboBox5.ForeColor = Color.FromName("Black");
            comboBox6.ForeColor = Color.FromName("Black");


            if (pictureBox1.Image == null)
            { pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible; }


            ADQUIRIR.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
        }
        #endregion

        #region BINDING NAVIGATOR
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            limpio_botones();
            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;
            rowpos = 0;
            this.BindDatosDT();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            limpio_botones();

            if (rowpos != 0)
            {
                rowpos--;
                if (rowpos == 0)
                {
                    bindingNavigator1.MoveFirstItem.Enabled = false;
                    bindingNavigator1.MovePreviousItem.Enabled = false;
                }
            }
            else
            {
                bindingNavigator1.MoveFirstItem.Enabled = false;
                bindingNavigator1.MovePreviousItem.Enabled = false;
            }


            this.BindDatosDT();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            limpio_botones();

            if (rowpos < adherentesDT.Rows.Count - 1)
            {
                rowpos++;
                if (rowpos == adherentesDT.Rows.Count - 1)
                {
                    bindingNavigator1.MoveLastItem.Enabled = false;
                    bindingNavigator1.MoveNextItem.Enabled = false;
                }
            }
            else
            {
                bindingNavigator1.MoveLastItem.Enabled = false;
                bindingNavigator1.MoveNextItem.Enabled = false;
            }


            this.BindDatosDT();

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            limpio_botones();

            if (adherentesDT.Rows.Count != 0)
            {
                rowpos = adherentesDT.Rows.Count - 1;
            }
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;

            this.BindDatosDT();
        }
        #endregion

        private void nuevo_Click(object sender, EventArgs e)
        {
            if ((VGlobales.v_soc_fallecido == "5") || (VGlobales.v_soc_fallecido == "8"))
            {
                MessageBox.Show("SOCIO TITULAR FALLECIDO, NO PUEDEN DARSE NUEVAS ALTAS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Crear_fila();
                //BindDatosDT();
            }
        }

        private void Crear_fila()
        {
            int txtBarra = 0;
            int nrowpos = 0;
            isediting = "NO";
            isadding = "SI";
            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;
            cancelar.Enabled = true;
            grabar.Enabled = true;
            editar.Enabled = false;
            nuevo.Enabled = false;
            Ficha.Enabled = false;
            maskedTextBox1.Text = Socios.vp_nro_soc.ToString();
            maskedTextBox2.Text = Socios.vp_nro_dep.ToString();
            limpio_campos();

            if (gpofamiliar==true)
            {
                nrowpos = rowpos;
                maskedTextBox3.Text = adherentesDT.Rows[nrowpos]["NRO_ADH"].ToString().TrimEnd();
                maskedTextBox13.Text = adherentesDT.Rows[nrowpos]["NRO_DEPADH"].ToString().TrimEnd();
                maskedTextBox11.Text = adherentesDT.Rows[nrowpos]["BARRA"].ToString().TrimEnd();
                txtBarra = Convert.ToInt32(maskedTextBox11.Text) + 1;
                maskedTextBox11.Text = txtBarra.ToString();
            }
            else
            {
                maskedTextBox3.Text = "0";

                if (VGlobales.vp_adh_inp == "A")
                {
                    maskedTextBox13.Text = "978";

                    if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                    {
                        maskedTextBox13.Text = "917";
                    }
                }
                else
                {
                    maskedTextBox13.Text = "11";
                }

                maskedTextBox11.Text = "0";
            }
                
            textBox15.Focus();
                    
            // Fecha de Alta Circulo    
            maskedTextbox4.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') +
                                  DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
                                  DateTime.Today.Date.Year.ToString();
            // Fecha de Carnet
            maskedTextbox7.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') +
                                  DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
                                  DateTime.Today.Date.Year.ToString();
            //Gimnasio
            textBox4.Text = "N"; 

            Byte[] byteBLOBData1 = imageToByteArray(SOCIOS.Properties.Resources.fotonodisponible);
            newpos = rowpos;
            Habilitar();
        }

        private void editar_Click(object sender, EventArgs e)
        {
            isediting = "SI";
            isadding = "NO";

            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;

            cancelar.Enabled = true;
            grabar.Enabled = true;
            editar.Enabled = false;
            nuevo.Enabled = false;
            Ficha.Enabled = false;

            Habilitar();

        }

        private void grabar_Click(object sender, EventArgs e)
        {
            if (Consistir_Datos())
            {
                observ = Guardar_ListBox();

                if (isadding == "SI")
                {
                    rowpos = adherentesDT.Rows.Count;

                    try
                    {
                        v_semaforo_baja_adh = false;
                        adherentesDT.Rows.Add(new object[] { maskedTextBox1.Text.Trim(), maskedTextBox2.Text.Trim(), maskedTextBox3.Text.Trim(),
                                                 maskedTextBox11.Text.Trim(), textBox15.Text.Trim(), textBox14.Text.Trim(),
                                                 "0000", "", maskedTextBox9.Text, maskedTextBox10.Text, 
                                                 maskedTextbox14.Text.Trim(), textBox2.Text.Trim(), textBox1.Text.Trim(), textBox6.Text.Trim(),
                                                 textBox7.Text.Trim(), textBox9.Text.Trim(), textBox8.Text.Trim(), "",
                                                 maskedTextBox8.Text.Trim(), textBox10.Text.Trim(), maskedTextBox12.Text.Trim(),
                                                 textBox11.Text.Trim(), maskedTextbox4.Text.Trim(), maskedTextbox5.Text.Trim(), "",
                                                 observ, maskedTextbox7.Text.Trim(), "", maskedTextBox13.Text.Trim(),
                                                 textBox5.Text.Trim(), textBox3.Text.Trim(), imageToByteArray(pictureBox1.Image), textBox4.Text.Trim(), tbEmailContacto.Text.Trim() });
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show(ex.Message.ToString().ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        maskedTextBox3.Focus();
                        return;
                    }
                }
                else
                {
                    try
                    {
                        adherentesDT.Rows[rowpos]["NRO_SOCIO"] = maskedTextBox1.Text.Trim();
                        adherentesDT.Rows[rowpos]["NRO_DEP"] = maskedTextBox2.Text.Trim();
                        adherentesDT.Rows[rowpos]["NRO_ADH"] = maskedTextBox3.Text.Trim();
                        adherentesDT.Rows[rowpos]["BARRA"] = maskedTextBox11.Text.Trim();
                        adherentesDT.Rows[rowpos]["APE_ADH"] = textBox15.Text.Trim();
                        adherentesDT.Rows[rowpos]["NOM_ADH"] = textBox14.Text.Trim();

                        if (comboBox1.SelectedIndex != -1)
                            adherentesDT.Rows[rowpos]["CAT_SOC"] = comboBox1.SelectedValue.ToString();
                        else
                            adherentesDT.Rows[rowpos]["CAT_SOC"] = null;

                        if (comboBox5.SelectedIndex != -1)
                            adherentesDT.Rows[rowpos]["TIP_DOCADH"] = comboBox5.SelectedValue.ToString();
                        else
                            adherentesDT.Rows[rowpos]["TIP_DOCADH"] = null;

                        adherentesDT.Rows[rowpos]["NUM_DOCADH"] = maskedTextBox9.Text.Trim();
                        adherentesDT.Rows[rowpos]["NUM_CEDADH"] = maskedTextBox10.Text.Trim();
                        adherentesDT.Rows[rowpos]["F_NACIMADH"] = maskedTextbox14.Text.Trim();
                        adherentesDT.Rows[rowpos]["CALLE_ADH"] = textBox2.Text.Trim();
                        adherentesDT.Rows[rowpos]["PISO_ADH"] = textBox6.Text.Trim();
                        adherentesDT.Rows[rowpos]["DPTO_ADH"] = textBox7.Text.Trim();
                        adherentesDT.Rows[rowpos]["LOC_ADH"] = textBox8.Text.Trim();
                        adherentesDT.Rows[rowpos]["CODPOS_ADH"] = textBox9.Text.Trim();

                        if (comboBox6.SelectedIndex != -1)
                            adherentesDT.Rows[rowpos]["PCIA_ADH"] = comboBox6.SelectedValue.ToString();
                        else
                            adherentesDT.Rows[rowpos]["PCIA_ADH"] = null;

                        adherentesDT.Rows[rowpos]["NRO_DEPADH"] = maskedTextBox13.Text.Trim();
                        adherentesDT.Rows[rowpos]["F_BAJADH"] = maskedTextbox5.Text.Trim();
                        adherentesDT.Rows[rowpos]["F_ALTADH"] = maskedTextbox4.Text.Trim();
                        adherentesDT.Rows[rowpos]["F_CARADH"] = maskedTextbox7.Text.Trim();
                        adherentesDT.Rows[rowpos]["CAR_TE1ADH"] = maskedTextBox8.Text.Trim();
                        adherentesDT.Rows[rowpos]["NUM_TE1ADH"] = textBox10.Text.Trim();
                        adherentesDT.Rows[rowpos]["CAR_TE2ADH"] = maskedTextBox12.Text.Trim();
                        adherentesDT.Rows[rowpos]["NUM_TE2ADH"] = textBox11.Text.Trim();

                        if (comboBox2.SelectedIndex != -1)
                            adherentesDT.Rows[rowpos]["TIP_CARADH"] = comboBox2.SelectedValue.ToString();
                        else
                            adherentesDT.Rows[rowpos]["TIP_CARADH"] = null;

                        adherentesDT.Rows[rowpos]["NUMERO_ADH"] = textBox1.Text.Trim();
                        adherentesDT.Rows[rowpos]["SEXO"] = textBox3.Text.Trim();

                        if (maskedTextbox5.Text == "")
                            adherentesDT.Rows[rowpos]["COD_DTO"] = textBox5.Text.Trim();
                        else
                            adherentesDT.Rows[rowpos]["COD_DTO"] = "000";

                        if (comboBox3.SelectedIndex != -1)
                            adherentesDT.Rows[rowpos]["M_BAJADH"] = comboBox3.SelectedValue.ToString();
                        else
                            adherentesDT.Rows[rowpos]["M_BAJADH"] = null;

                        adherentesDT.Rows[rowpos]["FOTO"] = imageToByteArray(pictureBox1.Image);
                        adherentesDT.Rows[rowpos]["GIMNASIO"] = textBox4.Text.Trim();
                        adherentesDT.Rows[rowpos]["OBSER_ADH"] = observ;
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show(ex.Message.ToString().ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                Grabar_AdherentesDT();
                VerificarCadeteAdh();
                //VerificarNoSocioAdh();
                limpio_botones();
                cancelar.Enabled = false;
                grabar.Enabled = false;
                Cargo_Datos4();
                Proteger();
            }
            else
            {
                MessageBox.Show("ERROR EN CONSISTIR DATOS");
            }

        }

        private void Grabar_AdherentesDT()
        {
            try
            {
                string vcomando;
                string cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(3)"; // con 3 obtiene numerador de ADHERENTES
                int nro_adherente = 0;
           
                conString conString = new conString();
                string connectionString = conString.get();
                
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();

                    if (isediting == "SI")
                    {
                        vcomando = "P_UPDATEADH";
                    }
                    else
                    {
                        vcomando = "P_INSERTADH";

                        if (!gpofamiliar)
                        {
                            nro_adherente = Obtener_Nro_Adherente(cmd_numerador, connection, transaction);
                            maskedTextBox3.Text = nro_adherente.ToString();
                        }
                    }

                    FbCommand cmd = new FbCommand(vcomando, connection, transaction);
                    cmd.CommandText = vcomando;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@P01", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox3.Text);
                    cmd.Parameters.Add("@P02", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox11.Text);
                    cmd.Parameters.Add("@P03", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox1.Text);
                    cmd.Parameters.Add("@P04", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox2.Text);
                    cmd.Parameters.Add("@P05", FbDbType.Char).Value = textBox15.Text;
                    cmd.Parameters.Add("@P06", FbDbType.Char).Value = textBox14.Text;

                    if (comboBox5.SelectedIndex != -1)
                        cmd.Parameters.Add("@P07", FbDbType.Char).Value = comboBox5.SelectedValue.ToString();
                    else
                        cmd.Parameters.Add("@P07", FbDbType.Char).Value = " ";

                    cmd.Parameters.Add("@P08", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox9.Text);
                    cmd.Parameters.Add("@P09", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox10.Text);

                    if (maskedTextbox14.Text == " " || maskedTextbox14.Text.Length == 0) // fecha Nacim
                        cmd.Parameters.Add("@P10", FbDbType.Char).Value = null;
                    else
                        cmd.Parameters.Add("@P10", FbDbType.Char).Value = maskedTextbox14.Text;

                    cmd.Parameters.Add("@P11", FbDbType.Char).Value = textBox2.Text;
                    cmd.Parameters.Add("@P12", FbDbType.Char).Value = textBox1.Text;
                    cmd.Parameters.Add("@P13", FbDbType.Char).Value = textBox6.Text;
                    cmd.Parameters.Add("@P14", FbDbType.Char).Value = textBox7.Text;

                    if (textBox9.Text.Length != 0)
                        cmd.Parameters.Add("@P15", FbDbType.Integer).Value = Convert.ToInt32(textBox9.Text);
                    else
                        cmd.Parameters.Add("@P15", FbDbType.Integer).Value = null;

                    cmd.Parameters.Add("@P16", FbDbType.Char).Value = textBox8.Text;

                    if (comboBox6.SelectedIndex != -1)
                        cmd.Parameters.Add("@P17", FbDbType.Char).Value = comboBox6.SelectedValue.ToString();
                    else
                        cmd.Parameters.Add("@P17", FbDbType.Char).Value = "  ";

                    cmd.Parameters.Add("@P18", FbDbType.Char).Value = maskedTextBox8.Text;
                    cmd.Parameters.Add("@P19", FbDbType.Char).Value = textBox10.Text;
                    cmd.Parameters.Add("@P20", FbDbType.Char).Value = maskedTextBox12.Text;
                    cmd.Parameters.Add("@P21", FbDbType.Char).Value = textBox11.Text;

                    if (maskedTextbox4.Text == " " || maskedTextbox4.Text.Length == 0) //fecAlta
                        cmd.Parameters.Add("@P22", FbDbType.Char).Value = null;
                    else
                        cmd.Parameters.Add("@P22", FbDbType.Char).Value = maskedTextbox4.Text;

                    if (maskedTextbox5.Text == " " || maskedTextbox5.Text.Length == 0) //fecBaja
                        cmd.Parameters.Add("@P23", FbDbType.Char).Value = null;
                    else
                        cmd.Parameters.Add("@P23", FbDbType.Char).Value = maskedTextbox5.Text;

                    if (comboBox3.SelectedIndex != -1)
                        cmd.Parameters.Add("@P24", FbDbType.Char).Value = comboBox3.SelectedValue.ToString();
                    else
                        cmd.Parameters.Add("@P24", FbDbType.Char).Value = " ";

                    cmd.Parameters.Add("@P25", FbDbType.Char).Value = observ;

                    if (maskedTextbox7.Text == " " || maskedTextbox7.Text.Length == 0) //fecCarnet
                        cmd.Parameters.Add("@P28", FbDbType.Char).Value = null;
                    else
                        cmd.Parameters.Add("@P28", FbDbType.Char).Value = maskedTextbox7.Text;

                    if (comboBox2.SelectedIndex != -1)
                        cmd.Parameters.Add("@P29", FbDbType.Char).Value = comboBox2.SelectedValue.ToString();
                    else
                        cmd.Parameters.Add("@P29", FbDbType.Char).Value = " ";

                    if (maskedTextBox13.Text.Length != 0)
                        cmd.Parameters.Add("@P30", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox13.Text);
                    else
                        cmd.Parameters.Add("@P30", FbDbType.Integer).Value = null;

                    if (maskedTextbox5.Text == " " || maskedTextbox5.Text.Length == 0) //fecBaja
                        cmd.Parameters.Add("@P31", FbDbType.Char).Value = textBox5.Text; //COD_DTO
                    else
                        cmd.Parameters.Add("@P31", FbDbType.Char).Value = "000"; //COD_DTO

                    cmd.Parameters.Add("@P32", FbDbType.Char).Value = textBox3.Text;
                    cmd.Parameters.Add("@PFOTO", FbDbType.Binary).Value = imageToByteArray(pictureBox1.Image);
                    cmd.Parameters.Add("@P34", FbDbType.Char).Value = textBox4.Text;

                    if (tbEmailContacto.Text != "")
                        cmd.Parameters.Add("E_MAIL", FbDbType.Char).Value = tbEmailContacto.Text.Trim();
                    else
                        cmd.Parameters.Add("E_MAIL", FbDbType.Char).Value = null;

                    try
                    {
                        cmd.ExecuteNonQuery();

                        if ((maskedTextbox5.Text.Length > 0) && (v_semaforo_baja_adh))
                        {
                            DialogResult dr = MessageBox.Show("CONFIRMA LA BAJA DE LOS ADHERENTES DEL GRUPO?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            
                            if (dr == DialogResult.Yes)
                            {
                                FbCommand cmd2 = new FbCommand("P_BAJA_ADH_TIT", connection, transaction);
                                cmd2.CommandText = "P_BAJA_ADH_TIT";
                                cmd2.Connection = connection;
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.Add(new FbParameter("@V_ID_ADHERENTE", FbDbType.Integer));
                                cmd2.Parameters.Add(new FbParameter("@VF_BAJCI", FbDbType.Char, 8));
                                int id_titular99 = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;
                                cmd2.Parameters["@V_ID_ADHERENTE"].Value = (Convert.ToInt32(maskedTextBox3.Text) * 100000) + (Convert.ToInt32(maskedTextBox13.Text) * 100);
                                cmd2.Parameters["@VF_BAJCI"].Value = maskedTextbox5.Text;
                                cmd2.ExecuteNonQuery();
                            }
                        }

                        v_semaforo_baja_adh = false;

                        transaction.Commit();

                        MessageBox.Show("OPERACION EFECTUADA EXISTOSAMENTE", vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    }
                    catch (FbException e)
                    {
                        MessageBox.Show(e.ToString());

                        try
                        {
                            transaction.Rollback();
                        }
                        catch (FbException ex)
                        {
                            if (transaction.Connection != null)
                            {
                                MessageBox.Show("ERROR - NO SE PUDO HACER ROLLBACK DE LA TRANSACCION", vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    finally
                    {
                        connection.Dispose();
                        Socios.vp_nro_adh = nro_adherente; //resetea variable, ojo
                        gpofamiliar = true;
                        adherentesDT.Rows[rowpos]["NRO_ADH"] = maskedTextBox3.Text;
                    }
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("ERROR - NO SE PUDO COMPLETAR LA OPERACION");
            }
        }

        private int Obtener_Nro_Adherente(string cmd_num, FbConnection conn, FbTransaction tran)
        {
            FbCommand cmd = new FbCommand(cmd_num, conn, tran);

            cmd.CommandText = cmd_num;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            return (int)cmd.ExecuteScalar();
        }

        private bool Consistir_Datos()
        {
            DateTime fecNac;
            DateTime fecAlta;
            DateTime fecBaja;
            DateTime fecCarnet;
            int fechas;

            // Falta verificar que el DNI o CEDULA no existe en otro socio

            this.txt_VerNull(maskedTextBox3, new EventArgs());
            if (errorProvider1.GetError(maskedTextBox3).Length != 0)
            {
                maskedTextBox3.Focus();
                return false;
            }

            this.txt_VerNull(maskedTextBox13, new EventArgs());
            if (errorProvider1.GetError(maskedTextBox13).Length != 0)
            {
                maskedTextBox13.Focus();
                return false;
            }

            this.txt_VerNull(maskedTextBox11, new EventArgs());
            if (errorProvider1.GetError(maskedTextBox11).Length != 0)
            {
                maskedTextBox11.Focus();
                return false;
            }

            this.txt_VerNull(textBox15, new EventArgs());
            if (errorProvider1.GetError(textBox15).Length != 0)
            {
                textBox15.Focus();
                return false;
            }

            this.txt_VerNull(textBox14, new EventArgs());
            if (errorProvider1.GetError(textBox14).Length != 0)
            {
                textBox14.Focus();
                return false;
            }

            /*
            if (comboBox1.SelectedIndex == -1)
                {
                    errorProvider1.SetError(comboBox1, "DEBE SELECCIONAR UNA CATEGORIA");
                    comboBox1.Focus();
                    return false;
                }
            */

            // Validacion de Tipo y Nro. Documento
            if ((comboBox5.SelectedIndex == -1) && maskedTextBox9.Text.Length > 1)
            {
                errorProvider1.SetError(comboBox5, "SI INFORMA DOCUMENTO DEBE INFORMAR TIPO");
                comboBox5.Focus();
                return false;
            }
            else
                if ((comboBox5.SelectedIndex != -1) && maskedTextBox9.Text.Length == 0)
                {
                    errorProvider1.SetError(maskedTextBox9, "SI INFORMA TIPO DEBE INFORMAR DOCUMENTO");
                    maskedTextBox9.Focus();
                    return false;
                }
                else
                {
                    if (maskedTextBox9.Text == " " || Convert.ToInt32(maskedTextBox9.Text) == 0 || maskedTextBox9.Text.Length == 0) // num doc 
                        maskedTextBox9.Text = "0";
                    //else
                    //    if (BUSCAR_DOCUMENTO("D", maskedTextBox9.Text))
                    //    {
                    //        errorProvider1.SetError(maskedTextBox9, "DOCUMENTO YA INFORMADO EN OTRO TITULAR/FAMILIAR/ADHERENTE");
                    //        maskedTextBox9.Focus();
                    //        return false;
                    //    }
                }



            if (maskedTextBox10.Text == " " || Convert.ToInt32(maskedTextBox10.Text) == 0 || maskedTextBox10.Text.Length == 0) // num ced 
                maskedTextBox10.Text = "0";
            //else
            //    if (BUSCAR_DOCUMENTO("C", maskedTextBox10.Text))
            //    {
            //        errorProvider1.SetError(maskedTextBox10, "CEDULA YA INFORMADA EN OTRO TITULAR/FAMILIAR/ADHERENTE");
            //        maskedTextBox10.Focus();
            //        return false;
            //    }


            //validación de fecha y tipo de carnet
            if ((comboBox2.SelectedIndex == -1) && (maskedTextbox7.Text.Length > 0))
            {
                errorProvider1.SetError(comboBox2, "SI INFORMA FECHA DE CARNET DEBE INFORMAR TIPO");
                comboBox2.Focus();
                return false;
            }
            else
                if ((comboBox2.SelectedIndex != -1) && (maskedTextbox7.Text.Length == 0))
                {
                    errorProvider1.SetError(maskedTextbox7, "SI INFORMA TIPO DEBE INFORMAR FECHA DE CARNET");
                    maskedTextbox7.Focus();
                    return false;
                }


            //validación de fecha y tipo de Baja Circulo
            /*int MTB5 = maskedTextbox5.Text.Length;
            int COB3 = comboBox3.SelectedIndex;

            if ((MTB5 > 0) && (COB3 == -1))
            {
                errorProvider1.SetError(comboBox3, "SI INFORMA FECHA DE BAJA DEBE INFORMAR TIPO");
                comboBox3.Focus();
                return false;
            }
            else if ((COB3 == 0) && (MTB5 == 0))
            {
                errorProvider1.SetError(maskedTextbox5, "SI INFORMA TIPO DEBE INFORMAR FECHA DE BAJA");
                maskedTextbox5.Focus();
                return false;
            }*/

            if (maskedTextbox14.Text.Length > 0)
            {
                fecNac = ObtenerFecha(maskedTextbox14.Text);
                if (fecNac.Date.Year == 1900 &&
                    fecNac.Date.Month == 01 &&
                    fecNac.Date.Day == 01)
                {
                    errorProvider1.SetError(maskedTextbox14, "FECHA DE NACIMIENTO INVALIDA - CORRIJA");
                    maskedTextbox14.Focus();
                    return false;
                }
            }
            else
                fecNac = ObtenerFecha("01011900");



            if (maskedTextbox4.Text.Length > 0)
            {
                fecAlta = ObtenerFecha(maskedTextbox4.Text);
                if (fecAlta.Date.Year == 1900 &&
                    fecAlta.Date.Month == 01 &&
                    fecAlta.Date.Day == 01)
                {
                    errorProvider1.SetError(maskedTextbox4, "FECHA DE ALTA INVALIDA - CORRIJA");
                    maskedTextbox4.Focus();
                    return false;
                }
            }
            else
                fecAlta = ObtenerFecha("01011900");


            if (maskedTextbox5.Text.Length > 0)
            {
                fecBaja = ObtenerFecha(maskedTextbox5.Text);
                if (fecBaja.Date.Year == 1900 &&
                    fecBaja.Date.Month == 01 &&
                    fecBaja.Date.Day == 01)
                {
                    errorProvider1.SetError(maskedTextbox5, "FECHA DE BAJA INVALIDA - CORRIJA");
                    maskedTextbox5.Focus();
                    return false;
                }
            }
            else
                fecBaja = ObtenerFecha("01011900");


            if (maskedTextbox7.Text.Length > 0)
            {
                fecCarnet = ObtenerFecha(maskedTextbox7.Text);
                if (fecCarnet.Date.Year == 1900 &&
                    fecCarnet.Date.Month == 01 &&
                    fecCarnet.Date.Day == 01)
                {
                    errorProvider1.SetError(maskedTextbox7, "FECHA DE CARNET INVALIDA - CORRIJA");
                    maskedTextbox7.Focus();
                    return false;
                }
            }
            else
                fecCarnet = ObtenerFecha("01011900");

            //familiaresDT.Rows[rowpos]["FOTO"] = imageToByteArray(pictureBox1.Image);

            // Control de Fechas
            //
            // Verificar que ninguna fecha es superior a HOY

            
            /*  MODIFICADO A PEDIDO DE SUSANA AL 28-12-2009
            fechas = DateTime.Compare(fecAlta, DateTime.Today);

            if (fechas == 1) //feclta > HOY
            {
                errorProvider1.SetError(maskedTextbox4, "FECHA DE ALTA NO PUEDE SER MAYOR A HOY");
                maskedTextbox4.Focus();
                return false;
            }
            */
           
            fechas = DateTime.Compare(fecCarnet, DateTime.Today);
            if (fechas == 1) //fecCarnet > HOY
            {
                errorProvider1.SetError(maskedTextbox7, "FECHA DE CARNET NO PUEDE SER MAYOR A HOY");
                maskedTextbox7.Focus();
                return false;
            }
            

            /*  MODIFICADO EL 28-12-2009
            fechas = DateTime.Compare(fecBaja, DateTime.Today);
            if (fechas == 1) //fecBaja > Hoy
            {
                errorProvider1.SetError(maskedTextbox5, "FECHA DE BAJA NO PUEDE SER MAYOR A HOY");
                maskedTextbox5.Focus();
                return false;
            }
            */

            // Control entre fechas
            //
            fechas = DateTime.Compare(fecNac, fecAlta);

            if ((fechas == 1) &&
                !(fecAlta.Date.Year == 1900 &&
                  fecAlta.Date.Month == 01 &&
                  fecAlta.Date.Day == 01)) //fecNac > fecAlta (Alta esta como 1900-01-01 cuando esta vacia)
            {
                errorProvider1.SetError(maskedTextbox4, "FECHA DE ALTA NO PUEDE SER ANTERIOR A FECHA NACIMIENTO");
                maskedTextbox4.Focus();
                return false;
            }

            fechas = DateTime.Compare(fecNac, fecBaja);

            if ((fechas == 1) &&
                !(fecBaja.Date.Year == 1900 &&
                  fecBaja.Date.Month == 01 &&
                  fecBaja.Date.Day == 01)) //fecNac > fecBaja
            {
                errorProvider1.SetError(maskedTextbox5, "FECHA DE BAJA NO PUEDE SER ANTERIOR A FECHA NACIMIENTO");
                maskedTextbox5.Focus();
                return false;
            }


            fechas = DateTime.Compare(fecNac, fecCarnet);

            if ((fechas == 1) &&
                !(fecCarnet.Date.Year == 1900 &&
                  fecCarnet.Date.Month == 01 &&
                  fecCarnet.Date.Day == 01)) //fecNac > fecCarnet
            {
                errorProvider1.SetError(maskedTextbox7, "FECHA DE CARNET NO PUEDE SER ANTERIOR A FECHA NACIMIENTO");
                maskedTextbox7.Focus();
                return false;
            }


            /*  MODIFICADO EL 28-12-2009
            fechas = DateTime.Compare(fecAlta, fecCarnet);

            if ((fechas == 1) &&
                !(fecCarnet.Date.Year == 1900 &&
                  fecCarnet.Date.Month == 01 &&
                  fecCarnet.Date.Day == 01)) //fecAlta > fecCarnet
            {
                errorProvider1.SetError(maskedTextbox7, "FECHA DE CARNET NO PUEDE SER ANTERIOR A FECHA ALTA");
                maskedTextbox7.Focus();
                return false;
            }
            */

            fechas = DateTime.Compare(fecAlta, fecBaja);
            if ((fechas == 1) &&
                !(fecBaja.Date.Year == 1900 &&
                  fecBaja.Date.Month == 01 &&
                  fecBaja.Date.Day == 01)) //fecAlta > fecBaja
            {
                errorProvider1.SetError(maskedTextbox5, "FECHA DE BAJA NO PUEDE SER ANTERIOR A FECHA ALTA");
                maskedTextbox5.Focus();
                return false;
            }


            fechas = DateTime.Compare(fecCarnet, fecBaja);
            if ((fechas == 1) &&
                !(fecBaja.Date.Year == 1900 &&
                  fecBaja.Date.Month == 01 &&
                  fecBaja.Date.Day == 01)) //fecCarnet > fecBaja
            {
                errorProvider1.SetError(maskedTextbox5, "FECHA DE BAJA NO PUEDE SER ANTERIOR A FECHA DE CARNET");
                maskedTextbox5.Focus();
                return false;
            }


            this.textBox4_TextChanged(textBox4, new EventArgs());
            if (errorProvider1.GetError(textBox4).Length != 0)
            {
                textBox4.Focus();
                return false;
            }


            this.textBox3_TextChanged(textBox3, new EventArgs());
            if (errorProvider1.GetError(textBox3).Length != 0)
            {
                textBox3.Focus();
                return false;
            }

            return true;
        }

        private bool BUSCAR_DOCUMENTO(string tipo, string documento)
        {
            try
            {
                string vcomando;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    vcomando = "P_BUSCAR_DOCUMENTO";

                    FbCommand cmd = new FbCommand(vcomando, connection, transaction);

                    cmd.CommandText = vcomando;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@P01", FbDbType.Char).Value = tipo;
                    cmd.Parameters.Add("@P02", FbDbType.Integer).Value = Convert.ToInt32(documento);

                    FbDataReader doc = cmd.ExecuteReader();


                    if (doc.Read())
                        return true;
                    else
                        return false;

                    transaction.Commit();
                    connection.Dispose();
                }
            }
            catch (FbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                Mails1 mensaje = new Mails1();
                mensaje.Enviar_Mail_Error(ex.ToString());

                return true;
            }
        }

        private DateTime ObtenerFecha(string fecha)
        {
            DateTime d;

            if (IsValidDate(fecha))
            {
                d = new DateTime(Convert.ToInt32(fecha.Substring(4, 4)),
                                 Convert.ToInt32(fecha.Substring(2, 2)),
                                 Convert.ToInt32(fecha.Substring(0, 2)));
            }
            else
            {
                d = new DateTime(1900, 01, 01);

            }

            return d;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("CONFIRMA CANCELAR LA EDICION?", "ATENCION",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                limpio_botones();
                //editar.Enabled = true;
                //nuevo.Enabled = true;
                errorProvider1.Clear();

                Proteger();

                if (isadding == "SI")
                {
                    rowpos = newpos;
                }

                if (Socios.vp_nro_adh < 0)
                {
                    VGlobales.vp_ntp = true;
                    this.Close();
                    VGlobales.vp_ntp = false;
                    
                }
                else
                {
                    BindDatosDT();
                }

                isediting = "NO";
                isadding = "NO";

            }
        }

        private void TXT_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Focus();
            ((TextBox)sender).SelectAll();
        }

        private void MSK_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).Focus();
            ((MaskedTextBox)sender).SelectAll();
        }

        private void CMB_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).Focus();
            ((ComboBox)sender).SelectAll();
        }

        private void TXT_paso(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
                SendKeys.Send("{TAB}");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            lleno_combo_adh();
            limpio_botones();
            Socios.Ver_Privilegios("ADHERENT");
            Habilitar_Botones();
          
            if (Socios.vp_nro_adh < 0)
            {
                rowpos = 0;
                gpofamiliar = false;
                            
                if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
                {
                    VGlobales.vp_ntp = true;
                    this.Close();
                    VGlobales.vp_ntp = false;
                }
            }
            else
            {
                rowpos = Socios.vp_nro_adh;
                gpofamiliar = true;
            }
            
            Cargo_Datos4();
        }

        private void lleno_combo_adh()
        {
            //Cambia el valor para INv.PArticipa o Adherentes comunes

            BindDatosDT();

            if (VGlobales.vp_adh_inp == "A")
                Socios.dsllc.Tables["BADH"].Rows[0]["descrip"] = "ADHERENTE TITULAR";
            else
            {
                Socios.dsllc.Tables["BADH"].Rows[0]["descrip"] = "INV.PARTICIPATIVO TITULAR";
            }
            
        }

        private void BuscarAdh()
        {
            string isbarra = string.Empty;
            int drrow = 0;

            maskedTextBox3.Text = buscar.vcampo.Substring(2, 5).TrimStart('0'); // nro_adh
            maskedTextBox13.Text = buscar.vcampo.Substring(7, 3); //nro_depadh
            if (maskedTextBox13.Text == "000")
                maskedTextBox13.Text = "0";
            else
                maskedTextBox13.Text = maskedTextBox13.Text.TrimStart('0');

            Existe_Barra(Socios.vp_nro_adh.ToString(), ref isbarra, ref drrow);

            if (isbarra != string.Empty)
            {
                rowpos = drrow;   // Lo encontró
            }
        }

        private void Habilitar_Botones()
        {
            if (VGlobales.vp_boton_modi == "U")
                editar.Enabled = true;
            else
                editar.Enabled = false;

            if (VGlobales.vp_boton_alta == "I")
                nuevo.Enabled = true;
            else
                nuevo.Enabled = false;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (VGlobales.vp_ntp == false)
            {
                DialogResult dr = MessageBox.Show("CONFIRMA CERRAR ESTA PANTALLA?", "ATENCION",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Yes)
                {
                    if (cancelar.Enabled == true)
                    {
                        MessageBox.Show("DEBE CONFIRMAR O CANCELAR LOS CAMBIOS, RECUERDE QUE ESTA EDITANDO",
                               "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }*/
        }

        private void Cargo_Datos4()
        {
            // separar si es adherente o invitado participativo
            string vcondicion; 
            int id_titular = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;

            if (VGlobales.vp_adh_inp == "I")
            {
                vcondicion = "= 11";
            }
            else
            {
                vcondicion = "<> 11";
            }
            
            string vcmd = "SELECT NRO_SOCIO, NRO_DEP, A.NRO_ADH, A.BARRA, ";
            vcmd = vcmd + "APE_ADH, NOM_ADH, ";
            vcmd = vcmd + "case when A.BARRA > 1 then '0002' else cast(A.BARRA as char)  END AS CAT_SOC, ";
            vcmd = vcmd + "case when TIP_DOCADH  is null then 'Z'        else TIP_DOCADH end as TIP_DOCADH, ";
            vcmd = vcmd + "case when NUM_DOCADH  is null then '0'        else NUM_DOCADH end as NUM_DOCADH, ";
            vcmd = vcmd + "case when NUM_CEDADH  is null then '0'        else NUM_CEDADH end as NUM_CEDADH, ";
            vcmd = vcmd + "case when F_NACIMADH  is null then '        ' else (LPAD(EXTRACT(day FROM F_NACIMADH),2,'0')|| LPAD(EXTRACT(month FROM F_NACIMADH),2,'0')|| EXTRACT(year FROM F_NACIMADH)) end AS F_NACIMADH, ";
            vcmd = vcmd + "case when CALLE_ADH  is null then ' '         else CALLE_ADH end as CALLE_ADH, ";
            vcmd = vcmd + "case when NUMERO_ADH  is null then '      '   else NUMERO_ADH end as NUMERO_ADH, ";
            vcmd = vcmd + "case when PISO_ADH  is null then '  '         else PISO_ADH end as PISO_ADH, ";
            vcmd = vcmd + "case when DPTO_ADH  is null then '  '         else DPTO_ADH end as DPTO_ADH, ";
            vcmd = vcmd + "case when CODPOS_ADH  is null then '0'        else CODPOS_ADH end as CODPOS_ADH, ";
            vcmd = vcmd + "case when LOC_ADH  is null then  '  '         else LOC_ADH end as LOC_ADH, ";
            vcmd = vcmd + "case when PCIA_ADH  is null then  '  '        else PCIA_ADH end as PCIA_ADH, ";
            vcmd = vcmd + "case when CAR_TE1ADH  is null then  '  '      else CAR_TE1ADH end as CAR_TE1ADH, ";
            vcmd = vcmd + "case when NUM_TE1ADH  is null then   '  '     else NUM_TE1ADH end as NUM_TE1ADH, ";
            vcmd = vcmd + "case when CAR_TE2ADH  is null then   '  '     else CAR_TE2ADH end as CAR_TE2ADH, ";
            vcmd = vcmd + "case when NUM_TE2ADH  is null then   '  '     else NUM_TE2ADH end as NUM_TE2ADH, ";
            vcmd = vcmd + "case when F_ALTADH  is null then '        '   else (LPAD(EXTRACT(day FROM F_ALTADH),2,'0')|| LPAD(EXTRACT(month FROM F_ALTADH),2,'0')|| EXTRACT(year FROM F_ALTADH)) end AS F_ALTADH, ";
            vcmd = vcmd + "case when F_BAJADH  is null then '        '   else (LPAD(EXTRACT(day FROM F_BAJADH),2,'0')|| LPAD(EXTRACT(month FROM F_BAJADH),2,'0')|| EXTRACT(year FROM F_BAJADH)) end AS F_BAJADH, ";
            vcmd = vcmd + "case when M_BAJADH  is null then  '  '        else M_BAJADH end as M_BAJADH, ";
            vcmd = vcmd + "case when OBSER_ADH  is null then  '  '       else OBSER_ADH end as OBSER_ADH, ";
            //vcmd = vcmd + "case when FUM_ADH  is null then '        '    else (LPAD(EXTRACT(day FROM FUM_ADH),2,'0')|| LPAD(EXTRACT(month FROM FUM_ADH),2,'0')|| EXTRACT(year FROM FUM_ADH)) end AS FUM_ADH, ";                     
            //vcmd = vcmd + "case when EMPLEADO is null then '  '          else EMPLEADO end as EMPLEADO, ";
            vcmd = vcmd + "case when F_CARADH  is null then  '        '  else (LPAD(EXTRACT(day FROM F_CARADH),2,'0')|| LPAD(EXTRACT(month FROM F_CARADH),2,'0')|| EXTRACT(year FROM F_CARADH)) end AS F_CARADH, ";
            vcmd = vcmd + "case when TIP_CARADH  is null then   '  '     else TIP_CARADH end as TIP_CARADH, ";
            vcmd = vcmd + "case when A.NRO_DEPADH  is null then  '0'       else A.NRO_DEPADH end as NRO_DEPADH, ";
            vcmd = vcmd + "case when COD_DTO  is null then     '  '      else COD_DTO end as COD_DTO, ";
            vcmd = vcmd + "case when SEXO  is null then ' '              else SEXO end as SEXO, ";
            vcmd = vcmd + "FOTO, ";
            vcmd = vcmd + "case when GIMNASIO is null then ' '           else GIMNASIO end as GIMNASIO, ";
            vcmd = vcmd + "E_MAIL ";
            vcmd = vcmd + "FROM ADHERENT A, ADHERENT_IMAGEN B WHERE A.ID_TITULAR = " + id_titular.ToString() + " AND B.ID_TITULAR = " + id_titular.ToString();
            vcmd = vcmd + " and  A.ID_ADHERENTE = B.ID_ADHERENTE ";
            vcmd = vcmd + "and  A.NRO_DEPADH " + vcondicion + " ORDER BY A.ID_TITULAR, A.ID_ADHERENTE ASC";
            
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(vcmd, connection, transaction);
                    FbDataReader mt = cmd.ExecuteReader();
                    adherentesDT.Load(mt);
                }

                cancelar.Enabled = false;
                grabar.Enabled = false;
                Ficha.Enabled = true;
                this.BindDatosDT();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void BindDatosDT()
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.DataSource = Socios.dsllc.Tables["BADH"];
            comboBox1.DisplayMember = "descrip";
            comboBox1.ValueMember = "codigo";

            comboBox5.SelectedIndex = -1;
            comboBox5.DataSource = Socios.dsllc.Tables["TD"];
            comboBox5.DisplayMember = "descrip";
            comboBox5.ValueMember = "codigo";

            comboBox6.SelectedIndex = -1;
            comboBox6.DataSource = Socios.dsllc.Tables["PR"];
            comboBox6.DisplayMember = "descrip";
            comboBox6.ValueMember = "codigo";

            comboBox2.SelectedIndex = -1;
            comboBox2.DataSource = Socios.dsllc.Tables["TF"];
            comboBox2.DisplayMember = "descrip";
            comboBox2.ValueMember = "codigo";

            comboBox3.SelectedIndex = -1;
            comboBox3.DataSource = Socios.dsllc.Tables["BH"];
            comboBox3.DisplayMember = "descrip";
            comboBox3.ValueMember = "codigo";


            if (adherentesDT.Rows.Count == 0 || Socios.vp_nro_adh < 0)
            {
                Crear_fila();
            }

            else
            {
                if (VGlobales.vp_cod_bar == "A")  //viene por codigo de barra
                {
                    BuscarAdh();
                    VGlobales.vp_cod_bar = string.Empty;
                }
               
                maskedTextBox1.Text = adherentesDT.Rows[rowpos]["NRO_SOCIO"].ToString().TrimEnd();
                maskedTextBox2.Text = adherentesDT.Rows[rowpos]["NRO_DEP"].ToString().TrimEnd();
                maskedTextBox3.Text = adherentesDT.Rows[rowpos]["NRO_ADH"].ToString().TrimEnd();
                maskedTextBox11.Text = adherentesDT.Rows[rowpos]["BARRA"].ToString().TrimEnd();
                textBox15.Text = adherentesDT.Rows[rowpos]["APE_ADH"].ToString().TrimEnd();
                textBox14.Text = adherentesDT.Rows[rowpos]["NOM_ADH"].ToString().TrimEnd();

                comboBox1.SelectedValue = adherentesDT.Rows[rowpos]["CAT_SOC"].ToString().Trim().PadLeft(4, '0');

                comboBox5.SelectedValue = adherentesDT.Rows[rowpos]["TIP_DOCADH"].ToString();

                maskedTextBox9.Text = adherentesDT.Rows[rowpos]["NUM_DOCADH"].ToString().TrimEnd();
                maskedTextBox10.Text = adherentesDT.Rows[rowpos]["NUM_CEDADH"].ToString().TrimEnd();
                maskedTextbox14.Text = adherentesDT.Rows[rowpos]["F_NACIMADH"].ToString().TrimEnd();

                textBox2.Text = adherentesDT.Rows[rowpos]["CALLE_ADH"].ToString().TrimEnd();
                textBox6.Text = adherentesDT.Rows[rowpos]["PISO_ADH"].ToString().TrimEnd();
                textBox7.Text = adherentesDT.Rows[rowpos]["DPTO_ADH"].ToString().TrimEnd();
                textBox8.Text = adherentesDT.Rows[rowpos]["LOC_ADH"].ToString().TrimEnd();
                textBox9.Text = adherentesDT.Rows[rowpos]["CODPOS_ADH"].ToString().TrimEnd();

                comboBox6.SelectedValue = adherentesDT.Rows[rowpos]["PCIA_ADH"].ToString();

                maskedTextBox13.Text = adherentesDT.Rows[rowpos]["NRO_DEPADH"].ToString().TrimEnd();
                maskedTextbox5.Text = adherentesDT.Rows[rowpos]["F_BAJADH"].ToString().TrimEnd();
                if (maskedTextbox5.Text == " " || maskedTextbox5.Text.Length == 0) //fecBaja
                {
                    v_semaforo_baja_adh = true;
                }
                else
                {
                    v_semaforo_baja_adh = false;
                }
                maskedTextbox4.Text = adherentesDT.Rows[rowpos]["F_ALTADH"].ToString().TrimEnd();
                maskedTextbox7.Text = adherentesDT.Rows[rowpos]["F_CARADH"].ToString().TrimEnd();
                maskedTextBox8.Text = adherentesDT.Rows[rowpos]["CAR_TE1ADH"].ToString().TrimEnd();
                textBox10.Text = adherentesDT.Rows[rowpos]["NUM_TE1ADH"].ToString().TrimEnd();
                maskedTextBox12.Text = adherentesDT.Rows[rowpos]["CAR_TE2ADH"].ToString().TrimEnd();
                textBox11.Text = adherentesDT.Rows[rowpos]["NUM_TE2ADH"].ToString().TrimEnd();

                comboBox2.SelectedValue = adherentesDT.Rows[rowpos]["TIP_CARADH"].ToString();

                textBox1.Text = adherentesDT.Rows[rowpos]["NUMERO_ADH"].ToString().TrimEnd();
                textBox3.Text = adherentesDT.Rows[rowpos]["SEXO"].ToString().TrimEnd();
                textBox5.Text = adherentesDT.Rows[rowpos]["COD_DTO"].ToString().TrimEnd();
               
                //si el barra 0 no cumple con esto 
                if (Convert.ToInt32(maskedTextBox11.Text) == 0) //barra 0
                {
                  if (textBox5.Text != "641" && textBox5.Text != "643" &&
                      textBox5.Text != "A/S" && textBox5.Text != "S/C")                      
                  {
                     VGlobales.vp_esSocioAdh = false;
                  }
                  else
                  {
                    VGlobales.vp_esSocioAdh = true;
                  }
                }

                comboBox3.SelectedValue = adherentesDT.Rows[rowpos]["M_BAJADH"].ToString();

                if (!adherentesDT.Rows[rowpos].IsNull("FOTO"))
                {
                    byte[] img = (byte[])adherentesDT.Rows[rowpos]["FOTO"];
                    pictureBox1.Image = byteArrayToImage(img);
                }
                else
                { pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible; }

                textBox4.Text = adherentesDT.Rows[rowpos]["GIMNASIO"].ToString().TrimEnd();
                tbEmailContacto.Text = adherentesDT.Rows[rowpos]["E_MAIL"].ToString().TrimEnd();

                itemsobs = Mostrar_ListBox();

                VerificarCadeteAdh();
            }
        }

        private void VerificarCadeteAdh()
        {
            DateTime vfecha;

            vfecha = ObtenerFecha(maskedTextbox14.Text);

            if (Convert.ToInt32(maskedTextBox3.Text) > 1 && Convert.ToInt32(maskedTextBox11.Text) > 1)
            {
                if (DateTime.Compare(DateTime.Today, vfecha.AddYears(18)) < 0)
                {
                    label31.Text = "";
                    label31.BorderStyle = BorderStyle.None;
                    label31.BackColor = Color.Transparent;
                }
                else
                {
                    label31.BorderStyle = BorderStyle.FixedSingle;
                    label31.BackColor = Color.Crimson;
                    if (VGlobales.vp_adh_inp == "I")
                    {
                        label31.Text = " INV.PARTICIPATIVO  MAYOR DE 18 AÑOS  ó  FEC.NACIMIENTO NO INFORMADA  ";
                    }
                    else
                    {
                        label31.Text = " ADHERENTE MAYOR DE 18 AÑOS  ó  FEC.NACIMIENTO NO INFORMADA  ";

                    }
                }
            }
            else
            {
                label31.Text = "";
                label31.BorderStyle = BorderStyle.None;
                label31.BackColor = Color.Transparent;
            }
        }

        private int Mostrar_ListBox()
        {
            listBox1.Items.Clear();
            string observaciones = adherentesDT.Rows[rowpos]["OBSER_ADH"].ToString();
            int longitud = (observaciones.TrimEnd()).Length;
            lngObserv = longitud;
            int inicio = 0;
            while (longitud > 0)
            {
                if (longitud < 60)
                    listBox1.Items.Add(observaciones.Substring(inicio, longitud));
                else
                    listBox1.Items.Add(observaciones.Substring(inicio, 60));

                inicio = inicio + 60;
                longitud = longitud - 60;
            }
            label15.Text = lngObserv.ToString();
            return listBox1.Items.Count;
        }

        private string Guardar_ListBox()
        {
            string observaciones = "";
            for (int i = 0; i <= listBox1.Items.Count - 1; i++)
            {
                observaciones += listBox1.Items[i].ToString().TrimEnd() + " ";

            }

            return observaciones;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Familiares.fotoZoom = resizeImage(pictureBox1.Image, 249, 216);

            using (FotoZoom frmFOTO = new FotoZoom())
            {
                frmFOTO.ShowDialog(this);
            }
        }

        private void ADQUIRIR_Click_1(object sender, EventArgs e)
        {

            string nombreFoto = "A-" + maskedTextBox3.Text.Trim().PadLeft(5, '0');
            string sfilename = "";
            string spath = "";
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "JPEG|*.jpg|GIF|*.gif";
            opn.ShowDialog();

            if (opn.FileName.Length > 0)
            {
                sfilename = System.IO.Path.GetFileName(opn.FileName);
                spath = System.IO.Path.GetDirectoryName(opn.FileName);


                if (sfilename.Substring(0, 7) == nombreFoto && sfilename.Substring(7, 1) == "-"
                    && sfilename.Substring(8, 1) == maskedTextBox11.Text.Trim())
                {
                    Bitmap IMG = new Bitmap(opn.FileName);
                    pictureBox1.Image = IMG;
                }
                else
                {
                    if (sfilename.Substring(0, 7) == nombreFoto && sfilename.Substring(7, 1) == "-"
                       && sfilename.Substring(8, 2) == maskedTextBox11.Text.Trim().PadLeft(2, '0'))
                    {
                        Bitmap IMG = new Bitmap(opn.FileName);
                        pictureBox1.Image = IMG;
                    }
                    else
                    {
                        MessageBox.Show("LA FOTO SELECCIONADA NO CORRESPENDE AL ADHERENTE", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ADQUIRIR_Click_1(ADQUIRIR, new EventArgs());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textbox12.Text != "")
            {
                if ((lngObserv + textbox12.Text.Length) < 120)  // POR AHORA EL MAXIMO ES 120 = 60 * 2
                {
                    listBox1.Items.Insert(lbxrow, textbox12.Text);
                    lngObserv += textbox12.Text.Length;
                    textbox12.Clear();
                    textbox12.Focus();
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    label15.Text = lngObserv.ToString();
                    lbxrow += 1;
                }
                else
                {
                    MessageBox.Show("SUPERA MÁXIMO DE OBSERVACIONES A AGREGAR");
                    textbox12.Clear();
                }
            }
            else
                MessageBox.Show("DEBE INGRESAR OBSERVACIONES ANTES DE AGREGAR");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
               // if (listBox1.SelectedIndex > (itemsobs - 1))  // pedido por susana 07-01-10
                {
                    lbxrow = listBox1.SelectedIndex;
                    textbox12.Text = listBox1.SelectedItem.ToString();

                    lngObserv -= listBox1.SelectedItem.ToString().Length;
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    label15.Text = lngObserv.ToString();
                }

               // else
                 //   MessageBox.Show("NO PUEDE BORRAR OBSERVACIONES ANTERIORES");
            else
                MessageBox.Show("SELECCIONE LA LINEA QUE DESEA BORRAR");
        }

        // conversiones de BLOB a IMG y viceversa
        // De image a byte []:
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        // De byte [] a image:
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private static Image resizeImage(Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }


        private static Image resizeImage2(Image imgToResize)
        {
            Bitmap b = new Bitmap(imgToResize);
            using (Graphics gr = Graphics.FromImage((Image)b))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gr.DrawImage(imgToResize, new Rectangle(0, 0, imgToResize.Width, imgToResize.Height));
            }
            return (Image)b;
        }


        private void textbox12_TextChanged(object sender, EventArgs e)
        {
            label30.Text = textbox12.Text.Length.ToString();
        }

        private void msk_Fecha(object sender, EventArgs e)
        {
            string input = "1900-01-01";

            if (isadding == "SI" || isediting == "SI")
            {
                Control ctrl = (Control)sender;


                if (ctrl.Text.Length != 0)
                {
                    if (IsValidDate(ctrl.Text))
                    {
                        DateTime dateTime;
                        input = ctrl.Text.Substring(4, 4) + "-" +  // paso la fecha a formato yyyy-mm-dd 
                                 ctrl.Text.Substring(2, 2) + "-" +  // para validar 
                                 ctrl.Text.Substring(0, 2);


                        if (DateTime.TryParse(input, out dateTime))
                        {
                            errorProvider1.SetError(ctrl, "");

                        }
                        else
                        {
                            errorProvider1.SetError(ctrl, "FECHA INVALIDA - CORRIJA");
                            ctrl.Focus();

                        }
                    }
                    else
                    {
                        errorProvider1.SetError(ctrl, "FECHA INVALIDA - CORRIJA");
                        ctrl.Focus();

                    }
                }
                else
                {
                    errorProvider1.SetError(ctrl, "");
                    this.msk_TextChanged(ctrl, new EventArgs());   
                }

            }

            return;
        }

        //Checks for format of date (dd/mm/yyyyy)
        //separators = /-.
        //format = xx/xx/xxxx or xx/xx/xx
        //Month and day must be within correct calendar range
        //Year can be anything either 2 or 4 digits
        private static bool IsValidDate(string dt)
        {
            // estas expresiones controlan la barra o guion 
            //^([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])[- /.][0-9]{4}$
            //^(0[1-9]|1[0-2])[./-](0[1-9]|1[0-9]|2[0-9]|3[0-1])[./-](\\d{2}|\\d{4})$;

            return (Regex.IsMatch(dt, "^(0[1-9]|1[0-9]|2[0-9]|3[0-1])" +
                                      "(0[1-9]|1[0-2])" +
                                      "((19|20)\\d{2})$"));
                                      //"(\\d{4})$"));
        }


        private void txt_VerNull(object sender, EventArgs e)
        {
            if (isadding == "SI" || isediting == "SI")
            {
                Control ctrl = (Control)sender;
                if (ctrl.Text.Length == 0 || ctrl.Text == " ")
                {
                    errorProvider1.SetError(ctrl, "DATO OBLIGATORIO - DEBE INFORMAR CAMPO ");
                    ctrl.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(ctrl, "");

                    if (ctrl.Name == "maskedTextBox11")  // valido existencia
                    {
                        //if ()
                        {
                            this.msk_TextChanged(ctrl, new EventArgs());
                            errorProvider1.SetError(ctrl, Ver_Barra(ctrl.Text));
                            if (errorProvider1.GetError(maskedTextBox11).Length != 0)
                            {
                                maskedTextBox11.Focus();
                                return;
                            }

                        }

                    }
                    else
                        // aca agregar control para invitados participativos
                        if (ctrl.Name == "maskedTextBox13")  // valido que sea 978 0 005 o 011
                        {
                                                    
                                if (VGlobales.vp_adh_inp == "I")
                                {
                                    if (ctrl.Text != "11")
                                    {
                                        errorProvider1.SetError(ctrl, "DEPURACION DEBE SER '11'");
                                        ctrl.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (ctrl.Text != "978" && ctrl.Text != "5" && ctrl.Text != "917")
                                     {
                                       errorProvider1.SetError(ctrl, "DEPURACION DEBE SER '978' 0 '5' 0 '917'");
                                       ctrl.Focus();
                                       return;
                                     }
                                }
                                
                        }

                        
                }
            }
        }

        private void msk_TextChanged(object sender, EventArgs e)
        {
            // Blanquea el error apenas se selecciona algo 
            Control ctrl = (Control)sender;
            errorProvider1.SetError(ctrl, "");
            int sv;

            switch (ctrl.Name)
            {
                case "maskedTextbox7":   // F. carnet
                    {
                        errorProvider1.SetError(comboBox2, "");
                        if (ctrl.Text.Length == 0 || ctrl.Text == string.Empty || ctrl.Text == "      ")
                        {
                            comboBox2.SelectedIndex = -1;
                            comboBox2.Enabled = false;
                        }
                        else
                            comboBox2.Enabled = true;
                    }
                    break;
                case "maskedTextbox5":   // F. Baja
                    {
                        errorProvider1.SetError(comboBox3, "");
                        if (ctrl.Text.Length == 0 || ctrl.Text == string.Empty || ctrl.Text == "      ")
                        {
                            comboBox3.SelectedIndex = -1;
                            comboBox3.Enabled = false;
                        }
                        else
                            comboBox3.Enabled = true;
                    }
                    break;
                case "maskedTextBox11":   //Categoria (Barra)
                    {
                        errorProvider1.SetError(comboBox1, "");
                        if (ctrl.Text.Length == 0)
                        {
                            comboBox1.SelectedIndex = -1;
                            comboBox1.Enabled = false;
                        }
                        else
                        {
                            comboBox1.Enabled = true;
                            comboBox1.PreventDropDown = true;
                            sv = Convert.ToInt32(ctrl.Text);
                            if (sv > 2)
                                sv = 2;
                            comboBox1.SelectedValue = sv.ToString().PadLeft(4, '0');
                        }
                    }
                    break;
                default:
                    break;

            }
        }

        private string Ver_Barra(string pkey)
        {
            string isbarra = string.Empty;
            int drrow = 0;
            int intpkey = 0;
            int antkey = 0;
            int drbarra = 0;


            Existe_Barra(pkey, ref isbarra, ref drrow);

            if (isbarra != string.Empty && isediting == "SI")
            {
                if (rowpos == drrow)   // es la misma fila, estaría bien el valor
                {
                    isbarra = string.Empty;
                }
            }


            // es la ultima fila del datarow
                if (isadding == "SI" && isbarra == string.Empty) //NO existe la fila, veo si es consecutivo
               {
                   drrow = 0;
                   if (Int32.TryParse(pkey, out intpkey))
                   {
                       if (adherentesDT.Rows.Count > 0) //Hay otros adherentes
                       {
                           antkey = intpkey - 1;
                               if (antkey >= 0)
                               {
                                   Existe_Barra(antkey.ToString(), ref isbarra, ref drrow); //verifico que exista el anterior
                                   if (isbarra == string.Empty) //indica que no existe
                                   {
                                       if (antkey != 1) //para saltear a la esposa
                                        {
                                           isbarra = "EL VALOR DE 'BARRA' NO ES CONSECUTIVO O FALTA ADH. TITULAR";
                                       }
                                       else
                                           isbarra = string.Empty;  // la blanqueo para QUE NO DE ERROR
                                   }
                                   else
                                       isbarra = string.Empty;  // la blanqueo para QUE NO DE ERROR
                               }
                           
                       }

                       else // es el primer adherente
                       {
                           if (intpkey != 0)
                           {
                               isbarra = "EL PRIMER VALOR DE 'BARRA' DEBE SER 0 (ADH. TITULAR)";
                           }
                       }

                   }
               }
   
            return isbarra;
        }

        /*
                private string Ver_Barra(string pkey)
        {
            string isbarra = string.Empty;
            int drrow = 0;
            int intpkey = 0;
            int drbarra = 0;


            Existe_Barra(pkey, ref isbarra, ref drrow);

            if (isbarra != string.Empty && isediting == "SI")
            {
                if (rowpos == drrow)   // es la misma fila, estaría bien el valor
                {
                    isbarra = string.Empty;
                }
            }


            // es la ultima fila del datarow
            if (isadding == "SI" && isbarra == string.Empty)
               {
                   drrow = 0;
                   if (Int32.TryParse(pkey, out intpkey))
                   {
                       if (adherentesDT.Rows.Count > 0)
                       {
                           for (int i = 0; i < intpkey; i++)
                          {
                           Existe_Barra(i.ToString(), ref isbarra, ref drrow);
                           if (isbarra == string.Empty) //indica que no existe
                           {
                               if (drrow != 1) //para saltear a la esposa
                               {
                                   isbarra = "EL VALOR DE 'BARRA' NO ES CONSECUTIVO O FALTA ADH. TITULAR";
                                   break;
                               }
                           }
                           else
                               isbarra = string.Empty;  // la blanqueo para la siguiente vez
                          }
                       }
                       else
                       {
                           if (intpkey != 0)
                           {
                               isbarra = "EL PRIMER VALOR DE 'BARRA' DEBE SER 0 (ADH. TITULAR)";
                           }
                       }
                   }
                   else
                   {
                       intpkey = 0;
                       isbarra = "EL VALOR DE 'BARRA' INGRESADO ES INVALIDO - REINGRESE";
                   }

               }

            return isbarra;
        }
         */
        private void Existe_Barra(string pkey, ref string isbarra, ref int drrow)
        {
            foreach (DataRow dr in adherentesDT.Rows)
            {
                // dr[2] es ADH                                dr[28] es ADH_DEP                            dr[3] es BARRA           
                if (dr[2].ToString() == maskedTextBox3.Text && dr[28].ToString() == maskedTextBox13.Text && dr[3].ToString() == pkey)
                {
                    isbarra = "EL VALOR DE 'BARRA' YA EXISTE EN OTRO ADHERENTE DEL GRUPO FAMILIAR";
                    break;
                }
                drrow++;
            }
        }
         
        // validaciones GIMNASIO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (textBox4.Text == " " || textBox4.Text.Length == 0)
            {
                errorProvider1.SetError(textBox4, "");
            }
            else
            {
                if (textBox4.Text != "N" && textBox4.Text != "S")
                {
                    errorProvider1.SetError(textBox4, "VALORES VALIDOS: N, S o BLANCO");
                    textBox4.Focus();
                    return;
                }
                else
                    errorProvider1.SetError(textBox4, "");
            }

        }

        // validaciones SEXO
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == " " || textBox3.Text.Length == 0)
            {
                errorProvider1.SetError(textBox3, "");
            }
            else
            {
                if (textBox3.Text != "F" && textBox3.Text != "M")
                {
                    errorProvider1.SetError(textBox3, "VALORES VALIDOS: F, M o BLANCO");
                    textBox3.Focus();
                    return;
                }
                else
                    errorProvider1.SetError(textBox3, "");
            }
        }

        //< Modificado SEbastian 17-02-2016 hasta la 2960

        private void GenerarCarnetLocal()


        {


            // ojo con los invitados participativos
            string vobservac;
            int TipoCarnet;
            SOCIOS.Carnet.GeneradorCarnet genCarnet;
            string vp1 = "";
            string vp2 = "";
            string vp3 = "";
            string vcadena = "";
            string vaux = "";
            string NroSocio = maskedTextBox1.Text;
            string Nombre = textBox14.Text;
            string Apellido = textBox15.Text;
            string Documento = maskedTextBox9.Text;
            string Vencimiento = "";
            string Fecha = maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4);
            string vcodigobarra;

            if (VGlobales.vp_adh_inp == "A")
            {

                if (maskedTextbox4.Text == "")
                {
                    MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                    return;
                }

                else
                    if (Convert.ToInt32(maskedTextBox11.Text) > 1)
                    {
                        // adh simil cadete hasta 18 años
                        // VALIDACION DE CADETE SI ES MAYOR A 18 NO SE IMPRIME
                    ;
                 
                       
                    
                        DateTime vfecha;
                        DateTime vvto;
                        string vpaso;
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.CADETE;
                        vfecha = ObtenerFecha(maskedTextbox14.Text);

                        Datos_ini ini_carnet = new Datos_ini();

                        vvto = vfecha.AddYears(18);
                        if (DateTime.Compare(DateTime.Today, vvto) < 0)
                        {
                            vpaso = vvto.ToString();
                        }
                        else
                        {
                            MessageBox.Show("EL ADHERENTE CADETE ES MAYOR A 18 AÑOS, NO SE PUEDE EMITIR CARNET");
                            return;
                        }
                      

                        // falta el resto...................

                        // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                        if (Socios.v_par == 2)
                        {
                            vp1 = Socios.v_pcrjp1.ToString();
                            vp2 = Socios.v_pcrjp2.ToString();
                            vp3 = Socios.v_pcrjp3.ToString(); ;
                        }
                        else
                        {
                            vp1 = Socios.v_acrjp1.ToString();
                            vp2 = Socios.v_acrjp2.ToString();
                            vp3 = Socios.v_acrjp3.ToString();
                        }

                        vaux = maskedTextBox11.Text.Trim();
                        vaux = vaux.PadLeft(2, '0');

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;


                        genCarnet = new SOCIOS.Carnet.GeneradorCarnet(TipoCarnet, SOCIOS.Utils.ImagenCarnet(pictureBox1.Image));

                        string Afiliado_Beneficio = vp1 + "  /  " + vp2 + "  /  " + vp3;
                        vcodigobarra = "A" + vcodigobarra;
                        if (vpaso.Length > 0)
                            Vencimiento = DateTime.Parse(vpaso).ToShortDateString();


                        if (genCarnet.GenerarCarnet(Fecha, NroSocio, Apellido, Nombre, Documento, Afiliado_Beneficio, vcodigobarra, "", Vencimiento,""))
                        {
                            Actualizar_F_Carnet();

                        }
                        else
                        {

                        }


                                      

                    

                        MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");


                    }
                    else
                    {

                       
                       

                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.ADHERENTE;


                        // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                        if (Socios.v_par == 2)
                        {
                            vp1 = Socios.v_pcrjp1.ToString();
                            vp2 = Socios.v_pcrjp2.ToString();
                            vp3 = Socios.v_pcrjp3.ToString(); ;
                        }
                        else
                        {
                            vp1 = Socios.v_acrjp1.ToString();
                            vp2 = Socios.v_acrjp2.ToString();
                            vp3 = Socios.v_acrjp3.ToString();
                        }

                        vaux = maskedTextBox11.Text.Trim();
                        vaux = vaux.PadLeft(2, '0');

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;

                        string Afiliado_Beneficio = vp1 + "  /  " + vp2 + "  /  " + vp3;
                        vcodigobarra = "A" + vcodigobarra;

                        genCarnet = new SOCIOS.Carnet.GeneradorCarnet(TipoCarnet, SOCIOS.Utils.ImagenCarnet(pictureBox1.Image));

                        if (genCarnet.GenerarCarnet(Fecha, NroSocio, Apellido, Nombre, Documento, Afiliado_Beneficio, vcodigobarra, "", "",""))
                        {
                            Actualizar_F_Carnet();

                        }
                        else
                        {

                        }



                    

                        Actualizar_F_Carnet();

                        MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");

                    }
            }

            else
            {


                if (maskedTextbox4.Text == "")
                {
                    MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                    return;
                }

                else
                    if (Convert.ToInt32(maskedTextBox11.Text) > 1)
                    {
                        // adh simil cadete hasta 18 años
                        // VALIDACION DE CADETE SI ES MAYOR A 18 NO SE IMPRIME
                     
                        vcodigobarra = "";
                   
                      
                        DateTime vfecha;
                        DateTime vvto;
                        string vpaso;


                        vfecha = ObtenerFecha(maskedTextbox14.Text);

                        vobservac = listBox1.Items[0].ToString().TrimEnd();


                        Datos_ini ini_carnet = new Datos_ini();

                        vvto = vfecha.AddYears(18);
                        if (DateTime.Compare(DateTime.Today, vvto) < 0)
                        {
                            vpaso = vvto.ToString();
                        }
                        else
                        {
                            MessageBox.Show("EL INVITADO PARTICIPATIVO CADETE ES MAYOR A 18 AÑOS, NO SE PUEDE EMITIR CARNET");
                            return;
                        }

                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.INVITADO_PARTICIPAIVO;

                        // falta el resto...................

                        // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                        if (Socios.v_par == 2)
                        {
                            vp1 = Socios.v_pcrjp1.ToString();
                            vp2 = Socios.v_pcrjp2.ToString();
                            vp3 = Socios.v_pcrjp3.ToString(); ;
                        }
                        else
                        {
                            vp1 = Socios.v_acrjp1.ToString();
                            vp2 = Socios.v_acrjp2.ToString();
                            vp3 = Socios.v_acrjp3.ToString();
                        }

                        vaux = maskedTextBox11.Text.Trim();
                        vaux = vaux.PadLeft(2, '0');

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;

                        string Afiliado_Beneficio = vp1 + "  /  " + vp2 + "  /  " + vp3;
                        vcodigobarra = "A" + vcodigobarra;



                        genCarnet = new SOCIOS.Carnet.GeneradorCarnet(TipoCarnet, SOCIOS.Utils.ImagenCarnet(pictureBox1.Image));

                        if (genCarnet.GenerarCarnet(Fecha, NroSocio, Apellido, Nombre, Documento, Afiliado_Beneficio, vcodigobarra, "", "",vobservac))
                        {
                        
                        
                        }
                       

                    

                   

                        Actualizar_F_Carnet();

                        MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");


                    }
                    else
                    {

                     
                        vcodigobarra = "";
                     
                       



                        // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                        if (Socios.v_par == 2)
                        {
                            vp1 = Socios.v_pcrjp1.ToString();
                            vp2 = Socios.v_pcrjp2.ToString();
                            vp3 = Socios.v_pcrjp3.ToString(); ;
                        }
                        else
                        {
                            vp1 = Socios.v_acrjp1.ToString();
                            vp2 = Socios.v_acrjp2.ToString();
                            vp3 = Socios.v_acrjp3.ToString();
                        }

                        vaux = maskedTextBox11.Text.Trim();
                        vaux = vaux.PadLeft(2, '0');

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;


                        
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.INVITADO_PARTICIPAIVO;

                        string Afiliado_Beneficio = vp1 + "     /     " + vp2 + "     /      " + vp3;

                        genCarnet = new SOCIOS.Carnet.GeneradorCarnet(TipoCarnet, SOCIOS.Utils.ImagenCarnet(pictureBox1.Image));

                        if (genCarnet.GenerarCarnet(Fecha, NroSocio, Apellido, Nombre, Documento, Afiliado_Beneficio, vcodigobarra, "", "", "Exhibir Recibo Pago"))
                        {
                            Actualizar_F_Carnet();

                            MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");
                        }
                    }



            }
        
        
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Generar_Carnet_ODBC();
        }


        private void Generar_Carnet_ODBC()
        { 
            string vobservac;

            if (VGlobales.vp_adh_inp == "A")
            {
                if (maskedTextbox4.Text == "")
                {
                    MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                    return;
                }
                else if (Convert.ToInt32(maskedTextBox11.Text) > 1)
                {
                    string v_coneccion_acces;
                    string v_provider;
                    string vcadena;
                    string vcodigobarra = "";
                    string vaux = "";
                    string vp1 = "";
                    string vp2 = "";
                    string vp3 = "";
                    DateTime vfecha;
                    DateTime vvto;
                    string vpaso;
                    string id_empleado = "";

                    vfecha = ObtenerFecha(maskedTextbox14.Text);

                    Datos_ini ini_carnet = new Datos_ini();

                    vvto = vfecha.AddYears(18);

                    if (DateTime.Compare(DateTime.Today, vvto) < 0)
                    {
                        vpaso = vvto.ToString();
                    }
                    else
                    {
                        MessageBox.Show("EL ADHERENTE CADETE ES MAYOR A 18 AÑOS, NO SE PUEDE EMITIR CARNET");
                        return;
                    }

                    if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                    {
                        v_coneccion_acces = ini_carnet.Vcarnet_metro;
                    }
                    else if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                    {
                        v_coneccion_acces = ini_carnet.Vcarnet_adh_interfuerza_adh_vto;
                    }
                    else
                    {
                        v_coneccion_acces = ini_carnet.Vcarnet_adh_menor;
                    }

                    v_provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + v_coneccion_acces;
                    OleDbConnection aConnection = new OleDbConnection(v_provider);

                    if (Socios.v_par == 2)
                    {
                        vp1 = Socios.v_pcrjp1.ToString();
                        vp2 = Socios.v_pcrjp2.ToString();
                        vp3 = Socios.v_pcrjp3.ToString();
                    }
                    else
                    {
                        vp1 = Socios.v_acrjp1.ToString();
                        vp2 = Socios.v_acrjp2.ToString();
                        vp3 = Socios.v_acrjp3.ToString();
                    }

                    vaux = maskedTextBox11.Text.Trim();
                    vaux = vaux.PadLeft(2, '0');

                    vcodigobarra = maskedTextBox3.Text.Trim();
                    vcodigobarra = vcodigobarra.PadLeft(6, '0');
                    vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;

                    vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                    vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                    vcadena = vcadena + "IDCCRJP2,IDCsbarra,IDCcrjp3,IDCfoto,IDCvto) values ( '" + maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4) + "', ";
                    vcadena = vcadena + "'" + "A" + vcodigobarra;
                    vcadena = vcadena + "','" + maskedTextBox3.Text.Trim() + "','" + textBox15.Text.Trim() + "','" + textBox14.Text.Trim();
                    vcadena = vcadena + "','" + maskedTextBox9.Text.Trim() + "'," + "'DNI'" + "," + "'" + vp1 + "','" + vp2 + "','" + vaux;
                    vcadena = vcadena + "','" + vp3 + "',?,'" + vpaso + "')";

                    if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                    {
                        vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                        vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                        vcadena = vcadena + "IDCCRJP2,IDCsbarra,IDCcrjp3,IDCfoto,IDCvto,IDCEmpleado) values ( '" + maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4) + "', ";
                        vcadena = vcadena + "'" + "A" + vcodigobarra;
                        vcadena = vcadena + "','" + maskedTextBox3.Text.Trim() + "','" + textBox15.Text.Trim() + "','" + textBox14.Text.Trim();
                        vcadena = vcadena + "','" + maskedTextBox9.Text.Trim() + "'," + "'DNI'" + "," + "'" + vp1 + "','" + vp2 + "','" + vaux;
                        vcadena = vcadena + "','" + vp3 + "',?," + "'" + vpaso + "', '"+VGlobales.ID_EMPLEADO+"')";
                    }

                    OleDbParameter parImagen = new OleDbParameter("@imagen", OleDbType.LongVarBinary, imageToByteArray(pictureBox1.Image).Length);

                    parImagen.Value = imageToByteArray(pictureBox1.Image);
                    OleDbCommand aCommand = new OleDbCommand(vcadena, aConnection);
                    aCommand.Parameters.Add(parImagen);
                    aConnection.Open();
                    aCommand.ExecuteNonQuery();
                    aConnection.Close();
                    Actualizar_F_Carnet();
                    MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");
                }
                else
                {
                    string v_coneccion_acces;
                    string v_provider;
                    string vcadena;
                    string vcodigobarra = "";
                    string vaux = "";
                    string vp1 = "";
                    string vp2 = "";
                    string vp3 = "";

                    Datos_ini ini_carnet = new Datos_ini();

                    if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                    {
                        v_coneccion_acces = ini_carnet.Vcarnet_metro;
                    }
                    else if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                    {
                        v_coneccion_acces = ini_carnet.Vcarnet_adh_interfuerza_adh;
                    }
                    else
                    {
                        v_coneccion_acces = ini_carnet.Vcarnet_adherente;
                    }
                    
                    v_provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + v_coneccion_acces;

                    OleDbConnection aConnection = new OleDbConnection(v_provider);


                    // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                    if (Socios.v_par == 2)
                    {
                        vp1 = Socios.v_pcrjp1.ToString();
                        vp2 = Socios.v_pcrjp2.ToString();
                        vp3 = Socios.v_pcrjp3.ToString(); ;
                    }
                    else
                    {
                        vp1 = Socios.v_acrjp1.ToString();
                        vp2 = Socios.v_acrjp2.ToString();
                        vp3 = Socios.v_acrjp3.ToString();
                    }

                    vaux = maskedTextBox11.Text.Trim();
                    vaux = vaux.PadLeft(2, '0');

                    vcodigobarra = maskedTextBox3.Text.Trim();
                    vcodigobarra = vcodigobarra.PadLeft(6, '0');
                    vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;

                    vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                    vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                    vcadena = vcadena + "IDCCRJP2,IDCsbarra,IDCcrjp3,IDCfoto) values ( '" + maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4) + "', ";
                    vcadena = vcadena + "'" + "A" + vcodigobarra;
                    vcadena = vcadena + "','" + maskedTextBox3.Text + "','" + textBox15.Text + "','" + textBox14.Text;
                    vcadena = vcadena + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "','" + vp2 + "','" + vaux;
                    vcadena = vcadena + "','" + vp3 + "',?)";

                    if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                    {
                        vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                        vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                        vcadena = vcadena + "IDCCRJP2,IDCsbarra,IDCcrjp3,IDCfoto,IDCEmpleado) values ( '" + maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4) + "', ";
                        vcadena = vcadena + "'" + "A" + vcodigobarra;
                        vcadena = vcadena + "','" + maskedTextBox3.Text + "','" + textBox15.Text + "','" + textBox14.Text;
                        vcadena = vcadena + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "','" + vp2 + "','" + vaux;
                        vcadena = vcadena + "','" + vp3 + "',?,'" + VGlobales.ID_EMPLEADO + "')";
                    }

                    OleDbParameter parImagen = new OleDbParameter("@imagen", OleDbType.LongVarBinary, imageToByteArray(pictureBox1.Image).Length);
                    parImagen.Value = imageToByteArray(pictureBox1.Image);
                    OleDbCommand aCommand = new OleDbCommand(vcadena, aConnection);
                    aCommand.Parameters.Add(parImagen);
                    aConnection.Open();
                    aCommand.ExecuteNonQuery();
                    aConnection.Close();
                    Actualizar_F_Carnet();
                    MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");
                }
            }
            else
            {
                if (maskedTextbox4.Text == "")
                {
                    MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                    return;
                }

                else
                    if (Convert.ToInt32(maskedTextBox11.Text) > 1)
                    {
                        // adh simil cadete hasta 18 años
                        // VALIDACION DE CADETE SI ES MAYOR A 18 NO SE IMPRIME
                        string v_coneccion_acces;
                        string v_provider;
                        string vcadena;
                        string vcodigobarra = "";
                        string vaux = "";
                        string vp1 = "";
                        string vp2 = "";
                        string vp3 = "";
                        DateTime vfecha;
                        DateTime vvto;
                        string vpaso;


                        vfecha = ObtenerFecha(maskedTextbox14.Text);

                        vobservac = listBox1.Items[0].ToString().TrimEnd();


                        Datos_ini ini_carnet = new Datos_ini();

                        vvto = vfecha.AddYears(18);
                        if (DateTime.Compare(DateTime.Today, vvto) < 0)
                        {
                            vpaso = vvto.ToString();
                        }
                        else
                        {
                            MessageBox.Show("EL INVITADO PARTICIPATIVO CADETE ES MAYOR A 18 AÑOS, NO SE PUEDE EMITIR CARNET");
                            return;
                        }
                        v_coneccion_acces = ini_carnet.Vcarnet_invitado;

                        v_provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + v_coneccion_acces;

                        OleDbConnection aConnection = new OleDbConnection(v_provider);

                        // falta el resto...................

                        // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                        if (Socios.v_par == 2)
                        {
                            vp1 = Socios.v_pcrjp1.ToString();
                            vp2 = Socios.v_pcrjp2.ToString();
                            vp3 = Socios.v_pcrjp3.ToString(); ;
                        }
                        else
                        {
                            vp1 = Socios.v_acrjp1.ToString();
                            vp2 = Socios.v_acrjp2.ToString();
                            vp3 = Socios.v_acrjp3.ToString();
                        }

                        vaux = maskedTextBox11.Text.Trim();
                        vaux = vaux.PadLeft(2, '0');

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;


                        vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                        vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                        vcadena = vcadena + "IDCCRJP2,IDCsbarra,IDCcrjp3,IDCfoto,IDCobservaciones) values ( '" + maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4) + "', ";
                        vcadena = vcadena + "'" + "A" + vcodigobarra;
                        vcadena = vcadena + "','" + maskedTextBox3.Text + "','" + textBox15.Text + "','" + textBox14.Text;
                        vcadena = vcadena + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "','" + vp2 + "','" + vaux;
                        vcadena = vcadena + "','" + vp3 + "',?," + "'" + vpaso + "','" + vobservac + "')";

                        OleDbParameter parImagen = new OleDbParameter("@imagen", OleDbType.LongVarBinary, imageToByteArray(pictureBox1.Image).Length);

                        parImagen.Value = imageToByteArray(pictureBox1.Image);
                        OleDbCommand aCommand = new OleDbCommand(vcadena, aConnection);

                        aCommand.Parameters.Add(parImagen);

                        aConnection.Open();

                        aCommand.ExecuteNonQuery();

                        aConnection.Close();

                        Actualizar_F_Carnet();

                        MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");


                    }
                    else
                    {

                        string v_coneccion_acces;
                        string v_provider;
                        string vcadena;
                        string vcodigobarra = "";
                        string vaux = "";
                        string vp1 = "";
                        string vp2 = "";
                        string vp3 = "";

                        Datos_ini ini_carnet = new Datos_ini();
                        v_coneccion_acces = ini_carnet.Vcarnet_invitado;
                        v_provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + v_coneccion_acces;

                        OleDbConnection aConnection = new OleDbConnection(v_provider);


                        // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                        if (Socios.v_par == 2)
                        {
                            vp1 = Socios.v_pcrjp1.ToString();
                            vp2 = Socios.v_pcrjp2.ToString();
                            vp3 = Socios.v_pcrjp3.ToString(); ;
                        }
                        else
                        {
                            vp1 = Socios.v_acrjp1.ToString();
                            vp2 = Socios.v_acrjp2.ToString();
                            vp3 = Socios.v_acrjp3.ToString();
                        }

                        vaux = maskedTextBox11.Text.Trim();
                        vaux = vaux.PadLeft(2, '0');

                        vcodigobarra = maskedTextBox3.Text.Trim();
                        vcodigobarra = vcodigobarra.PadLeft(6, '0');
                        vcodigobarra = vcodigobarra + maskedTextBox13.Text.Trim().PadLeft(3, '0') + vaux;


                        vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                        vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                        vcadena = vcadena + "IDCCRJP2,IDCsbarra,IDCcrjp3,IDCfoto) values ( '" + maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4) + "', ";
                        vcadena = vcadena + "'" + "A" + vcodigobarra;
                        vcadena = vcadena + "','" + maskedTextBox3.Text + "','" + textBox15.Text + "','" + textBox14.Text;
                        vcadena = vcadena + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "','" + vp2 + "','" + vaux;
                        vcadena = vcadena + "','" + vp3 +  "',?)";

                        OleDbParameter parImagen = new OleDbParameter("@imagen", OleDbType.LongVarBinary, imageToByteArray(pictureBox1.Image).Length);

                        parImagen.Value = imageToByteArray(pictureBox1.Image);
                        OleDbCommand aCommand = new OleDbCommand(vcadena, aConnection);

                        aCommand.Parameters.Add(parImagen);

                        aConnection.Open();

                        aCommand.ExecuteNonQuery();

                        aConnection.Close();


                        Actualizar_F_Carnet();

                        MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");

                    }



            }
        
        }
        // Modificado SEbastian 17-02-2016 >



        private void Actualizar_F_Carnet()
        {
            // GRABAMOS EN LA BASE.-

            conString conString = new conString();
            string connectionString = conString.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                string vcomando;
                int vid_adh = 0;

                vid_adh = (Convert.ToInt32(maskedTextBox3.Text) * 100000) + (Convert.ToInt32(maskedTextBox13.Text) * 100) + Convert.ToInt32(maskedTextBox11.Text);

                vcomando = "UPDATE ADHERENT SET F_CARADH=CURRENT_DATE WHERE ID_ADHERENTE = " + vid_adh.ToString();

                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(vcomando, connection, transaction);
                cmd.CommandText = vcomando;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                connection.Dispose();
                maskedTextbox7.Text = Convert.ToString(DateTime.Today);
                adherentesDT.Rows[rowpos]["F_CARADH"] = maskedTextbox7.Text;

            }
        }

        private void Ficha_Click(object sender, EventArgs e)
        {
            vp_id_adherente = ((Convert.ToInt32(maskedTextBox3.Text) * 100000) + 
                               (Convert.ToInt32(maskedTextBox13.Text) * 100) + 
                                Convert.ToInt32(maskedTextBox11.Text));
            using (FichaAdherente frmFICHADH = new FichaAdherente())
            {
                frmFICHADH.ShowDialog(this);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int id_adherente = (Convert.ToInt32(maskedTextBox3.Text) * 100000) + (Convert.ToInt32(maskedTextBox13.Text) * 100) + Convert.ToInt32(maskedTextBox11.Text);
            int id_titular = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;
            genHTML gh = new genHTML();
            gh.authIndividualAdherente(id_titular, id_adherente);
        }
    }
}