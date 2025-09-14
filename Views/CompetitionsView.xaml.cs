using System.Windows.Controls;
using SportClub.ViewModels;

namespace SportClub.Views
{
    public partial class CompetitionsView : UserControl
    {
        public CompetitionsView()
        {
            InitializeComponent();
            DataContext = new CompetitionsViewModel();
        }
    }
}