using NetCoreAdoNet.Models;
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
    public partial class Form08CrudDepartamentos : Form
    {
        RepositoryDepartament repo;
        public Form08CrudDepartamentos()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartament();
            this.LoadDepartamentos();
        }

        private async Task LoadDepartamentos()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            this.lstDepartamentos.Items.Clear();
            foreach(Departamento dept in departamentos)
            {
                this.lstDepartamentos.Items.Add
                    (dept.IdDepartamento + "-"
                    + dept.Nombre + "-"
                    + dept.Localidad);
            }
        }
    }
}
