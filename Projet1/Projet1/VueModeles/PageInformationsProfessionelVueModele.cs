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
    class PageInformationsProfessionelVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Professionel> _leProfessionel;
        #endregion
        #region Constructeurs
        public PageInformationsProfessionelVueModele()
        {
            // code permettant d'afficher la liste des professionels
            ObservableCollection<Professionel> unProfessionel = Professionel.GetProfessionelChoisie();
            LeProfessionel = new ObservableCollection<Professionel>(unProfessionel);

            BoutonRetour = new Command(ActionCommandBoutonRetour);
            BoutonPrendreRendezVous = new Command(ActionBoutonPrendreRendezVous);
        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<Professionel> LeProfessionel
        {
            get
            {
                return _leProfessionel;
            }
            set
            {
                SetProperty(ref _leProfessionel, value);
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
            Professionel.SuppresionProfessionelChoisie();
            Application.Current.MainPage = new PageRechercheVue();
        }
        #endregion
    }
}
