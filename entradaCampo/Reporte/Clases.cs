using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOCIOS;

namespace Reportes
{
    public class ReporteEntradaCampo 
    {
        public int ID { get; set; }
      
        public DateTime FECHA { get; set; }

        public string Tipo { get; set; }
        public string DNI { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }

       
        public int INVITADO { get; set; }
        public decimal MONTO_INVITADO { get; set; }

        public int INVITADO_PILETA { get; set; }
        public decimal MONTO_INVITADO_PILETA { get; set; }
        public int INVITADO_ESTACIONAMIENTO { get; set; }
        public decimal MONTO_INVITADO_EST { get; set; }

        public int SOCIO { get; set; }
        public decimal MONTO_SOCIO { get; set; }
        public int SOCIO_PILETA { get; set; }
        public decimal MONTO_SOCIO_PILETA { get; set; }
        public int SOCIO_ESTACIONAMIENTO { get; set; }
        public decimal MONTO_SOCIO_EST { get; set; }

        public int INTERCIRCULO { get; set; }
        public decimal MONTO_INTER { get; set; }

        public int INTERCIRCULO_PILETA { get; set; }
        public decimal MONTO_INTERCIRCULO_PILETA { get; set; }

        public int INTERCIRCULO_ESTACIONAMIENTO { get; set; }
        public decimal MONTO_INTERCIRCULO_EST { get; set; }

        public int TOTAL { get; set; }
        public decimal MONTO_TOTAL { get; set; }

        public int MENOR { get; set; }
        public int DISCAPACITADO { get; set; }
        public int DISCAPACITADO_ACOM { get; set; }
        public int ID_REAL { get; set; }
        public int EVENTO            { get; set; }
        public decimal  MONTO_EVENTO { get; set; }

    }
}
