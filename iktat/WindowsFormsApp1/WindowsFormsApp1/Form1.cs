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
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Változók definiálása
        #region Kapcsolat properties
        private MySqlConnection mysqlConn;
        private MySqlDataReader mysqlDr;
        #endregion Kapcsolat properties

        #region Üzenet szövegek
        private string openSikeres = "A kapcsolódás az adatbázishoz sikeres!", openNemSikeres = "A kapcsolódás az adatbázishoz sikertelen!", cantoRead = "Az olvasás megkezdődhet!", closedDB = "Az adatbázis bezárva!";
        #endregion Üzenet szövegek


        #region Tárolt eljárások
        private string userTeljesLista = "userTeljesLista";
        private string userInsert = "userInsert";
        private string userUpdate = "userUpdate";
        private string userDelete = "userDelete";
        #endregion Tárolt eljárások


        #region A Form és az adatbázis állapotai
        private enum FormState
        {
            Closed, // Zárva, nincs csatlakoztatva
            Opened, // Adabázishoz csatlakozva, de olvasásra nincs megnyitva
            Reading, // Olvasás közben
            EditInsert, // Beszúrás adatainak beírása közben
            EditUpdate, // Rekord szerkesztése közben
        }
        private FormState formState = FormState.Closed;
        #endregion A Form és az adatbázis állapotai

        #region Gomb feliratai
        private string insBasic = "Beszúrás";
        private string insEdit = "Szerkesztés vége";
        private string updBasic = "Módosítás";
        private string updEdit = "Módosítás vége";
        #endregion Gomb feliratai

        #region Gombok elérhetőségének beállításai
        private void buttonSwitch(FormState fs)
        {
            switch (fs)
            {
                case FormState.Closed:
                    button2.Enabled = true; //button2 == kapcsolódás/connection
                    button3.Enabled = false; //button3 == Megnyitás/open adatbázis
                    button4.Enabled = false; //button4 == Olvasás/Read
                    button5.Enabled = false; //button5 == Beszúrás/Insert
                    button6.Enabled = false; //button6 == Update/Módosítások
                    button7.Enabled = false; //button7 == Törlés/Delete
                    button1.Enabled = false; //button1 == Kapcsolat bontása
                    break;
                case FormState.Opened:
                    button2.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button1.Enabled = true;

                    textBox1.Enabled = false; //textBox1 == Id/Azonosító
                    textBox2.Enabled = false; //textBox2 == Name/név
                    textBox3.Enabled = false; //textBox3 == Password/Jelszó
                    checkBox1.Enabled = false; //checkBox1 == Admin?

                    //Gomb feliratok
                    button5.Text = insBasic;
                    button6.Text = updBasic;
                    break;
                case FormState.Reading:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button1.Enabled = true;
                    break;
                case FormState.EditInsert:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button1.Enabled = true;

                    //Beviteli mezők elérhetősége
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    checkBox1.Enabled = true;

                    //Beviteli mezők ürítése
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    checkBox1.Checked = false;

                    //Gomb feliratok
                    button5.Text = insEdit;
                    break;
                case FormState.EditUpdate:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = true;
                    button7.Enabled = false;
                    button1.Enabled = true;

                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    checkBox1.Enabled = true;

                    //Gomb feliratok
                    button6.Text = updEdit;
                    break;
            }
        }
        #endregion Gombok elérhetőségének beállításai
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mysqlConn.Close();
            MessageBox.Show(closedDB);

            formState = FormState.Closed;
            buttonSwitch(formState);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            mysqlConnect();
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

                formState = FormState.Opened;
                buttonSwitch(formState);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{openNemSikeres} \n {ex.Message}");
            }
        }


        #region Adatbázis megnyitása
        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlCommand prancs = new MySqlCommand(userTeljesLista, mysqlConn))
            {
                prancs.CommandType = CommandType.StoredProcedure;

                try
                {
                    //Olvasás a táblából
                    mysqlDr = prancs.ExecuteReader();

                    MessageBox.Show(cantoRead);

                    formState = FormState.Reading;
                    buttonSwitch(formState);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion Adatbázis megnyitása


        private void button4_Click(object sender, EventArgs e)
        {
            NextUser();
        }


        #region A következő rekord beolvasása
        private void NextUser()
        {
            // A következő rekord olvasása
            mysqlDr.Read();
            textBox1.Text = mysqlDr[0].ToString().Trim();
            textBox2.Text = mysqlDr[1].ToString().Trim();
            textBox3.Text = mysqlDr[2].ToString().Trim();
            checkBox1.Checked = (bool)mysqlDr[3];
        }
        #endregion A következő rekord olvasása

        private void button5_Click(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Opened:
                    formState = FormState.EditInsert;
                    buttonSwitch(formState);
                    break;
                case FormState.Reading:
                    mysqlDr.Close();
                    formState = FormState.EditInsert;
                    buttonSwitch(formState);
                    break;
                case FormState.EditInsert:
                    InsertUser(textBox2.Text, textBox3.Text, (checkBox1.Checked) ? 1 : 0);
                    formState = FormState.Opened;
                    buttonSwitch(formState);
                    break;
            }
        }



        #region Rekord beszúrása
        private void InsertUser(string username, string password, int admin)
        {
            using (MySqlCommand sqlComm = new MySqlCommand(userInsert, mysqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;

                //Paraméterek beállítása
                MySqlParameter p = new MySqlParameter();
                p.ParameterName = "username";
                p.Value = username;
                p.MySqlDbType = MySqlDbType.String;
                sqlComm.Parameters.Add(p);

                sqlComm.Parameters.AddWithValue("password", password);
                sqlComm.Parameters.AddWithValue("admin", admin);

                try
                {
                    //Olvasás a táblából
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("A rekord felvétele sikeres.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion Rekord beszúrása
        }

        #region Rekord módosítása
        private void button6_Click(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Opened:
                    formState = FormState.EditUpdate;
                    buttonSwitch(formState);
                    break;
                case FormState.Reading:
                    mysqlDr.Close();
                    formState = FormState.EditUpdate;
                    buttonSwitch(formState);
                    break;
                case FormState.EditUpdate:
                    UpdateUser(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, (checkBox1.Checked) ? 1 : 0);
                    formState = FormState.Opened;
                    buttonSwitch(formState);
                    break;
            }
        }



        private void UpdateUser(int pID, string username, string password, int admin)
        {
            using (MySqlCommand cmd = new MySqlCommand(userUpdate, mysqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                //Paraméterek beállítása
                cmd.Parameters.AddWithValue("pID", pID);

                MySqlParameter p = new MySqlParameter();
                p.ParameterName = "username";
                p.Value = username;
                p.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(p);

                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("admin", admin);

                try
                {
                    //Olvasás a táblából
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A rekord módosítása sikeres.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion Rekord módosítása

        private void button2_Click_1(object sender, EventArgs e)
        {
            mysqlConnect();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (MySqlCommand prancs = new MySqlCommand(userTeljesLista, mysqlConn))
            {
                prancs.CommandType = CommandType.StoredProcedure;

                try
                {
                    //Olvasás a táblából
                    mysqlDr = prancs.ExecuteReader();

                    MessageBox.Show(cantoRead);

                    formState = FormState.Reading;
                    buttonSwitch(formState);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            NextUser();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Opened:
                    formState = FormState.EditInsert;
                    buttonSwitch(formState);
                    break;
                case FormState.Reading:
                    mysqlDr.Close();
                    formState = FormState.EditInsert;
                    buttonSwitch(formState);
                    break;
                case FormState.EditInsert:
                    InsertUser(textBox2.Text, textBox3.Text, (checkBox1.Checked) ? 1 : 0);
                    formState = FormState.Opened;
                    buttonSwitch(formState);
                    break;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Opened:
                    formState = FormState.EditUpdate;
                    buttonSwitch(formState);
                    break;
                case FormState.Reading:
                    mysqlDr.Close();
                    formState = FormState.EditUpdate;
                    buttonSwitch(formState);
                    break;
                case FormState.EditUpdate:
                    UpdateUser(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, (checkBox1.Checked) ? 1 : 0);
                    formState = FormState.Opened;
                    buttonSwitch(formState);
                    break;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Reading:
                    break;
            }
            if (formState == FormState.Reading)
            {
                mysqlDr.Close(); // Bezárom a DataReader típusú objektumot, mert az új művelethez előlről kell olvasni az adatbázist.
                formState = FormState.Opened;
                buttonSwitch(formState);
            }
            DeleteUser(Convert.ToInt32(textBox1.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // A form állapotának beállítása
            switch (formState)
            {
                case FormState.Reading:
                    break;
            }
            if (formState == FormState.Reading)
            {
                mysqlDr.Close(); // Bezárom a DataReader típusú objektumot, mert az új művelethez előlről kell olvasni az adatbázist.
                formState = FormState.Opened;
                buttonSwitch(formState);
            }
            DeleteUser(Convert.ToInt32(textBox1.Text));
        }
        private void DeleteUser(int pID)
        {
            using (MySqlCommand sqlComm = new MySqlCommand(userDelete, mysqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;

                //Paraméterek beállítása
                sqlComm.Parameters.AddWithValue("pID", pID);

                try
                {
                    //Törlés a táblából
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("A rekord törlése sikeres.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ha még nincs bezárva az adatbázis, akkor zárja be.
            if (mysqlConn != null)
            {
                mysqlConn.Close();
                MessageBox.Show(closedDB);
            }
        }
    }
}