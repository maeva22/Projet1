using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Projet1.Modeles;
using Projet1.Services;

namespace Projet1.VueModeles
{
    class PageInscription3VueModele : BaseVueModele
    {
        #region Attributs
        #endregion
        #region Constructeurs
        public PageInscription3VueModele()
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonAccepter => new Command(ActionCommandBoutonAccepter);

        public ICommand CommandBoutonRetour { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonAccepter()
        {

            //Application.Current.MainPage = new PageIndexPatient(); 
        }

        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new PageInscription2Vue();
        }
        #endregion
    }
}
