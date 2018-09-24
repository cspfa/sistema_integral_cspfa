﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Factura_Electronica
{
    public partial class Testing_Facturacion : Form
    {
        int TipoComprobante = 0;
        int TipoDocumento = 0;
        FacturaCSPFA serviceFactura = new FacturaCSPFA();
        Afip.AfipFactResults result = new Afip.AfipFactResults();
        public Testing_Facturacion()
        {
            InitializeComponent();
            this.Inicializo();

        }

        private void Inicializo()

        {
            cbTipoComprobante.Items.Insert(0, "RECIBOS C");
            cbTipoComprobante.Items.Insert(1, "NOTAS DE VENTA AL CONTADO C");
            
            cbTipoComprobante.SelectedIndex = 0;
            cbTipoComprobante.Refresh();

            cbTipoDocumento.Items.Insert(0, "DNI");
            cbTipoDocumento.Items.Insert(1, "CUIT");
            cbTipoDocumento.SelectedIndex = 0;
            cbTipoDocumento.Refresh();
        
        }

        private void ObtenerDatos()
        {
            if (cbTipoComprobante.Text.Contains("RECIBOS C"))
            {
                TipoComprobante = 15;
            }
            else
                TipoComprobante = 16;
            if ((cbTipoDocumento.Text.Contains("DNI")))
                TipoDocumento = 96;
            else
                TipoDocumento=80;
              

        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            this.ObtenerDatos();


            try
            {

                result = serviceFactura.Facturar(Int32.Parse(tbPuntoVenta.Text),dtFecha.Value,TipoComprobante,TipoDocumento,tbDni.Text,2,decimal.Parse(tbMonto.Text));
                lbCAE.Text = result.Cae;
                lbVencimiento.Text = result.Vencimiento;
                lbNumero.Text = result.Numero.ToString();
            }
            catch (Exception ex)

            {
                lbResult.Text = "ERROR" +ex.Message;
            
            
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}