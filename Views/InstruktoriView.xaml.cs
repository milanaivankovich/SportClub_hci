using System.Windows.Controls;
using SportClub.ViewModels;

namespace SportClub.Views
{
    public partial class InstruktoriView : UserControl
    {
        public InstruktoriView()
        {
            InitializeComponent();
            DataContext = new InstruktoriViewModel();
        }
    }
}