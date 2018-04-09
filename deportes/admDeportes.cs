using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using System.IO;
using System.Globalization;
using  ImageResizer;


namespace SOCIOS
{
    public partial class admDeportes : Form
    {
        bo_Deportes dlog = new bo_Deportes();

        Socios socios;
        Image imagen_defecto;
        int ID_ROL = 0;
        string ROL = "";
        bool SoloVista=false;
        int ID_REGISTRO = 0;
        
        bool  Copio_Apto = false;
        List<SOCIOS.deportes.Registro_Responsables> Responsables = new List<deportes.Registro_Responsables>();
        DateTime fecha_Apto;
        deportes.DeportesService ds = new deportes.DeportesService();

        private string Num_Doc_Titular="";
        private string Num_Tel_Titular = "";
        private string AF_Ben_Titular = "";
        public admDeportes(string var_NombreTabla, string var_Numero, string var_Depuracion, string var_Barra, string var_Numero_Titular, string var_Depuracion_Titular, int var_Id_Socio, string DNI, string var_Nombre, string var_Apellido, Image imagenTitular, string var_Role,int ID,bool pCopioApto,DateTime? pFechaApto)
        {

            //INICIALIZO VARIABLES Y COMBOS

            InitializeComponent();

            ns = new nombreSocio();
            ts = new tipoSocio();
            ee = new edad();
            
            btnGrabar.Enabled = true;
            btnActividades.Enabled = true;
            btnGrabar.Enabled = true;

            SOCIOS.COD_DTO dto = new SOCIOS.COD_DTO();
            socios = new Socios();

            pictureBox.Image = SOCIOS.Properties.Resources.fotonodisponible;
            nro_dep = int.Parse(var_Depuracion);
            nro_soc = int.Parse(var_Numero);
            barra = int.Parse(var_Barra);
            tipo_soc = var_NombreTabla.Substring(0, 3);
            lbTipoSocio.Text = tipo_soc;
            apellido = var_Apellido;
            nombre = var_Nombre;
            lbNombre.Text = var_Apellido + "," + var_Nombre;
            Nombre = var_Nombre;
            Apellido = var_Apellido;
            lbDni.Text = DNI;
            tabla = var_NombreTabla;
            titular_soc = var_Numero_Titular;
            titular_dep = var_Depuracion_Titular;
           // var_Id_Socio = Int32.Parse(titular_soc + titular_dep);
            
            titular_id = var_Id_Socio;
            num_doc = DNI;
            ROL = var_Role;
            adherente_id = 0;
            COD_DTO = dto.getCodigoDTO(nro_soc.ToString(), nro_dep.ToString(), var_NombreTabla);
            idsoc = var_Id_Socio;
            imagen_defecto = imagenTitular;
            //copio foto y fecha de apto
            
            if (pCopioApto && pFechaApto!=null)
            {
                Copio_Apto = true;
                fecha_Apto = pFechaApto.Value;

              
            }
            
            //Comprobacion y limpieza Directory Carnets
            SOCIOS.Carnet.Utils.InicializarDirectorioCarnet("C://CSPFA_SOCIOS//TMP_CARNET//");
            //Combos
            this.ComboCarnet();
            this.CombosMora();
            this.ComboFormaPago();

            //Cargo Datos Sociales y De Deportes
    
            
            DatosSociales();
            Datos_Titular();

            if (ID == 0)
                DatosDeportes();
            else
                DatosDeportes(ID);
            
            ArmoCodigoBarra();
            //Carga dtTipoCarnet
            this.Setear_Vista_Fecha_Carnet();
            
            Responsables = ds.Get_Responsables(ID_ROL,ROL);





        }


      




        #region Locales



        private int ID;
        public int _id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private int IDPDF;
        public int _idpdf
        {
            get
            {
                return _idpdf;
            }
            set
            {
                _idpdf = value;
            }
        }


        private string Mode;
        public int _mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        private string nombre;
        public int _nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        private string apellido;
        public int _apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }


        private int idsoc;
        public int _idsoc
        {
            get
            {
                return idsoc;
            }
            set
            {
                idsoc = value;
            }
        }

        private int nro_soc;
        public int _nro_soc
        {
            get
            {
                return nro_soc;
            }
            set
            {
                nro_soc = value;
            }
        }

        private int nro_dep;
        public int _nro_dep
        {
            get
            {
                return nro_dep;
            }
            set
            {
                nro_dep = value;
            }
        }

        private int barra;
        public int _barra
        {
            get
            {
                return barra;
            }
            set
            {
                barra = value;
            }
        }

