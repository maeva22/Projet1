using Projet1.Modeles;
using Projet1.Vues;
using Projet1.Vues.Flyout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    public class PageRechercheVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Professionnel> _maListeProfessionnel;
        private ObservableCollection<object> _selectedProfessionnel; 
        private Professionnel _unProfessionnel;
        #endregion

        #region Constructeurs
        public PageRechercheVueModele()
        {   // code permettant d'afficher la liste des professionels
            ObservableCollection<Professionnel> listeProfessionnel = Professionnel.GetListSQLite();
            MaListeProfessionnel = new ObservableCollection<Professionnel>(listeProfessionnel);

            SelectedProfessionnel = new ObservableCollection<object>();
            UnProfessionnel = new Professionnel
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
                Presentation = "",
            };

            SelectionChangedCommandProfessionnel = new Command(ActionSelectionProfessionnel);

            CommandReturn = new Command(ActionCommandReturn);
        }
        #endregion

        #region Getters/Setters 
        public ObservableCollection<Professionnel> MaListeProfessionnel
        {
            get
            {
                return _maListeProfessionnel;
            }
            set
            {
                SetProperty(ref _maListeProfessionnel, value);
            }
        }
        public ObservableCollection<object> SelectedProfessionnel
        {
            get
            {
                return _selectedProfessionnel;
            }
            set
            {
                SetProperty(ref _selectedProfessionnel, value);
            }
        }
        public Professionnel UnProfessionnel
        {
            get
            {
                return _unProfessionnel;
            }
            set
            {
                SetProperty(ref _unProfessionnel, value);
            }
        }
        public ICommand SelectionChangedCommandProfessionnel { get; }
        public ICommand CommandReturn { get; }
        #endregion

        #region Methodes 
        public void Method()
        {
            if (SelectedProfessionnel.Count > 0)
                UnProfessionnel = (Professionnel)this.SelectedProfessionnel[SelectedProfessionnel.Count - 1];
            Professionnel.AjoutProfessionnelChoisie(UnProfessionnel);
        }
        public void ActionSelectionProfessionnel()
        {
            Method();
            Application.Current.MainPage = new PageInformationsProfessionnelVue();
        }
        public void ActionCommandReturn()
        {
            Application.Current.MainPage = new PageAccueilVue();
        }

        #endregion
    }
}
