using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Factura_Electronica
{      
    public partial class PARCHE_RECIBOS : Form
    {
        int recibo_id; 
        
        public PARCHE_RECIBOS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int CANTIDAD = 1;
            maxid mid = new maxid();
            BO.bo_Caja BO_CAJA = new BO.bo_Caja();
            BO.BO_Afip BO_AFIP = new BO.BO_Afip();


            //2341 
            recibo_id= int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301159, 100207, 12, 7017012, 2645, "1", "CSAAVEDRA", 120,
                               "SILVA, NAHUEL ALEJANDRO", "005", "Generado Automaticamente sistemas", "24/07/2019", 0,
                               "SILVA, NAHUEL ALEJANDRO", "32615466", "ACTIVO", 4701, "0025", 0,
                               "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id,23,226, "69093744890005", "20190310", 1,0);
   
            ////2341 
            //recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;


                recibo_id= int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301159, 100207, 12, 7017012, 2645, "1", "CSAAVEDRA", 120,
                               "SILVA, NAHUEL ALEJANDRO", "005", "Generado Automaticamente sistemas", "24/07/2019", 0,
                               "SILVA, NAHUEL ALEJANDRO", "32615466", "ACTIVO", 4702, "0025", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id,23, 227, "69093744966180", "20190620", 1,0);


            //BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 801186, 116, 9108020, 115, "1", "MORELLANO", 163,
            //                 "FLORENCIO, NESTOR EDUARDO", "002", "Generado Automaticamente sistemas", "12/06/2019", 0,
            //                 "FLORENCIO, NESTOR EDUARDO", "26951200", "ADH INTERFUERZAS", 100637, "004", 0,
            //                 "PATAGONIA");

            //BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 6602, "69153795941949", "20190419", 1);

            // 2342...


        }
    }
}
