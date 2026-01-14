using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NetCoreAdoNet
{
    public partial class Form03EliminarEnfermos : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form03EliminarEnfermos()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.LoadEnfermos();
        }

        private void LoadEnfermos()
        {
            string sql = "select * from ENFERMO";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();//Fallo conexion
            this.reader = this.com.ExecuteReader();//Fallo comando sql
            this.lstEnfermos.Items.Clear();
            while (this.reader.Read())
            {
                string inscripcion = this.reader["INSCRIPCION"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(inscripcion + " - " + apellido);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnEliminarEnfermo_Click(object sender, EventArgs e)
        {
            //LOS PARAMETROS DEBEN SER DEL MISMO TIPO DE DATO QUE LA COLUMNA
            int inscripcion = int.Parse(this.txtInscripcion.Text);
            string sql = "delete from ENFERMO where INSCRIPCION= @inscripcion" ;
            //DEBEMOS CONFIGURAR UNO O VARIOS PARAMETROS
            SqlParameter pamIns = new SqlParameter("@inscripcion", inscripcion);
            //CONFIGURAMOS NOMBRE DEL PARAMETRO EN LA CONSULTA, NO PUEDE ESTAR REPETIDO
            //pamIns.ParameterName = "@inscripcion";
            //pamIns.DbType = DbType.Int32;
            ////POR DEFECTO, LA DIRECCION ES INPUT
            //pamIns.Direction = ParameterDirection.Input;
            ////EL VALOR DEL PARAMETRO PARA SUSTITUIR EN LA CONSULTA
            //pamIns.Value = inscripcion;
            //AGREGAMOS EL PARAMETRO A LA COLECCION
            this.com.Parameters.Add(pamIns);

            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            //LAS CONSULTAS DE ACCION DEVUELVEN UN int CON EL NUMERO DE 
            //REGISTROS AFECTADOS
            int registros = this.com.ExecuteNonQuery();
            this.cn.Close();
            //LIBERAMOS LOS PARAMETROS DE LA COLECCION
            this.com.Parameters.Clear();
            this.LoadEnfermos();
            MessageBox.Show("Enfermos eliminados: " + registros);
        }
    }
}
