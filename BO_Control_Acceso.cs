using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace SOCIOS
{
    public class BO_Datos
    {
        private DA_Datos datDatos;

        public BO_Datos()
        {
            datDatos = new DA_Datos(this);
        }

        public void Obtener_login()
        {
            string comando;
            FbDataReader resultado;
            comando = "SELECT current_timestamp, current_user, current_role  FROM RDB$Database";
            datDatos.OpenCnn();
            //datDatos.NewTransaction();
            resultado = datDatos.EjecutoReader(comando);

            resultado.Read();
          
            VGlobales.vp_username = resultado.GetString(resultado.GetOrdinal("user"));
            VGlobales.vp_role = resultado.GetString(resultado.GetOrdinal("role"));
            VGlobales.vp_timestamp = resultado.GetString(resultado.GetOrdinal("current_timestamp"));
            
            //datDatos.CommitTransaction();
            datDatos.CloseCnn();
        }

        public FbDataReader Obtener_roles()
        {
            string comando2;
            comando2 = "SELECT u.RDB$RELATION_NAME as USRROLE FROM RDB$USER_PRIVILEGES u WHERE u.RDB$PRIVILEGE = 'M' and u.RDB$USER = '";
            comando2 = comando2 + VGlobales.vp_username.TrimEnd() + "' ORDER BY 1 ";
            FbDataReader resultado = datDatos.EjecutoReader(comando2);
            return resultado;
        }

        public FbDataReader Obtener_Datos(string comando)
        {
            FbDataReader drFam;
            DA_Datos resultado = new DA_Datos();

            drFam = resultado.EjecutoReader(comando);
            return drFam;
        }
        /*
        public DataSet BO_Find()
        {
            DataSet ds1 = null;
            ds1 = datDatos.Find();
            return ds1;
        }
        */

        public DataSet BO_EjecutoDataset(string query)
        {
            DataSet ds1 = null;
            ds1 = datDatos.EjecutoDataSet(query);
            return ds1;
        }

        /*
        public DataSet1 BO_EjecutoDatasetRep(string query)
        {
            DataSet1 ds1 = null;
            ds1 = datDatos.EjecutoDataSetRep(query);
            return ds1;
        }
        */
        
        public DataTable BO_EjecutoDataTable(string query)
        {
            DataTable dt1 = null;
            dt1 = datDatos.EjecutoDataTable(query);
            return dt1;
        }





        public FbDataReader Busco_Titulares(string vapellido, string vnombres, string vnro_soc, string vnro_dep,
            string vaar, string vacrjp2, string vleg_per, string vpcrjp3,
            string vpcrjp2, string vpcrjp1, string vnrodoc, bool foto)
        {

            FbDataReader vlista ;

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(vapellido.TrimEnd());
            vector_contenidos.Add(vnombres.TrimEnd());
            vector_contenidos.Add((vnro_soc == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_soc))));
            vector_contenidos.Add((vnro_dep == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_dep))));
            vector_contenidos.Add((vaar == "" ? 0 : (int?)(System.Convert.ToInt32(vaar))));
            vector_contenidos.Add((vacrjp2 == "" ? 0 : (int?)(System.Convert.ToInt32(vacrjp2))));
            vector_contenidos.Add((vleg_per == "" ? 0 : (int?)(System.Convert.ToInt32(vleg_per))));
            vector_contenidos.Add((vpcrjp3 == "" ? 0 : (int?)(System.Convert.ToInt32(vpcrjp3))));
            vector_contenidos.Add((vpcrjp2 == "" ? 0 : (int?)(System.Convert.ToInt32(vpcrjp2))));
            vector_contenidos.Add((vpcrjp1 == "" ? 0 : (int?)(System.Convert.ToInt32(vpcrjp1))));
            vector_contenidos.Add((vnrodoc == "" ? 0 : (int?)(System.Convert.ToInt32(vnrodoc))));

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@P_APE_SOC");
            vector_nombres.Add("@P_NOM_SOC");
            vector_nombres.Add("@P_NRO_SOCIO");
            vector_nombres.Add("@P_NRO_DEPURACION");
            vector_nombres.Add("@P_AAR");
            vector_nombres.Add("@P_ACRJP2");
            vector_nombres.Add("@P_LEG_PER");
            vector_nombres.Add("@VPCRJP3");
            vector_nombres.Add("@VPCRJP2");
            vector_nombres.Add("@VPCRJP1");
            vector_nombres.Add("@VNRODOC");

            string vprocedure;

            if (!foto)  //sin foto
            {
                vprocedure = "SELECT * FROM P_BUSCO_UN_TITULAR (@P_APE_SOC,@P_NOM_SOC,";
                vprocedure = vprocedure + "@P_NRO_SOCIO,@P_NRO_DEPURACION,@P_AAR,";
                vprocedure = vprocedure + "@P_ACRJP2,@P_LEG_PER,@VPCRJP3,@VPCRJP2,@VPCRJP1,@VNRODOC)";
            }
            else  
            {
                vprocedure = "SELECT * FROM P_BUSCO_TITULAR (@P_APE_SOC,@P_NOM_SOC,"; //este trae Foto
                vprocedure = vprocedure + "@P_NRO_SOCIO,@P_NRO_DEPURACION,@P_AAR,";
                vprocedure = vprocedure + "@P_ACRJP2,@P_LEG_PER,@VPCRJP3,@VPCRJP2,@VPCRJP1,@VNRODOC)";
            }

            vlista = resultado.Ejecuto_Stored(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            return vlista;

        }


        public FbDataReader Busco_FamAdhe(string vapellido, string vnombres, string vnrodoc,
            string vnro_adh, string vnro_dep, string vproc)
        {
            // en realidad en vproc viene el SP a ejecutar puede ser P_BUSCO_FAMADHE, P_BUSCO_FAMILIAR o P_BUSCO_ADHERENTE

            FbDataReader vlista;

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(vapellido.TrimEnd());
            vector_contenidos.Add(vnombres.TrimEnd());
            vector_contenidos.Add((vnrodoc == "" ? 0 : (int?)(System.Convert.ToInt32(vnrodoc))));
            vector_contenidos.Add((vnro_adh == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_adh))));
            vector_contenidos.Add((vnro_dep == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_dep))));

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@P_APE_FAM");
            vector_nombres.Add("@P_NOM_FAM");
            vector_nombres.Add("@VNRODOC");
            vector_nombres.Add("@VNROADH");
            vector_nombres.Add("@VNRODEP");

            string vprocedure;
            vprocedure = "SELECT * FROM " + vproc + "(@P_APE_FAM,@P_NOM_FAM,@VNRODOC,@VNROADH,@VNRODEP)";

            vlista = resultado.Ejecuto_Stored(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            return vlista;

        }


        public FbDataReader Busco_Familiares(string vnro_soc, string vnro_dep, string vbarra)
     
        {

            FbDataReader vlista;

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add((vnro_soc == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_soc))));
            vector_contenidos.Add((vnro_dep == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_dep))));
            vector_contenidos.Add((vbarra == "" ? 0 : (int?)(System.Convert.ToInt32(vbarra))));

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@VNROSOC");
            vector_nombres.Add("@VNRODEP");
            vector_nombres.Add("@VBARRA");

            string vprocedure;
            vprocedure = "SELECT * FROM P_BUSCO_UN_FAMILIAR(@VNROSOC,@VNRODEP,@VBARRA)";

            vlista = resultado.Ejecuto_Stored(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            return vlista;

        }


        public FbDataReader Busco_Adherentes(string vnro_adh, string vnro_depadh, string vbarra)
        {

            FbDataReader vlista;

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add((vnro_adh == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_adh))));
            vector_contenidos.Add((vnro_depadh == "" ? 0 : (int?)(System.Convert.ToInt32(vnro_depadh))));
            vector_contenidos.Add((vbarra == "" ? 0 : (int?)(System.Convert.ToInt32(vbarra))));

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@VNROADH");
            vector_nombres.Add("@VNRODEPADH");
            vector_nombres.Add("@VBARRA");

            string vprocedure;
            vprocedure = "SELECT * FROM P_BUSCO_UN_ADHERENTE(@VNROADH,@VNRODEPADH,@VBARRA)";

            vlista = resultado.Ejecuto_Stored(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            return vlista;

        }

        public FbDataReader Busco_VisitaProv(string vtipdoc, string vnumdoc, string vapeinv, string vnominv)
        {

            FbDataReader vlista;

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(vtipdoc.TrimEnd());
            vector_contenidos.Add((vnumdoc == "" ? 0 : (int?)(System.Convert.ToInt32(vnumdoc))));
            vector_contenidos.Add(vapeinv.TrimEnd());
            vector_contenidos.Add(vnominv.TrimEnd());

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@VTIPDOC");
            vector_nombres.Add("@VNUMDOC");
            vector_nombres.Add("@VAPEINV");
            vector_nombres.Add("@VNOMINV");

            string vprocedure;
            vprocedure = "SELECT * FROM P_BUSCO_INVITADO(@VTIPDOC,@VNUMDOC,@VAPEINV,@VNOMINV)";

            vlista = resultado.Ejecuto_Stored(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            return vlista;

        }

        public void Inserto_Ingreso(string vapellido,
                                    string vnombre, 
                                    string vtipo,
                                    string vrol,
                                    string vdestino,
                                    string id_destino,
                                    string nro_soc,
                                    string nro_dep,
                                    string nro_adh,
                                    string nro_depadh,
                                    string barra,
                                    string dni,
                                    string vcod_dto,
                                    string vid_profesional)
        {

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(vapellido.TrimEnd());
            vector_contenidos.Add(vnombre.TrimEnd());
            vector_contenidos.Add(vtipo.TrimEnd());
            vector_contenidos.Add(vrol.TrimEnd());
            vector_contenidos.Add(vdestino.TrimEnd());
            vector_contenidos.Add(id_destino.TrimEnd());
            vector_contenidos.Add((nro_soc == "" ? 0 : (int?)(System.Convert.ToInt32(nro_soc))));
            vector_contenidos.Add((nro_dep == "" ? 0 : (int?)(System.Convert.ToInt32(nro_dep))));
            vector_contenidos.Add((nro_adh == "" ? 0 : (int?)(System.Convert.ToInt32(nro_adh))));
            vector_contenidos.Add((nro_depadh == "" ? 0 : (int?)(System.Convert.ToInt32(nro_depadh))));
            vector_contenidos.Add((barra == "" ? 0 : (int?)(System.Convert.ToInt32(barra))));
            vector_contenidos.Add((dni == "" ? 0 : (int?)(System.Convert.ToInt32(dni))));
            vector_contenidos.Add(vcod_dto.TrimEnd());
            vector_contenidos.Add((vid_profesional == "" ? 0 : (int?)(System.Convert.ToInt32(vid_profesional))));

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDBType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@ID_DESTINO");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_ADH");
            vector_nombres.Add("@NRO_DEPADH");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@COD_DTO");
            vector_nombres.Add("@ID_PROFESIONAL");

            string vprocedure;

            vprocedure = "P_INGRESOS_A_PROCESAR_I2";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Alta_VisitaProv(string tipdoc,
                                   string nrodoc,
                                   string apellido,
                                   string nombre, 
                                   string sexo,
                                   string car_tel1,
                                   string num_tel1,
                                   string car_tel2,
                                   string num_tel2,
                                   string email,
                                   string observ,
                                   char proveedor,
                                   string categoria)
        {

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(tipdoc);
            vector_contenidos.Add((nrodoc == "" ? 0 : (int?)(System.Convert.ToInt32(nrodoc))));
            vector_contenidos.Add(apellido.TrimEnd());
            vector_contenidos.Add(nombre.TrimEnd());
            vector_contenidos.Add(sexo);
            vector_contenidos.Add((car_tel1 == "" ? 0 : (int?)(System.Convert.ToInt32(car_tel1))));
            vector_contenidos.Add(num_tel1.TrimEnd());
            vector_contenidos.Add((car_tel2 == "" ? 0 : (int?)(System.Convert.ToInt32(car_tel2))));
            vector_contenidos.Add(num_tel2.TrimEnd());
            vector_contenidos.Add(email.TrimEnd());
            vector_contenidos.Add(observ.TrimEnd());
            vector_contenidos.Add(proveedor);
            vector_contenidos.Add(categoria.TrimEnd());


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@TIP_DOC");
            vector_nombres.Add("@NUM_DOC");
            vector_nombres.Add("@APE_INV");
            vector_nombres.Add("@NOM_INV");
            vector_nombres.Add("@SEXO");
            vector_nombres.Add("@CAR_TE1");
            vector_nombres.Add("@NUM_TE1");
            vector_nombres.Add("@CAR_TE2");
            vector_nombres.Add("@NUM_TE2");
            vector_nombres.Add("@E_MAIL");
            vector_nombres.Add("@OBSER");
            vector_nombres.Add("@PROVEEDOR");
            vector_nombres.Add("@CAT_SOC");


            string vprocedure;
            vprocedure = "P_ALTA_INVITADO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Modi_VisitaProv(string tipdoc,
                                   string nrodoc,
                                   string apellido,
                                   string nombre,
                                   string sexo,
                                   string car_tel1,
                                   string num_tel1,
                                   string car_tel2,
                                   string num_tel2,
                                   string email,
                                   string observ,
                                   char proveedor)
        {

            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(tipdoc);
            vector_contenidos.Add((nrodoc == "" ? 0 : (int?)(System.Convert.ToInt32(nrodoc))));
            vector_contenidos.Add(apellido.TrimEnd());
            vector_contenidos.Add(nombre.TrimEnd());
            vector_contenidos.Add(sexo);
            vector_contenidos.Add((car_tel1 == "" ? 0 : (int?)(System.Convert.ToInt32(car_tel1))));
            vector_contenidos.Add(num_tel1.TrimEnd());
            vector_contenidos.Add((car_tel2 == "" ? 0 : (int?)(System.Convert.ToInt32(car_tel2))));
            vector_contenidos.Add(num_tel2.TrimEnd());
            vector_contenidos.Add(email.TrimEnd());
            vector_contenidos.Add(observ.TrimEnd());
            vector_contenidos.Add(proveedor);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@TIP_DOC");
            vector_nombres.Add("@NUM_DOC");
            vector_nombres.Add("@APE_INV");
            vector_nombres.Add("@NOM_INV");
            vector_nombres.Add("@SEXO");
            vector_nombres.Add("@CAR_TE1");
            vector_nombres.Add("@NUM_TE1");
            vector_nombres.Add("@CAR_TE2");
            vector_nombres.Add("@NUM_TE2");
            vector_nombres.Add("@E_MAIL");
            vector_nombres.Add("@OBSER");
            vector_nombres.Add("@PROVEEDOR");

            string vprocedure;
            vprocedure = "P_MODIFICA_INVITADO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        // ACA ESTA EL PATRON ESTRATEGIA PARA BUSCAR Y OBTENER EL DATASET DE RESULTADO

        /*
        public interface BuscoDatos
        {
            DataSet Buscar_los_Datos(string nro_soc, string nro_dep, string nombre, string apellido);
        }

        
        public class BuscoTitulares : BuscoDatos
        {
            BuscoTitulares() { }

            public DataSet Buscar_los_Datos(string nro_soc, string nro_dep, string nombre, string apellido)
            {
                MessageBox.Show("Entro en buscar un titular");

                string comando2;
                DataSet resultado;
                DA_Datos variable = new DA_Datos();
                comando2 = "SELECT * FROM P_BUSCO_UN_TITULAR()";
                variable.OpenCnn();
                variable.NewTransaction();
                resultado = variable.EjecutoDataSet(comando2);
                variable.CommitTransaction();
                variable.CloseCnn();
                return resultado;
            }
            
        }
        
        public class BuscoFamiliares : BuscoDatos
        {
            BuscoFamiliares() { }

            public DataSet Buscar_los_Datos(string nro_soc, string nro_dep, string nombre, string apellido)
            {
                MessageBox.Show("Entro en buscar familiar");


                string comando2;
                DataSet resultado;
                DA_Datos variable = new DA_Datos();
                comando2 = "SELECT * FROM P_BUSCO_FAMILIAR()";
                variable.OpenCnn();
                variable.NewTransaction();
                resultado = variable.EjecutoDataSet(comando2);
                variable.CommitTransaction();
                variable.CloseCnn();
                return resultado;
            }

        }

        // ESTA ES LA CLASE CONTEXTO
        public class Contenedor
        {
            private String contenedor;
            private string nro_soc;
            private string nro_dep;
            private BuscoDatos Buscardatos;

            public string getnro_soc()
            {
                return nro_soc;
            }

            public string getnro_dep()
            {
                return nro_dep;
            }

            public String getContenedor()
            {
                return contenedor;
            }

            public BuscoDatos getBuscoDatos()
            {
                return Buscardatos;
            }

            public Contenedor(String _contenedor, string _nro_soc, string _nro_dep, BuscoDatos _BuscoDatos)
            {
                if (_BuscoDatos == null)
                    throw new Exception("Debe indicar una forma de busqueda");
                else
                {
                    this.contenedor = _contenedor;
                    this.nro_dep = _nro_dep;
                    this.nro_soc = _nro_soc;
                    this.Buscardatos = _BuscoDatos;
                }
            }
        }

        // CREAMOS LA CLASE QUE REALIZARA EL TRABAJO
        public class Busqueda_Concreta
        {
            private Contenedor contenedor;
            private string nro_soc;
            private string nro_dep;
             
            public Busqueda_Concreta(Contenedor _contenedor)
            {
                this.contenedor = _contenedor;
            }

            public DataSet Buscar_los_Datos()
            {
                return (contenedor.getBuscoDatos());
            }

        }

        // FIN PATRON ESTRATEGIA
        */
    }
}