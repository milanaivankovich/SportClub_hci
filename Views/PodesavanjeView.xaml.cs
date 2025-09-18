using System.Windows;
using System.Windows.Controls;
using SportClub.ViewModels;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class PodesavanjeView : UserControl
    {
        public PodesavanjeView()
        {
            InitializeComponent();

            
            if (CurrentUserService.Instance.IsLoggedIn)
            {
                DataContext = new SettingsViewModel(CurrentUserService.Instance.CurrentUser.IdUser);
            }
            else
            {
                 
                DataContext = new SettingsViewModel();
            }
        }

        private void CurrentPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SettingsViewModel vm)
            {
                vm.CurrentPassword = ((PasswordBox)sender).Password;
            }
        }

        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SettingsViewModel vm)
            {
                vm.NewPassword = ((PasswordBox)sender).Password;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SettingsViewModel vm)
            {
                vm.ConfirmPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}