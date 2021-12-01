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
    public partial class PageInscription1Vue : ContentPage
    {
        PageInscription1VueModele vueModele;
        public PageInscription1Vue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageInscription1VueModele();
        }

        // code pour vérifier si l'adresse email est valide 
        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        /*public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }*/
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
                    // voir si l'email est déjà présent dans la collection
                    //if (Utilisateur.(EmailEntry.Text))
                    //{
                        // verifier que le numero de telephone est correct
                        //if (IsPhoneNumber(NumEntry.Text))
                        //{
                            // faire en sorte que l'utilisateur puisse seulement cocher un genre et non 2 
                            if ((FemmeEntry.IsChecked == true && HommeEntry.IsChecked == true) || (FemmeEntry.IsChecked == false && HommeEntry.IsChecked == false))
                            {
                                await DisplayAlert("Erreur", "Vous ne pouvez pas avoir 2 genres de coché !", "ok");
                            }
                            else
                            {
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

                                    await DisplayAlert("Bravo", "enregistrement reussi", "ok");
                                    Application.Current.MainPage = new PageConnexionVue();
                                }
                                else
                                {
                                    await DisplayAlert("Erreur", "Vos mots de passes ne sont pas les mêmes", "ok");
                                }
                            }
                       // }
                        //else
                        //{
                            //await DisplayAlert("Erreur", "Votre numéro de téléphone n'est pas valide", "ok");
                        //}
                    /*}
                    else
                    {
                        await DisplayAlert("Erreur", "Cette adresse email est déjà prise! Vous avez peut-être déjà un compte ?", "ok");
                    }*/
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