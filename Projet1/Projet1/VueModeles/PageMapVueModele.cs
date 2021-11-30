using Projet1.Vues;
using Projet1.Vues.Flyout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
     class PageMapVueModele : BaseVueModele
    {
        #region Attributs
        #endregion
        #region Constructeurs
        public PageMapVueModele()
        {
            BoutonRetour = new Command(ActionCommandBoutonRetour);
        }
        #endregion

        #region Getters/Setters
        public ICommand BoutonRetour { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {

            Application.Current.MainPage = new PageAccueilVue(); 
        }

        #endregion
    }
}