        private int titular_id;
        public int _titular_id
        {
            get
            {
                return titular_id;
            }
            set
            {
                titular_id = value;
            }
        }
        public string Codigo_Barra;
        public string _Codigo_Barra
        {
            get
            {
                return Codigo_Barra;
            }
            set
            {
                Codigo_Barra = value;
            }
        }
        public int adherente_id;
        public int _adherente_id
        {
            get
            {
                return adherente_id;
            }
            set
            {
                adherente_id = value;
            }
        }


        private string numero_doc;
        public string _numero_doc
        {
            get
            {
                return numero_doc;
            }
            set
            {
                numero_doc = value;
            }
        }


        private string titular_dep;
        public string _titular_dep
        {
            get
            {
                return titular_dep;
            }
            set
            {
                titular_dep = value;
            }
        }

        private string titular_soc;
        public string _titular_soc
        {
            get
            {
                return titular_soc;
            }
            set
            {
                titular_soc = value;
            }
        }


        private string tipo_soc;
        public string _tipo_soc
        {
            get
            {
                return tipo_soc;
            }
            set
            {
                tipo_soc = value;
            }
        }



        private string num_doc;
        public string _num_doc
        {
            get
            {
                return num_doc;
            }
            set
            {
                num_doc = value;
            }
        }

        private string tabla;
        public string _tabla
        {
            get
            {
                return tabla;
            }
            set
            {
                tabla = value;
            }
        }

        private string categoria_social;
        public string _categoria_social
        {
            get
            {
                return categoria_social;
            }
            set
            {
                categoria_social = value;
            }
        }

        private nombreSocio ns;
        internal nombreSocio _ns
        {
            get
            {
                return ns;
            }
            set
            {
                ns = value;
            }

        }
        private tipoSocio ts;

        internal tipoSocio _ts
        {
            get { return ts; }
            set { ts = value; }
        }

        private edad ee;

        internal edad _ee
        {
            get { return ee; }
            set { ee = value; }
        }


        private string Nombre;
        public string _Nombre
        {
            get
            {
                return Nombre;
            }
            set
            {
                Nombre = value;
            }
        }

        private string Apellido;
        public string _Apellido
        {
            get
            {
                return Apellido;
            }
            set
            {
                Apellido = value;
            }
        }

        private string COD_DTO;
        public string _COD_DTO
        {
            get
            {
                return COD_DTO;
            }
            set
            {
                COD_DTO = value;
            }
        }






        #endregion

        #region Funciones







        private void SetVencimiento()
        {
            DateTime fecha = dpApto.Value.AddYears(1);
            lbVencimiento.Text = fecha.ToShortDateString();
        }



        #endregion

