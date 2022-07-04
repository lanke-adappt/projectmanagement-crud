using Task1.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Task1.Api.Services
{
    public class UserDetailsManager : IUserDetails
    {
        readonly DataContext _dbContext;
        public UserDetailsManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserDetails> GetUserDetails()
        {
            try
            {
                return _dbContext.UserDetails.ToList();
            }
            catch
            {
                throw;
            }

        }

        public void AddUserDetails(UserDetails userDetails)
        {
            try
            {
                _dbContext.UserDetails.Add(userDetails);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

       

        public void UpdateUserDetails(UserDetails userDetails)
        {
            try
            {
                _dbContext.Entry(userDetails).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch  (Exception ex)
            {
                Log.Error("Error in updating object", ex.Message);
            }
        }

        public UserDetails GetUserData(int id)
        {
            try
            {
                UserDetails? userDetail = _dbContext.UserDetails.Find(id);
                if (userDetail != null)
                {
                    return userDetail;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in Fetching object", ex.Message);
                return null;
            }
        }
        public void DeleteUserDetails(int id)
        {
            try
            {
                UserDetails? userDetail = _dbContext.UserDetails.Find(id);
                if (userDetail != null)
                {
                    _dbContext.UserDetails.Remove(userDetail);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();


                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in Deleting object object", ex.Message);
                
            }


        }
    }
}
