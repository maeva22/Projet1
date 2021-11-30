﻿using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    internal class PageInscriptionProfessionelVueModele : BaseVueModele
    {
        #region Attributs
        #endregion
        #region Constructeurs
        public PageInscriptionProfessionelVueModele()
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
        }
        #endregion

        #region Getters/Setters

        public ICommand CommandBoutonRetour { get; }
        #endregion

        #region Methodes

        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new IndexPageVue();
        }

        #endregion
    }
}
