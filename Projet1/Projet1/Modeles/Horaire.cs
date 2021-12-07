using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Modeles
{
    [Table("Horaire")]
    public class Horaire
    {
        #region Attributs
        public static ObservableCollection<Horaire> CollHoraireChoisie = new ObservableCollection<Horaire>();
        public static ObservableCollection<Horaire> CollHoraireRestant = new ObservableCollection<Horaire>();
        private int _id;
        private string _heuredébut;
        #endregion

        #region Constructeurs
        public Horaire()
        {
            
        }
        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public  int ID { get => _id; set => _id = value; }
        public string Heuredébut { get => _heuredébut; set => _heuredébut = value; }


        #endregion

        #region Methodes

        public static ObservableCollection<Horaire> GetListSQLite()
        {
            return App.Database.GetItemsAsync<Horaire>();
        }
        public static async Task<Horaire> AjoutItemSqlite(Horaire param)
        {

            Horaire.AjoutHoraireRestant(param);
            await App.Database.SaveItemAsync<Horaire>(param);
            return param;

        }
        public static ObservableCollection<Horaire> GetHoraireRestant()
        {
            return Horaire.CollHoraireRestant;
        }
        public static void AjoutHoraireRestant(Horaire param)
        {
            Horaire.CollHoraireRestant.Add(param);
        }        
        public static void SupprimeHoraireRestant(Horaire param)
        {
            Horaire.CollHoraireRestant.Remove(param);
        }
        public static void AjoutHoraireChoisie(Horaire param)
        {
            Horaire.CollHoraireChoisie.Add(param);
        }
        #endregion
    }
}
