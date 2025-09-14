using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SportClub.Data;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using SportClub.Views;
using SportClub.Models;

namespace SportClub.ViewModels
{
    public class CompetitionsViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private ObservableCollection<Competition> _competitions;
        private Competition _selectedCompetition;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Competition> Competitions
        {
            get => _competitions;
            set
            {
                _competitions = value;
                OnPropertyChanged();
            }
        }

        public Competition SelectedCompetition
        {
            get => _selectedCompetition;
            set
            {
                _selectedCompetition = value;
                OnPropertyChanged();
            }
        }

        public ICommand PreviewCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }

        public CompetitionsViewModel()
        {
            _context = new SportClubContext();
            LoadCompetitions();
            PreviewCommand = new RelayCommand(Preview);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private void LoadCompetitions()
        {
            Competitions = new ObservableCollection<Competition>(_context.Competitions.ToList());
        }

        private void Preview()
        {
            LoadCompetitions();
        }

        private void Add()
        {
            var addWindow = new AddCompetitionWindow();
            if (addWindow.ShowDialog() == true)
            {
                _context.Competitions.Add(addWindow.NewCompetition);
                _context.SaveChanges();
                LoadCompetitions();
            }
        }

        private void Edit()
        {
            if (SelectedCompetition == null)
            {
                MessageBox.Show("Odaberite takmičenje za izmjenu!");
                return;
            }

            var editWindow = new EditCompetitionWindow(SelectedCompetition);
            if (editWindow.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadCompetitions();
            }
        }

        private bool CanEdit()
        {
            return SelectedCompetition != null;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}