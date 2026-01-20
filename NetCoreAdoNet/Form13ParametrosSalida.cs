using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region PROCEDIMIENTO ALMACENADOS
//create procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
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
//	select @suma= sum(salario), @media = avg(salario), @personas = count(emp_no) from emp where dept_no= @iddept
//go
#endregion

namespace NetCoreAdoNet
{
    public partial class Form13ParametrosSalida : Form
    {
        RepositoryParametersOut repo;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            this.repo = new RepositoryParametersOut();
            this.LoadDepartamentos();
        }

        private async Task LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach(string nombre in departamentos)
            {
                this.cmbDepartamentos.Items.Add(nombre);
            }
        }

        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            EmpleadosParametersOut model = await this.repo.GetEmpleadosModelAsync(nombre);
            this.lstPersonas.Items.Clear();
            foreach(string ape in model.Apellidos)
            {
                this.lstPersonas.Items.Add(ape);
            }
            this.txtSumaSalarial.Text = model.SumaSalarial.ToString();
            this.txtMediaSalarial.Text = model.MediaSalarial.ToString();
            this.txtPersonas.Text = model.Personas.ToString();
        }
    }
}
