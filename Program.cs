using MicroFour.StrataFrame.Application;
using MicroFour.StrataFrame.Data;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SOCIOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            // Detectamos instancias con el mismo nombre
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length > 1)
            {
                MessageBox.Show("La aplicación ya se está ejecutando.");
                Application.Exit();
            }
            else
            {






                //-- Enable visual styles on the application
                Application.EnableVisualStyles();

                //-- Add event handlers for the application events
                StrataFrameApplication.ShowGateway +=
                    new StrataFrameApplication.ShowGatewayEventHandler(
                    ShowGateway);
                StrataFrameApplication.InitializingApplication +=
                    new StrataFrameApplication.InitializingApplicationEventHandler(
                    InitApplication);
                StrataFrameApplication.SetDataSources +=
                    new StrataFrameApplication.SetDataSourcesEventHandler(
                    SetDataSources);
                StrataFrameApplication.UnhandledExceptionFound +=
                    new StrataFrameApplication.UnhandledExceptionFoundEventHandler(
                    UnhandledExceptionFound);
                StrataFrameApplication.ShowLoginAndInitializeForm +=
                    new StrataFrameApplication.ShowLoginAndInitializeFormEventHandler(
                    ShowLoginAndInitMainForm);

                //-- Run the application

                StrataFrameApplication.RunApplication();
            }
        }

        /// <summary>
        /// Gets the connection string if the application will use a custom method to aquire the connection
        /// string rather than the StrataFrame Connection String Manager (optional)
        /// </summary>
        /// <remarks></remarks>
        private static void SetDataSources()
        {
            // ToDo:  1) Set the connection information below including the connection application settings and the
            //           required settings information and then call the ConnectionManager's SetConnections() method.
            //
            //          OR
            //
            //        2) Manually set the DataSourceItems on the DataSources collection below.

            //  -- You can set as many data sources as necessary.  The business objects use the data source specified
            //     by their DataSourceKey property (defaults to "").


            //------------------------------------
            //  Using the Connection Manager
            //------------------------------------

            //-- Set the information specific to this application and the data sources
            //       The application key:
            //ConnectionManager.ApplicationKey = "SOCIOS";
            //ConnectionManager.ApplicationDefaultTitle = "SOCIOS Connection";
            //ConnectionManager.ApplicationDefaultDescription = "This application connection is used by SOCIOS";

            //-- Set the required data source information so that the ConnectionManager can gather it
            //      SQL Connection
            //ConnectionManager.AddRequiredDataSourceItem("", "SQL Connection",
            //    DataSourceTypeOptions.SqlServer, "MyDatabase", "This connection is used by SOCIOS.");
            //      Oracle Connection
            //ConnectionManager.AddRequiredDataSourceItem("", "Oracle Connection", 
            //    DataSourceTypeOptions.Oracle, "", "This connection is used by SOCIOS.");
            //      Access Connection
            //ConnectionManager.AddRequiredDataSourceItem("", "Access Connection", 
            //    DataSourceTypeOptions.MicrosoftAccess, "", "This connection is used by SOCIOS.");
            //      FoxPro Connection
            //ConnectionManager.AddRequiredDataSourceItem("", "Visual Fox Pro Connection", 
            //    DataSourceTypeOptions.VisualFoxPro, "", "This connection is used by SOCIOS.");

            //-- Make the call to SetConnections which will gather the connection information, show the connection wizard
            //   if needed and set the DataSources collection on the DataLayer class.
            //ConnectionManager.SetConnections();


            //------------------------------------
            //  Setting the data sources manually
            //------------------------------------
            //-- SQL Server
            //DataLayer.DataSources.Add(new SqlDataSourceItem("", "myconnectionstring"));

            //-- Oracle
            //DataLayer.DataSources.Add(new OracleDataSourceItem("", "myconnectionstring"));

            //-- Microsoft Access
            //DataLayer.DataSources.Add(new AccessDataSourceItem("", "myconnectionstring"));

            //-- Visual Fox Pro
            //DataLayer.DataSources.Add(new VfpDataSourceItem("", "myconnectionstring"));
        }

        /// <summary>
        /// Shows the "Gateway" form (a custom form that gives the user a choice to launch different components
        /// within the application) (optional)
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private static void ShowGateway(ShowGatewayEventArgs e)
        {
            //-- Inform the application to not show the "Gateway" form again after the main form has closed
            e.ShowGatewayAfterMainFormClose = false;
        }

        /// <summary>
        /// Shows a login form before a main form is shown and allows security to be checked before the application
        /// launches the main form (optional)
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private static void ShowLoginAndInitMainForm(ShowLoginAndInitFormEventArgs e)
        {
            //-- ToDo: add any code to show a login form and authenticate the user
            //   e.LoginSuccessful = ?
        }

        /// <summary>
        /// Provides a centralized location to add any initialization parameters that need to be set before
        /// the application is loaded and defines the form types used as main forms by the application
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private static void InitApplication(InitializingApplicationEventArgs e)
        {
            //-- Add the main form type
            //-- If more than one form is added to the collection, they can be chosen by showing a "Gateway" form
            //   and supplying the index of the form to show (At least 1 form type must be added to the collection



                //e.Forms.Add(typeof(SOCIOS.Form2));

                //e.Forms.Add(typeof(SOCIOS.LoginForm1));

                e.Forms.Add(typeof(SOCIOS.MenuABM));

                //-- ToDo:  Add any extra application initialization
                MicroFour.StrataFrame.UI.Localization.MessageKeyType = MicroFour.StrataFrame.Messaging.MessageKeyDataType.XML;
                MicroFour.StrataFrame.UI.Localization.MessageLocaleID = MicroFour.StrataFrame.UI.Localization.GetActiveLanguage("SOCIOS", "", false); ;
        }

        /// <summary>
        /// Catches any unhandled exception within the application and provides a place to log the information
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private static void UnhandledExceptionFound(UnhandledExceptionFoundEventArgs e)
        {
            //-- ToDo: add any error logging required.  To prevent the StrataFrame ApplicationErrorForm from showing,
            //   set:
            //   e.Handled = true
        }
    }
}