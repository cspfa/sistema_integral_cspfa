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

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1","MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas","19/12/2018",0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450","VITALICIO", 91222,"004", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2341, "68513983294795", "20181229", 1);
            //2356

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2356, "68513993793414", "20181229", 1);

            //2362

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2362, "68513993853406", "20181229", 1);

            //2367

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2367, "68513994240763", "20181229", 1);

            //2372

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2372, "68513994256327", "20181229", 1);

            //2373

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2373, "68513994444321", "20181229", 1);


            //2378

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2378, "68513994605808", "20181229", 1);

            //2379

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2379, "68513994968737", "20181229", 1);

            //2384

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2384, "68513994995623", "20181229", 1);


            //2386

            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 12342994, 110, "1", "MORELLANO", 172,
                               "DIOLOSA, AGUSTIN OSCAR", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "DIOLOSA, AGUSTIN OSCAR", "4411450", "VITALICIO", 91222, "004", 0,
                               "PATAGONIA");

            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2386, "68513995616243", "20181229", 1);

            // GRUPO 2
            // 2349 al 2380
            //2349
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 24613994, 75, "1", "PCABROL",45,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "14011143", "VITALICIO", 91230, "004", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2349, "68513991911863", "20181229", 1);

              //2352
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 24613994, 75, "1", "PCABROL",45,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "14011143", "VITALICIO", 91230, "004", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2352, "68513993792617", "20181229", 1);


             //2358
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 24613994, 75, "1", "PCABROL",45,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "14011143", "VITALICIO", 91230, "004", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2358, "68513993850123", "20181229", 1);

            
             //2368
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 24613994, 75, "1", "PCABROL",45,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "14011143", "VITALICIO", 91230, "004", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2368, "68513994254985", "20181229", 1);
             
            //2380
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 24613994, 75, "1", "PCABROL",45,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "FRANGOULIDES, ALEJANDRO RUBEN", "14011143", "VITALICIO", 91230, "004", 0,
                               "PATAGONIA");
            BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2380, "68513994994795", "20181229", 1);


                
            // GRUPO 3
            // 2348 al 2381
              // 2348
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112,8928994, 110, "1", "PCABROL", 193,
                            "MOLINA, AMADO DAVID", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "MOLINA, AMADO DAVID", "7941981", "VITALICIO", 91229, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2348, "68513990017344", "20181229", 1);
            // 2353
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112,8928994, 110, "1", "PCABROL", 193,
                            "MOLINA, AMADO DAVID", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "MOLINA, AMADO DAVID", "7941981", "VITALICIO", 91229, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2353, "68513993792793", "20181229", 1);

               // 2359
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112,8928994, 110, "1", "PCABROL", 193,
                            "MOLINA, AMADO DAVID", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "MOLINA, AMADO DAVID", "7941981", "VITALICIO", 91229, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2359, "68513993851580", "20181229", 1);

               // 2369
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112,8928994, 110, "1", "PCABROL", 193,
                            "MOLINA, AMADO DAVID", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "MOLINA, AMADO DAVID", "7941981", "VITALICIO", 91229, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2369, "68513994255300", "20181229", 1);

               // 2381
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112,8928994, 110, "1", "PCABROL", 193,
                            "MOLINA, AMADO DAVID", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "MOLINA, AMADO DAVID", "7941981", "VITALICIO", 91229, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2381, "68513994994986", "20181229", 1);


            // GRUPO 4
            // TIPO 2399
            
            //2347
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 44536994, 75, "1", "PCABROL", 45,
                            "QUIROGA, BERNARDO JAVIER", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "QUIROGA, BERNARDO JAVIER", "22355613", "ACTIVO", 91228, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2347, "68513989050657", "20181229", 1);

            //2354
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 44536994, 75, "1", "PCABROL", 45,
                            "QUIROGA, BERNARDO JAVIER", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "QUIROGA, BERNARDO JAVIER", "22355613", "ACTIVO", 91228, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2354, "68513993792939", "20181229", 1);

              //2360
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 44536994, 75, "1", "PCABROL", 45,
                            "QUIROGA, BERNARDO JAVIER", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "QUIROGA, BERNARDO JAVIER", "22355613", "ACTIVO", 91228, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2360, "68513993853082", "20181229", 1);

                //2370
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 44536994, 75, "1", "PCABROL", 45,
                            "QUIROGA, BERNARDO JAVIER", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "QUIROGA, BERNARDO JAVIER", "22355613", "ACTIVO", 91228, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2370, "68513994255680", "20181229", 1);

                //2382
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 44536994, 75, "1", "PCABROL", 45,
                            "QUIROGA, BERNARDO JAVIER", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "QUIROGA, BERNARDO JAVIER", "22355613", "ACTIVO", 91228, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2382, "68513994995212", "20181229", 1);

                       



            // GRUPO 4
            // 2400 ..

              // 2343
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 47030994, 210, "1", "PCABROL", 172,
                            "ESTEVEZ, MARIELA CARINA", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ESTEVEZ, MARIELA CARINA", "26337933", "ACTIVO", 91224, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2343, "68513985909906", "20181229", 1);


            // 2355
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 47030994, 210, "1", "PCABROL", 172,
                            "ESTEVEZ, MARIELA CARINA", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ESTEVEZ, MARIELA CARINA", "26337933", "ACTIVO", 91224, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2355, "68513993793210", "20181229", 1);


              // 2361
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 47030994, 210, "1", "PCABROL", 172,
                            "ESTEVEZ, MARIELA CARINA", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ESTEVEZ, MARIELA CARINA", "26337933", "ACTIVO", 91224, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2361, "68513993853202", "20181229", 1);



              // 2371
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 47030994, 210, "1", "PCABROL", 172,
                            "ESTEVEZ, MARIELA CARINA", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ESTEVEZ, MARIELA CARINA", "26337933", "ACTIVO", 91224, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2371, "68513994256047", "20181229", 1);

             // 2383
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 47030994, 210, "1", "PCABROL", 172,
                            "ESTEVEZ, MARIELA CARINA", "001", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ESTEVEZ, MARIELA CARINA", "26337933", "ACTIVO", 91224, "004", 0,
                            "PATAGONIA");
             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2383, "68513994995429", "20181229", 1);



            // GRUPO 4
            // 2346
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 11616994, 110, "1", "PCABROL", 193,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91227, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2346, "68513988877223", "20181229", 1);

              // 2363
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 11616994, 110, "1", "PCABROL", 193,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91227, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2363, "68513993881351", "20181229", 1);
              
               // 2346
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 11616994, 110, "1", "PCABROL", 193,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91227, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2374, "68513994507332", "20181229", 1);


                    // 2387
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 11616994, 110, "1", "PCABROL", 193,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91227, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2387, "68513995983894", "20181229", 1);


                    // 2391
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100111, 112, 11616994, 110, "1", "PCABROL", 193,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91227, "004", 0,
                            "PATAGONIA");
              BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2391, "68513996024701", "20181229", 1);





            // GRUPO 4
            // 2445...

                
 
            //2345
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 11616994, 75, "1", "PCABROL", 45,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91226, "004", 0,
                            "PATAGONIA");

           BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2345, "68513988855589", "20181229", 1);

            //2364
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 11616994, 75, "1", "PCABROL", 45,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91226, "004", 0,
                            "PATAGONIA");

           BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2364, "68513993881513", "20181229", 1);


            //2375
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 11616994, 75, "1", "PCABROL", 45,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91226, "004", 0,
                            "PATAGONIA");

           BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2375, "68513994507463", "20181229", 1);
           //2388
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 11616994, 75, "1", "PCABROL", 45,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91226, "004", 0,
                            "PATAGONIA");

           BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2388, "68513995984086", "20181229", 1);

             //2392
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100145, 164, 11616994, 75, "1", "PCABROL", 45,
                            "BAKIRDJIAN, JORGE", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "BAKIRDJIAN, JORGE", "8462275", "VITALICIO", 91226, "004", 0,
                            "PATAGONIA");

           BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2392, "68513996024887", "20181229", 1);


            // GRUPO 4
            // 2344
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 401104, 209, 25084994, 9885, "1", "PCABROL", 97,
                            "ALBARRACIN, MANUEL EDUARDO", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ALBARRACIN, MANUEL EDUARDO", "13181313", "VITALICIO", 91225, "004", 0,
                            "PATAGONIA");

             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2344, "68513988005994", "20181229", 1);
             
              // 2365
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 401104, 209, 25084994, 9885, "1", "PCABROL", 97,
                            "ALBARRACIN, MANUEL EDUARDO", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ALBARRACIN, MANUEL EDUARDO", "13181313", "VITALICIO", 91225, "004", 0,
                            "PATAGONIA");

             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2365, "68513993881657", "20181229", 1);


            // 2376
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 401104, 209, 25084994, 9885, "1", "PCABROL", 97,
                            "ALBARRACIN, MANUEL EDUARDO", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ALBARRACIN, MANUEL EDUARDO", "13181313", "VITALICIO", 91225, "004", 0,
                            "PATAGONIA");

             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2376, "68513994507890", "20181229", 1);

  // 2389
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 401104, 209, 25084994, 9885, "1", "PCABROL", 97,
                            "ALBARRACIN, MANUEL EDUARDO", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ALBARRACIN, MANUEL EDUARDO", "13181313", "VITALICIO", 91225, "004", 0,
                            "PATAGONIA");

             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2389, "68513995984366", "20181229", 1);

              // 2393
            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

            BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 401104, 209, 25084994, 9885, "1", "PCABROL", 97,
                            "ALBARRACIN, MANUEL EDUARDO", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ALBARRACIN, MANUEL EDUARDO", "13181313", "VITALICIO", 91225, "004", 0,
                            "PATAGONIA");

             BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2393, "68513996025066", "20181229", 1);

            // GRUPO 6
            // 2342 al finale...
             // 2342...


               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;


               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100136, 165, 17287011, 480,"4", "MORELLANO", 55,
                            "ROMERO, MANUEL", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ARES, DAMIAN OSVALDO", "31895807", "INP", 91223, "004", 0,
                            "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2342, "68513985015583", "20181229", 1);


               // 2342...
               //2366	68513993881851
               //2377	68513994509703
              //2390	68513995984502
              //2394	68513996025228
              
            //2366

               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;


               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100136, 165, 17287011, 480, "4", "MORELLANO", 55,
                            "ROMERO, MANUEL", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ARES, DAMIAN OSVALDO", "31895807", "INP", 91223, "004", 0,
                            "PATAGONIA");
            
               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2366, "68513993881851", "20181229", 1);

               //2377
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;


               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100136, 165, 17287011, 480, "4", "MORELLANO", 55,
                            "ROMERO, MANUEL", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ARES, DAMIAN OSVALDO", "31895807", "INP", 91223, "004", 0,
                            "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2377, "68513994509703 ", "20181229", 1);

               //2390
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;


               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100136, 165, 17287011, 480, "4", "MORELLANO", 55,
                            "ROMERO, MANUEL", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ARES, DAMIAN OSVALDO", "31895807", "INP", 91223, "004", 0,
                            "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2390, "68513995984502", "20181229", 1);


               //2394
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;


               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100136, 165, 17287011, 480, "4", "MORELLANO", 55,
                            "ROMERO, MANUEL", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                            "ARES, DAMIAN OSVALDO", "31895807", "INP", 91223, "004", 0,
                            "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2394, "68513996025228", "20181229", 1);
            //GRUPO 8 2350 en adelante
            //2350	68513993736197
            //2351	68513993766175
            //2357	68513993828805
            //2385	68513995000221
            //2395	68513996064936

            //2350
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100147, 236, 54744994, 140, "1", "GPANDOLFI",176 ,
                               "GALVAN, GUILLERMO JAVIER", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "GALVAN, JUAN JOSE", "7616084", "FAM", 91187, "004", 0,
                               "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2350, "68513993736197", "20181229", 1);
            //2351
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100147, 236, 54744994, 140, "1", "GPANDOLFI", 176,
                               "GALVAN, GUILLERMO JAVIER", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "GALVAN, JUAN JOSE", "7616084", "FAM", 91187, "004", 0,
                               "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2351, "68513993766175", "20181229", 1);
            //2357
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100147, 236, 54744994, 140, "1", "GPANDOLFI", 176,
                               "GALVAN, GUILLERMO JAVIER", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "GALVAN, JUAN JOSE", "7616084", "FAM", 91187, "004", 0,
                               "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2357, "68513993828805", "20181229", 1);

               //2385
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100147, 236, 54744994, 140, "1", "GPANDOLFI", 176,
                               "GALVAN, GUILLERMO JAVIER", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "GALVAN, JUAN JOSE", "7616084", "FAM", 91187, "004", 0,
                               "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2385, "68513995000221", "20181229", 1);

               //2395
               recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;

               BO_CAJA.nuevoReciboCaja(recibo_id, 301101, 100147, 236, 54744994, 140, "1", "GPANDOLFI", 176,
                               "GALVAN, GUILLERMO JAVIER", "002", "Generado Automaticamente sistemas", "19/12/2018", 0,
                               "GALVAN, JUAN JOSE", "7616084", "FAM", 91187, "004", 0,
                               "PATAGONIA");

               BO_AFIP.Marca_Afip_Recibo(recibo_id, 2, 2395, "68513996064936", "20181229", 1);
        }
    }
}
