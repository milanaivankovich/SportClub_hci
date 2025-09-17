using System.Windows;
using System.Windows.Controls;
using SportClub.Views;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
            Loaded += MainWindowAdmin_Loaded;
        }

        private void MainWindowAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            // Set default view to Instruktori
            OpenInstruktori(null, null);
        }

        private void SetActiveMenuItem(MenuItem activeItem)
        {
            // Reset all menu items
            InstruktoriMenuItem.Tag = "";
            TakmicenjaMenuItem.Tag = "";
            ClanarineMenuItem.Tag = "";
            PodesavanjeMenuItem.Tag = "";

            // Set the active one
            if (activeItem != null)
            {
                activeItem.Tag = "Active";
            }
        }

        private void OpenInstruktori(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InstruktoriView();
            SetActiveMenuItem(InstruktoriMenuItem);
        }

        private void OpenTakmicenja(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CompetitionsView();
            SetActiveMenuItem(TakmicenjaMenuItem);
        }

        private void OpenClanarine(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MembershipsView();
            SetActiveMenuItem(ClanarineMenuItem);
        }

        private void OpenPodesavanje(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PodesavanjeView();
            SetActiveMenuItem(PodesavanjeMenuItem);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Logout the user
            CurrentUserService.Instance.Logout();

            // Otvori login prozor
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // Zatvori trenutni admin prozor
            this.Close();
        }
    }
}