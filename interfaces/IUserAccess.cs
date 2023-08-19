using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paperless_rfa.Models;

namespace Paperless_rfa.interfaces
{
    public interface IUserAccess
    {
        public UserApp GetUser(int id);
        public UserApp GetUserAppByEmployeeID(string employeeId);
        public IEnumerable<UserApp> GetUsers();
        public int UpdateUserApp(int id, UserApp userApp);
        public int DeleteUserApp(int id);
        public int InsertUserApp(UserApp userApp);

    }
}