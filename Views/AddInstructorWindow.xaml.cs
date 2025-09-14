using System.Windows;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class AddInstructorWindow : Window
    {
        public Instructor NewInstructor { get; private set; }

        public AddInstructorWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImeTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrezimeTextBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }

            NewInstructor = new Instructor
            {
                FirstName = ImeTextBox.Text,
                LastName = PrezimeTextBox.Text,
                Username = UsernameTextBox.Text,
                Password = PasswordBox.Password // Note: In production, hash the password
            };

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}