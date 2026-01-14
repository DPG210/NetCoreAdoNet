using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form07DepartamentosEmpleados : Form
    {
        RepositoryDepartamentos repo;
        public Form07DepartamentosEmpleados()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();
            this.lstDepartamentos.Items.Clear();
            foreach (string nombre in departamentos)
            {
                lstDepartamentos.Items.Add(nombre);
            }
        }

        private async Task LoadEmpleados()
        {
            string departamento = this.lstDepartamentos.SelectedItem.ToString();
            List<string> empleados = await this.repo.GetEmpleadosAsync(departamento);
            this.lstEmpleados.Items.Clear();
            foreach (string nombre in empleados)
            {
                lstEmpleados.Items.Add(nombre);
            }
        }

        private async void  btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedIndex != -1)
            {
                string apellido = this.lstEmpleados.SelectedItem.ToString();
                int registros = await this.repo.DeleteEmpleadoAsync(apellido);
                MessageBox.Show("Eliminamos: " + registros);
                this.LoadEmpleados();
            }
            
        }

        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if(this.lstDepartamentos.SelectedIndex != -1)
            {
                this.LoadEmpleados();
            }
            
        }
    }
}
