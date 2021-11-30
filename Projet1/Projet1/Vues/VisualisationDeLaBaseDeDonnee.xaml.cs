﻿using Projet1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet1.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualisationDeLaBaseDeDonnee : ContentPage
    {
        public VisualisationDeLaBaseDeDonnee()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = Professionel.GetProfessionelChoisie();
        }
    }
}
                           