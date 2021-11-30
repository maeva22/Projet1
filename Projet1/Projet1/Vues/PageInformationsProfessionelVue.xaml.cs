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
    public partial class PageInformationsProfessionelVue : ContentPage
    {
        PageInformationsProfessionelVueModele vueModele;
        public PageInformationsProfessionelVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageInformationsProfessionelVueModele();
        }
    }
}