using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    class PageChoixUtilisateurVueModele : BaseVueModele
    {
        #region Attributs
        #endregion

        #region Constructeurs
        public PageChoixUtilisateurVueModele()
        {
            CommandBoutonProfessionel = new Command(ActionCommandBoutonProfessionel);

            CommandBoutonPatient = new Command(ActionCommandBoutonPatient);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonProfessionel { get; }

        public ICommand CommandBoutonPatient { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonProfessionel()
        {
            Application.Current.MainPage = new PageInscriptionProfessionelVue();
        }

        public void ActionCommandBoutonPatient()
        {
            Application.Current.MainPage = new PageInscription1Vue();
        }
        #endregion
    }
}
