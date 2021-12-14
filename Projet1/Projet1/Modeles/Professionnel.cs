using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Modeles
{
    [Table("Professionel")]
    public class Professionnel : Utilisateur
    {
        #region Attributs
        public static ObservableCollection<Professionnel> CollProfessionnelChoisie = new ObservableCollection<Professionnel>();
        public static ObservableCollection<Professionnel> CollProfessionnelExistant = new ObservableCollection<Professionnel>();
        public static ObservableCollection<Professionnel> CollProfessionnelNouveauAttente = new ObservableCollection<Professionnel>();
        public static ObservableCollection<Professionnel> CollProfessionnelConnecter = new ObservableCollection<Professionnel>();

        private int _id;
        private string _formation;
        private string _adresse;
        private string _codePostale;
        private string _ville;
        private string _tarif;
        private string _presentation;
        #endregion

        #region Constructeurs
        public Professionnel()
        {
        }
        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public new int ID { get => _id; set => _id = value; }
        public string Formation { get => _formation; set => _formation = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string CodePostale { get => _codePostale; set => _codePostale = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string Tarif { get => _tarif; set => _tarif = value; }
        public string Presentation { get => _presentation; set => _presentation = value; }


        #endregion

        #region Methodes

        public static new ObservableCollection<Professionnel> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Professionnel>();
        }
        public static async Task<Professionnel> AjoutItemSqlite(Professionnel param)
        {
            await App.Database.SaveItemAsync<Professionnel>(param);
            return param;

        }

        // CollClasse du professionel selectionne par l'utilisateur 
        public static ObservableCollection<Professionnel> GetProfessionnelChoisie()
        {
            return Professionnel.CollProfessionnelChoisie;
        }
        public static void AjoutProfessionnelChoisie(Professionnel param)
        {
            Professionnel.CollProfessionnelChoisie.Add(param);
        }
        public static void SuppresionProfessionnelChoisie()
        {
            Professionnel.CollProfessionnelChoisie.Clear();
        }

        // CollClasse pour calculer les patients existant 
        public static ObservableCollection<Professionnel> GetProfessionnelExistant()
        {
            return Professionnel.CollProfessionnelExistant;
        }
        public static void AjoutProfessionnelExistant(Professionnel param)
        {
            Professionnel.CollProfessionnelExistant.Add(param);
        }
        public static void SuppresionProfessionnelExistant()
        {
            Professionnel.CollProfessionnelExistant.Clear();
        }
        // CollClasse pour calculer les patients potentiellement nouveau 
        public static ObservableCollection<Professionnel> GetProfessionnelNouveauAttente()
        {
            return Professionnel.CollProfessionnelNouveauAttente;
        }
        public static void AjoutProfessionnelNouveauAttente(Professionnel param)
        {
            Professionnel.CollProfessionnelNouveauAttente.Add(param);
        }
        public static void SuppresionProfessionnelNouveauAttente()
        {
            Professionnel.CollProfessionnelNouveauAttente.Clear();
        }
        #endregion
    }
}
