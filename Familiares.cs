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
    public partial class Familiares : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public Familiares()
        {
            InitializeComponent();
        }


        public static Image fotoZoom = null;
        private string isadding = "NO";
        private string isediting = "NO";
        private bool protegido = true;
        private int newpos = 0;
        private int rowpos = 0;
        private int rowexacto = 0;
        private byte[] img;
        DataTable familiaresDT = new DataTable("FAM");

        public void datosContacto(string NRO_SOC, string NRO_DEP, string BARRA)
        {
            bo dlog = new bo();

            string query = "SELECT * FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA;

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                tbTelefonoContacto.Text = foundRows[0][5].ToString();
                tbEmailContacto.Text = foundRows[0][4].ToString();
            }
        }

        
        public void limpio_botones()
        {
            bindingNavigator1.MoveFirstItem.Enabled = true;
            bindingNavigator1.MoveLastItem.Enabled = true;
            bindingNavigator1.MoveNextItem.Enabled = true;
            bindingNavigator1.MovePreviousItem.Enabled = true;
            cancelar.Enabled = false;
            grabar.Enabled = false;
            //editar.Enabled = true;
            //nuevo.Enabled = true;
            Habilitar_Botones();
            ADQUIRIR.Enabled = false;

        }
        

        public void limpio_campos()
        {
            //maskedTextBox1.Text = "0";
            //maskedTextBox2.Text = "0";
            maskedTextBox3.Text = "0";
            maskedTextbox4.Text = string.Empty;
            maskedTextbox5.Text = string.Empty;
            maskedTextbox7.Text = string.Empty;
            //maskedTextbox6.Text = " ";
            maskedTextbox8.Text = string.Empty;
            maskedTextBox9.Text = "0";
            maskedTextBox10.Text = "0";

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox14.Text = string.Empty;
            lblNoSocio.Text = "";

            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            
        }

        private void Proteger()
        {
            protegido = true;
            tbEmailContacto.ReadOnly = true;
            tbTelefonoContacto.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;

            maskedTextbox4.ReadOnly = true;
            maskedTextbox5.ReadOnly = true;
            maskedTextbox7.ReadOnly = true;
            //maskedTextbox6.ReadOnly = true;
            maskedTextbox8.ReadOnly = true;
            maskedTextBox9.ReadOnly = true;
            maskedTextBox10.ReadOnly = true;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox14.ReadOnly = true;

            comboBox1.PreventDropDown = true;
            comboBox2.PreventDropDown = true;
            comboBox3.PreventDropDown = true;
            comboBox4.PreventDropDown = true;

         //   comboBox1.BackColor = System.Drawing.SystemColors.Window;
            comboBox1.BackColor = Color.FromName("Control");
            comboBox2.BackColor = Color.FromName("Control");
            comboBox3.BackColor = Color.FromName("Control");
            comboBox4.BackColor = Color.FromName("Control");

            comboBox1.ForeColor = Color.FromName("Black");
            comboBox2.ForeColor = Color.FromName("Black");
            comboBox3.ForeColor = Color.FromName("Black");
            comboBox4.ForeColor = Color.FromName("Black");

           // themedStatusStrip1.Text = " ";
            ADQUIRIR.Enabled = false;
        }

        private void Habilitar()
        {
            tbTelefonoContacto.ReadOnly = false;
            tbEmailContacto.ReadOnly = false;
            protegido = false;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;

            if (isediting == "SI")
            {
                maskedTextBox3.ReadOnly = true;
                textBox1.Focus();
            }
            else
            {
                maskedTextBox3.ReadOnly = false;
                maskedTextBox3.Focus();
            }

            maskedTextbox4.ReadOnly = false;
            maskedTextbox5.ReadOnly = false;
            maskedTextbox7.ReadOnly = false;
           // maskedTextbox6.ReadOnly = false;
            maskedTextbox8.ReadOnly = false;
            maskedTextBox9.ReadOnly = false;
            maskedTextBox10.ReadOnly = false;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox14.ReadOnly = false;


            comboBox1.PreventDropDown = true; // nunca se habilita se setea por barra
            comboBox2.PreventDropDown = false;
            comboBox3.PreventDropDown = false;
            comboBox4.PreventDropDown = false;

            comboBox1.BackColor = Color.FromName("white");
            comboBox2.BackColor = Color.FromName("white");
            comboBox3.BackColor = Color.FromName("white");
            comboBox4.BackColor = Color.FromName("white");

            comboBox1.ForeColor = Color.FromName("Black");
            comboBox2.ForeColor = Color.FromName("Black");
            comboBox3.ForeColor = Color.FromName("Black");
            comboBox4.ForeColor = Color.FromName("Black");



            if (pictureBox1.Image == null)
            { pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible; }

          //  themedStatusStrip1.Text = " ";
            ADQUIRIR.Enabled = true;
        }

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
            { rowpos--; 
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

            if (rowpos < familiaresDT.Rows.Count - 1)
            {
                rowpos++;
                if (rowpos == familiaresDT.Rows.Count - 1)
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

            if (familiaresDT.Rows.Count != 0)
            {
                rowpos = familiaresDT.Rows.Count - 1;
            }  
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            

            this.BindDatosDT();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            if ((VGlobales.v_soc_fallecido == "5") || (VGlobales.v_soc_fallecido == "8"))
            {
                MessageBox.Show("SOCIO TITULAR FALLECIDO, NO PUEDEN DARSE NUEVAS ALTAS",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Crear_fila();
                // BindDatosDT();
            }
        }


        private void Crear_fila()
        {
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

            maskedTextBox1.Text = Socios.vp_nro_soc.ToString();
            maskedTextBox2.Text = Socios.vp_nro_dep.ToString();

            limpio_campos();


            // se pone fecha del día en los siguientes campos
            // Fecha de Alta Circulo    
            maskedTextbox4.Text =  DateTime.Today.Date.Day.ToString().PadLeft(2, '0') + 
                                   DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Today.Date.Year.ToString();
            // Fecha de Carnet
            maskedTextbox7.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') + 
                                  DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
                                  DateTime.Today.Date.Year.ToString();
            //Gimnasio
           textBox14.Text = "N"; 

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


            Habilitar();

        }

        private void grabar_Click(object sender, EventArgs e)
        {
            if (Consistir_Datos())
            {
                if (isadding == "SI")
                {
                  rowpos = familiaresDT.Rows.Count;
                  try
                  {
                      familiaresDT.Rows.Add(new object[] { maskedTextBox1.Text, maskedTextBox2.Text,
                                                 maskedTextBox3.Text, textBox1.Text,
                                                 textBox2.Text, "0000",
                                                 maskedTextbox7.Text, maskedTextbox8.Text,
                                                 maskedTextbox5.Text, maskedTextbox4.Text, "",
                                               //  maskedTextbox6.Text,  
                                                 maskedTextBox9.Text, maskedTextBox10.Text,
                                                 textBox5.Text,
                                                 "", "", 
                                                 textBox3.Text, imageToByteArray(pictureBox1.Image), textBox14.Text });
                  }
                  catch (SystemException ex)
                  {
            
                      MessageBox.Show(ex.Message.ToString().ToUpper(),
                               "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      //  errorProvider1.SetError(maskedTextBox3, ex.Message.ToString().ToUpper());
                      //Mails1 mensaje = new Mails1();
                     // mensaje.Enviar_Mail_Error(ex.ToString());

                      return;
                  }

                }
                 else
                {
                  try
                  {
                    familiaresDT.Rows[rowpos]["NRO_SOC"] = maskedTextBox1.Text;
                    familiaresDT.Rows[rowpos]["NRO_DEP"] = maskedTextBox2.Text;
                    familiaresDT.Rows[rowpos]["BARRA"] = maskedTextBox3.Text;

                    familiaresDT.Rows[rowpos]["APE_FAM"] = textBox1.Text;
                    familiaresDT.Rows[rowpos]["NOM_FAM"] = textBox2.Text;

                    if (comboBox1.SelectedIndex != -1)
                        familiaresDT.Rows[rowpos]["CAT_SOC"] = comboBox1.SelectedValue.ToString();
                    else
                        familiaresDT.Rows[rowpos]["CAT_SOC"] = null;

                    familiaresDT.Rows[rowpos]["F_CARFAM"] = maskedTextbox7.Text;
                    familiaresDT.Rows[rowpos]["F_NACFAM"] = maskedTextbox8.Text;
                    familiaresDT.Rows[rowpos]["F_BAJA"] = maskedTextbox5.Text;
                    familiaresDT.Rows[rowpos]["F_ALTA"] = maskedTextbox4.Text;
                    //familiaresDT.Rows[rowpos]["F_UMOVFA"] = maskedTextbox6.Text;

                    if (comboBox4.SelectedIndex != -1)
                        familiaresDT.Rows[rowpos]["TIP_DOCF"] = comboBox4.SelectedValue.ToString();
                    else
                        familiaresDT.Rows[rowpos]["TIP_DOCF"] = null; 

                    familiaresDT.Rows[rowpos]["NUM_DOCF"] = maskedTextBox9.Text;
                    familiaresDT.Rows[rowpos]["NUM_CEDF"] = maskedTextBox10.Text;

                    familiaresDT.Rows[rowpos]["CAS_ESP"] = textBox5.Text;

                    if (comboBox2.SelectedIndex != -1)
                        familiaresDT.Rows[rowpos]["TIP_CARN"] = comboBox2.SelectedValue.ToString();
                    else
                        familiaresDT.Rows[rowpos]["TIP_CARN"] = null ;

                    if (comboBox3.SelectedIndex != -1)
                        familiaresDT.Rows[rowpos]["M_BAJA"] = comboBox3.SelectedValue.ToString();
                    else
                        familiaresDT.Rows[rowpos]["M_BAJA"] = null ;

                    familiaresDT.Rows[rowpos]["SEXO"] = textBox3.Text;

                    familiaresDT.Rows[rowpos]["FOTO"] = imageToByteArray(pictureBox1.Image);
                    familiaresDT.Rows[rowpos]["GIMNASIO"] = textBox14.Text;
                   }
                 catch (SystemException ex)
                    {

                    MessageBox.Show(ex.Message.ToString().ToUpper(),
                         "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //  errorProvider1.SetError(maskedTextBox3, ex.Message.ToString().ToUpper());
                   // Mails1 mensaje = new Mails1();
                   // mensaje.Enviar_Mail_Error(ex.ToString());

                    return;
                    }
                }

                //lblNoSocio.Text = "";

                Grabar_FamiliaresDT();
                VerificarCadeteFam();
                //VerificarNoSocioFam();
                limpio_botones();
                cancelar.Enabled = false;
                grabar.Enabled = false;
                //editar.Enabled = true;
                //nuevo.Enabled = true;
                Proteger();
            }
                
            
        }

        private void Grabar_FamiliaresDT()
        {
                
                string connectionString;
                string vcomando;
                Datos_ini ini2 = new Datos_ini();
                try
                {
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                    cs.Database = ini2.Ubicacion;
                    cs.UserID = VGlobales.vp_username;
                    cs.Password = VGlobales.vp_password;
                    cs.Role = VGlobales.vp_role;
                    cs.Dialect = 3;
                    connectionString = cs.ToString();
                    using (FbConnection connection = new FbConnection(connectionString))
                    {
                        connection.Open();
                        FbTransaction transaction = connection.BeginTransaction();

                        if (isediting == "SI")
                        {
             
                            vcomando = "P_UPDATEFAM";
                             
                        }
                        else
                        {

                            vcomando = "P_INSERTFAM";
                            
                        }

                     

                        FbCommand cmd = new FbCommand(vcomando, connection, transaction);

                        cmd.CommandText = vcomando;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                    
                        cmd.Parameters.Add("@P01", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox1.Text);
                        cmd.Parameters.Add("@P02", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox2.Text);
                        cmd.Parameters.Add("@P03", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox3.Text);
                        
                        cmd.Parameters.Add("@P05", FbDbType.Char).Value = textBox1.Text;
                        cmd.Parameters.Add("@P06", FbDbType.Char).Value = textBox2.Text;
                        
                        if (comboBox1.SelectedIndex != -1)
                            cmd.Parameters.Add("@P04", FbDbType.Char).Value = comboBox1.SelectedValue.ToString();
                        else
                            cmd.Parameters.Add("@P04", FbDbType.Char).Value = "0000";

                        if (maskedTextbox7.Text == " " || maskedTextbox7.Text.Length == 0) // fecha de carnet
                            cmd.Parameters.Add("@P07", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P07", FbDbType.Char).Value = maskedTextbox7.Text;
                       
                        if (maskedTextbox8.Text == " " || maskedTextbox8.Text.Length == 0) // fecha nacimiento
                            cmd.Parameters.Add("@P09", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P09", FbDbType.Char).Value = maskedTextbox8.Text;

                        if (maskedTextbox5.Text == " " || maskedTextbox5.Text.Length == 0) // fecha de BJA
                            cmd.Parameters.Add("@P016", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P016", FbDbType.Char).Value = maskedTextbox5.Text;
                        
                        if (maskedTextbox4.Text == " " || maskedTextbox4.Text.Length == 0) // fecha de Alta Circulo
                            cmd.Parameters.Add("@P018", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P018", FbDbType.Char).Value = maskedTextbox4.Text;
                        
                        //cmd.Parameters.Add("@P014", FbDbType.Date).Value = ;
                        if (comboBox4.SelectedIndex != -1)
                            cmd.Parameters.Add("@P010", FbDbType.Char).Value = comboBox4.SelectedValue.ToString();
                        else
                            cmd.Parameters.Add("@P010", FbDbType.Char).Value = "Z";
                        cmd.Parameters.Add("@P011", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox9.Text);
                        cmd.Parameters.Add("@P012", FbDbType.Integer).Value = Convert.ToInt32(maskedTextBox10.Text);
                        //cmd.Parameters.Add("@P015", FbDbType.Char).Value = textBox4.Text;
                        if (textBox5.Text == " " || textBox5.Text.Length == 0)
                            cmd.Parameters.Add("@P013", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P013", FbDbType.Char).Value = textBox5.Text;
                        
                        if (comboBox2.SelectedIndex != -1)
                            cmd.Parameters.Add("@P08", FbDbType.Char).Value = comboBox2.SelectedValue.ToString();
                        else
                            cmd.Parameters.Add("@P08", FbDbType.Char).Value = " ";
                        if (comboBox3.SelectedIndex != -1)
                            cmd.Parameters.Add("@P017", FbDbType.Char).Value = comboBox3.SelectedValue.ToString();
                        else
                            cmd.Parameters.Add("@P17", FbDbType.Char).Value = " ";

                        if (textBox3.Text == " " || textBox3.Text.Length == 0)
                            cmd.Parameters.Add("@P019", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P019", FbDbType.Char).Value = textBox3.Text;

                        cmd.Parameters.Add("@PFOTO", FbDbType.Binary).Value = imageToByteArray(pictureBox1.Image);

                        if (textBox14.Text == " " || textBox14.Text.Length == 0)
                            cmd.Parameters.Add("@P021", FbDbType.Char).Value = null;
                        else
                            cmd.Parameters.Add("@P021", FbDbType.Char).Value = textBox14.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("OPERACION EFECTUADA EXISTOSAMENTE", vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (FbException e)
                        {
                            try
                            {
                                transaction.Rollback();
                                MessageBox.Show("ERROR - LA OPERACION NO PUDO COMPLETARSE\n " + e, vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            lblNoSocio.Text = "";
                        }
                 
                        
                    }
                }
                catch (FbException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    lblNoSocio.Text = "";
                   
                }
            }


        private bool Consistir_Datos()
        {

            DateTime fecNac;
            DateTime fecAlta;
            DateTime fecBaja;
            DateTime fecCarnet;
            int fechas;


            this.txt_VerNull(maskedTextBox3, new EventArgs());
            if (errorProvider1.GetError(maskedTextBox3).Length != 0)
            {
                maskedTextBox3.Focus();
                return false;
            }

            this.txt_VerNull(textBox1, new EventArgs());
            if (errorProvider1.GetError(textBox1).Length != 0)
            {
                textBox1.Focus();
                return false;
            }
           
            this.txt_VerNull(textBox2, new EventArgs());
            if (errorProvider1.GetError(textBox2).Length != 0)
            {
                textBox2.Focus();
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
            if ((comboBox4.SelectedIndex == -1) && maskedTextBox9.Text.Length > 1) 
            {
                errorProvider1.SetError(comboBox4, "SI INFORMA DOCUMENTO DEBE INFORMAR TIPO");
                comboBox4.Focus();
                return false;
            }
            else
                if ((comboBox4.SelectedIndex != -1) && maskedTextBox9.Text.Length == 0)
                {
                    errorProvider1.SetError(maskedTextBox9, "SI INFORMA TIPO DEBE INFORMAR DOCUMENTO");
                    maskedTextBox9.Focus();
                    return false;
                }
                else
                {
                    if (maskedTextBox9.Text == " " || Convert.ToInt32(maskedTextBox9.Text) == 0 || maskedTextBox9.Text.Length == 0) // num doc 
                        maskedTextBox9.Text = "0";
                    /*else  
                        if (!((comboBox4.DisplayMember == "LC" && textBox3.Text == "F") ||
                            (comboBox4.DisplayMember == "LE" && textBox3.Text == "M")))
                            errorProvider1.SetError(comboBox4, "TIPO DE DOC. NO CORRESPONDE AL SEXO");
                            comboBox4.Focus();
                            return false;*/
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
                //if (BUSCAR_DOCUMENTO("C", maskedTextBox10.Text))
                //{
                //  errorProvider1.SetError(maskedTextBox10, "CEDULA YA INFORMADA EN OTRO TITULAR/FAMILIAR/ADHERENTE");
                //  maskedTextBox10.Focus();
                //  return false;
                //}


  
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
            if ((comboBox3.SelectedIndex == -1) && (maskedTextbox5.Text.Length > 0))
            {
                errorProvider1.SetError(comboBox3, "SI INFORMA FECHA DE BAJA DEBE INFORMAR TIPO");
                comboBox3.Focus();
                return false;
            }
            else
                if ((comboBox3.SelectedIndex != -1) && (maskedTextbox5.Text.Length == 0))
                {
                    errorProvider1.SetError(maskedTextbox5, "SI INFORMA TIPO DEBE INFORMAR FECHA DE BAJA");
                    maskedTextbox5.Focus();
                    return false;
                }
               

            if (maskedTextbox8.Text.Length > 0)
            {
                fecNac = ObtenerFecha(maskedTextbox8.Text);
                if (fecNac.Date.Year == 1900 &&
                    fecNac.Date.Month == 01  &&
                    fecNac.Date.Day == 01 )
                {
                    errorProvider1.SetError(maskedTextbox8, "FECHA DE NACIMIENTO INVALIDA - CORRIJA");
                    maskedTextbox8.Focus();
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
           
            
            
            // MODIFICADO POR SUSANA AL 28-12-2009
            /*
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


            /* MODIFICADO 28-12-2009
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


            /* MODIFICADO 28-12-2009
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
                errorProvider1.SetError(maskedTextbox5, "FECHA DE BAJA NO PUEDE SER ANTERIOR A FECHA BAJA");
                maskedTextbox5.Focus();
                return false;
            }


            this.textBox14_TextChanged(textBox14, new EventArgs());
            if (errorProvider1.GetError(textBox14).Length != 0)
            {
                textBox14.Focus();
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

            string connectionString;
            string vcomando;
            Datos_ini ini2 = new Datos_ini();
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();
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
                //Mails1 mensaje = new Mails1();
                //mensaje.Enviar_Mail_Error(ex.ToString());

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
                d = new DateTime(1900,01,01);
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
                { //familiaresDT.Rows.RemoveAt(rowpos);
                  rowpos = newpos;
                }

                if (Socios.vp_barra < 0)
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
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }



        private void Form3_Load(object sender, EventArgs e)
        {
          
            limpio_botones();
            
            Socios.Ver_Privilegios("FAMILIAR");

            Habilitar_Botones();

            // se para en el familiar sobre el que dio el click
            if (Socios.vp_barra < 0)
            {
                rowpos = 0;

                if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
                {
                    
                    VGlobales.vp_ntp = true;
                    this.Close();
                    VGlobales.vp_ntp = false;
                }
            }
            else
            {
                rowpos = Socios.vp_barra;
            }

            lblNoSocio.Text = "";

            Cargo_Datos3();

                                 
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

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

            //e.Cancel = (MessageBox.Show("CONFIRMA SALIR DE LA PANTALLA?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes);
            if (VGlobales.vp_ntp == false)
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
            }


        }

        private void Cargo_Datos3()
        {
            int id_titular = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;
            string connectionString;
            string vcmd = "SELECT NRO_SOC, NRO_DEP, A.BARRA, ";
            vcmd = vcmd + "APE_FAM, NOM_FAM, ";
            vcmd = vcmd + "case when A.BARRA > 3 then 4 else A.BARRA  END AS CAT_SOC, ";
            vcmd = vcmd + "case when F_CARFAM is null then '        ' else (LPAD(EXTRACT(day FROM F_CARFAM),2,'0')|| LPAD(EXTRACT(month FROM F_CARFAM),2,'0')|| EXTRACT(year FROM F_CARFAM)) end AS F_CARFAM, ";
            vcmd = vcmd + "case when F_NACFAM is null then '        ' else (LPAD(EXTRACT(day FROM F_NACFAM),2,'0')|| LPAD(EXTRACT(month FROM F_NACFAM),2,'0')|| EXTRACT(year FROM F_NACFAM)) end AS F_NACFAM, ";
            vcmd = vcmd + "case when F_BAJA   is null then '        ' else (LPAD(EXTRACT(day FROM F_BAJA),2,'0')|| LPAD(EXTRACT(month FROM F_BAJA),2,'0')|| EXTRACT(year FROM F_BAJA)) end AS F_BAJA, ";
            vcmd = vcmd + "case when F_ALTA   is null then '        ' else (LPAD(EXTRACT(day FROM F_ALTA),2,'0')|| LPAD(EXTRACT(month FROM F_ALTA),2,'0')|| EXTRACT(year FROM F_ALTA)) end AS F_ALTA, ";
            //vcmd = vcmd + "case when F_UMOVFA is null then '        ' else (LPAD(EXTRACT(day FROM F_UMOVFA),2,'0')|| LPAD(EXTRACT(month FROM F_UMOVFA),2,'0')|| EXTRACT(year FROM F_UMOVFA)) end AS F_UMOVFA, ";
            vcmd = vcmd + "case when TIP_DOCF is null then 'Z'        else TIP_DOCF end as TIP_DOCF, ";
            vcmd = vcmd + "case when NUM_DOCF is null then '0'        else NUM_DOCF end as NUM_DOCF, ";
            vcmd = vcmd + "case when NUM_CEDF is null then '0'        else NUM_CEDF end as NUM_CEDF, ";
            vcmd = vcmd + "case when CAS_ESP  is null then '  '       else CAS_ESP end as CAS_ESP, ";
            vcmd = vcmd + "case when TIP_CARN is null then ' '        else TIP_CARN end as TIP_CARN, ";
            vcmd = vcmd + "case when M_BAJA   is null then ' '        else M_BAJA end as M_BAJA, ";
            vcmd = vcmd + "case when SEXO     is null then ' '        else SEXO end as SEXO, ";
            vcmd = vcmd + "FOTO, " ;
            vcmd = vcmd + "case when GIMNASIO is null then ' '        else GIMNASIO end as GIMNASIO ";
            vcmd = vcmd + "FROM FAMILIAR A, FAMILIAR_IMAGEN B WHERE A.ID_TITULAR = " + id_titular.ToString() + " AND B.ID_TITULAR = " + id_titular.ToString() ;
            vcmd = vcmd + "and  A.BARRA = B.BARRA ORDER BY A.ID_TITULAR, A.BARRA ASC";



            Datos_ini ini2 = new Datos_ini();
            try
            {

                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();


                using (FbConnection connection = new FbConnection(connectionString))
                {

                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(vcmd, connection, transaction);
                    FbDataReader mt = cmd.ExecuteReader();
                    familiaresDT.Load(mt);
                }

                cancelar.Enabled = false;
                grabar.Enabled = false;

                this.BindDatosDT();

            }

            catch (FbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }



        private void BindDatosDT()
        {

            comboBox1.SelectedIndex = -1;
            comboBox1.DataSource = Socios.dsllc.Tables["BA"];
            comboBox1.DisplayMember = "descrip";
            comboBox1.ValueMember = "codigo";

            comboBox4.SelectedIndex = -1;
            comboBox4.DataSource = Socios.dsllc.Tables["TD"];
            comboBox4.DisplayMember = "descrip";
            comboBox4.ValueMember = "codigo";

            comboBox2.SelectedIndex = -1;
            comboBox2.DataSource = Socios.dsllc.Tables["TF"];
            comboBox2.DisplayMember = "descrip";
            comboBox2.ValueMember = "codigo";

            comboBox3.SelectedIndex = -1;
            comboBox3.DataSource = Socios.dsllc.Tables["BF"];
            comboBox3.DisplayMember = "descrip";
            comboBox3.ValueMember = "codigo";

            if (familiaresDT.Rows.Count == 0 || Socios.vp_barra < 0)
            {
                Crear_fila();
            }
            else
            {

                if (VGlobales.vp_cod_bar == "F")
                {
                    BuscarFam();
                    VGlobales.vp_cod_bar = string.Empty;
                    
                }

                maskedTextBox1.Text = familiaresDT.Rows[rowpos]["NRO_SOC"].ToString();
                maskedTextBox2.Text = familiaresDT.Rows[rowpos]["NRO_DEP"].ToString();
                maskedTextBox3.Text = familiaresDT.Rows[rowpos]["BARRA"].ToString().TrimEnd();

                textBox1.Text = familiaresDT.Rows[rowpos]["APE_FAM"].ToString().TrimEnd();
                textBox2.Text = familiaresDT.Rows[rowpos]["NOM_FAM"].ToString().TrimEnd();

                comboBox1.SelectedValue = familiaresDT.Rows[rowpos]["CAT_SOC"].ToString();

                maskedTextbox7.Text = familiaresDT.Rows[rowpos]["F_CARFAM"].ToString();
                maskedTextbox8.Text = familiaresDT.Rows[rowpos]["F_NACFAM"].ToString();
                maskedTextbox5.Text = familiaresDT.Rows[rowpos]["F_BAJA"].ToString();
                maskedTextbox4.Text = familiaresDT.Rows[rowpos]["F_ALTA"].ToString();
                // maskedTextbox6.Text = familiaresDT.Rows[rowpos]["F_UMOVFA"].ToString();

                
                comboBox4.SelectedValue = familiaresDT.Rows[rowpos]["TIP_DOCF"].ToString();


                maskedTextBox9.Text = familiaresDT.Rows[rowpos]["NUM_DOCF"].ToString();
                maskedTextBox10.Text = familiaresDT.Rows[rowpos]["NUM_CEDF"].ToString();

                textBox5.Text = familiaresDT.Rows[rowpos]["CAS_ESP"].ToString().TrimEnd();

                
                comboBox2.SelectedValue = familiaresDT.Rows[rowpos]["TIP_CARN"].ToString();

                
                comboBox3.SelectedValue = familiaresDT.Rows[rowpos]["M_BAJA"].ToString();


                textBox3.Text = familiaresDT.Rows[rowpos]["SEXO"].ToString();

                if (!familiaresDT.Rows[rowpos].IsNull("FOTO"))
                {
                    byte[] img = (byte[])familiaresDT.Rows[rowpos]["FOTO"];
                    pictureBox1.Image = byteArrayToImage(img);
                }
                else
                { pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible; }

                textBox14.Text = familiaresDT.Rows[rowpos]["GIMNASIO"].ToString();



                VerificarCadeteFam();

               // VerificarNoSocioFam();

                datosContacto(maskedTextBox1.Text, maskedTextBox2.Text, maskedTextBox3.Text);

            }
           }

        private void VerificarCadeteFam()
        {
            // NUEVO, LABEL QUE DICE SI EL CADETE >3 ES MAYOR A 18 AÑOS.-

            DateTime vfecha;

            vfecha = ObtenerFecha(maskedTextbox8.Text);

            if (Convert.ToInt32(maskedTextBox3.Text) > 3)
            {
                if (DateTime.Compare(DateTime.Today, vfecha.AddYears(18)) < 0)
                {
                    lblNoSocio.Text = "";
                    lblNoSocio.BorderStyle = BorderStyle.None;
                    lblNoSocio.BackColor = Color.Transparent;
                }
                else
                {
                    lblNoSocio.Text = " CADETE MAYOR DE 18 AÑOS  ó  FEC.NACIMIENTO NO INFORMADA ";
                    lblNoSocio.BorderStyle = BorderStyle.FixedSingle;
                    lblNoSocio.BackColor = Color.Crimson;
                }
            }
            else
            {
                lblNoSocio.Text = "";
                lblNoSocio.BorderStyle = BorderStyle.None;
                lblNoSocio.BackColor = Color.Transparent;
            }
        }

        /*private void VerificarNoSocioFam()
        {
            // Ver Si es SOCIO o NO SOCIO
            //si fecha de baja informada, no es 
            if (!VGlobales.vp_esSocioTit || maskedTextbox5.Text != string.Empty || lblNoSocio.Text != string.Empty )
            {
                lblNoSocio.BorderStyle = BorderStyle.FixedSingle;
                lblNoSocio.BackColor = Color.Crimson;
                lblNoSocio.Text = " NO SOCIO " + lblNoSocio.Text;
            }
            else
            {
                lblNoSocio.BorderStyle = BorderStyle.FixedSingle;
                lblNoSocio.BackColor = Color.DarkBlue;
                lblNoSocio.Text = " ES SOCIO ";
            }
        }*/

        private void BuscarFam()
        {
            string isbarra = string.Empty;
            rowexacto = 0;

            isbarra = Ver_Barra(Socios.vp_barra.ToString());

            if (isbarra != string.Empty)
            {
                rowpos = rowexacto;   // Lo encontró
            }
        }

        private void ADQUIRIR_Click_1(object sender, EventArgs e)
        {
            
            string nombreFoto = maskedTextBox1.Text.Trim().PadLeft(5, '0');
            string sfilename = "";
            string spath = "";
            OpenFileDialog opn = new OpenFileDialog();
            //opn.FileName = nombreFoto + "-0";    OJO que hay que utilizar los botones
            opn.Filter = "JPEG|*.jpg|GIF|*.gif";
            opn.ShowDialog();
            if (opn.FileName.Length > 0)
            {
                sfilename = System.IO.Path.GetFileName(opn.FileName);
                spath = System.IO.Path.GetDirectoryName(opn.FileName);

                //MessageBox.Show(sfilename + "  " + spath);


                if (sfilename.Substring(0, 5) == nombreFoto && sfilename.Substring(5, 1) == "-"
                    && sfilename.Substring(6, 1) == maskedTextBox3.Text.Trim())
                {
                    Bitmap IMG = new Bitmap(opn.FileName);
                    pictureBox1.Image = IMG;
                    //pictureBox1.Image = resizeImage(IMG, 83, 72);
                }
                else
                {

                  if (sfilename.Substring(0, 5) == nombreFoto && sfilename.Substring(5, 1) == "-"
                    && sfilename.Substring(6, 2) == maskedTextBox3.Text.Trim().PadLeft(2, '0'))
                  {
                      Bitmap IMG = new Bitmap(opn.FileName);
                      pictureBox1.Image = IMG;
                      //pictureBox1.Image = resizeImage(IMG, 83, 72);
                  }
                  else
                  {
                      MessageBox.Show("LA FOTO SELECCIONADA NO CORRESPENDE AL FAMILIAR", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                      ADQUIRIR_Click_1(ADQUIRIR, new EventArgs());
                  }

                }
            }
         }


        
       


        // conversiones de BLOB a IMG y viceversa
        // De image a byte []:
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fotoZoom = resizeImage(pictureBox1.Image, 249, 216);

            using (FotoZoom frmFOTO = new FotoZoom())
            {
                frmFOTO.ShowDialog(this);
            }

        }

        public void msk_Fecha(object sender, EventArgs e)
        {

          string input = "1900-01-01";

          if (isadding == "SI" || isediting == "SI")
            {
                Control ctrl = (Control)sender;
                

                if (ctrl.Text.Length != 0 )
                {
                    if (IsValidDate(ctrl.Text))
                    {
                        DateTime dateTime;
                         input =  ctrl.Text.Substring(4, 4) + "-" +  // paso la fecha a formato yyyy-mm-dd 
                                  ctrl.Text.Substring(2, 2) + "-" +  // para validar 
                                  ctrl.Text.Substring(0, 2) ;
                   
                    
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
                                     // "(\\d{4})$"));
        }



        private void themedGroupBox1_Load(object sender, EventArgs e)
        {

        }

        private void txt_VerNull(object sender, EventArgs e)
        {
            if (isadding == "SI" || isediting == "SI")
            {
               
               Control ctrl = (Control)sender;
               if (ctrl.Name != "maskedTextBox3")
               {
                    if (ctrl.Text.Length == 0 || ctrl.Text == " ")
                    {
                        errorProvider1.SetError(ctrl, "DATO OBLIGATORIO - DEBE INFORMAR CAMPO ");
                        ctrl.Focus();
                        return;
                    }
                }
                else
                {
                    errorProvider1.SetError(ctrl, "");

                    if (ctrl.Name == "maskedTextBox3")  // valido existencia
                    {
                        //if ()
                        {
                            errorProvider1.SetError(ctrl, Ver_Barra(ctrl.Text));
                            if (errorProvider1.GetError(maskedTextBox3).Length != 0)
                            {
                                maskedTextBox3.Focus();
                                return;
                            }
                        }

                    }

                }
            }
        }

        public void msk_TextChanged(object sender, EventArgs e)
        {
            // Blanquea el error apenas se selecciona algo 
            Control ctrl = (Control)sender;
            errorProvider1.SetError(ctrl, "");
            int sv;
           

                    switch (ctrl.Name)
                    {
                        case "maskedTextbox7":   //F. Carnet
                            {
                                errorProvider1.SetError(comboBox2, "");
                                if (ctrl.Text.Length == 0 || ctrl.Text == "      ")
                                {
                                    comboBox2.SelectedIndex = -1;
                                    comboBox2.Enabled = false;
                                }
                                else
                                    comboBox2.Enabled = true;
                            }
                            break;
                        case "maskedTextbox5":  //F. Baja
                            {
                                errorProvider1.SetError(comboBox3, "");
                                if (ctrl.Text.Length == 0 || ctrl.Text == "      ")
                                {
                                    comboBox3.SelectedIndex = -1;
                                    comboBox3.Enabled = false;
                                }
                                else
                                    comboBox3.Enabled = true;
                            }
                            break;
                        case "maskedTextBox3":  //Categoria (Barra)
                            {
                        
                                errorProvider1.SetError(comboBox1, "");
                                if (ctrl.Text.Length == 0 || ctrl.Text == "0")
                                {
                                    comboBox1.SelectedIndex = -1;
                                    comboBox1.Enabled = false;
                                }
                                else
                                {
                                    comboBox1.Enabled = true;
                                    comboBox1.PreventDropDown = true;
                                    sv = Convert.ToInt32(ctrl.Text);
                                    if (sv > 4)
                                        sv = 4;
                                    comboBox1.SelectedValue = sv.ToString();
                                }
                            }
                            break;
                  /*      case "maskedTextbox9":
                            {
                                errorProvider1.SetError(comboBox4, "");
                                if (ctrl.Text.Length == 0 || ctrl.Text == "0")
                                {
                                    comboBox4.SelectedIndex = -1;
                                    comboBox4.Enabled = false;
                                }
                                else
                                    comboBox4.Enabled = true;
                            }
                            break; */
                        default:
                            break;

                    }
        }

        private string Ver_Barra(string pkey)
        {
            string isbarra = string.Empty;
            int drrow = 0;
            int intpkey = 0;
            int drbarra = 0;


            if ((Int32.TryParse(pkey, out intpkey) && intpkey == 0))
            {
                isbarra = "EL VALOR DE 'BARRA' NO PUEDE SER 0";
            }
            else
            {

                foreach (DataRow dr in familiaresDT.Rows)
                {

                    if (dr[2].ToString() == pkey)
                    {
                        isbarra = "EL VALOR DE 'BARRA' YA EXISTE EN OTRO FAMILIAR";
                        break;
                    }
                    drrow++;
                }

                rowexacto = drrow; //es para usarlo cuando viene por Codigo de barra o por Buscar

                if (isbarra != string.Empty && isediting == "SI")
                {
                    if (rowpos == drrow)   // es la misma fila estaría bien el valor
                    {
                        isbarra = string.Empty;
                    }
                }

                // es la ultima fila del datarow
                if (isadding == "SI")
                {
                    if (Int32.TryParse(pkey, out intpkey))
                    {
                        if (familiaresDT.Rows.Count > 0)
                        {
                            drbarra = (int)familiaresDT.Rows[familiaresDT.Rows.Count - 1]["BARRA"];
                        }
                        else
                        {
                            drbarra = 0;
                        }
                    }
                    else
                        intpkey = 0;

                    // debe ser consecutivo si es > 3 (padre, madre o esposa pueden ir despues (el primer cadete 
                    // puede que esté antes que esté alguien < 4
                    if ((drbarra != intpkey - 1) && intpkey > 4)
                        isbarra = "EL VALOR DE 'BARRA' DEBE SER CONSECUTIVO PARA VALORES MAYORES A 3";

                }
            }
            return isbarra;
        }

        // validaciones GIMNASIO
        
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox14.Text == " " || textBox14.Text.Length == 0)
            {
                errorProvider1.SetError(textBox14, "");
            }
            else
            {
                if (textBox14.Text != "N" && textBox14.Text != "S")
                {
                    errorProvider1.SetError(textBox14, "VALORES VALIDOS: N, S o BLANCO");
                    textBox14.Focus();
                    return ;
                }
                else
                    errorProvider1.SetError(textBox14, "");
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
                {
                    errorProvider1.SetError(textBox3, "");
                 /*   if (!((comboBox4.DisplayMember == "LC" && textBox3.Text == "F") ||
                          (comboBox4.DisplayMember == "LE" && textBox3.Text == "M") ||
                          (comboBox4.SelectedIndex == -1 || textBox3.Text == " ")))
                        errorProvider1.SetError(textBox3, "TIPO DE DOC. NO CORRESPONDE AL SEXO");
                    textBox3.Focus();
                    return ;*/
                }

            }
        }

        //< Modificado SEbastian 17-02-2016 hasta la 2083 


        private void GenerarCarnetLocal()


        {
            if (maskedTextbox8.Text == "" && Convert.ToInt32(maskedTextBox3.Text) > 3)
            {
                MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE NACIMIENTO");
                return;
            }
            else
            {
                if (maskedTextbox4.Text == "")
                {
                    MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                    return;
                }


                else
                {

                    // VALIDACION DE CADETE SI ES MAYOR A 18 NO SE IMPRIME
                    string v_coneccion_acces;
                    string v_provider;
                    string vcadena;
                    string vcodigobarra = "";
                    string vaux = "";
                    string vp1 = "";
                    string vp2 = "";
                    string vp3 = "";
                    string Afiliado_Beneficio = "";
                    string aar = "";
                    DateTime vfecha;
                    DateTime vvto;
                    string vpaso;
                    int TipoCarnet;

                    SOCIOS.Carnet.GeneradorCarnet genCarnet;

                    vfecha = ObtenerFecha(maskedTextbox8.Text);

                    Datos_ini ini_carnet = new Datos_ini();

                    if (Convert.ToInt32(maskedTextBox3.Text) > 3)
                    {
                        vvto = vfecha.AddYears(18);

                        if (DateTime.Compare(DateTime.Today, vvto) < 0)
                        {
                            vpaso = vvto.ToString();
                        }
                        else
                        {
                            MessageBox.Show("EL CADETE ES MAYOR A 18 AÑOS, NO SE PUEDE EMITIR CARNET");
                            return;
                        }

                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.CADETE;
                    }
                    else
                    {

                        if (maskedTextBox2.ToString() == "13")
                        {
                            TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.SOCIO_INVITADO;
                        }

                        if (maskedTextBox2.ToString() == "013")
                        {
                            TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.SOCIO_INVITADO;
                        }
                        else
                        {
                            TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.FAMILIAR;
                        }

                        vpaso = "";
                    }



                

                    // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                    if (Socios.v_par == 2)
                    {
                        vp1 = Socios.v_pcrjp1.ToString();
                        vp2 = Socios.v_pcrjp2.ToString();
                        vp3 = Socios.v_pcrjp3.ToString();
                        Afiliado_Beneficio =  vp1 + "  /  " + vp2 + "  /  " + vp3;
                    }
                    else
                    {
                        vp1 = Socios.v_acrjp1.ToString();
                        vp2 = Socios.v_acrjp2.ToString();
                        vp3 = Socios.v_acrjp3.ToString();
                        aar = Socios.v_aar.ToString();
                        Afiliado_Beneficio = vp1 + "  /  " + aar + "  /  " + vp3;
                    }

                    vcodigobarra = maskedTextBox1.Text.Trim();
                    vcodigobarra = vcodigobarra.PadLeft(6, '0');
                    vcodigobarra = vcodigobarra + maskedTextBox2.Text.Trim().PadLeft(3, '0');
                    vaux = maskedTextBox3.Text.Trim();
                    vaux = vaux.PadLeft(2, '0');
                    vcodigobarra = vcodigobarra + vaux;
                    
                    
                    
                    string NroSocio = maskedTextBox1.Text;
                    string Nombre = textBox2.Text;
                    string Apellido = textBox1.Text;
                    string Documento = maskedTextBox9.Text;
                    string Vencimiento="";
                    string Fecha = maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4);
                    vcodigobarra = "F" + vcodigobarra;
                    genCarnet = new SOCIOS.Carnet.GeneradorCarnet(TipoCarnet,SOCIOS.Utils.ImagenCarnet(pictureBox1.Image));

               
             
                    if   (vpaso.Length > 0)
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





            }
        


        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Generar_Carnet_ODBC();

        }

        private void Generar_Carnet_ODBC()
        {
            if (maskedTextbox8.Text == "" && Convert.ToInt32(maskedTextBox3.Text) > 3)
            {
                MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE NACIMIENTO");
                return;
            }
            else
            {
                if (maskedTextbox4.Text == "")
                {
                    MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                    return;
                }
                else
                {
                    // VALIDACION DE CADETE SI ES MAYOR A 18 NO SE IMPRIME
                    string v_coneccion_acces;
                    string v_provider;
                    string vcadena;
                    string vcodigobarra = "";
                    string vaux = "";
                    string vp1 = "";
                    string vp2 = "";
                    string vp3 = "";
                    string aar = "";
                    DateTime vfecha;
                    DateTime vvto;
                    string vpaso;
                    vfecha = ObtenerFecha(maskedTextbox8.Text);

                    Datos_ini ini_carnet = new Datos_ini();

                    if (Convert.ToInt32(maskedTextBox3.Text) > 3)
                    {
                        vvto = vfecha.AddYears(18);

                        if (DateTime.Compare(DateTime.Today, vvto) < 0)
                        {
                            vpaso = vvto.ToString();
                        }
                        else
                        {
                            MessageBox.Show("EL CADETE ES MAYOR A 18 AÑOS, NO SE PUEDE EMITIR CARNET");
                            return;
                        }

                        v_coneccion_acces = ini_carnet.Vcarnet_cadete;

                        if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                        {
                            v_coneccion_acces = ini_carnet.Vcarnet_metro;
                        }
                        else if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                        {
                            v_coneccion_acces = ini_carnet.Vcarnet_adh_interfuerza_cad;
                        }
                    }
                    else
                    {

                        if (maskedTextBox2.Text == "13" || maskedTextBox2.Text == "013")
                        {
                            v_coneccion_acces = ini_carnet.Vcarnet_socio_invitado;
                        }
                        else if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                        {
                            v_coneccion_acces = ini_carnet.Vcarnet_metro;
                        }
                        else if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                        {
                            v_coneccion_acces = ini_carnet.Vcarnet_adh_interfuerza_fam;
                        }
                        else
                        {
                            v_coneccion_acces = ini_carnet.Vcarnet_familiar;
                        }

                        vpaso = "";
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
                        aar = Socios.v_aar.ToString();
                    }

                    vcodigobarra = maskedTextBox1.Text.Trim();
                    vcodigobarra = vcodigobarra.PadLeft(6, '0');
                    vcodigobarra = vcodigobarra + maskedTextBox2.Text.Trim().PadLeft(3, '0');
                    vaux = maskedTextBox3.Text.Trim();
                    vaux = vaux.PadLeft(2, '0');
                    vcodigobarra = vcodigobarra + vaux;

                    string IDCf_altci = maskedTextbox4.Text.Substring(2, 2) + "/" + maskedTextbox4.Text.Substring(4, 4);
                    string IDCBarCodeField1 = "F" + vcodigobarra;
                    string IDCnro_soc = maskedTextBox1.Text.Trim();
                    string IDCape_soc = textBox1.Text.Trim();
                    string IDCNOM_SOC = textBox2.Text.Trim();
                    string IDCnro_doc = maskedTextBox9.Text;
                    string IDCTIP_DOC = "DNI";
                    string IDCNRO_DEP = maskedTextBox2.Text;

                    if (Convert.ToInt32(maskedTextBox3.Text) > 3) //SI ES MAYOR A 3 SON HIJOS
                    {
                        string VTO = vpaso.ToString().Replace(" 12:00:00 a.m.", "");
                        string D_VTO = VTO.Substring(0, 2);
                        string M_VTO = VTO.Substring(3, 2);
                        string A_VTO = VTO.Substring(8, 2);
                        string VTO_FINAL_MET = "VTO:" + D_VTO + "/" + M_VTO + "/" + A_VTO;
                        string VTO_FINAL = D_VTO + "/" + M_VTO + "/" + A_VTO;

                        vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCsbarra, IDCvto) ";
                        vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + vp1 + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "','" + VTO_FINAL + "')";

                        if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                        {
                            vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCsbarra, IDCvto1, IDCNRO_DEP) ";
                            vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + aar + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "', '" + VTO_FINAL_MET + "', '" + IDCNRO_DEP + "')";
                        }

                        if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                        {
                            vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCsbarra, IDCvto, IDCEmpleado) ";
                            vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + aar + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "', '" + VTO_FINAL_MET + "', '"+VGlobales.ID_EMPLEADO+"')";
                        }
                    }
                    else
                    {
                        vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCsbarra) ";
                        vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + vp1 + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "')";

                        if (maskedTextBox2.Text == "13" || maskedTextBox2.Text == "013")
                        {
                            vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCbarr_1) ";
                            vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + vp1 + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "')";
                        }

                        if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                        {
                            vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCsbarra, IDCNRO_DEP) ";
                            vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + aar + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "', '" + IDCNRO_DEP + "')";
                        }

                        if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                        {
                            vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCsbarra, IDCEmpleado) ";
                            vcadena += " VALUES ('" + IDCf_altci + "', '" + IDCBarCodeField1 + "', '" + IDCnro_soc + "','" + IDCape_soc + "','" + IDCNOM_SOC + "', '" + IDCnro_doc + "', '" + IDCTIP_DOC + "', '" + aar + "', '" + vp2 + "', '" + vp3 + "', ?, '" + vaux + "', '" + VGlobales.ID_EMPLEADO + "')";
                        }
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
        }

        // Modificado SEbastian 17-02-2016 >


        private void Actualizar_F_Carnet()
        {
            // GRABAMOS EN LA BASE.-

            string connectionString;

            Datos_ini ini2 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
            cs.Database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            using (FbConnection connection = new FbConnection(connectionString))
            {
                string vcomando;

                vcomando = "UPDATE FAMILIAR SET  F_CARFAM=CURRENT_DATE WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                vcomando = vcomando + " AND BARRA = " + maskedTextBox3.Text;

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
                familiaresDT.Rows[rowpos]["F_CARFAM"] = maskedTextbox7.Text;
            }
        }
        
    }
}