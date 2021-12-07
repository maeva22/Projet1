using Projet1.Modeles;
using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    class PageRechercheVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Professionel> _maListeProfessionel;
        private ObservableCollection<object> _selectedProfessionel; 
        private Professionel _unProfessionel;
        #endregion

        #region Constructeurs
        public PageRechercheVueModele()
        {   // code permettant d'afficher la liste des professionels
            ObservableCollection<Professionel> listeProfessionel = Professionel.GetListSQLite();
            MaListeProfessionel = new ObservableCollection<Professionel>(listeProfessionel);

            SelectedProfessionel = new ObservableCollection<object>();
            UnProfessionel = new Professionel
            {
                Genre = "",
                Nom = "",
                Prenom = "",
                DateDeNaissance = DateTime.Now,
                NumeroTelephone = "",
                Email = "",
                Password = "",
                Formation = "",
                Adresse = "",
                CodePostale = "",
                Ville = "",
                Tarif = "",
                Presentation = ""
            };

            BoutonPrendreRendezVous = new Command(ActionBoutonPrendreRendezVous);
            SelectionChangedCommandProfessionel = new Command(ActionSelectionProfessionel);
        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<Professionel> MaListeProfessionel
        {
            get
            {
                return _maListeProfessionel;
            }
            set
            {
                SetProperty(ref _maListeProfessionel, value);
            }
        }
        public ObservableCollection<object> SelectedProfessionel
        {
            get
            {
                return _selectedProfessionel;
            }
            set
            {
                SetProperty(ref _selectedProfessionel, value);
            }
        }
        public Professionel UnProfessionel
        {
            get
            {
                return _unProfessionel;
            }
            set
            {
                SetProperty(ref _unProfessionel, value);
            }
        }
        public ICommand BoutonPrendreRendezVous { get; }
        public ICommand SelectionChangedCommandProfessionel { get; }
        #endregion

        #region Methodes
        public void Method()
        {
            if (SelectedProfessionel.Count > 0)
                UnProfessionel = (Professionel)this.SelectedProfessionel[SelectedProfessionel.Count - 1];
            Professionel.AjoutProfessionelChoisie(UnProfessionel);
        }
        public void ActionSelectionProfessionel()
        {
            Method();
            Application.Current.MainPage = new PageInformationsProfessionelVue();
        }
        public void ActionBoutonPrendreRendezVous()
        {
            Method();
            Application.Current.MainPage = new NavigationPage(new PagePriseDeRendezVousVue());
        }

        #endregion
    }
}
