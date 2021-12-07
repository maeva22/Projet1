using Projet1.Calendrier.Enums;
using Projet1.Calendrier.Models;
using Projet1.Modeles;
using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
     class PagePriseDeRendezVousVueModele : BaseVueModele
    {
        #region Attributs
        protected Page page;
        ObservableCollection<Professionel> _leProfessionel;

        ObservableCollection<Horaire> _maListeHoraire;
        private ObservableCollection<object> _selectedHoraire;
        private Horaire _unHoraire;

        private int _day = DateTime.Today.Day;
        private int _month = DateTime.Today.Month;
        private int _year = DateTime.Today.Year;

        private DateTime _shownDate = DateTime.Today;
        private DateTime? _selectedDate = DateTime.Today;
        private DateTime _minimumDate = DateTime.Today;
        private DateTime _maximumDate = DateTime.Today.AddMonths(5);
        #endregion

        #region Constructeurs
        public PagePriseDeRendezVousVueModele(Page page)
        {
            this.page = page;
            // affiche le professionel
            ObservableCollection<Professionel> unProfessionel = Professionel.GetProfessionelChoisie();
            LeProfessionel = new ObservableCollection<Professionel>(unProfessionel);

            BoutonRetour = new Command(ActionCommandBoutonRetour);

            ObservableCollection<Horaire> listeHoraire = Horaire.GetHoraireRestant();
            MaListeHoraire = new ObservableCollection<Horaire>(listeHoraire);

            SelectedHoraire = new ObservableCollection<object>();
            UnHoraire = new Horaire
            {
                Heuredébut = "",
            };
            SelectionChangedCommandHoraire = new Command(ActionSelectionHoraire);
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
        public ObservableCollection<Horaire> MaListeHoraire
        {
            get
            {
                return _maListeHoraire;
            }
            set
            {
                SetProperty(ref _maListeHoraire, value);
            }
        }
        public ObservableCollection<object> SelectedHoraire
        {
            get
            {
                return _selectedHoraire;
            }
            set
            {
                SetProperty(ref _selectedHoraire, value);
            }
        }
        public Horaire UnHoraire
        {
            get
            {
                return _unHoraire;
            }
            set
            {
                SetProperty(ref _unHoraire, value);
            }
        }
        public ICommand BoutonRetour { get; }
        public ICommand SelectionChangedCommandHoraire { get; }
        // code Calendrier

        public int Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }

        public int Month
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }

        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        public DateTime ShownDate
        {
            get => _shownDate;
            set => SetProperty(ref _shownDate, value);
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        public DateTime MinimumDate
        {
            get => _minimumDate;
            set => SetProperty(ref _minimumDate, value);
        }

        public DateTime MaximumDate
        {
            get => _maximumDate;
            set => SetProperty(ref _maximumDate, value);
        }

        #endregion

        #region Methodes 
        
        public void ActionCommandBoutonRetour()
        {
            Professionel.SuppresionProfessionelChoisie();
            Application.Current.MainPage = new PageRechercheVue();
        }
        public void Method()
        {
            if (SelectedHoraire.Count > 0)
                UnHoraire = (Horaire)this.SelectedHoraire[SelectedHoraire.Count - 1];
            Horaire.AjoutHoraireChoisie(UnHoraire);
            Horaire.SupprimeHoraireRestant(UnHoraire);
        }
        public async void ActionSelectionHoraire()
        {

            Method();
            await page.DisplayAlert("Bravo", "Vous venez de prendre rendez-vous !", "ok");
            Application.Current.MainPage = new PagePriseDeRendezVousVue();
        }
        #endregion
    }
}
