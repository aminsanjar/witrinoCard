using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace TestGemCard
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_btn_Click(object sender, EventArgs e)
        {


            JObject loginReply;
            if (username_input.Text != "" && password_input.Text != "")
            {
                var login_obg = new TestSmartcard.ws_login();
                loginReply = login_obg.Call_login(username_input.Text, password_input.Text, "0");


                //string XXXX = login_obg.hash_password(password_input.Text);
                //log_box.AppendText("PAS: "+XXXX + Environment.NewLine);

                if (loginReply["message"].ToString() == "ok")
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Vizitori");
                    key.SetValue("username", username_input.Text);
                    key.SetValue("password", password_input.Text);
                    key.Close();

                    MainForm fc = (MainForm)Application.OpenForms["MainForm"];
                    if (fc != null)
                    {
                        fc.token_value = loginReply["data"]["token"].ToString();
                        this.Close();
                    }
                }
                else
                {
                    log_box.AppendText(loginReply["message"].ToString() + Environment.NewLine);
                }
            }
            else
            {
                log_box.AppendText("نام کاربری و کلمه عبور را وارد کنید." + Environment.NewLine);
            }
        }
    }
}
