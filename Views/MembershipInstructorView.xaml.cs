using SportClub.Data;
using SportClub.Models;
using SportClub.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SportClub.Views
{
    public partial class MembershipInstructorView : UserControl
    {
        private readonly SportClubContext _context;
        private readonly MembershipInstructorViewModel _viewModel;

        public MembershipInstructorView()
        {
            InitializeComponent();
            _context = new SportClubContext();
            _viewModel = new MembershipInstructorViewModel();
            DataContext = _viewModel;

             
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;

             
            this.Unloaded += MembershipInstructorView_Unloaded;

             
            LoadAvailableMembers();
        }

        private void MembershipInstructorView_Unloaded(object sender, RoutedEventArgs e)
        {
           
            if (_viewModel != null)
            {
                _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
            }

             
            _context?.Dispose();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedMembership))
            {
                LoadAvailableMembers();
            }
        }

        private void LoadAvailableMembers()
        {
            _viewModel.LoadAvailableMembers();
            AvailableMembersComboBox.ItemsSource = _viewModel.AvailableMembers;
        }

        private void AddMembership_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddMembershipWindow();
            if (dialog.ShowDialog() == true && dialog.NewMembership != null)
            {
                _viewModel.AddNewMembership(
                    dialog.NewMembership.Type,
                    dialog.NewMembership.Price,
                    dialog.NewMembership.Duration
                );
            }
        }

        private void AddMemberToMembership_Click(object sender, RoutedEventArgs e)
        {
            if (AvailableMembersComboBox.SelectedItem is ClubMember selectedMember && _viewModel.SelectedMembership != null)
            {
                try
                {
                    _viewModel.AddMemberToMembership(selectedMember);
                    AvailableMembersComboBox.SelectedItem = null;
                    LoadAvailableMembers(); 
                    MessageBox.Show("Član je uspješno dodan na članarinu.", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri dodavanju člana: {ex.Message}", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite članarinu i člana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}