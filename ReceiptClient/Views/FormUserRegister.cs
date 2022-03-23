using ReceiptClient.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceiptClient.Dtos.Request;
using ReceiptClient.Controllers.Interfaces;
using Newtonsoft.Json.Linq;
using ReceiptClient.Dtos.Response;

namespace ReceiptClient.Views
{
    public partial class FormUserRegister : Form
    {
        private readonly IButtonEnableControl _buttonEnableControl;
        private readonly IAuthController _authController;

        private bool closedFromMyButton;

        public FormUserRegister(IButtonEnableControl buttonEnableControl, IAuthController authController)
        {
            InitializeComponent();
            labelNameError.Text = "";
            labelEmailError.Text = "";
            labelPasswordError.Text = "";
            labelConfirmPasswordError.Text = "";
            _buttonEnableControl = buttonEnableControl;
            _authController = authController;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            var formLogin = Program.serviceProvider.GetService<FormLogin>();
            formLogin.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormUserRegister_Load(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            var textBoxsNotEmpty = _buttonEnableControl.CheckTexBoxtFilled(Controls);

            if (textBoxsNotEmpty)
                buttonRegister.Enabled = true;
            else
                buttonRegister.Enabled = false;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            var textBoxsNotEmpty = _buttonEnableControl.CheckTexBoxtFilled(Controls);

            if (textBoxsNotEmpty)
                buttonRegister.Enabled = true;
            else
                buttonRegister.Enabled = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            var textBoxsNotEmpty = _buttonEnableControl.CheckTexBoxtFilled(Controls);

            if (textBoxsNotEmpty)
                buttonRegister.Enabled = true;
            else
                buttonRegister.Enabled = false;
        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            var textBoxsNotEmpty = _buttonEnableControl.CheckTexBoxtFilled(Controls);

            if (textBoxsNotEmpty)
                buttonRegister.Enabled = true;
            else
                buttonRegister.Enabled = false;
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;

            textBoxName.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxConfirmPassword.Enabled = false;

            labelNameError.Text = "";
            labelEmailError.Text = "";
            labelPasswordError.Text = "";
            labelConfirmPasswordError.Text = "";

            var user = new UserCreateDto
            {
                Name = textBoxName.Text,
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,
                ConfirmPassword = textBoxConfirmPassword.Text
            };

            try
            {
                var registerResponse = await _authController.Register(user);

                var jsonString = await registerResponse.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(jsonString);

                var resultFail = !registerResponse.IsSuccessStatusCode;

                if (resultFail)
                {
                    var notifications = jObject["notifications"].ToObject<List<NotificationDto>>();

                    var nameIsLowerOrEqualsThan = notifications.Where(x => x.Key == "nameIsLowerOrEqualsThan").Select(x => x.Message).FirstOrDefault();
                    var emailIsEmail = notifications.Where(x => x.Key == "emailIsEmail").Select(x => x.Message).FirstOrDefault();
                    var emailIsLowerThan = notifications.Where(x => x.Key == "emailIsLowerThan").Select(x => x.Message).FirstOrDefault();
                    var emailExists = notifications.Where(x => x.Key == "emailExists").Select(x => x.Message).FirstOrDefault();
                    var passwordIsLowerOrEqualsThan = notifications.Where(x => x.Key == "passwordIsLowerOrEqualsThan").Select(x => x.Message).FirstOrDefault();
                    var passwordIsGreaterOrEqualsThan = notifications.Where(x => x.Key == "passwordIsGreaterOrEqualsThan").Select(x => x.Message).FirstOrDefault();
                    var passwordAreEquals = notifications.Where(x => x.Key == "passwordAreEquals").Select(x => x.Message).FirstOrDefault();
                    var saveChangesError = notifications.Where(x => x.Key == "saveChangesError").Select(x => x.Message).FirstOrDefault();

                    if (nameIsLowerOrEqualsThan != null)
                        labelNameError.Text = nameIsLowerOrEqualsThan;

                    if (emailIsEmail != null)
                        labelEmailError.Text = emailIsEmail;

                    if (emailIsLowerThan != null)
                        labelEmailError.Text = emailIsLowerThan;

                    if (emailExists != null)
                        MessageBox.Show(emailExists);

                    if (passwordIsLowerOrEqualsThan != null)
                        labelPasswordError.Text = passwordIsLowerOrEqualsThan;

                    if (passwordIsGreaterOrEqualsThan != null)
                        labelPasswordError.Text = passwordIsGreaterOrEqualsThan;

                    if (passwordAreEquals != null)
                        labelConfirmPasswordError.Text = passwordAreEquals;

                    if (saveChangesError != null)
                        MessageBox.Show(saveChangesError);
                }
                else
                {
                    var token = jObject["data"].ToObject<TokenDto>();
                    MessageBox.Show("Você se cadastrou com sucesso! Agora vou me virar pra passar seu token pra outra tela! Obrigado por testar.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            buttonRegister.Enabled = true;
            textBoxName.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxPassword.Enabled = true;
            textBoxConfirmPassword.Enabled = true;
        }

        private void labelPasswordError_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
