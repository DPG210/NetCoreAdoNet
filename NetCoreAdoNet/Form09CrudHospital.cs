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

namespace NetCoreAdoNet
{
    public partial class Form09CrudHospital : Form
    {
        RepositoryHospital repo;
        public Form09CrudHospital()
        {
            InitializeComponent();
            this.repo = new RepositoryHospital();
            this.LoadHospitales();
        }

        private async Task LoadHospitales()
        {
            List<Hospital> hospitales = await this.repo.GetHospitalesAsync();
            this.lstHospitales.Items.Clear();
            foreach(Hospital hosp in hospitales)
            {
                this.lstHospitales.Items.Add(hosp.CodigoHospital + " - " + hosp.Nombre
                    + " - " + hosp.Direccion + " - "
                    + hosp.Telefono + " - " + hosp.Camas);
            }
        }
        private async void btnCrear_Click(object sender, EventArgs e)
        {
            int codHosp = int.Parse(this.txtCodHosp.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int camas = int.Parse(this.txtNumeroCamas.Text);

            await this.repo.CreateHospitalAsync(codHosp, nombre, direccion, telefono, camas);
            await this.LoadHospitales();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int codHosp = int.Parse(this.txtCodHosp.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int camas = int.Parse(this.txtNumeroCamas.Text);

            await this.repo.UpdateHospitalAsync(codHosp, nombre, direccion, telefono, camas);
            await this.LoadHospitales();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int codHosp = int.Parse(this.txtCodHosp.Text);

            await this.repo.DeleteHospitalAsync(codHosp);
            await this.LoadHospitales();
        }
    }
}
