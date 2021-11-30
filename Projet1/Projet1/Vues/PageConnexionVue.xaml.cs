using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet1.VueModeles;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Projet1.Modeles;

namespace Projet1.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageConnexionVue : ContentPage
    {
        PageConnexionVueModele vueModele;
        public PageConnexionVue()
        { 
            InitializeComponent();
            BindingContext = vueModele = new PageConnexionVueModele(this);
        }
    }
}