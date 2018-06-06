using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Bonos
{
    public partial class Bono_Blanco : Form
    {
        BonoUtils bu = new BonoUtils();
        bo_Turismo dlog = new bo_Turismo();
        public SOCIOS.bono.handlerDatosSocios srvDatosSocio;
        int Nro_Socio_titular;
        int Nro_Dep_Titular;
        int Nro_Socio;
        int Nro_Dep;
        bool YaGrabado = false;
     
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new SOCIOS.Turismo.TurismoUtils();
        public Bono_Blanco(string pSocTitular,string pdepTitular,string pSoc,string pDep)
        {
            InitializeComponent();
            
            cbCODIGOS.ValueMember = "CODIGO";
            cbCODIGOS.DisplayMember = "DES";
            cbCODIGOS.DataSource = bu.getCodigos(VGlobales.vp_role.TrimEnd().TrimStart());
           
            this.DatosTitular(pSocTitular, pdepTitular);
            Nro_Socio = Int32.Parse(pSoc);
            Nro_Dep = Int32.Parse(pDep);

        }

        private void DatosTitular(string pSocTitular, string pdepTitular)
        {
            srvDatosSocio = new handlerDatosSocios(pSocTitular, pdepTitular);

            Categoria.Text = srvDatosSocio.CAB.TipoTitular;
            nroSocio.Text = srvDatosSocio.CAB.NroSocioTitular;
            Beneficio.Text = srvDatosSocio.CAB.NroBeneficioTitular;
            Afiliado.Text = srvDatosSocio.CAB.NroAfiliadoTitular;
            Nombres.Text = srvDatosSocio.CAB.NombreTitular;
            Dni.Text = srvDatosSocio.CAB.Dni;
            Sexo.Text = srvDatosSocio.CAB.Sexo;
            domicilio.Text = srvDatosSocio.CAB.Domicilio;
            Cp.Text = srvDatosSocio.CAB.Localidad;
            Telefono.Text = srvDatosSocio.CAB.Telefonos;
            DEP.Text = srvDatosSocio.CAB.NroDepTitular;
            Nro_Socio_titular = Int32.Parse(pSocTitular);
            Nro_Dep_Titular  = Int32.Parse(pdepTitular);

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            int CODINT = Int32.Parse(cbCODIGOS.SelectedValue.ToString());



            string Nombre = this.srvDatosSocio.CAB.NOMBRE;
            string Apellido = this.srvDatosSocio.CAB.APELLIDO;
            string Dni = this.srvDatosSocio.CAB.Dni;
            string fechaNacimiento = this.srvDatosSocio.CAB.FechaNac;

            string Telefono = this.srvDatosSocio.CAB.Telefonos;
            string TIPO = "";
            if (cbCODIGOS.Text.Contains("PASAJE"))
                TIPO = "PAS";
            else if (cbCODIGOS.Text.Contains("PAQ"))
                TIPO = "PAQ";
            else
                TIPO = "HOT";
            if (YaGrabado == false)
            {
                dlog.InsertBonoTurismo(Nro_Socio_titular, Nro_Socio, Nro_Dep, Nro_Dep_Titular, 0, System.DateTime.Now, 0, 0, 0, 0, 0, 0, Nombre, Apellido, Dni, fechaNacimiento, "", Telefono, "", this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, "", "", 0, "", "", VGlobales.vp_username, TIPO, 0, 0, "", 0, VGlobales.vp_role.TrimEnd().TrimStart(), CODINT, 0,"SI",0,0);
                YaGrabado = true;
            }
            int ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), TIPO);

            //Obtener Proximo ID_ROL
           int ID_ROL = utilsTurismo.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT) + 1;

            dlog.Seteo_Id_ROL(ID, ID_ROL);


            if (TIPO =="HOT")
            {
                ReporteBonoHotel_Blanco bb = new ReporteBonoHotel_Blanco(ID_ROL, ID, System.DateTime.Now, srvDatosSocio.CAB, VGlobales.vp_role.TrimEnd().TrimStart());
                bb.ShowDialog();

            }
            else if (TIPO == "PAQ")
            {
                ReporteBonoPaquete_Blanco bp = new ReporteBonoPaquete_Blanco(ID_ROL, ID, System.DateTime.Now, srvDatosSocio.CAB, VGlobales.vp_role.TrimEnd().TrimStart());
                bp.ShowDialog();
            }
            else if (TIPO == "PAS")
            {
                ReporteBonoPasaje_Blanco bp = new ReporteBonoPasaje_Blanco(ID_ROL, ID, System.DateTime.Now, srvDatosSocio.CAB, VGlobales.vp_role.TrimEnd().TrimStart());
                bp.ShowDialog();
            }
            
        }
    }
}
