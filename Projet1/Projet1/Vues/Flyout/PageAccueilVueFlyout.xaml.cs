using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet1.Vues.Flyout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAccueilVueFlyout : ContentPage
    {
        public ListView ListView;

        public PageAccueilVueFlyout()
        {
            InitializeComponent();

            BindingContext = new PageAccueilVueFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class PageAccueilVueFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PageAccueilVueFlyoutMenuItem> MenuItems { get; set; }

            public PageAccueilVueFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PageAccueilVueFlyoutMenuItem>(new[]
                {
                    new PageAccueilVueFlyoutMenuItem { Id = 0, Title = "Accueil",IconSource="icon_home.png",TargetType =typeof(PageAccueilVueDetail)},
                    new PageAccueilVueFlyoutMenuItem { Id = 1, Title = "Mon Compte",TargetType =typeof(PageConnexionVue) },
                    new PageAccueilVueFlyoutMenuItem { Id = 2, Title = "Mes Rendez-vous",TargetType =typeof(PageMapVue) },
                    new PageAccueilVueFlyoutMenuItem { Id = 3, Title = "Déconnexion",TargetType =typeof(PageAccueilVue) }

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}