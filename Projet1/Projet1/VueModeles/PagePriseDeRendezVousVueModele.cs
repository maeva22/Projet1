using Projet1.Modeles;
using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Projet1.Calendrier.Enums ;
using Projet1.Calendrier.Models;
using Projet1.VueModeles;

namespace Projet1.VueModeles
{
    public class PagePriseDeRendezVousVueModele : BaseVueModele
    {
        #region Attributs
        protected Page page;
        ObservableCollection<Professionnel> _leProfessionnel;

        ObservableCollection<Horaire> _maListeHoraire;
        private ObservableCollection<object> _selectedHoraire;
        private Horaire _unHoraire;

        // calendrier 
        private DateTime _maximumDate = DateTime.Today.AddMonths(5);
        private DateTime _minimumDate = DateTime.Today;
        private DateTime? _selectedDate = DateTime.Today;
        private WeekLayout _calendarLayout = WeekLayout.Week;
        private DateTime _shownDate = DateTime.Today;
        private int _year = DateTime.Today.Year;
        private int _month = DateTime.Today.Month;
        private int _day = DateTime.Today.Day;
        #endregion

        #region Constructeurs
        public PagePriseDeRendezVousVueModele(Page page) : base()
        {
            this.page = page;

            // affiche le professionel
            ObservableCollection<Professionnel> unProfessionnel = Professionnel.GetProfessionnelChoisie();
            LeProfessionnel = new ObservableCollection<Professionnel>(unProfessionnel);

            BoutonRetour = new Command(ActionCommandBoutonRetour);

            // code essaie pour l'horaire 
            ObservableCollection<Horaire> listeHoraire = Horaire.GetListSQLite();
            MaListeHoraire = new ObservableCollection<Horaire>(listeHoraire);

            SelectedHoraire = new ObservableCollection<object>();
            UnHoraire = new Horaire
            {
                Heuredébut = "",
            };
            SelectionChangedCommandHoraire = new Command(ActionSelectionHoraire);
            // fin code essaie 

            CommandHoraire = new Command(ActionHoraire);

            Events = new HoraireCollection
            {
                [DateTime.Now.AddDays(10)] = new List<Horaire>(GenerateEvents(1, "Pas de rendez-vous possible ce jour là")),
            };
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
        // public Calendrier 
        public HoraireCollection Events { get; }
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
        public WeekLayout CalendarLayout
        {
            get => _calendarLayout;
            set => SetProperty(ref _calendarLayout, value);
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
        public ICommand TodayCommand => new Command(() =>
        {
            ShownDate = DateTime.Today;
            SelectedDate = DateTime.Today;
        });

        public ICommand BoutonRetour { get; }
        public ICommand SelectionChangedCommandHoraire { get; }
        public ICommand HoraireSelectedCommand => new Command(async (item) => await ActionHoraireSelectedCommand(item));
        public ICommand CommandHoraire { get; }
        
        #endregion

        #region Methodes 
        //methode Caldendrier
        private IEnumerable<Horaire> GenerateEvents(int count, string name)
        {
            return Enumerable.Range(1, count).Select(x => new Horaire
            {
                Heuredébut = $"{name} event{x}",
            });
        }
        private async Task ActionHoraireSelectedCommand(object item)
        {
            if (item is Horaire eventModel)
            {
                await App.Current.MainPage.DisplayAlert(eventModel.Heuredébut,"Rendez-vous", "Ok");
            }
        }

        // methode bouton retour  
        public void ActionCommandBoutonRetour()
        {
            Professionnel.SuppresionProfessionnelChoisie();
            Application.Current.MainPage = new PageRechercheVue();
        }

        public void ActionHoraire()
        {
        }

        //Methode pour la prise de RDV
        public void Method()
        {
            if (SelectedHoraire.Count > 0)
                UnHoraire = (Horaire)this.SelectedHoraire[SelectedHoraire.Count - 1];
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
