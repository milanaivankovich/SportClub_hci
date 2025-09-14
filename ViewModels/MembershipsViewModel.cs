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
    public class MembershipsViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private ObservableCollection<Membership> _memberships;
        private Membership _selectedMembership;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Membership> Memberships
        {
            get => _memberships;
            set
            {
                _memberships = value;
                OnPropertyChanged();
            }
        }

        public Membership SelectedMembership
        {
            get => _selectedMembership;
            set
            {
                _selectedMembership = value;
                OnPropertyChanged();
            }
        }

        public ICommand PreviewCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }

        public MembershipsViewModel()
        {
            _context = new SportClubContext();
            LoadMemberships();
            PreviewCommand = new RelayCommand(Preview);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private void LoadMemberships()
        {
            Memberships = new ObservableCollection<Membership>(_context.Memberships.ToList());
        }

        private void Preview()
        {
            LoadMemberships();
        }

        private void Add()
        {
            var addWindow = new AddMembershipWindow();
            if (addWindow.ShowDialog() == true)
            {
                _context.Memberships.Add(addWindow.NewMembership);
                _context.SaveChanges();
                LoadMemberships();
            }
        }

        private void Edit()
        {
            if (SelectedMembership == null)
            {
                MessageBox.Show("Odaberite članarinu za izmjenu!");
                return;
            }

            var editWindow = new EditMembershipWindow(SelectedMembership);
            if (editWindow.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadMemberships();
            }
        }

        private bool CanEdit()
        {
            return SelectedMembership != null;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}