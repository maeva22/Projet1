using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Projet1.Vues.Flyout;
using Projet1.Vues;

namespace Projet1.VueModeles
{
    public class PageAccueilVueModele : BaseVueModele
    {
        #region Attributs
        #endregion

        #region Constructeurs
        public PageAccueilVueModele()
        {
            CommandBoutonMap = new Command(ActionCommandBoutonMap);

            CommandBoutonProfession = new Command(ActionCommandBoutonProfession);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonMap { get; }
        public ICommand CommandBoutonProfession { get; }
        #endregion

        #region Methodes
        public void ActionCommandBoutonMap()
        {
            Application.Current.MainPage = new PageMapVue();
        }
        public void ActionCommandBoutonProfession()
        {
            Application.Current.MainPage = new PageRechercheVue();
        }
        #endregion
    }
}
