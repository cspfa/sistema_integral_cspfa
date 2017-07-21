using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SOCIOS
{
   public partial class XLS
    {

       public static void releaseObject(object obj)
       {
           try
           {
               System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
               obj = null;
           }
           catch (Exception ex)
           {
               obj = null;

           }
           finally
           {
               GC.Collect();
           }
       }
    }
}
