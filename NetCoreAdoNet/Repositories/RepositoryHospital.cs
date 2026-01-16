using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using NetCoreAdoNet.Models;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "select * from Hospital";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Hospital> hospitales = new List<Hospital>();
            while(await this.reader.ReadAsync())
            {
                Hospital hosp = new Hospital();
                hosp.CodigoHospital =int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hosp.Nombre = this.reader["NOMBRE"].ToString();
                hosp.Direccion = this.reader["DIRECCION"].ToString();
                hosp.Telefono = this.reader["TELEFONO"].ToString();
                hosp.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hosp);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }

        public async Task CreateHospitalAsync(int codHosp, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "insert into HOSPITAL values(@codHosp, @nombre, @direccion, @telefono, @camas)";
            SqlParameter pamCod = new SqlParameter("@codHosp", codHosp);
            SqlParameter pamNom = new SqlParameter("@nombre", nombre);
            SqlParameter pamDir = new SqlParameter("@direccion", direccion);
            SqlParameter pamTel = new SqlParameter("@telefono", telefono);
            SqlParameter pamCam = new SqlParameter("@camas", camas);
            this.com.Parameters.Add(pamCod);
            this.com.Parameters.Add(pamNom);
            this.com.Parameters.Add(pamDir);
            this.com.Parameters.Add(pamTel);
            this.com.Parameters.Add(pamCam);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task UpdateHospitalAsync (int codHosp, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "update Hospital set nombre=@nombre, direccion=@direccion, telefono=@telefono, num_cama=@camas where hospital_cod=@codHosp";
            SqlParameter pamCod = new SqlParameter("@codHosp", codHosp);
            SqlParameter pamNom = new SqlParameter("@nombre", nombre);
            SqlParameter pamDir = new SqlParameter("@direccion", direccion);
            SqlParameter pamTel = new SqlParameter("@telefono", telefono);
            SqlParameter pamCam = new SqlParameter("@camas", camas);
            this.com.Parameters.Add(pamCod);
            this.com.Parameters.Add(pamNom);
            this.com.Parameters.Add(pamDir);
            this.com.Parameters.Add(pamTel);
            this.com.Parameters.Add(pamCam);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task DeleteHospitalAsync(int codHosp)
        {
            string sql = "delete from hospital where hospital_cod=@codHosp";
            SqlParameter pamCod = new SqlParameter("@codHosp", codHosp);
            this.com.Parameters.AddWithValue("@codHosp", codHosp);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

    }
}
