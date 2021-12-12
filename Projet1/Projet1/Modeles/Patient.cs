using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Modeles
{
    [Table("Patient")]
    public class Patient : Utilisateur
    {
        #region Attributs
        public static ObservableCollection<Patient> CollPatientConnecter = new ObservableCollection<Patient>();
        public static ObservableCollection<Patient> CollPatientExistant = new ObservableCollection<Patient>();
        public static ObservableCollection<Patient> CollPatientNouveauAttente = new ObservableCollection<Patient>();

        private int _id;
        #endregion

        #region Constructeurs
        public Patient()
        {
        }
        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public new int ID { get => _id; set => _id = value; }


        #endregion

        #region Methodes
        public static new ObservableCollection<Patient> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Patient>();
        }
        public static async Task<Patient> AjoutItemSqlite(Patient param)
        {
            await App.Database.SaveItemAsync<Patient>(param);
            return param;

        }

        // CollClasse pour calculer les patients existant 
        public static ObservableCollection<Patient> GetPatientExistant()
        {
            return Patient.CollPatientExistant;
        }
        public static void AjoutPatientExistant(Patient param)
        {
            Patient.CollPatientExistant.Add(param);
        }
        public static void SuppresionPatientExistant()
        {
            Patient.CollPatientExistant.Clear();
        }
        // CollClasse pour calculer les patients potentiellement nouveau 
        public static ObservableCollection<Patient> GetPatientNouveauAttente()
        {
            return Patient.CollPatientNouveauAttente;
        }
        public static void AjoutPatientNouveauAttente(Patient param)
        {
            Patient.CollPatientNouveauAttente.Add(param);
        }
        public static void SuppresionPatientNouveauAttente()
        {
            Patient.CollPatientNouveauAttente.Clear();
        }


        // Collection pour l'utilisateur connecter 
        public static ObservableCollection<Patient> GetPatientConnecter()
        {
            return Patient.CollPatientConnecter;
        }
        public static void AjoutPatientConnecter(Patient param)
        {
            Patient.CollPatientConnecter.Add(param);
        }
        public static void SuppresionPatientConnecter()
        {
            Patient.CollPatientConnecter.Clear();
        }


        #endregion
    }
}
