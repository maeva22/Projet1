using Projet1.Calendrier.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet1.Calendrier.Controls
{
    /// <summary>
    /// Internal class used by Xamarin.Plugin.Calendar
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayView : ContentView
    {        
        internal DayView()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (BindingContext is DayModel dayModel && !dayModel.IsDisabled && dayModel.IsVisible)
            {
                dayModel.IsSelected = !dayModel.IsSelected;
                dayModel.DayTappedCommand?.Execute(dayModel.Date);
            }
        }
    }
}