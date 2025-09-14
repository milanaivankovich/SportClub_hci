using SportClub.Data;
using SportClub.Models;
using SportClub.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SportClub.Views
{
    public partial class AttendanceView : UserControl
    {
        private readonly SportClubContext _context;
        private readonly AttendanceViewModel _viewModel;

        public AttendanceView()
        {
            InitializeComponent();
            _context = new SportClubContext();
            _viewModel = new AttendanceViewModel();
            DataContext = _viewModel;

            // Pretplati se na promjenu odabranog treninga
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;

            // Pretplati se na Unloaded događaj
            this.Unloaded += AttendanceView_Unloaded;

            LoadMembers();
        }

        private void AttendanceView_Unloaded(object sender, RoutedEventArgs e)
        {
            // Otkloni pretplatu na događaje
            if (_viewModel != null)
            {
                _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
            }

            // Oslobodi resurse
            _context?.Dispose();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedTraining))
            {
                LoadMembers(); // Osveži listu članova kada se promeni odabrani trening
            }
        }

        private void LoadMembers()
        {
            var allActiveMembers = _context.ClubMembers.Where(m => m.Active).ToList();

            if (_viewModel.SelectedTraining != null)
            {
                // Dobij IDs članova koji su već prisutni na odabranom treningu
                var attendingMemberIds = _context.Attendances
                    .Where(a => a.IdTraining == _viewModel.SelectedTraining.IdTraining)
                    .Select(a => a.IdClubMember)
                    .ToList();

                // Filtriraj samo članove koji NISU prisutni na treningu
                var availableMembers = allActiveMembers
                    .Where(m => !attendingMemberIds.Contains(m.IdClubMember))
                    .ToList();

                MembersComboBox.ItemsSource = availableMembers;
            }
            else
            {
                // Ako nema odabranog treninga, pokaži sve aktivne članove
                MembersComboBox.ItemsSource = allActiveMembers;
            }
        }

        private void AddTraining_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddTrainingWindow();
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddNewTraining(dialog.TrainingName, dialog.TrainingType, dialog.TrainingDateTime);
            }
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            if (MembersComboBox.SelectedItem is ClubMember selectedMember && _viewModel.SelectedTraining != null)
            {
                try
                {
                    _viewModel.AddMemberToTraining(selectedMember);
                    MembersComboBox.SelectedItem = null;
                    LoadMembers(); // Osveži listu dostupnih članova
                    MessageBox.Show("Član je uspješno dodan na trening.", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri dodavanju člana: {ex.Message}", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite trening i člana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}