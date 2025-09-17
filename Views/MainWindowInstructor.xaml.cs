using System.Windows;
using System.Windows.Controls;
using SportClub.Views;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class MainWindowInstructor : Window
    {
        public MainWindowInstructor()
        {
            InitializeComponent();
            Loaded += MainWindowInstructor_Loaded;
        }

        private void MainWindowInstructor_Loaded(object sender, RoutedEventArgs e)
        {
            // Set default view to Instruktori
            OpenClanovi(null, null);
        }

        private void SetActiveMenuItem(MenuItem activeItem)
        {
            // Reset all menu items
            ClanoviMenuItem.Tag = "";
            PrisustvoMenuItem.Tag = "";
            TakmicenjeMenuItem.Tag = "";
            ClanarineMenuItem.Tag = "";
            PodesavanjeMenuItem.Tag = "";

            // Set the active one
            if (activeItem != null)
            {
                activeItem.Tag = "Active";
            }
        }

        private void OpenClanovi(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClubMembersView();
            SetActiveMenuItem(ClanoviMenuItem);
        }

        private void OpenPrisustvo(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AttendanceView();
            SetActiveMenuItem(PrisustvoMenuItem);
        }

        private void OpenClanarine(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MembershipInstructorView(); // Ensure ClanarineView exists
            SetActiveMenuItem(ClanarineMenuItem);
        }

        private void OpenPodesavanje(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PodesavanjeView();
            SetActiveMenuItem(PodesavanjeMenuItem);
        }

        private void OpenTakmicenje(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InstructorCompetitionsView();
            SetActiveMenuItem(TakmicenjeMenuItem);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Logout the user
            CurrentUserService.Instance.Logout();

            // Otvori login prozor
            var loginWindow = new LoginWindow();
            loginWindow.Show();

           
            this.Close();
        }
    }
}