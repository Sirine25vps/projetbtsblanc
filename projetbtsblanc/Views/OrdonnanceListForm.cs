using System;
using System.Windows.Forms;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;

namespace projetbtsblanc.Views
{
    public partial class OrdonnanceListForm : Form
    {
        private OrdonnanceController _controller = new OrdonnanceController();

        public OrdonnanceListForm()
        {
            InitializeComponent();

            // On s'abonne aux événements
            this.Load += OrdonnanceListForm_Load;
            dgvOrdonnances.SelectionChanged += dgvOrdonnances_SelectionChanged;
        }

        private void OrdonnanceListForm_Load(object sender, EventArgs e)
        {
            // Chargement de la liste des ordonnances en haut
            dgvOrdonnances.DataSource = _controller.ObtenirToutesLesOrdonnances();

            // Optionnel : Mise en forme
            dgvOrdonnances.ReadOnly = true;
            dgvLignes.ReadOnly = true;
        }

        private void dgvOrdonnances_SelectionChanged(object sender, EventArgs e)
        {
            // On vérifie qu'une ligne est bien sélectionnée
            if (dgvOrdonnances.CurrentRow != null && dgvOrdonnances.CurrentRow.DataBoundItem is Ordonnance selectedOrdo)
            {
                // Chargement des médicaments pour l'ordonnance sélectionnée en bas
                dgvLignes.DataSource = _controller.ObtenirLignes(selectedOrdo.Id);
            }
        }
    }
}