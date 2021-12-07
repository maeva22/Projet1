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
    public class Professionel : Utilisateur
    {
        #region Attributs
        public static ObservableCollection<Professionel> CollProfessionelChoisie = new ObservableCollection<Professionel>();

        private int _id;
        private string _formation;
        private string _adresse;
        private string _codePostale;
        private string _ville;
        private string _tarif;
        private string _presentation;
        private  ObservableCollection<Professionel> _maCollHoraire ;
        #endregion

        #region Constructeurs
        public Professionel()
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

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Professionel> MaCollHoraire { get => _maCollHoraire; set => _maCollHoraire = value; }

        #endregion

        #region Methodes
        public static new ObservableCollection<Professionel> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Professionel>();
        }
        public static async Task<Professionel> AjoutItemSqlite(Professionel param)
        {
            await App.Database.SaveItemAsync<Professionel>(param);
            return param;

        }

        // CollClasse du professionel selectionne par l'utilisateur 
        public static ObservableCollection<Professionel> GetProfessionelChoisie()
        {
            return Professionel.CollProfessionelChoisie;
        }
        public static void AjoutProfessionelChoisie(Professionel param)
        {
            Professionel.CollProfessionelChoisie.Add(param);
        }
        public static void SuppresionProfessionelChoisie()
        {
            Professionel.CollProfessionelChoisie.Clear();
        }
        #endregion
    }
}
