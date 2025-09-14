using System.Windows.Controls;
using SportClub.ViewModels;

namespace SportClub.Views
{
    public partial class MembershipsView : UserControl
    {
        public MembershipsView()
        {
            InitializeComponent();
            DataContext = new MembershipsViewModel();
        }
    }
}