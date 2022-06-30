using Task1.Shared.Models;
namespace Task1.Api.Interface
{
    public interface IUserDetails
    {
        public List<UserDetails> GetUserDetails();
        public void AddUserDetails(UserDetails UserDetails);
        public void UpdateUserDetails(UserDetails UserDetails);
        public UserDetails GetUserData(int id);
        public void DeleteUserDetails(int id);
    }
}
