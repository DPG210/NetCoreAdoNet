using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;

namespace NetCoreAdoNet.Repositories
{
    
    public class RepositoryDepartamentos
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "select DNOMBRE from DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            return departamentos;
        }

        public async Task<List<string>> GetEmpleadosAsync(string nomDept)
        {
            string sql = "select APELLIDO from EMP  INNER JOIN DEPT " +
                "on EMP.DEPT_NO = DEPT.DEPT_NO where DEPT.DNOMBRE = @nomDept";
            SqlParameter pamNom = new SqlParameter("@nomdept", nomDept);
            this.com.Parameters.Add(pamNom);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> empleados = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                empleados.Add(apellido);
                
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;
        }

        public async Task<int> DeleteEmpleadoAsync(string apellido)
        {
            string sql = "delete from emp where apellido=@apellido";
            SqlParameter pamApe = new SqlParameter("@apellido", apellido);
            this.com.Parameters.Add(pamApe);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return registros;
        }
    }

    
}
