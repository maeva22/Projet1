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
     class PagePriseDeRendezVousVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Professionel> _leProfessionel;
        private DateTime _datePickerSelected;
        private DateTime _minDate;
        private DateTime _maxDate;
        #endregion
        #region Constructeurs
        public PagePriseDeRendezVousVueModele()
        {
            // affiche le professionel
            ObservableCollection<Professionel> unProfessionel = Professionel.GetProfessionelChoisie();
            LeProfessionel = new ObservableCollection<Professionel>(unProfessionel);

            BoutonRetour = new Command(ActionCommandBoutonRetour);

            DateTime dt = DateTime.Now;
            DatePickerSelected = dt.AddDays(5);
        }
        #endregion

        #region Getters/Setters BoutonPrendreRendezVous
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
        public DateTime DatePickerSelected
        {
            get
            {
                return _datePickerSelected;
            }
            set
            {
                SetProperty(ref _datePickerSelected, value);
            }
        }
        public DateTime MinDate
        {
            get
            {
                return _minDate;
            }
            set
            {
                SetProperty(ref _minDate, value);
            }
        }
        public DateTime MaxDate
        {
            get
            {
                return _maxDate;
            }
            set
            {
                SetProperty(ref _maxDate, value);
}
        }
        public ICommand BoutonRetour { get; }
        #endregion

        #region Methodes

        public void ActionCommandBoutonRetour()
        {
            Professionel.SuppresionProfessionelChoisie();
            Application.Current.MainPage = new PageRechercheVue();
        }

        #endregion
    }
}
