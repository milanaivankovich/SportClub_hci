using System.Windows;
using System.Windows.Controls;
using SportClub.Views;

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
            MainContent.Content = new CompetitionsView(); // Ensure TakmicenjaView exists
            SetActiveMenuItem(TakmicenjaMenuItem);
        }

        private void OpenClanarine(object sender, RoutedEventArgs e)
        {
        
            MainContent.Content = new MembershipsView();
            SetActiveMenuItem(ClanarineMenuItem);
        }

        private void OpenPodesavanje(object sender, RoutedEventArgs e)
        {
            // Placeholder for PodesavanjeView (create this view if not already implemented)
            //MainContent.Content = new PodesavanjeView(); // Ensure PodesavanjeView exists
            SetActiveMenuItem(PodesavanjeMenuItem);
        }
    }
}