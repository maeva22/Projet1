using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet1.VueModeles;

namespace Projet1.Vues.Flyout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAccueilVueDetail : ContentPage
    {
        PageAccueilVueModele vueModele;
        public PageAccueilVueDetail()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageAccueilVueModele();
        }
    }
}