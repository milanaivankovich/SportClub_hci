// ClubMemberExtensions.cs
namespace SportClub.Models
{
    public static class ClubMemberExtensions
    {
        public static string FullName(this ClubMember member)
        {
            return $"{member.FirstName} {member.LastName}";
        }
    }
}