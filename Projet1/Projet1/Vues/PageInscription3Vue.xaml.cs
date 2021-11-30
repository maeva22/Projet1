using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet1.VueModeles;

namespace Projet1.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInscription3Vue : ContentPage
    {
        PageInscription3VueModele vueModele;
        public PageInscription3Vue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageInscription3VueModele();
        }
    }
}