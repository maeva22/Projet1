using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet1.VueModeles;
using Projet1.Modeles;
using Projet1.Vues.Flyout;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.ObjectModel;

namespace Projet1.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInscriptionPatientVue : ContentPage
    {
        PageInscriptionPatientVueModele vueModele;
        
        public PageInscriptionPatientVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageInscriptionPatientVueModele();
        }

        // code pour vérifier si l'adresse email est valide 
        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        // methode pour verifier si l'email est deja present dans la bdd
        public void NewEmailOrNot()
        {
            Patient.SuppresionPatientExistant();
            Patient.SuppresionPatientNouveauAttente();
            // voir si l'email est déjà présent dans la collection
            ObservableCollection<Patient> LesPastients = Patient.GetListSQLite();
            foreach (Patient unpatient in LesPastients)
            {
                if (EmailEntry.Text != unpatient.Email)
                {
                    Patient.AjoutPatientNouveauAttente(unpatient);
                }
                else
                {
                    Patient.AjoutPatientExistant(unpatient);
                }
            }
        }
        private string genreChoice;
        public string GenreChoice { get => genreChoice; set => genreChoice = value; }

        // code pour que l'utilisateur puisse s'inscrire
        async void OnButtonClickedPatient(object sender, EventArgs e)
        {   // verifir si l'utilisateur a rentre toutes les informations demande
            if (!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text) 
                && !string.IsNullOrEmpty(PasswordVerifyEntry.Text) && !string.IsNullOrEmpty(NomEntry.Text) 
                && !string.IsNullOrEmpty(PrenomEntry.Text) && !string.IsNullOrEmpty(NumEntry.Text))
            {
                // vérifie que l'email saisie est correct
                if (ValidateEmail(EmailEntry.Text))
                {
                    NewEmailOrNot();
                    if(Patient.CollPatientExistant.Count == 0)
                    {
                        // faire en sorte que l'utilisateur puisse seulement cocher un genre et non 2 
                        if ((FemmeEntry.IsChecked == true && HommeEntry.IsChecked == true) || (FemmeEntry.IsChecked == false && HommeEntry.IsChecked == false))
                        {
                            await DisplayAlert("Erreur", "Vous ne pouvez pas avoir 2 genres de coché !", "ok");
                        }
                        else
                        {   // vérifier que le mot de passe entré et le même entré dans le mot de passe de vérification
                            if (PasswordEntry.Text == PasswordVerifyEntry.Text)
                            {
                                if (FemmeEntry.IsChecked == true)
                                {
                                    GenreChoice = "Femme";
                                }
                                else
                                {
                                    GenreChoice = "Homme";
                                }
                                await App.Database.SaveItemAsync(new Patient
                                {

                                    Nom = NomEntry.Text,
                                    Prenom = PrenomEntry.Text,
                                    Genre = GenreChoice,
                                    DateDeNaissance = DateEntry.Date,
                                    NumeroTelephone = NumEntry.Text,
                                    Email = EmailEntry.Text,
                                    Password = PasswordEntry.Text
                                });

                                await DisplayAlert("Bravo", "enregistrement réussi", "ok");
                                Application.Current.MainPage = new PageConnexionVue();
                            }
                            else
                            {
                                await DisplayAlert("Erreur", "Vos mots de passes ne sont pas les mêmes", "ok");
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Erreur", "Cette adresse email est déjà existante! Vous avez peut-être déjà un compte ?", "ok");
                    }
                }
                else
                {
                    await DisplayAlert("Erreur", "Votre adresse email n'est pas valide", "ok");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Vous n'avez pas remplis tous les champs nécessaire !", "ok");
            }
        }
    }
}