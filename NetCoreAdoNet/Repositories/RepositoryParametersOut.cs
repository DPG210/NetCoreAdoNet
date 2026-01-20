using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helpers;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text;

#region PROCEDIMIENTO ALMACENADOS
//create procedure SP_ALL_DEPARTAMENTOS 
//as
//  select* from DEPT
//go
//ALTER procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
//(@nombre nvarchar(50),
//@suma int out,
//@media int out,
//@personas int out)
//as
//	declare @iddept int
//	select @iddept = dept_no from dept
//	where dnombre= @nombre
//	--LA CONSULTA DEL PROCEDIMIENTO
//	select * from emp where dept_no=@iddept
//	--RELLENAMOS LAS VARIABLES DE SALIDA
//	select @suma= ISNULL(sum(salario),0), @media = ISNULL(avg(salario), 0),
//    @personas = count(emp_no) from emp where dept_no= @iddept
//go
        #endregion

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryParametersOut
    {
        
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryParametersOut()
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();
            string connectionString = configuration.GetConnectionString("SqlLocalTajamar");
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task <List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            this.reader.CloseAsync();
            this.cn.CloseAsync();
            return departamentos;
        }

        public async Task <EmpleadosParametersOut> GetEmpleadosModelAsync(string nombreDepartamento)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            //TENEMOS UN PARAMETRO DE ENTRADA, POR DEFECTO, TODOS SON DE ENTRADA
            // PODEMOS SEGUIR USANDO AddWithValue CON DICHO PARAMETRO
            SqlParameter pamNombre = new SqlParameter();
            pamNombre.ParameterName = "@nombre";
            pamNombre.Value = nombreDepartamento;
            this.com.Parameters.Add(pamNombre);
            //LOS PARAMETRO DE SALIDA, DEBEMOS CREARLOS DE FORMA EXPLICITA
            //EN ESTE EJEMPLO, NO HEMOS PUESTO VALORES POR DEFECTO A LOS PARAMETROS
            //POR LO QUE SON OBLIGATORIOS
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            pamSuma.Value = 0;
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);
            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@media";
            pamMedia.Value = 0;
            pamMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);
            SqlParameter pamPersonas = new SqlParameter();
            pamPersonas.ParameterName = "@personas";
            pamPersonas.Value = 0;
            pamPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamPersonas);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            EmpleadosParametersOut model = new EmpleadosParametersOut();
            //model.Apellidos = new List<string>();
            //IF EN SQL = NULL
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                model.Apellidos.Add(apellido);
            }
            //DIBUJAMOS LOS PARAMETROS
            await this.reader.CloseAsync();
            //ESTABLECEMOS LOS DATOS
            model.SumaSalarial = int.Parse(pamSuma.Value.ToString());
            model.MediaSalarial = int.Parse(pamMedia.Value.ToString());
            model.Personas = int.Parse(pamPersonas.Value.ToString());
            //LIBERAMOS LOS RECURSOS DE LA CONEXION Y DEMAS

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return model;
        }
    }
}
