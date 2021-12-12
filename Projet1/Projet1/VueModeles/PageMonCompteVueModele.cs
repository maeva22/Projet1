using Projet1.Modeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projet1.VueModeles
{
    public class PageMonCompteVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Patient> _lePatient;
        #endregion
        #region Constructeurs
        public PageMonCompteVueModele()
        {
            // code permettant d'afficher la liste des professionels
            ObservableCollection<Patient> unPatient = Patient.GetPatientConnecter();
            LePatient = new ObservableCollection<Patient>(unPatient);
        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<Patient> LePatient
        {
            get
            {
                return _lePatient;
            }
            set
            {
                SetProperty(ref _lePatient, value);
            }
        }
        #endregion

        #region Methodes
        #endregion
    }
}
