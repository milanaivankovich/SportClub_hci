using SportClub.Models;

namespace SportClub.Services
{
    public class CurrentUserService
    {
        private static CurrentUserService _instance;
        public static CurrentUserService Instance => _instance ??= new CurrentUserService();

        public User CurrentUser { get; private set; }

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public void ClearCurrentUser()
        {
            CurrentUser = null;
        }
        
        public void Logout()
        {
            CurrentUser = null;
            
        }
        public bool IsLoggedIn => CurrentUser != null;
    }
}