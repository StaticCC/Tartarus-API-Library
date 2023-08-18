using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using AutoUpdaterDotNET;

namespace TartarusLib
{
    public partial class Authenticate : MaterialForm
    {
        Connection con = new Connection();

        string autoUser = "";
        string autoPassword = "";
        public Authenticate()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal300, Accent.Teal200, TextShade.WHITE);
            
        }


        public string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }

       
        public string GetIP()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }

        public bool Auth(string app)
        {

            byte[] key = { 0x02, 0x03, 0x01, 0x03, 0x03, 0x07, 0x07, 0x08, 0x09, 0x09, 0x11, 0x11, 0x16, 0x17, 0x19, 0x16 };
            //Get ConnectionData
            try
            {
                // create file stream
                using FileStream myStream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "Tartarus.dll", FileMode.Open);

                // create instance
                using Aes aes = Aes.Create();

                // reads IV value
                byte[] iv = new byte[aes.IV.Length];
                myStream.Read(iv, 0, iv.Length);

                // decrypt data
                using CryptoStream cryptStream = new CryptoStream(
                   myStream,
                   aes.CreateDecryptor(key, iv),
                   CryptoStreamMode.Read);

                // read stream
                using StreamReader sReader = new StreamReader(cryptStream);

                string rawConnectionData = sReader.ReadLine();

                string[] connectionDataArray = rawConnectionData.Split();
                ServerData.host = connectionDataArray[0];
                ServerData.sqlDb = connectionDataArray[1];
                ServerData.sqlUser = connectionDataArray[2];
                ServerData.sqlPass = connectionDataArray[3];
            }
            catch
            {
                // error
                MessageBox.Show("Missing core app depend(s). Are all neccessary files in this directory?", "Severe Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                throw;
            }

            AppData.appName = app;
            Form auth = new Authenticate();
            auth.Show();
            auth.Activate();
            return true;
        }

        void loginButton_Click(object sender, EventArgs e)
        {
            if(AppData.appName != "")
            {
                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                if (!regexItem.IsMatch(AppData.appName) || !regexItem.IsMatch(loginUsername.Text) || !regexItem.IsMatch(loginPassword.Text))
                {
                    MessageBox.Show("Invalid Characters Detected!");
                    Environment.Exit(1);
                } 
                else
                {
                    if (loginUsername.Text != "" && loginPassword.Text != "")
                    {
                        try
                        {
                            con.Open();
                            string query = "SELECT username,appkey,hwid,ip,banned FROM " + AppData.appName + "_users WHERE username='" + loginUsername.Text + "'";
                            MySqlDataReader row;
                            row = con.ExecuteReaderIgnore(query);
                            if (row.HasRows)
                            {
                                int banned = 0;
                                string username = "";
                                string sqlAppKey = "";
                                string sqlHwid = "";
                                string sqlIp = "";
                                while (row.Read())
                                {
                                    banned = Int32.Parse(row["banned"].ToString());
                                    sqlAppKey = row["appkey"].ToString();
                                    sqlHwid = row["hwid"].ToString();
                                    sqlIp = row["ip"].ToString();
                                }

                                if(sqlAppKey != loginPassword.Text)
                                {
                                    MessageBox.Show("Incorrect Username/Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(0);

                                }
                                row.Close();
                                row.Dispose();
                                string hwid = GetMachineGuid();
                                if (sqlHwid != hwid && sqlHwid != "")
                                {
                                    MessageBox.Show("You can only login from one machine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(0);
                                } 
                                else if(sqlHwid == "")
                                {
                                    string update = "UPDATE " + AppData.appName + "_users SET hwid = '" + hwid + "' WHERE username = '" + loginUsername.Text + "'";
                                    con.ExecuteNonQuery(update);
                                }
                                string ip = GetIP();
                                if (sqlIp != ip && sqlIp != "")
                                {
                                    MessageBox.Show("You can only login from the original network you registered on!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(0);
                                } 
                                else if(sqlIp == "")
                                {
                                    string update = "UPDATE " + AppData.appName + "_users SET ip = '" + ip + "' WHERE username = '" + loginUsername.Text + "'";
                                    con.ExecuteNonQuery(update);
                                }

                                if(banned == 1)
                                {
                                    MessageBox.Show("You have been banned. \n\nIf you feel like this was a false ban, please contact your application administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(1);
                                }

                                username = loginUsername.Text;
                                DateTime myDateTime = DateTime.Now;
                                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                                string appLog = "INSERT INTO " + AppData.appName + "_logs(date,user,log) VALUES('" + sqlFormattedDate + "','" + username + "','LOGGED IN!')";
                                con.ExecuteNonQuery(appLog);

                                Success();
                            } else
                            {
                                MessageBox.Show("Your login information could not be found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to authenticate! Is your app set correctly?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Username/Password cannot be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void Success()
        {
            Form formToShow = new Form();
            Form authForm = new Form();
            foreach(Form frm in Application.OpenForms)
            {
                if (frm.Name != this.Name)
                {
                    formToShow = frm;
                }
                else
                {
                    authForm = frm;
                }
            }
            MessageBox.Show("Successfully logged in!", "Thank you for using Tartarus", MessageBoxButtons.OK, MessageBoxIcon.Question);
            
            formToShow.Visible = true;
            formToShow.Activate();
            formToShow.ShowInTaskbar = true;
            formToShow.ShowInTaskbar = true;
            authForm.Hide();
        }

        private void faqButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tartarus Licensing System | v1\nFor account issues, contact your applications adminstrator.\nFor issues, concerns, comments visit: https://tartarus.gg", "FAQ", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (AppData.appName != "")
            {
                string hwid = GetMachineGuid();
                string ip = "";
                try
                { 
                    ip = GetIP();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to a needed host.\n"+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                if (!regexItem.IsMatch(AppData.appName) || !regexItem.IsMatch(registerUsername.Text) || !regexItem.IsMatch(registerKey.Text))
                {
                    MessageBox.Show("Invalid Characters Detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                else
                {
                    if (registerUsername.Text != "" && registerKey.Text != "")
                    {
                        try
                        {
                            con.Open();
                            string appkeyquery = "SELECT appkeys FROM " + AppData.appName;
                            string appKeys = "";
                            MySqlDataReader row;
                            row = con.ExecuteReaderIgnore(appkeyquery);
                            if (row.HasRows)
                            {
                                while (row.Read())
                                {
                                    appKeys = row["appkeys"].ToString();
                                }
                            }
                            row.Close();
                            row.Dispose();

                            if (appKeys.Contains(registerKey.Text) && registerKey.Text.Length == 16)
                            {
                                appKeys = appKeys.Replace(registerKey.Text + ",", "");
                                string update = "UPDATE " + AppData.appName  +" SET appkeys  = '" + appKeys + "'";
                                con.ExecuteNonQuery(update);
                                string insert = "INSERT INTO " + AppData.appName + "_users (username,appkey,hwid,ip,banned) VALUES('" + registerUsername.Text + "','" + registerKey.Text + "','" + hwid + "','" + ip + "','0')";
                                con.ExecuteNonQuery(insert);
                                MessageBox.Show("Sucessfully registered! Please login.","Thank you for using Tartarus!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                DateTime myDateTime = DateTime.Now;
                                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                                string appLog = "INSERT INTO " + AppData.appName + "_logs(date,user,log) VALUES('" + sqlFormattedDate + "','" + registerUsername.Text + "','REGISTERED AN ACCOUNT!')";
                                con.ExecuteNonQuery(appLog);
                            } else
                            {
                                MessageBox.Show("Product Key invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to authenticate! Is your app set correctly?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username/Password cannot be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Authenticate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void loginPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                loginButton_Click(sender,e);
            }
        }
    }
}
