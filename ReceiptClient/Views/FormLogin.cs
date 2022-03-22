using Newtonsoft.Json.Linq;
using ReceiptClient.Controllers;
using ReceiptClient.Dtos.Request;
using ReceiptClient.Dtos.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptClient.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            labelEmailError.Text = "";
            labelPasswordError.Text = "";
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_ClickAsync(object sender, EventArgs e)
        {
            var user = new UserLoginPostDto
            {
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,
            };

            var loginResponse = await AuthController.Login(user);

            var jsonString = await loginResponse.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            var resultFail = !loginResponse.IsSuccessStatusCode;

            if (resultFail)
            {
                var notifications = jObject["notifications"].ToObject<List<NotificationDto>>();

                var emailIsEmail = notifications.Where(x => x.Key == "emailIsEmail").Select(x => x.Message).FirstOrDefault();
                var passwordIsLowerOrEqualsThan = notifications.Where(x => x.Key == "passwordIsLowerOrEqualsThan").Select(x => x.Message).FirstOrDefault();
                var passwordIncorrect = notifications.Where(x => x.Key == "passwordIncorrect").Select(x => x.Message).FirstOrDefault();
                var userNotFound = notifications.Where(x => x.Key == "userNotFound").Select(x => x.Message).FirstOrDefault();

                if (emailIsEmail != null)
                    labelEmailError.Text = emailIsEmail;

                if (passwordIsLowerOrEqualsThan != null)
                    labelPasswordError.Text = passwordIsLowerOrEqualsThan;

                if (passwordIncorrect != null)
                    MessageBox.Show(passwordIncorrect);

                if (userNotFound != null)
                    MessageBox.Show(userNotFound);
            }
            else
            {
                var token = jObject["data"].ToObject<TokenDto>();
                MessageBox.Show("Você logou com sucesso!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            var textBoxsLoginNotEmpty = textBoxEmail.Text.Length > 0 && textBoxPassword.Text.Length > 0;

            if (textBoxsLoginNotEmpty)
                buttonLogin.Enabled = true;
            else
                buttonLogin.Enabled = false;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
