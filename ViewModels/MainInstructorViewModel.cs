using SportClub.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportClub.ViewModels
{
    class MainInstructorViewModel : INotifyPropertyChanged
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

        public MainInstructorViewModel()
        {
            
            CurrentView = new InstruktoriView();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
