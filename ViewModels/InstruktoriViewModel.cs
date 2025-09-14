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
    public class InstruktoriViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private ObservableCollection<Instructor> _instructors;
        private Instructor _selectedInstructor;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Instructor> Instructors
        {
            get => _instructors;
            set
            {
                _instructors = value;
                OnPropertyChanged();
            }
        }

        public Instructor SelectedInstructor
        {
            get => _selectedInstructor;
            set
            {
                _selectedInstructor = value;
                OnPropertyChanged();
            }
        }

        public ICommand PreviewCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }

        public InstruktoriViewModel()
        {
            _context = new SportClubContext();
            LoadInstructors();
            PreviewCommand = new RelayCommand(Preview);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private void LoadInstructors()
        {
            Instructors = new ObservableCollection<Instructor>(_context.Instructors.ToList());
        }

        private void Preview()
        {
            LoadInstructors();
        }

        private void Add()
        {
            var addWindow = new AddInstructorWindow();
            if (addWindow.ShowDialog() == true)
            {
                _context.Instructors.Add(addWindow.NewInstructor);
                _context.SaveChanges();
                LoadInstructors();
            }
        }

        private void Edit()
        {
            if (SelectedInstructor == null)
            {
                MessageBox.Show("Odaberite instruktora za izmjenu!");
                return;
            }

            var editWindow = new EditInstructorWindow(SelectedInstructor);
            if (editWindow.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadInstructors();
            }
        }

        private bool CanEdit()
        {
            return SelectedInstructor != null;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}