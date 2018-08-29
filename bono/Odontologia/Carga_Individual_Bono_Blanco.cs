using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Odontologia
{
    public partial class Carga_Individual_Bono_Blanco : Form
    {
        private int ID = 0;
        private int ID_ROL = 0;
        private int SecAct = 0;
        private int Profesional = 0;
        private int Nro_Soc;
        private int Nro_Dep;
        private int Barra;
        private int Nro_Soc_Tit;
        private int Nro_Dep_Tit;

        public Carga_Individual_Bono_Blanco(int pID,int pIdRol, int pSecAct,int pProfesional)
        {
            InitializeComponent();
            ID = pID;
            ID_ROL = pID;
            SecAct = pSecAct;
            Profesional = pProfesional;
            lbInfo.Text = "CARGA DE BONO ID : " + pIdRol.ToString();
        }

        private void btn_Carga_Bono_Click(object sender, EventArgs e)
        {
            this.Validar();
            BonoOdontologico b = new BonoOdontologico(Nro_Soc.ToString(), Nro_Dep.ToString(), Barra.ToString(), Nro_Soc_Tit.ToString(), Nro_Dep_Tit.ToString(), SecAct, 0, false, "");
            b.ID_REGISTRO = ID;
            b.BONO_BLANCO = true;
            b.ID_ROL = ID_ROL;
            b.idProfesional = Profesional;
            b.ShowDialog();

        }

        private void Validar()

        { try {

            if (tbNroSoc.Text.Length > 0)
            {
                Nro_Soc = Int32.Parse(tbNroSoc.Text);
            }
            else
                throw new Exception("Debe ingresar Nro de Socio");
            if (tbNroDep.Text.Length > 0)
            {
                Nro_Dep = Int32.Parse(tbNroDep.Text);
            }
            else
                throw new Exception("Debe ingresar Nro de Depuracion");
            if (tbBarra.Text.Length > 0)
            {
                Barra = Int32.Parse(tbBarra.Text);
            }
            else
                throw new Exception("Debe ingresar Barra");
              if (tbSocTitular.Text.Length > 0)
            {
                Nro_Soc_Tit = Int32.Parse(tbSocTitular.Text);
            }
              else
                  throw new Exception("Debe ingresar Nro de Socio Titular");

              if (tbDepTitular.Text.Length > 0)
              {
                  Nro_Dep_Tit = Int32.Parse(tbDepTitular.Text);
              }
              else
                  throw new Exception("Debe ingresar Nro de Depuracion Titular");


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        }
    }
}
