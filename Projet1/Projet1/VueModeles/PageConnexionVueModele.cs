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
using System.Collections.ObjectModel;

namespace Projet1.VueModeles
{
    public class PageConnexionVueModele :BaseVueModele
    {
        #region Attributs
        protected Page page;
        private string _emailEntry;
        private string _passwordEntry;

        #endregion
        #region Constructeur
        public PageConnexionVueModele(Page page)
        {
            this.page = page;
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
            CommandBoutonConnexionPatient = new Command(OnSubmit);
        }
        #endregion

        #region Getters/Setters
        public string EmailEntry
        {
            get 
            {
                return _emailEntry;
            }  
            set
            {
                SetProperty(ref _emailEntry, value);
            }
        }

        public string PasswordEntry
        {
            get 
            { 
                return _passwordEntry; 
            }  
            set
            {
                SetProperty(ref _passwordEntry, value);
            }
        }
        public ICommand CommandBoutonRetour { get; }

        public ICommand CommandBoutonConnexionPatient { get; private set; }

        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new IndexPageVue();
        }

        // méthode permettant à un utilisateur de se connecter
        public async void OnSubmit()
        {
            NewEmailOrNot();
            if (Patient.CollPatientConnecter.Count == 1 )
            {
                Application.Current.MainPage = new PageAccueilVue();
                await page.DisplayAlert("Bravo", "Vous êtes connecté!", "ok");
            }
            else
            {
                await page.DisplayAlert("Erreur", "Votre mot de passe ou votre email n'est pas bon !", "ok");
            }
        }
        public void NewEmailOrNot()
        {
            Patient.SuppresionPatientExistant();
            Patient.SuppresionPatientConnecter();
            // voir si l'email est déjà présent dans la collection ainsi que le mot de passe qui lui appartient 
            ObservableCollection<Patient> LesPastients = Patient.GetListSQLite();
            foreach (Patient unpatient in LesPastients)
            {
                if (EmailEntry == unpatient.Email && PasswordEntry == unpatient.Password)
                {
                    Patient.AjoutPatientConnecter(unpatient);
                }
                else
                {
                    Patient.AjoutPatientExistant(unpatient);
                }
            }
        }

        #endregion
    }
}
