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

            BoutonPrendreRendezVous = new Command(ActionBoutonPrendreRendezVous);
            SelectionChangedCommandProfessionnel = new Command(ActionSelectionProfessionnel);
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
        public ICommand BoutonPrendreRendezVous { get; }
        public ICommand SelectionChangedCommandProfessionnel { get; }
        #endregion

        #region Methodes
        public void Method()
        {
            if (SelectedProfessionnel.Count > 0)
                UnProfessionnel = (Professionnel)this.SelectedProfessionnel[SelectedProfessionnel.Count - 1];
            Professionnel.AjoutProfessionnelChoisie(UnProfessionnel);
        }
        public async void ActionSelectionProfessionnel()
        {
            Method();
            var SalarieStored = await App.Database.GetAvecRelations<Professionnel>(UnProfessionnel);

            Horaire A1 = new Horaire
            {
                Heuredébut = "9h00"
            };
            Horaire A2 = new Horaire
            {
                Heuredébut = "9h00"
            };
            SalarieStored.MaCollHoraire.Add(A1);

            await App.Database.SaveItemAsync<Horaire>(A1);
            SalarieStored.MaCollHoraire.Add(A2);

            await App.Database.SaveItemAsync<Horaire>(A2);

            await App.Database.MiseAJourRelation(SalarieStored);

            Application.Current.MainPage = new PageInformationsProfessionnelVue();
        }
        public void ActionBoutonPrendreRendezVous()
        {
            Method();
            Application.Current.MainPage = new NavigationPage(new PagePriseDeRendezVousVue());
        }

        #endregion
    }
}
