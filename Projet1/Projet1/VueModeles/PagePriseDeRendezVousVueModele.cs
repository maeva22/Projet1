﻿using Projet1.Modeles;
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
        #endregion
        #region Constructeurs
        public PagePriseDeRendezVousVueModele()
        {
            ObservableCollection<Professionel> unProfessionel = Professionel.GetProfessionelChoisie();
            LeProfessionel = new ObservableCollection<Professionel>(unProfessionel);

            BoutonRetour = new Command(ActionCommandBoutonRetour);
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