// AttendanceViewModel.cs
using SportClub.Data;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace SportClub.ViewModels
{
    public class AttendanceViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private string _searchDate;
        private string _selectedTrainingType;
        private Training _selectedTraining;
        private List<Training> _allTrainings;

        public AttendanceViewModel()
        {
            _context = new SportClubContext();
            LoadTrainings();
            TrainingTypes = new List<string> { "Cardio", "Lead", "Boulder", "Mobility", "Speed", "Svi" };
            SelectedTrainingType = "Svi";
        }

        private void LoadTrainings()
        {
          
            _allTrainings = _context.Trainings
                .Include(t => t.Attendances)
                .ThenInclude(a => a.ClubMember)
                .OrderByDescending(t => t.DateTime)
                .ToList();

            Trainings = new ListCollectionView(_allTrainings);
            Trainings.Filter = FilterTrainings;
        }

        public ICollectionView Trainings { get; private set; }
        public List<string> TrainingTypes { get; set; }

        public string SearchDate
        {
            get => _searchDate;
            set
            {
                _searchDate = value;
                OnPropertyChanged(nameof(SearchDate));
                Trainings.Refresh();
            }
        }

        public string SelectedTrainingType
        {
            get => _selectedTrainingType;
            set
            {
                _selectedTrainingType = value;
                OnPropertyChanged(nameof(SelectedTrainingType));
                Trainings.Refresh();
            }
        }

        public Training SelectedTraining
        {
            get => _selectedTraining;
            set
            {
                _selectedTraining = value;
                OnPropertyChanged(nameof(SelectedTraining));
                OnPropertyChanged(nameof(AttendanceCount));
                OnPropertyChanged(nameof(AttendingMembers));
            }
        }

        public int AttendanceCount => SelectedTraining?.Attendances?.Count ?? 0;

        public List<ClubMember> AttendingMembers =>
            SelectedTraining?.Attendances?.Select(a => a.ClubMember).ToList() ?? new List<ClubMember>();

        private bool FilterTrainings(object obj)
        {
            if (obj is Training training)
            {
                bool dateMatch = true;
                bool typeMatch = true;

                
                if (!string.IsNullOrEmpty(SearchDate) && DateTime.TryParse(SearchDate, out DateTime searchDate))
                {
                    dateMatch = training.DateTime.Date == searchDate.Date;
                }

               
                if (SelectedTrainingType != "Svi")
                {
                    typeMatch = training.Type == SelectedTrainingType;
                }

                return dateMatch && typeMatch;
            }
            return false;
        }

        public void AddNewTraining(string name, string type, DateTime dateTime)
        {
            var newTraining = new Training
            {
                Name = name,
                Type = type,
                DateTime = dateTime
            };

            _context.Trainings.Add(newTraining);
            _context.SaveChanges();

            
            LoadTrainings();
            OnPropertyChanged(nameof(Trainings));
        }

        public void AddMemberToTraining(ClubMember member)
        {
            if (SelectedTraining != null && member != null)
            {
                
                var existingAttendance = _context.Attendances
                    .FirstOrDefault(a => a.IdClubMember == member.IdClubMember &&
                                        a.IdTraining == SelectedTraining.IdTraining);

                if (existingAttendance != null)
                {
                    return; 
                }

                var attendance = new Attendance
                {
                    Date = DateTime.Now,
                    IdClubMember = member.IdClubMember,
                    IdTraining = SelectedTraining.IdTraining
                };

                _context.Attendances.Add(attendance);
                _context.SaveChanges();

               
                RefreshSelectedTraining();
            }
        }

        private void RefreshSelectedTraining()
        {
            if (SelectedTraining != null)
            {
               
                var refreshedTraining = _context.Trainings
                    .Include(t => t.Attendances)
                    .ThenInclude(a => a.ClubMember)
                    .FirstOrDefault(t => t.IdTraining == SelectedTraining.IdTraining);

                if (refreshedTraining != null)
                {
                    
                    var trainingInList = _allTrainings.FirstOrDefault(t => t.IdTraining == SelectedTraining.IdTraining);
                    if (trainingInList != null)
                    {
                        trainingInList.Attendances = refreshedTraining.Attendances;
                    }

                    SelectedTraining = refreshedTraining;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}