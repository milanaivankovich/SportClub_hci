// CompetitionViewModel.cs
using SportClub.Models;
using SportClub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace SportClub.ViewModels
{
    public class CompetitionViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        private Competition _selectedCompetition;
        private ClubMember _selectedAvailableMember;
        private ClubMember _selectedParticipant;
        private SportClubContext _context;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Competition> Competitions { get; set; }
        public List<ClubMember> AllMembers { get; set; }
        public ObservableCollection<ClubMember> AvailableMembers { get; set; }
        public ObservableCollection<ClubMember> SelectedCompetitionParticipants { get; set; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FilteredCompetitions));
            }
        }

        public Competition SelectedCompetition
        {
            get => _selectedCompetition;
            set
            {
                _selectedCompetition = value;
                LoadParticipants();
                OnPropertyChanged();
            }
        }

        public ClubMember SelectedAvailableMember
        {
            get => _selectedAvailableMember;
            set
            {
                _selectedAvailableMember = value;
                OnPropertyChanged();
            }
        }

        public ClubMember SelectedParticipant
        {
            get => _selectedParticipant;
            set
            {
                _selectedParticipant = value;
                OnPropertyChanged();
            }
        }

        public List<Competition> FilteredCompetitions =>
            string.IsNullOrEmpty(SearchText)
            ? Competitions
            : Competitions.Where(c => c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

        public CompetitionViewModel(List<Competition> competitions, List<ClubMember> allMembers, SportClubContext context)
        {
            Competitions = competitions.OrderBy(c => c.Date).ToList();
            AllMembers = allMembers;
            _context = context;
            SelectedCompetitionParticipants = new ObservableCollection<ClubMember>();
            AvailableMembers = new ObservableCollection<ClubMember>();
        }

        private void LoadParticipants()
        {
            if (SelectedCompetition != null)
            {
                // Učitaj trenutne učesnike takmičenja iz baze
                var currentParticipants = _context.Competitions
                    .Where(c => c.IdCompetition == SelectedCompetition.IdCompetition)
                    .Include(c => c.ClubMembers)
                    .SelectMany(c => c.ClubMembers)
                    .ToList();

                SelectedCompetitionParticipants.Clear();
                foreach (var participant in currentParticipants)
                {
                    SelectedCompetitionParticipants.Add(participant);
                }

                // Učitaj dostupne članove (oni koji nisu učesnici trenutnog takmičenja)
                var participantIds = currentParticipants.Select(p => p.IdClubMember).ToList();
                var availableMembers = AllMembers.Where(m => !participantIds.Contains(m.IdClubMember)).ToList();

                AvailableMembers.Clear();
                foreach (var member in availableMembers)
                {
                    AvailableMembers.Add(member);
                }
            }
            else
            {
                SelectedCompetitionParticipants.Clear();
                AvailableMembers.Clear();
                foreach (var member in AllMembers)
                {
                    AvailableMembers.Add(member);
                }
            }

            OnPropertyChanged(nameof(SelectedCompetitionParticipants));
            OnPropertyChanged(nameof(AvailableMembers));
        }

        public void AddParticipant(ClubMember member)
        {
            if (SelectedCompetition != null && member != null && !SelectedCompetitionParticipants.Contains(member))
            {
                SelectedCompetitionParticipants.Add(member);
                AvailableMembers.Remove(member);
                OnPropertyChanged(nameof(SelectedCompetitionParticipants));
                OnPropertyChanged(nameof(AvailableMembers));
            }
        }

        public void RemoveParticipant(ClubMember member)
        {
            if (SelectedCompetition != null && member != null && SelectedCompetitionParticipants.Contains(member))
            {
                SelectedCompetitionParticipants.Remove(member);
                AvailableMembers.Add(member);
                OnPropertyChanged(nameof(SelectedCompetitionParticipants));
                OnPropertyChanged(nameof(AvailableMembers));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}