using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet1.VueModeles;
using System.Windows.Input;
using Projet1.Vues;
using System.ComponentModel;
using Projet1.Modeles;
using Projet1.Vues.Flyout;

namespace Projet1.VueModeles
{
    class PageConnexionVueModele :BaseVueModele
    {
        #region Attributs
        private string email;
        private string motdepasse;
        

        #endregion
        #region Constructeur
        public PageConnexionVueModele()
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);

            //CommandBoutonConnexion = new Command(ActionCommandBoutonConnexion);

            CommandBoutonConnexion = new Command(OnSubmit);
        }
        #endregion

        #region Getters/Setters
        public string Email
        {
            get 
            {
                return email;
            }  
            set
            {
                SetProperty(ref email, value);
            }
        }

        public string Motdepasse
        {
            get 
            { 
                return motdepasse; 
            }  
            set
            {
                SetProperty(ref motdepasse, value);
            }
        }
        public ICommand CommandBoutonRetour { get; }

        public ICommand CommandBoutonConnexion { get; private set; }

        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new IndexPageVue();
        }

        public void OnSubmit()
        {
            /*if (TextEmail == _email && TextPassword == _password)
            {
                Application.Current.MainPage = new PageAccueilVue();
            }
            else
            {
               
            }*/
        }


        /*public void ActionCommandBoutonConnexion()
        {
            Application.Current.MainPage = new PageInscription1Vue();
        }*/


        #endregion
    }
}
