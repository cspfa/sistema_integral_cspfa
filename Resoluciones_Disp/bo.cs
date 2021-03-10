using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Resoluciones
{
    class bo : SOCIOS.bo
    {
        private SOCIOS.db datDatos;
        public bo()
        {
            datDatos = new SOCIOS.db(this);
        }


    }
}
