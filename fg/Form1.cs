using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace fg
{
    public partial class Form1 : Form
    {
        #region Kapcsolat properties
        private MySqlConnection mysqlConn;
        private MySqlDataReader mySqlDr;
        #endregion kapcsolat properties

        #region Üzenet szövegek
        private string openSikeres = "A kapcsolódás az adatbázishoz sikeres!", openNemSikeres = "A kapcsolódás az adatbázishoz sikertelen!", cantoRead = "Az olvasás sikeres", closeDB = "Az adatbázis lezárva";
        #endregion Üzenet vége
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void mysqlConnect()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "iktat";

            try
            {
                mysqlConn = new MySqlConnection(sb.ToString());
                mysqlConn.Open();
                MessageBox.Show(openSikeres);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{openSikeres} \n{ex.Message}");
            }
        }
        #region Form és adatbázis állapotai
        private enum FormState
        {
            Closed, //Zárva, nincs csatlakozva
            Opened, //Csatlakozva, nincs olvasás
            Reading, //Olvasás közben
            EditInsert, //Beszúrás
            EditUpdate, //Rekord szerkesztés
        }
        private FormState formstate = FormState.Closed;
        #endregion a Form és az adatbázis állapotai

        #region Gomb feliratai
        private string insBasic = "Beszúrás";
        private string insEdit = "Szerkesztés vége";
        private string updBasic = "Módosítás";
        private string updEdit = "Módisítás vége";
        #endregion Gomb feliratai
    }
}