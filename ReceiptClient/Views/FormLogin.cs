using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using ReceiptClient.Controllers;
using ReceiptClient.Controllers.Interfaces;
using ReceiptClient.Dtos.Request;
using ReceiptClient.Dtos.Response;
using ReceiptClient.Services.Interfaces;
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
        private readonly IAuthController _authController;
        private readonly IButtonEnableControl _buttonEnableControl;
        private readonly FormUserRegister _formUserRegister;

        public FormLogin(IAuthController authController, IButtonEnableControl buttonEnableControl, FormUserRegister formUserRegister)
        {
            InitializeComponent();
            labelEmailError.Text = "";
            labelPasswordError.Text = "";

            _authController = authController;
            _buttonEnableControl = buttonEnableControl;
            _formUserRegister = formUserRegister;
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_ClickAsync(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;

            textBoxEmail.Enabled = false;
            textBoxPassword.Enabled = false;

            var user = new UserLoginPostDto
            {
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,
            };

            try
            {
                var loginResponse = await _authController.Login(user);

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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            buttonLogin.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxPassword.Enabled = true;
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
            var textBoxsNotEmpty = _buttonEnableControl.CheckTexBoxtFilled(Controls);

            if (textBoxsNotEmpty)
                buttonLogin.Enabled = true;
            else
                buttonLogin.Enabled = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            var textBoxsNotEmpty = _buttonEnableControl.CheckTexBoxtFilled(Controls);

            if (textBoxsNotEmpty)
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
            var formUserRegister = Program.serviceProvider.GetService<FormUserRegister>();
            formUserRegister.ShowDialog();
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
