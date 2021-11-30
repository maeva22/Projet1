using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Projet1.Modeles;
using Projet1.Vues;
using Projet1.Vues.Flyout;

namespace Projet1.VueModeles
{
    class IndexPageVueModele : BaseVueModele
    {
        #region Attributs
        #endregion

        #region Constructeurs
        public IndexPageVueModele()
        {
            CommandBoutonInscription = new Command(ActionCommandBoutonInscription);

            CommandBoutonConnexion = new Command(ActionCommandBoutonConnexion);

            CommandBoutonContinuer = new Command(ActionCommandBoutonContinuer);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonInscription { get; }
        public ICommand CommandBoutonConnexion { get; }
        public ICommand CommandBoutonContinuer { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonInscription()
        {
            Application.Current.MainPage = new PageChoixUtilisateurVue();
        }

        public void ActionCommandBoutonConnexion()
        {
            Application.Current.MainPage = new PageConnexionVue();
        }

        public void ActionCommandBoutonContinuer()
        {
            Application.Current.MainPage = new PageAccueilVue();
        }
        #endregion
    }
}
