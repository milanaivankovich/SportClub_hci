// MembershipInstructorViewModel.cs
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
    public class MembershipInstructorViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private string _searchText;
        private Membership _selectedMembership;
        private List<Membership> _allMemberships;

        public MembershipInstructorViewModel()
        {
            _context = new SportClubContext();
            LoadMemberships();
            AvailableMembers = new List<ClubMember>();
        }

        private void LoadMemberships()
        {
            _allMemberships = _context.Memberships
                .Include(m => m.MembershipClubMembers)
                .ThenInclude(mcm => mcm.ClubMember)
                .ToList();

            Memberships = new ListCollectionView(_allMemberships);
            Memberships.Filter = FilterMemberships;
        }

        public ICollectionView Memberships { get; private set; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                Memberships.Refresh();
            }
        }

        public Membership SelectedMembership
        {
            get => _selectedMembership;
            set
            {
                _selectedMembership = value;
                OnPropertyChanged(nameof(SelectedMembership));
                OnPropertyChanged(nameof(MembersWithMembership));
                LoadAvailableMembers();
            }
        }

        public List<MembershipClubMember> MembersWithMembership =>
            SelectedMembership?.MembershipClubMembers?.ToList() ?? new List<MembershipClubMember>();

        public List<ClubMember> AvailableMembers { get; private set; }

        private bool FilterMemberships(object obj)
        {
            if (obj is Membership membership)
            {
                if (string.IsNullOrEmpty(SearchText))
                    return true;

                return membership.Type.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public void LoadAvailableMembers()
        {
            var allActiveMembers = _context.ClubMembers.Where(m => m.Active).ToList();

            if (SelectedMembership != null)
            {
                
                var membersWithThisMembership = _context.MembershipClubMembers
                    .Where(mcm => mcm.IdMembership == SelectedMembership.IdMembership)
                    .Select(mcm => mcm.IdClubMember)
                    .ToList();

               
                var availableMembers = allActiveMembers
                    .Where(m => !membersWithThisMembership.Contains(m.IdClubMember))
                    .ToList();

                AvailableMembers = availableMembers;
            }
            else
            {
               
                AvailableMembers = allActiveMembers;
            }

            OnPropertyChanged(nameof(AvailableMembers));
        }

        public void AddNewMembership(string type, int price, TimeSpan duration)
        {
            var newMembership = new Membership
            {
                Type = type,
                Price = price,
                Duration = duration
            };

            _context.Memberships.Add(newMembership);
            _context.SaveChanges();

           
            LoadMemberships();
            OnPropertyChanged(nameof(Memberships));
        }

        public void AddMemberToMembership(ClubMember member)
        {
            if (SelectedMembership != null && member != null)
            {
               
                var existingMembership = _context.MembershipClubMembers
                    .FirstOrDefault(mcm => mcm.IdClubMember == member.IdClubMember &&
                                          mcm.IdMembership == SelectedMembership.IdMembership);

                if (existingMembership != null)
                {
                    throw new Exception("Član već ima ovu članarinu");
                }

                var membershipClubMember = new MembershipClubMember
                {
                    IdClubMember = member.IdClubMember,
                    IdMembership = SelectedMembership.IdMembership
                };

                _context.MembershipClubMembers.Add(membershipClubMember);
                _context.SaveChanges();

                
                RefreshSelectedMembership();
                LoadAvailableMembers(); 
            }
        }

        private void RefreshSelectedMembership()
        {
            if (SelectedMembership != null)
            {
                
                var refreshedMembership = _context.Memberships
                    .Include(m => m.MembershipClubMembers)
                    .ThenInclude(mcm => mcm.ClubMember)
                    .FirstOrDefault(m => m.IdMembership == SelectedMembership.IdMembership);

                if (refreshedMembership != null)
                {
                    
                    var membershipInList = _allMemberships.FirstOrDefault(m => m.IdMembership == SelectedMembership.IdMembership);
                    if (membershipInList != null)
                    {
                        membershipInList.MembershipClubMembers = refreshedMembership.MembershipClubMembers;
                    }

                    SelectedMembership = refreshedMembership;
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