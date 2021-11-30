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
    public partial class IndexPageVue : ContentPage
    {
        IndexPageVueModele vueModele;
        public IndexPageVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new IndexPageVueModele();
        }
    }
}