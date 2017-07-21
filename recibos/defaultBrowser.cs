using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SOCIOS
{
    class defaultBrowser
    {
        public string browser()
        {
            string browser = (string)Registry.GetValue("HKEY_CLASSES_ROOT\\http\\shell\\open\\command", null, string.Empty);
            return browser;
        }
    }
}
