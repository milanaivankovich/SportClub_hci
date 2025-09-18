// InstructorCompetitionsView.xaml.cs
using SportClub.Data;
using SportClub.Models;
using SportClub.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace SportClub.Views
{
    public partial class InstructorCompetitionsView : UserControl
    {
        private SportClubContext _context;
        private CompetitionViewModel _viewModel;

        public InstructorCompetitionsView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _context = new SportClubContext();

            var competitions = _context.Competitions
                .Include(c => c.ClubMembers)
                .ToList();

            var allMembers = _context.ClubMembers.ToList();

            _viewModel = new CompetitionViewModel(competitions, allMembers, _context);
            DataContext = _viewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Search is handled automatically through data binding
        }

        private void AddParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedAvailableMember != null)
            {
                _viewModel.AddParticipant(_viewModel.SelectedAvailableMember);
            }
        }

        private void RemoveParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedParticipant != null)
            {
                _viewModel.RemoveParticipant(_viewModel.SelectedParticipant);
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_viewModel.SelectedCompetition != null)
                {
                    var competition = _context.Competitions
                        .Include(c => c.ClubMembers)
                        .FirstOrDefault(c => c.IdCompetition == _viewModel.SelectedCompetition.IdCompetition);

                    if (competition != null)
                    {
                        
                        competition.ClubMembers.Clear();
                        foreach (var participant in _viewModel.SelectedCompetitionParticipants)
                        {
                            var member = _context.ClubMembers.Find(participant.IdClubMember);
                            if (member != null)
                            {
                                competition.ClubMembers.Add(member);
                            }
                        }

                        _context.SaveChanges();
                        MessageBox.Show("Promjene su uspješno sačuvane!", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);

                        
                        LoadData();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Greška pri čuvanju podataka: {ex.Message}", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}