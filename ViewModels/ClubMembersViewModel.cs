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
    public class ClubMembersViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private ObservableCollection<ClubMember> _clubMembers;
        private ClubMember _selectedClubMember;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ClubMember> ClubMembers
        {
            get => _clubMembers;
            set
            {
                _clubMembers = value;
                OnPropertyChanged();
            }
        }

        public ClubMember SelectedClubMember
        {
            get => _selectedClubMember;
            set
            {
                _selectedClubMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand PreviewCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }

        public ClubMembersViewModel()
        {
            _context = new SportClubContext();
            LoadClubMembers();
            PreviewCommand = new RelayCommand(Preview);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private void LoadClubMembers()
        {
            ClubMembers = new ObservableCollection<ClubMember>(_context.ClubMembers.ToList());
        }

        private void Preview()
        {
            LoadClubMembers();
        }

        private void Add()
        {
            var addWindow = new AddClubMemberWindow();
            if (addWindow.ShowDialog() == true)
            {
                _context.ClubMembers.Add(addWindow.NewClubMember);
                _context.SaveChanges();
                LoadClubMembers();
            }
        }

        private void Edit()
        {
            if (SelectedClubMember == null)
            {
                MessageBox.Show("Odaberite člana za izmjenu!");
                return;
            }

            var editWindow = new EditClubMemberWindow(SelectedClubMember);
            if (editWindow.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadClubMembers();
            }
        }

        private bool CanEdit()
        {
            return SelectedClubMember != null;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}