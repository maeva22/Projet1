using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet1.Vues;
using Projet1.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Projet1.Modeles;
using System.Linq;

namespace Projet1
{
    public partial class App : Application
    {
        static GestionDataBase database;
        public ObservableCollection<Professionnel> listeProfessionel;
        public ObservableCollection<Horaire> listeHoraire;
        public ObservableCollection<Patient> listePatient;
        public App()
        {
            InitializeComponent();
            GetListe();
            MainPage = new IndexPageVue();
        }

        protected override void OnStart()
        {
            Patient.SuppresionPatientConnecter();
        }

        protected override void OnSleep()
        {
            Patient.SuppresionPatientConnecter();
        }

        protected override void OnResume()
        {
            Patient.SuppresionPatientConnecter();
        }
        public static GestionDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GestionDataBase();
                }
                return database;
            }
        }
        public async Task GetListe()
        {
            await App.database.DeleteItemsAsync<Professionnel>(); // efface tous les professionels dans la table 

            listeProfessionel = App.Database.GetItemsAsync<Professionnel>();

            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "ROBIN") == null) await Professionnel.AjoutItemSqlite(new Professionnel{
                Genre = "Femme",
                Nom = "ROBIN",
                Prenom = "oceane",
                DateDeNaissance = new DateTime(2002, 10, 24),
                NumeroTelephone="0615489764",
                Email="orobin.ledantec@gmail.com",
                Password="toto",
                Formation= "Médecin généraliste",
                Adresse= "Rue des Cordiers",
                CodePostale="22300",
                Ville="lannion",
                Tarif="3.50",
                Presentation= "Le médecin généraliste accueille les enfants et les adultes pour tous types de soins médicaux généraux (consultation, contrôle annuel, vaccination, bilan de santé). " +
                "Il assure également un suivi des patients dans le temps et les oriente vers des médecins spécialistes en cas de besoin.",
            });
            /*if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "DESABLENS") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Femme",
                Nom = "DESABLENS", 
                Prenom = "maeva",
                DateDeNaissance = new DateTime(2002, 02, 24),
                NumeroTelephone = "0615489764",
                Email = "mdesablens.ledantec@gmail.com",
                Password = "toto",
                Formation = "Médecin généraliste",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le médecin généraliste accueille les enfants et les adultes pour tous types de soins médicaux généraux (consultation, contrôle annuel, vaccination, bilan de santé). " +
                "Il assure également un suivi des patients dans le temps et les oriente vers des médecins spécialistes en cas de besoin."
            });*/
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "L'HER") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Femme",
                Nom = "L'HER", 
                Prenom = "emilie",
                DateDeNaissance = new DateTime(2002, 12, 03),
                NumeroTelephone = "0615489764",
                Email = "elher.ledantec@gmail.com",
                Password = "toto",
                Formation = "Sage-Femme",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "La sage-femme est une spécialiste de la grossesse. Elle surveille le travail et pratique l'accouchement eutocique (l'accouchement normal). " +
                "Elle dispense aussi les soins nécessaires à la mère et au nouveau-né et conseille les femmes sur l'allaitement et la contraception."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "LEMARCHAND") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "BIGNON", 
                Prenom = "anthony",
                DateDeNaissance = new DateTime(2002, 12, 18),
                NumeroTelephone = "0615489764",
                Email = "abignon.ledantec@gmail.com",
                Password = "toto",
                Formation = "Chirurgien-dentiste",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le chirurgien-dentiste, aussi appelé dentiste, prend en charge les problèmes bucco-dentaires. " +
                "Ce spécialiste de la dentition s'occupe aussi bien des dents, des gencives et des nerfs que des maxillaires."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "CHASSAN") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "CHASSAN", 
                Prenom = "armand",
                DateDeNaissance = new DateTime(2000, 12, 27),
                NumeroTelephone = "0615489764",
                Email = "achassan.ledantec@gmail.com",
                Password = "toto",
                Formation = "Orthoptiste",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "L’orthoptiste est un professionnel de santé qui pratique la rééducation, la réadaptation, le dépistage et l’exploration fonctionnelle de la vision. " +
                "Sa fonction s’étend du nourrisson à la personne âgée et se fait uniquement sur prescription médicale."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "TOINEN") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "TOINEN", 
                Prenom = "benoit",
                DateDeNaissance = new DateTime(2002, 04, 11),
                NumeroTelephone = "0615489764",
                Email = "btoinen.ledantec@gmail.com",
                Password = "toto",
                Formation = "Rhumatologue",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le rhumatologue prend en charge les douleurs et dysfonctionnements des articulations, des os, de la colonne vertébrale et des muscles. " +
                "Il prend en charge des pathologies comme l'ostéoporose, l'arthrose, la hernie discale ou encore la tendinite. " +
                "Ce spécialiste des articulations s'occupe aussi des affections inflammatoires et des maladies auto-immunes qui peuvent avoir de nombreuses manifestations extra-articulaires (peau, yeux, reins, poumons, etc.)."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "CABIOCH") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "CABIOCH", 
                Prenom = "enzo",
                DateDeNaissance = new DateTime(2003, 10, 07),
                NumeroTelephone = "0615489764",
                Email = "ecabioch.ledantec@gmail.com",
                Password = "toto",
                Formation = "Médecin du travail ",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "La Médecine de Santé au Travail a pour but d'éviter toute altération de la santé des salariés en raison de leur travail. " +
                "Médicotel envisage cette mission sous l’angle d’une approche dans l'air du temps en usant de nouveaux modes de communication au bénéfice de tous. " +
                "C'est une Médecine préventive qui se doit d'être disponible et particulièrement en temps de crise sanitaire."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "DUAULT") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "DUAULT", 
                Prenom = "gurvan",
                DateDeNaissance = new DateTime(2001, 04, 16),
                NumeroTelephone = "0615489764",
                Email = "gduault.ledantec@gmail.com",
                Password = "toto",
                Formation = "Chirurgien oral",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = ""
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "THOMAS") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "THOMAS",
                Prenom = "jean-andre",
                DateDeNaissance = new DateTime(2002, 10, 21),
                NumeroTelephone = "0615489764",
                Email = "jthomas.ledantec@gmail.com",
                Password = "toto",
                Formation = "Audioprothésiste",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le chirurgien orthopédiste traite les problèmes musculo-squelettiques. " +
                "Il s'occupe plus généralement des traumatismes et des maladies de l'appareil locomoteur : tendons, ligaments, os, muscles et articulations."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "VILLALARD") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "VILLALARD", 
                Prenom = "kelig",
                DateDeNaissance = new DateTime(2003, 06, 12),
                NumeroTelephone = "0615489764",
                Email = "kvillalard.ledantec@gmail.com",
                Password = "toto",
                Formation = "Allergologue",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "L'allergologue est le médecin spécialiste des allergies. " +
                "Il prend en charge le patient du diagnostic au traitement et peut lui apporter des conseils " +
                "pour gérer au mieux les sources d'allergies dans son environnement : nature, nourriture, habitat, évolutions techniques, etc. "
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "LE PAVEC") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "LE PAVEC", 
                Prenom = "malo",
                DateDeNaissance = new DateTime(2002, 09, 23),
                NumeroTelephone = "0615489764",
                Email = "mlepavec.ledantec@gmail.com",
                Password = "toto",
                Formation = "Dermatologue",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le dermatologue traite les pathologies de la peau, des muqueuses et des phanères (ongles, cheveux, poils). " +
                "La vénérologie traite les maladies sexuellement transmissibles."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "CHENEVIERE") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Femme",
                Nom = "CHENEVIERE", 
                Prenom = "manon",
                DateDeNaissance = new DateTime(2000, 07, 27),
                NumeroTelephone = "0615489764",
                Email = "mcheneviere.ledantec@gmail.com",
                Password = "toto",
                Formation = "Généticien",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le généticien étudie les caractères héréditaires, leur transmission, les maladies qui leur sont associées et propose des moyens de les soigner ou de les prévenir. " +
                "Il traite des pathologies telles que l'hémophilie, " +
                "le cancer (du sein, par exemple, dans les familles porteuses des gènes BRCA1 ou BRCA2), les maladies neurologiques etc."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "TACON") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "TACON", 
                Prenom = "romain",
                DateDeNaissance = new DateTime(1999, 11, 02),
                NumeroTelephone = "0615489764",
                Email = "rtacon.ledantec@gmail.com",
                Password = "toto",
                Formation = "Infirmier",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "L’infirmier délivre des soins infirmiers prescrits ou conseillés. " +
                "Il participe aussi à différentes actions de prévention, d’éducation de la santé, de formation ou d’encadrement."
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "TAZARART") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Femme",
                Nom = "TAZARART", 
                Prenom = "thereza",
                DateDeNaissance = new DateTime(2001, 06, 16),
                NumeroTelephone = "0615489764",
                Email = "ttazarart.ledantec@gmail.com",
                Password = "toto",
                Formation = "Oculariste",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Nous accueillons des patients ayant subi des traumatismes oculaires, qu'ils soient accidentels, génétiques ou provoqués par une maladie. " +
                "Selon le cas, une opération est parfois nécessaire avant l'appareillage, mais dans la mesure du possible, nous évitons l'intervention en fabriquant des prothèses sur mesure. "
            });
            if (listeProfessionel.FirstOrDefault(cus => cus.Nom == "DARGHI") == null) await Professionnel.AjoutItemSqlite(new Professionnel {
                Genre = "Homme",
                Nom = "DARGHI", 
                Prenom = "wassil",
                DateDeNaissance = new DateTime(2000, 10, 13),
                NumeroTelephone = "0615489764",
                Email = "wdarghi.ledantec@gmail.com",
                Password = "toto",
                Formation = "Radiologue",
                Adresse = "Rue des Cordiers",
                CodePostale = "22300",
                Ville = "lannion",
                Tarif = "3.50",
                Presentation = "Le praticien a une longue expérience en imagerie (IRM et scanner) dans les domaines de la neurologie, l’ophtalmologie et l’ORL, les pathologies rachidiennes et médullaires. " +
                "Elle réalise ces explorations avec attention, adaptées au cas clinique du patient et le reçoit en consultation à l’issue de l’examen. "
            });

            // pour les patient 
            await App.database.DeleteItemsAsync<Patient>(); // efface tous les professionels dans la table 

            listePatient = App.Database.GetItemsAsync<Patient>();

            if (listePatient.FirstOrDefault(cus => cus.Nom == "DESABLENS") == null) await Patient.AjoutItemSqlite(new Patient
            {
                Genre = "Femme",
                Nom = "DESABLENS",
                Prenom = "maeva",
                DateDeNaissance = new DateTime(2002, 02, 24),
                NumeroTelephone = "0615489764",
                Email = "mdesablens.ledantec@gmail.com",
                Password = "toto"
            });



            // pour les horaires
            await App.database.DeleteItemsAsync<Horaire>(); // efface tous les horaires dans la table 

            listeHoraire = App.Database.GetItemsAsync<Horaire>();

            if (listeHoraire.FirstOrDefault(cus => cus.Heuredébut == "9h00") == null) await Horaire.AjoutItemSqlite(new Horaire
            {
                Heuredébut  = "9h00"
            });
            if (listeHoraire.FirstOrDefault(cus => cus.Heuredébut == "9h30") == null) await Horaire.AjoutItemSqlite(new Horaire
            {
                Heuredébut = "9h30"
            });
            if (listeHoraire.FirstOrDefault(cus => cus.Heuredébut == "10h00") == null) await Horaire.AjoutItemSqlite(new Horaire
            {
                Heuredébut = "10h00"
            });
        }
    }
}
