using Projet1.VueModeles;
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
    public partial class PageChoixUtilisateurVue : ContentPage
    {
        PageChoixUtilisateurVueModele vueModele;
        public PageChoixUtilisateurVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageChoixUtilisateurVueModele();
        }
    }
}