using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resoluciones_Disp
{
    class Utils
    {
        public int diasDeDiferencia(DateTime HASTA)
        {
            int DIFF = 0;
            DateTime TODAY = DateTime.Now;
            TimeSpan TS = HASTA - TODAY;
            DIFF = TS.Days;
            return DIFF;
        }

    }
}
