using Paperless_rfa.Models;
using Paperless_rfa.interfaces;

namespace Paperless_rfa.DataAccess
{
    public class UserAccess : IUserAccess
    {

        /// <summary>
        /// Delete user App by user ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUserApp(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.UserApp.Where(c => c.Id == id).SingleOrDefault();
                    if (result != null)
                    {
                        context.UserApp.Remove(result);
                        return 0;
                    }
                    return -1;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Getting user App by user ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserApp GetUser(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.UserApp.Where(c => c.Id == id).SingleOrDefault();
                    if (result != null)
                    {
                        return result;
                    }
                    return new UserApp();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get user App by Employee ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public UserApp GetUserAppByEmployeeID(string employeeId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.UserApp.Where(c => c.employee.EmployeeId == employeeId).SingleOrDefault();
                    if (result != null)
                    {
                        return result;
                    }
                    return new UserApp();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get All user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserApp> GetUsers()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.UserApp.ToList();
                    if (result.Count() > 0)
                    {
                        return result;
                    }
                    return new List<UserApp>();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// insert new record to user app table 
        /// </summary>
        /// <param name="userApp"></param>
        /// <returns></returns>
        public int InsertUserApp(UserApp userApp)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (userApp != null)
                    {
                        if (!string.IsNullOrEmpty(userApp.employee.EmployeeId) && !string.IsNullOrEmpty(userApp.userName) && !string.IsNullOrEmpty(userApp.password))
                        {
                            context.UserApp.Add(userApp);
                            context.SaveChanges();
                            return 0;
                        }
                        return -1;
                    }
                    return -1;

                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// update user app 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userApp"></param>
        /// <returns></returns>
        public int UpdateUserApp(int id, UserApp userApp)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.UserApp.Where(c => c.Id == id).SingleOrDefault();
                    if (result != null)
                    {
                        result.isLock = userApp.isLock;
                        result.password = userApp.password;
                       
                        context.UserApp.Update(result);
                        context.SaveChanges();
                        return 0;
                    }

                    return -1;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}