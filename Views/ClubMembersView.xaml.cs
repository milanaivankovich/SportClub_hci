using System.Windows.Controls;
using SportClub.ViewModels;

namespace SportClub.Views
{
    public partial class ClubMembersView : UserControl
    {
        public ClubMembersView()
        {
            InitializeComponent();
            DataContext = new ClubMembersViewModel();
        }
    }
}