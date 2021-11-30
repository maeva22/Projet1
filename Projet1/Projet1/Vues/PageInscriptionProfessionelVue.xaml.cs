﻿using Projet1.Modeles;
using Projet1.VueModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet1.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInscriptionProfessionelVue : ContentPage
    {
        PageInscriptionProfessionelVueModele vueModele;
        public PageInscriptionProfessionelVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageInscriptionProfessionelVueModele();
        }
        // code pour vérifier si l'adresse email est valide 
        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        private string genreChoice;
        public string GenreChoice { get => genreChoice; set => genreChoice = value; }
        // code pour que l'utilisateur puisse s'inscrire
        async void OnButtonClickedProfessionel(object sender, EventArgs e)
        {   // verifir si l'utilisateur a rentre toutes les informations demande
            if (!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text)
                && !string.IsNullOrEmpty(PasswordVerifyEntry.Text) && !string.IsNullOrEmpty(NomEntry.Text)
                && !string.IsNullOrEmpty(PrenomEntry.Text) && !string.IsNullOrEmpty(NumEntry.Text)
                && !string.IsNullOrEmpty(FormationEntry.Text) && !string.IsNullOrEmpty(AdresseEntry.Text)
                && !string.IsNullOrEmpty(CodePostaleEntry.Text) && !string.IsNullOrEmpty(TarifEntry.Text)
                && !string.IsNullOrEmpty(PresentationEntry.Text))
            {
                // vérifie que l'email saisie est correct
                if (ValidateEmail(EmailEntry.Text))
                {
                        // faire en sorte que l'utilisateur puisse seulement cocher un genre et non 2 
                        if (FemmeEntry.IsChecked == true && HommeEntry.IsChecked == true)
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
                            await App.Database.SaveItemAsync(new Professionel
                                {
                                    Nom = NomEntry.Text,
                                    Prenom = PrenomEntry.Text,
                                    Genre = GenreChoice,
                                    DateDeNaissance = DateEntry.Date,
                                    NumeroTelephone = NumEntry.Text,
                                    Email = EmailEntry.Text,
                                    Password = PasswordEntry.Text,
                                    Formation = FormationEntry.Text,
                                    Adresse = AdresseEntry.Text,
                                    CodePostale = CodePostaleEntry.Text,
                                    Ville = VilleEntry.Text,
                                    Tarif = TarifEntry.Text,    
                                    Presentation=PresentationEntry.Text
                                });

                                await DisplayAlert("Bravo", "enregistrement reussi", "ok");
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