using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Projet1.Modeles;
using Projet1.Vues;
using System.Text.RegularExpressions;
using System.Globalization;
using Projet1.Vues.Flyout;

namespace Projet1.VueModeles
{
    public class PageInscriptionPatientVueModele : BaseVueModele
    {
        #region Attributs
        #endregion
        #region Constructeurs
        public PageInscriptionPatientVueModele()
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
