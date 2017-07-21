using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;

namespace SOCIOS
{
    class printhtml
    {
        public void printHTML(string url)
        {
            Process printjob = new Process();
            printjob.StartInfo.FileName = url;
            printjob.StartInfo.UseShellExecute = true;
            printjob.StartInfo.Verb = "print";
            printjob.StartInfo.CreateNoWindow = false;
            printjob.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            printjob.Start();
        }
    }
}