        #region Datos
        private void ArmoCodigoBarra()
        {
            Codigo_Barra = "D0" + ID.ToString("00000000");



            //switch (tabla)
            //{
            //    case "TITULAR":
            //        Codigo_Barra ="T0" + nro_soc.ToString("00000") + nro_dep.ToString("000");

            //        break;

            //    case "ADHERENT":
            //        Codigo_Barra = "A0" + nro_soc.ToString("00000") + nro_dep.ToString("000") + "00";
            //        break;
            //    case "FAMILIAR":
            //        {
            //            Codigo_Barra = "F0" + nro_soc.ToString("00000") + nro_dep.ToString("000") + barra.ToString("00");

            //        }
            //        break;

            //}




        }
        private void DatosSociales()
        {


            switch (tabla)
            {
                case "TITULAR":
                    datosContacto(nro_soc.ToString(), nro_dep.ToString(), "0", tabla, "0", "0");

                    break;

                case "ADHERENT":
                    datosContacto("0", "0", barra.ToString(), tabla, nro_soc.ToString(), nro_dep.ToString());

                    break;

                case "FAMILIAR":
                    datosContacto(nro_soc.ToString(), nro_dep.ToString(), barra.ToString(), tabla, "0", "0");

                    break;
            }



            obrasocial os = new obrasocial();

            if (tabla == "TITULAR")
            {
                string[] datos = ns.NRO_SOC(nro_soc, nro_dep, "X");

                // lbNombreSocio.Text = datos[0] + ", " + datos[1];

                lbTelefono.Text = datos[2] + "-" + datos[3];

                lbEmail.Text = datos[4];

                //lbObraSocial.Text = os.nroObraSocial(int.Parse(var_Numero), int.Parse(var_Depuracion), "X");
            }
            else
            {
                string[] datos = ns.NRO_SOC(nro_soc, nro_dep, barra.ToString());

                //lbNombreSocio.Text = datos[0] + ", " + datos[1];

                lbTelefono.Text = datos[2] + "-" + datos[3];

                lbEmail.Text = datos[4];

                // lbObraSocial.Text = os.nroObraSocial(int.Parse(var_Numero), int.Parse(var_Depuracion), var_Barra);
            }








            int edad = 0;

            //Obtengo la Categoria Social

            categoria_social = ts.tipo(idsoc).Substring(0, 3);


            //SI ES FAMILIAR BARRA MAYOR A 3 (HIJO) Y YA CUMPLIO 18 AÑOS -> NO SOCIO
            if (tipo_soc == "FAM" && barra > 3)
            {
                edad = ee.FAMILIAR(idsoc, barra.ToString());

                if (edad >= 18)
                {
                    categoria_social = "005";
                }
            }

            //AVISAR SI ES VITALICIO DE ORO
            if (tipo_soc == "TIT")
            {
                edad = ee.VITALICIO_ORO(idsoc);

                if (edad >= 50)
                {
                    lbTipoSocioTitular.Text = "VITALICIO DE ORO";
                }
            }

            //EDAD
            lblEdad.Text = edad.ToString();
            //NOMBRE DEL SOCIO TITULAR
            //Obtengo el Numero

            if (tipo_soc == "ADH" || tipo_soc == "INP")
            {
                lbNombreSocioTitular.Text = ns.ADH(titular_soc, titular_dep);
                lbTipoSocioTitular.Text = "TITULAR";

            }
            else
            {
                lbNombreSocioTitular.Text = ns.TIT(idsoc);
                lbTipoSocioTitular.Text = ts.tipo(idsoc);

            }
            //Nro Socio , si es titular/fliar o adherente
            if (tipo_soc == "TIT" || tipo_soc == "FAM")
            {

                lbNroSocTitular.Text = nro_soc.ToString() + " - " + nro_dep.ToString();

            }
            else
            {
                lbNroSocTitular.Text = titular_soc.ToString() + " - " + titular_dep.ToString();
            }

            //NOMBRE SOCIO 
            // lblNombre.Text = Apellido + "," + Nombre;








        }
        public void datosContacto(string NRO_SOC, string NRO_DEP, string BARRA, string TIPO, string NRO_ADH, string DEP_ADH)
        {
            bo dlog = new bo();

            string query = "";


            lbTipoSocio.Text = TIPO;
            switch (TIPO)
            {
                case "TITULAR":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0 AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";

                    break;

                case "ADHERENT":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_ADH = " + NRO_ADH + " AND DEP_ADH = " + DEP_ADH + " AND BARRA = " + BARRA + " AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
                    lbTipoSocio.Text = "ADHERENTE";
                    this.getIdAdherente(NRO_ADH, DEP_ADH, BARRA);

                    break;

                case "FAMILIAR":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA + " AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
                    break;

                case "EMPLEADO":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0 AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
                    break;
            }

            //MessageBox.Show(query);

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                tbTelefonoContacto.Text = foundRows[0][5].ToString();
                lblEmailContacto.Text = foundRows[0][4].ToString();
                //tbObraSocialContacto.Text = foundRows[0][7].ToString();

            }
        }


        private void Datos_Titular()

        {

            switch (tabla)
            {
                case "TITULAR":
                datos_Titular(nro_soc.ToString(), nro_dep.ToString(), "0", tabla, "0", "0");

                    break;

                case "ADHERENT":
                    datos_Titular("0", "0", barra.ToString(), tabla, nro_soc.ToString(), nro_dep.ToString());

                    break;

                case "FAMILIAR":
                    datos_Titular(nro_soc.ToString(), nro_dep.ToString(), barra.ToString(), tabla, "0", "0");

                    break;
            }
        
        }

        public void datos_Titular(string NRO_SOC, string NRO_DEP, string BARRA, string TIPO, string NRO_ADH, string DEP_ADH)
        {
            bo dlog = new bo();

            string query = "";


            lbTipoSocio.Text = TIPO;
            switch (TIPO)
            {
                case "TITULAR":
                    query = "SELECT NUM_DOC,AAR,ACRJP2,Car_te1,num_te1 from Titular WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0;";

                    break;

                case "ADHERENT":
                    query = "SELECT NUM_DOC,AAR,ACRJP2,Car_te1,num_te1 from  adherent WHERE NRO_ADH = " + NRO_ADH + " AND DEP_ADH = " + DEP_ADH + " AND BARRA = " + BARRA + " AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
                    lbTipoSocio.Text = "ADHERENTE";
                    this.getIdAdherente(NRO_ADH, DEP_ADH, BARRA);

                    break;

                case "FAMILIAR":
                    query = "SELECT NUM_DOC,AAR,ACRJP2,Car_te1,num_te1 from Familiar WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0;";
                    break;

                case "EMPLEADO":
                    query = "SELECT NUM_DOC,AAR,ACRJP2,Car_te1,num_te1 from Titular WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0;";
                    break;
            }

            //MessageBox.Show(query);

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                Num_Doc_Titular = foundRows[0][0].ToString();
                Num_Tel_Titular = foundRows[0][3].ToString() +foundRows[0][4].ToString();
                AF_Ben_Titular = foundRows[0][1].ToString() + foundRows[0][2].ToString();

                //tbObraSocialContacto.Text = foundRows[0][7].ToString();

            }
        }


        private void DatosDeportes()
        {

            Byte[] byteBLOBData1 = new Byte[0];
            DateTime MORA;

            string Query = "SELECT  ID,FE_APTO,FE_CARNET, TIPO_CARNET,MOROSO,FOTO,POC,COALESCE(MONTOMORA,0) MONTOMORA,COALESCE(A_MORA,'') A_MORA,EMAIL,OBS,ROL,ID_ROL,FE_BAJA, DIRECCION FROM   DEPORTES_ADM" +
              " WHERE      coalesce(FE_BAJA,'1') = '1' AND  NRO_DEP= " + nro_dep.ToString() + "AND NRO_SOCIO = " + nro_soc.ToString() + " AND BARRA= " + barra.ToString() + " AND ROL ='" + ROL + "'";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {
                ID = Int32.Parse(foundRows[0][0].ToString().Trim());
                if (foundRows[0][1].ToString().Length >1)
                   dpApto.Value = DateTime.Parse(foundRows[0][1].ToString().Trim());

                if (foundRows[0][2].ToString().Length >1)
                   dpCarnet.Value = DateTime.Parse(foundRows[0][2].ToString().Trim());
                
                 

                cbCarnet.SelectedValue = foundRows[0][3].ToString().Trim();


                cbMora.SelectedValue = foundRows[0][4].ToString().Trim();
                cbMora.SelectedIndex = Int32.Parse(foundRows[0][4].ToString().Trim());




                if (foundRows[0][5].ToString().Length != 0)
                {
                    byteBLOBData1 = (byte[])foundRows[0][5];
                    MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                    pictureBox.Image = Image.FromStream(stmBLOBData1);
                }

                cbPago.SelectedValue = foundRows[0][6].ToString().Trim();

                tbMoraMonto.Text = decimal.Parse(foundRows[0][7].ToString().Trim()).ToString();
                if (foundRows[0][8].ToString().Length != 0)
                {
                    MORA = DateTime.Parse(foundRows[0][8].ToString());
                    cbMoraAnio.SelectedValue = MORA.Year;
                    cbMoraMes.SelectedValue = MORA.Month;

                }


                if (foundRows[0][9].ToString().Length != 0)
                {
                    tbMail.Text = foundRows[0][9].ToString();


                }
                if (foundRows[0][10].ToString().Length != 0)
                {
                    tbObs.Text = foundRows[0][10].ToString();


                }

                if (foundRows[0][11].ToString().Length != 0)
                {
                    lbROL.Text = foundRows[0][11].ToString();


                }

                if (foundRows[0][14].ToString().Length != 0)
                {
                    tbDireccion.Text = foundRows[0][14].ToString();
                }

                ID_ROL = Int32.Parse(foundRows[0][12].ToString());
                ROL = foundRows[0][11].ToString();
                
                Mode = "UPDATE";

                lblEstado.Text = "Se modificarán los datos ya cargados ,esta persona ya se encuentra asociada a Deportes";
                lblEstado.Visible = true;
                btnActividades.Visible = true;
                btnCarnet.Visible = true;

                if (VGlobales.vp_role.StartsWith("CPO") && lbROL.Text.Trim() != VGlobales.vp_role)
                    btnGrabar.Enabled = false;
                else
                    btnGrabar.Enabled = true;


                btnBaja.Visible = true;

               


            }
            else
            {
                Mode = "INSERT";
                pictureBox.Image = imagen_defecto;
                btnBaja.Visible = false;
               
                if (Copio_Apto)
                {
                    dpApto.Value = fecha_Apto;
                    dpApto.Visible = true;
                }

             DialogResult dr =    MessageBox.Show("Va a Generar un registro  de deportes con el ROL " + ROL,"Confirmar",MessageBoxButtons.YesNo);
             if (dr == DialogResult.No)
             {
                 this.Close();
             }
            }

            this.SetVencimiento();


            if (SoloVista)
            {
                btnBaja.Visible = false;
                btnActividades.Enabled = false;
                btnGrabar.Enabled = false;
                Ficha.Enabled = false;
            }


        }


        private void DatosDeportes(int ID)
        {

            Byte[] byteBLOBData1 = new Byte[0];
            DateTime MORA;
            bool Baja = false;

            string Query = "SELECT  ID,FE_APTO,FE_CARNET, TIPO_CARNET,MOROSO,FOTO,POC,COALESCE(MONTOMORA,0) MONTOMORA,COALESCE(A_MORA,'') A_MORA,EMAIL,OBS,ROL,ID_ROL,FE_BAJA FROM   DEPORTES_ADM" +
              " WHERE       ID = " + ID.ToString();

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {
                ID_REGISTRO = Int32.Parse(foundRows[0][0].ToString().Trim());
                if (foundRows[0][1].ToString().Trim().Length > 0)
                {
                    dpApto.Value = DateTime.Parse(foundRows[0][1].ToString().Trim());
                    cbApto.Checked = true;
                    dpApto.Visible=true;
                }
                else
                {
                    cbApto.Checked = false;
                    dpApto.Value = System.DateTime.Now;
                
                }

                if (foundRows[0][2].ToString().Length > 1)
                    dpCarnet.Value = DateTime.Parse(foundRows[0][2].ToString().Trim());

               
                cbCarnet.SelectedValue = foundRows[0][3].ToString().Trim();


                cbMora.SelectedValue = foundRows[0][4].ToString().Trim();
                cbMora.SelectedIndex = Int32.Parse(foundRows[0][4].ToString().Trim());




                if (foundRows[0][5].ToString().Length != 0)
                {
                    byteBLOBData1 = (byte[])foundRows[0][5];
                    MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                    pictureBox.Image = Image.FromStream(stmBLOBData1);
                }

                cbPago.SelectedValue = foundRows[0][6].ToString().Trim();

                tbMoraMonto.Text = decimal.Parse(foundRows[0][7].ToString().Trim()).ToString();
                if (foundRows[0][8].ToString().Length != 0)
                {
                    MORA = DateTime.Parse(foundRows[0][8].ToString());
                    cbMoraAnio.SelectedValue = MORA.Year;
                    cbMoraMes.SelectedValue = MORA.Month;

                }


                if (foundRows[0][9].ToString().Length != 0)
                {
                    tbMail.Text = foundRows[0][9].ToString();


                }
                if (foundRows[0][10].ToString().Length != 0)
                {
                    tbObs.Text = foundRows[0][10].ToString();


                }

                if (foundRows[0][11].ToString().Length != 0)
                {
                    lbROL.Text = foundRows[0][11].ToString();


                }

                ID_ROL = Int32.Parse(foundRows[0][12].ToString());
                ROL = foundRows[0][11].ToString();

                if (foundRows[0][13].ToString().Length > 0)

                {
                    Baja = true;
                
                }



                Mode = "UPDATE";
                lblEstado.Text = "Se modificarán los datos ya cargados ,esta persona ya se encuentra asociada a Deportes";
                lblEstado.Visible = true;
                btnActividades.Visible = true;
                btnCarnet.Visible = true;
                Ficha.Visible = true;


                if (VGlobales.vp_role.StartsWith("CPO") && lbROL.Text.Trim() != VGlobales.vp_role)
                    btnGrabar.Enabled = false;
                else
                    btnGrabar.Enabled = true;


                btnBaja.Visible = true;




            }
            else
            {
                Mode = "INSERT";
                pictureBox.Image = imagen_defecto;
                btnBaja.Visible = false;
                MessageBox.Show("Va a Generar un registro  de deportes con el ROL " + ROL);

            }

            this.SetVencimiento();


            if (Baja)
            {
                btnBaja.Visible = false;
                btnActividades.Enabled = false;
                btnGrabar.Enabled = false;
            }
            else
            {
                btnBaja.Visible        = true;
                btnActividades.Enabled = true;
                btnGrabar.Enabled      = true;
            
            }


        }


        private void getIDdeportes()
        {
            string Query = "SELECT  max(ID_ROL) FROM  DEPORTES_ADM" +
              " WHERE NRO_DEP= " + nro_dep.ToString() + "AND NRO_SOCIO = " + nro_soc.ToString() + " AND BARRA= " + barra.ToString() + " AND ROL='" +VGlobales.vp_role.TrimEnd() +"'";
            DataRow[] foundRows;


            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {
                ID = Int32.Parse(foundRows[0][0].ToString().Trim());
            }



        }

        private void getID_ROL_deportes()
        {
            string Query = "SELECT  ID_ROL FROM  DEPORTES_ADM" +
              " WHERE NRO_DEP= " + nro_dep.ToString() + "AND NRO_SOCIO = " + nro_soc.ToString() + " AND BARRA= " + barra.ToString() + " AND ROL='" + VGlobales.vp_role.TrimEnd() + "'";
            DataRow[] foundRows;


            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {
                ID = Int32.Parse(foundRows[0][0].ToString().Trim());
            }



        }
        private void getIdAdherente(string NRO_ADH, string DEP_ADH, string BARRA)
        {
            string Query = "SELECT ID_ADHERENTE FROM ADHERENT WHERE  NRO_ADH = " + NRO_ADH + "   AND NRO_DEPADH  = " + DEP_ADH + " AND BARRA = " + BARRA;

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();

            if (foundRows.Length > 0)
            {
                adherente_id = Int32.Parse(foundRows[0][0].ToString());
            }



        }
        #endregion
        #region Botones y Combos


        private void ComboCarnet()
        {
            string query = "SELECT ID,DESCRIPCION FROM CARNET_DEPORTE;";

            cbCarnet.DataSource = null;
            cbCarnet.Items.Clear();
            cbCarnet.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCarnet.DisplayMember = "DESCRIPCION";
            cbCarnet.ValueMember = "ID";
            cbCarnet.SelectedItem = 1;


        }

        #region Combo Mora
        public class ItemCombo
        {
            public int ID { get; set; }
            public string Texto { get; set; }
            public ItemCombo(int id, string texto)
            {

                ID = id;
                Texto = texto;
            }

        }
        public class ItemComboString
        {
            public string ID { get; set; }
            public string Texto { get; set; }
            public ItemComboString(string id, string texto)
            {

                ID = id;
                Texto = texto;
            }

        }

        private void CombosMora()
        {
            List<ItemCombo> lista = new List<ItemCombo>();
            lista.Add(new ItemCombo(0, "NO"));
            lista.Add(new ItemCombo(1, "SI"));

            cbMora.Items.Clear();
            cbMora.DisplayMember = "Texto";
            cbMora.ValueMember = "ID";
            cbMora.DataSource = lista;
            cbMora.SelectedItem = 1;



            //Meses

            DateTime hoy = System.DateTime.Now;

            List<ItemCombo> listaMeses = new List<ItemCombo>();

            for (int i = 1; i <= 12; i++)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

                listaMeses.Add(new ItemCombo(i, monthName.ToUpper()));



            }

            cbMoraMes.Items.Clear();
            cbMoraMes.DisplayMember = "Texto";
            cbMoraMes.ValueMember = "ID";
            cbMoraMes.DataSource = listaMeses;
            cbMoraMes.SelectedItem = hoy.Month;

            //Anios

            List<ItemCombo> listaAnios = new List<ItemCombo>();

            listaAnios.Add(new ItemCombo(hoy.AddYears(-1).Year, hoy.AddYears(-1).Year.ToString()));
            listaAnios.Add(new ItemCombo(hoy.Year, hoy.Year.ToString()));
            listaAnios.Add(new ItemCombo(hoy.AddYears(+1).Year, hoy.AddYears(+1).Year.ToString()));

            cbMoraAnio.Items.Clear();
            cbMoraAnio.DisplayMember = "Texto";
            cbMoraAnio.ValueMember = "ID";
            cbMoraAnio.DataSource = listaAnios;
            cbMoraAnio.SelectedItem = hoy.Year;

            //MONTO
            tbMoraMonto.Text = "0";

        }

        private void ComboFormaPago()
        {
            string query = "SELECT ID,DETALLE FROM FORMAS_DE_PAGO_DEPORTES;";

            cbPago.DataSource = null;
            cbPago.Items.Clear();
            cbPago.DataSource = dlog.BO_EjecutoDataTable(query);
            cbPago.DisplayMember = "DETALLE";
            cbPago.ValueMember = "ID";
            cbPago.SelectedItem = 1;


        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DateTime? fechaApto = null;
            DateTime? fechaCarnet = null;
            DateTime? Vencimiento = null;
            if (cbApto.Checked)
            {
                fecha_Apto = DateTime.Parse(dpApto.Text);
                Vencimiento = DateTime.Parse(lbVencimiento.Text);
            }
            
            DateTime fechaActual = System.DateTime.Now;
            DateTime? fechaMora = null;
            decimal monto = decimal.Parse(tbMoraMonto.Text);


            
            //si tiene mora marcar fecha mora, sino fecha en null
            if (lbMoraAnio.Visible == true)
                fechaMora = new DateTime(Int32.Parse(cbMoraAnio.SelectedValue.ToString()), Int32.Parse(cbMoraMes.SelectedValue.ToString()), 1);

            int TipoCarnet = Int32.Parse(cbCarnet.SelectedValue.ToString());
            int Moroso = Int32.Parse(cbMora.SelectedValue.ToString());
            
            string FormaPago = cbPago.SelectedValue.ToString();

            string Mail = "";

            if (tbMail.Text.Length > 0)
                Mail = tbMail.Text;
            else if ((lblEmailContacto.Text.Length > 0) && !(lblEmailContacto.Text.Contains("NO DISPONIBLE")))
                Mail = lblEmailContacto.Text;
            else if ((lbEmail.Text.Length > 0) && !(lbEmail.Text.Contains("NO DISPONIBLE")))
                Mail = lbEmail.Text;

            // 13-09 Fecha Carnet y Fecha De Vencimiento. todo en null dado el caso

            if (TipoCarnet !=4)
                fechaCarnet = DateTime.Parse(dpCarnet.Text);

            


            try
            {
                if (Mode == "INSERT")
                {

                    ID = dlog.InsertDeportes(titular_id, barra, adherente_id, fecha_Apto,fechaCarnet, TipoCarnet, Moroso, fechaActual, VGlobales.vp_username, nro_soc, nro_dep, num_doc, Vencimiento, socios.imageToByteArray(pictureBox.Image), FormaPago, monto, fechaMora, nombre, apellido, Mail, tbObs.Text, VGlobales.vp_role, dlog.Proximo_ID(VGlobales.vp_role),tbDireccion.Text);
                    
                    lblEstado.Text = "REGISTRO GRABADO CON EXITO!";
                    Mode = "UPDATE";
                    this.getIDdeportes();

                }
                else
                {
                    dlog.UpdateDeportes(ID_REGISTRO, titular_id, barra, adherente_id, fecha_Apto, fechaCarnet, TipoCarnet, Moroso, fechaActual, VGlobales.vp_username, nro_soc, nro_dep, num_doc, Vencimiento, socios.imageToByteArray(pictureBox.Image), FormaPago, monto, fechaMora, nombre, apellido, Mail, tbObs.Text,tbDireccion.Text);
                    this.getID_ROL_deportes();
                    
                    lblEstado.Text = "REGISTRO GRABADO CON EXITO!";



                }

                //grabar Responsables
                foreach (SOCIOS.deportes.Registro_Responsables rr in Responsables)
                {
                    if (rr.NUEVO)
                        dlog.Insert_Persona_Responsable(ID, rr.ROL, rr.APELLIDO, rr.NOMBRE, rr.TELEFONO, rr.EMAIL, DateTime.Parse(rr.FECHA), rr.VINCULO, rr.DNI);
                    if (rr.BORRAR)
                        dlog.Borro_Persona_Responsable(rr.ID_BASE, VGlobales.vp_username, System.DateTime.Now);

                }



                btnActividades.Visible = true;
                btnCarnet.Visible = true;
                Ficha.Visible = true;

                MessageBox.Show("REGISTRO DEPORTES GRABADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
               

            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO CARGAR EL REGISTRO DEPORTES\n" + error, "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        private void btnActividades_Click(object sender, EventArgs e)
        {


            SOCIOS.deportes.admActividades frmActividades = new deportes.admActividades(ID_ROL, lbROL.Text, categoria_social, nro_soc, nro_dep, barra, COD_DTO);
            DialogResult res = frmActividades.ShowDialog();
            

            this.DatosDeportes();

        }

        private void ADQUIRIR_Click(object sender, EventArgs e)
        {
            //string nombreFoto = maskedTextBox1.Text.Trim().PadLeft(5, '0');

            //string nombreFotoAfil = maskedTextBox7.Text.Trim() + "" + maskedTextBox6.Text.Trim();

            //string nombreFotoBenef = maskedTextBox3.Text.Trim() + "" + maskedTextBox4.Text.Trim() + "" + maskedTextBox5.Text.Trim();

            //MessageBox.Show(nombreFotoAfil);

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

                string[] split = sfilename.Split(new Char[] { '.' }); //LE SACO LA EXTENSION

                Bitmap IMG = new Bitmap(opn.FileName);

                pictureBox.Image = SOCIOS.Carnet.Utils.resizeImage(IMG, 100, 83);


            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            EjemploWebcam.Form1 frmfoto = new EjemploWebcam.Form1();
            frmfoto.ShowDialog(this);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Familiares.fotoZoom = SOCIOS.Carnet.Utils.resizeImage(pictureBox.Image, 249, 216);

            using (FotoZoom frmFOTO = new FotoZoom())
            {
                frmFOTO.ShowDialog(this);
            }
        }

        private void dpApto_ValueChanged(object sender, EventArgs e)
        {
            this.SetVencimiento();
        }

        private void VistaMora(bool ver)
        {

            if (ver)
            {
                lbMoraAnio.Visible = true;
                lbMoraMes.Visible = true;
                lbMoraMonto.Visible = true;
                tbMoraMonto.Visible = true;
                cbMoraAnio.Visible = true;
                cbMoraMes.Visible = true;


            }
            else
            {
                lbMoraAnio.Visible = false;
                lbMoraMes.Visible = false;
                lbMoraMonto.Visible = false;
                tbMoraMonto.Visible = false;
                cbMoraAnio.Visible = false;
                cbMoraMes.Visible = false;




            }

        }



        #endregion



        private void cbMora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMora.SelectedValue == null)
                return;
            if (Int32.Parse(cbMora.SelectedValue.ToString()) == 1)
                this.VistaMora(true);
            else
                this.VistaMora(false);

        }

        private void Carnet_Click(object sender, EventArgs e)
        {
            try
            {
                SOCIOS.deportes.serviceCarnet sc = new deportes.serviceCarnet();
                DateTime Fecha = DateTime.Parse(dpCarnet.Text);



                iTextSharp.text.Image foto = iTextSharp.text.Image.GetInstance(Utils.ImagenCarnet(pictureBox.Image), System.Drawing.Imaging.ImageFormat.Jpeg);

                IDPDF = IDPDF + 1;
                
                

                sc.GenerarCarnet(Fecha.Month.ToString() + '/' + Fecha.Year.ToString(), Nombre, Apellido, num_doc, ID_ROL, categoria_social, nro_soc, nro_dep, barra, COD_DTO, foto, Codigo_Barra, IDPDF, this.GetCuota(),ROL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private string GetCuota()
        {
            string Query = @"SELECT  SECTACT.DETALLE ACTIVIDAD   FROM   SOCIO_ACTIVIDADES ,PROFESIONALES,SECTACT  
                           WHERE   SOCIO_ACTIVIDADES.PROFESIONAL=PROFESIONALES.ID
                           AND     SOCIO_ACTIVIDADES.SECTACT    =   SECTACT.ID 
                           AND  SOCIO_ACTIVIDADES.ID_DEPORTE=" + ID.ToString() + @"
                           AND (SOCIO_ACTIVIDADES.F_UPDATE IS NULL
                           OR (SOCIO_ACTIVIDADES.F_UPDATE IS NOT NULL AND SOCIO_ACTIVIDADES.ESTADO=1))
                           
                           ORDER BY    ACTIVIDAD ;";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(Query).Select();

            if (foundRows.Length > 0)
            {
                return (foundRows[0][0].ToString().Trim());
            }
            else
              return "";




        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void EditarFoto_Click(object sender, EventArgs e)
        {
            // ImageResizer.ImageResizer ir = new ImageResizer.ImageResizer(pictureBox.Image);

            // DialogResult res = ir.ShowDialog();

            //   if (res == DialogResult.OK)
            // {
            //   pictureBox.Image = ir._editedImage;
            //}

        }

        private void admDeportes_Load(object sender, EventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Va a dar de Baja el Registro?", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dlog.BajaDeportes(ID);

                MessageBox.Show("Registro Dado de Baja con Exito");
                btnGrabar.Enabled = false;
                btnActividades.Enabled = false;
            }
        }

        private void cbApto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbApto.Checked)
            {
                dpApto.Visible = true;
                lblFecha.Visible = true;
                lbVencimiento.Visible = true;
            }
            else
            { dpApto.Visible = false;
              lblFecha.Visible = false;
              lbVencimiento.Visible = false;
            }
        }

        private void cbCarnet_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Setear_Vista_Fecha_Carnet();


        }
            private void Setear_Vista_Fecha_Carnet()
        {
            if (cbCarnet.Text.Contains("NO"))
            {
                lblFechaCarnet.Visible = false;
                dpCarnet.Visible = false;
            }
            else
            {
                lblFechaCarnet.Visible = true;
                dpCarnet.Visible = true;

            }
            }

            private void btn_Responsable_Click(object sender, EventArgs e)
            {
                SOCIOS.deportes.Responsables res= new SOCIOS.deportes.Responsables(Responsables);
                DialogResult dr = res.ShowDialog();
                if (dr==DialogResult.OK)
                {
                    Responsables =null;

                    Responsables = res.Lista;
                }

                
            }

            private void Ficha_Click(object sender, EventArgs e)
            {
                string Vinculo = "";

                if (barra >= 4)
                    Vinculo = "PADRE";
                else
                    Vinculo = "OTRO";

                deportes.ReporteFicha rf = new deportes.ReporteFicha(lbNombre.Text, lbDni.Text, lbNroSocio.Text, lbTelefono.Text, "", lbEmail.Text, "", "", tbObs.Text, Responsables, ID_ROL, ROL,Num_Doc_Titular,lbNombreSocioTitular.Text,Num_Tel_Titular,AF_Ben_Titular,lbNroSocTitular.Text,Vinculo);
                rf.ShowDialog();
            }

    }
}
