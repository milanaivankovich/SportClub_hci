using SportClub.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SportClub.ViewModels
{
    public class MainAdminViewModel : INotifyPropertyChanged
    {
        private UserControl _currentView;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainAdminViewModel()
        {
           
            CurrentView = new InstruktoriView();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}