using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CareerLinkPort.Wins
{
    public partial class UserAccount : Form
    {

        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:44339/api/user";
        public UserAccount()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            RoleType.Items.AddRange(new[] { "Employer", "Alumni" });
            RoleType.SelectedIndex = 0;
            BirthDate.MaxDate = DateTime.Now.AddYears(-18);
            BirthDate.Value = BirthDate.MaxDate;
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Text) ||
              string.IsNullOrWhiteSpace(Username.Text) ||
              string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            try
            {
                var user = new
                {
                    Email = Email.Text,
                    Username = Username.Text,
                    Password = Password.Text
                };

                var response = await _httpClient.PostAsync(
                    $"{ApiBaseUrl}/register",
                    new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registration successful");
                    ClearRegistrationFields();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Registration failed: {error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
