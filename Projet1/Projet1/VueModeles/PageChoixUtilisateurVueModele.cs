using Projet1.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet1.VueModeles
{
    public class PageChoixUtilisateurVueModele : BaseVueModele
    {
        #region Attributs
        #endregion

        #region Constructeurs
        public PageChoixUtilisateurVueModele()
        {
            CommandBoutonProfessionnel = new Command(ActionCommandBoutonProfessionnel);

            CommandBoutonPatient = new Command(ActionCommandBoutonPatient);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonProfessionnel { get; }

        public ICommand CommandBoutonPatient { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonProfessionnel()
        {
            Application.Current.MainPage = new PageInscriptionProfessionnelVue();
        }

        public void ActionCommandBoutonPatient()
        {
            Application.Current.MainPage = new PageInscriptionPatientVue();
        }
        #endregion
    }
}
