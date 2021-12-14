using Projet1.Modeles;
using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    public class PageInformationsProfessionnelVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Professionnel> _leProfessionnel;
        #endregion
        #region Constructeurs
        public PageInformationsProfessionnelVueModele()
        {
            // code permettant d'afficher la liste des professionels
            ObservableCollection<Professionnel> unProfessionnel = Professionnel.GetProfessionnelChoisie();
            LeProfessionnel = new ObservableCollection<Professionnel>(unProfessionnel);

            BoutonRetour = new Command(ActionCommandBoutonRetour);
            BoutonPrendreRendezVous = new Command(ActionBoutonPrendreRendezVous);
        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<Professionnel> LeProfessionnel
        {
            get
            {
                return _leProfessionnel;
            }
            set
            {
                SetProperty(ref _leProfessionnel, value);
            }
        }
        public ICommand BoutonPrendreRendezVous { get; }
        public ICommand BoutonRetour { get; }
        #endregion

        #region Methodes
        public void ActionBoutonPrendreRendezVous()
        {
            Application.Current.MainPage = new NavigationPage(new PagePriseDeRendezVousVue());
        }
        public void ActionCommandBoutonRetour()
        {
            Professionnel.SuppresionProfessionnelChoisie();
            Application.Current.MainPage = new NavigationPage(new PageRechercheVue());
        }
        #endregion
    }
}
