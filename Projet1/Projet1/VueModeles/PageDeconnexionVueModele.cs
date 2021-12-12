using Projet1.Modeles;
using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    public class PageDeconnexionVueModele : BaseVueModele
    {
        #region Attributs

        #endregion

        #region Constructeur
        public PageDeconnexionVueModele()
        {
            CommandBoutonDeconnexion = new Command(ActionCommandBoutonDeconnexion);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonDeconnexion { get; }


        #endregion

        #region Methodes
        public void ActionCommandBoutonDeconnexion()
        {
            Patient.SuppresionPatientConnecter();
            Application.Current.MainPage = new IndexPageVue();
        }


        #endregion
    }
}
