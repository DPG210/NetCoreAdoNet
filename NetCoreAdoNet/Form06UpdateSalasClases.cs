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
    public partial class Form06UpdateSalasClases : Form
    {
        RepositorySalas repo;
        public Form06UpdateSalasClases()
        {
            InitializeComponent();
            this.repo = new RepositorySalas();
            this.LoadSalas();
        }

        private void Form06UpdateSalasClases_Load(object sender, EventArgs e)
        {

        }
        private void LoadSalas()
        {
            List<string> salas = this.repo.GetNombreSalas();
            this.lstSalas.Items.Clear();
            foreach ( string nombre in salas)
            {
                this.lstSalas.Items.Add(nombre);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string oldName = this.lstSalas.SelectedItem.ToString();
            string newName = this.txtNombre.Text;
            int registros = this.repo.UpdateSala(newName, oldName);
            MessageBox.Show("Modificados: " + registros);
            this.LoadSalas();
        }
    }
}
