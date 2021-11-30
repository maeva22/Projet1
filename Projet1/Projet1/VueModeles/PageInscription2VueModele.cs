using System;
using System.Collections.Generic;
using System.Text;
using Projet1.VueModeles;
using Projet1.Vues;
using Projet1.Services;
using Projet1.Modeles;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    class PageInscription2VueModele :BaseVueModele
    {
        #region Attributs
        #endregion
        #region Constructeurs
        public PageInscription2VueModele()
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonSuivant => new Command(ActionCommandBoutonSuivant);

        public ICommand CommandBoutonRetour { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonSuivant()
        {

            Application.Current.MainPage = new PageInscription3Vue(); // mettre 2 
        }

        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new PageInscription1Vue();
        }
        #endregion
    }
}
