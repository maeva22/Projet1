using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet1.VueModeles;
using Projet1.Vues.Flyout;
using Xamarin.Forms;

namespace Projet1.Vues.Flyout
{
    public class PageAccueilVueFlyoutMenuItem 
    {
        public PageAccueilVueFlyoutMenuItem()
        {
            TargetType = typeof(PageAccueilVueFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string IconSource { get; set; }

    }
}