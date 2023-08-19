using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paperless_rfa.Models;

namespace Paperless_rfa.interfaces
{
    public interface IDepartementAccess
    {
        public IEnumerable<Departement> GetAllDpartement();             
        public IEnumerable<Departement> SearchDepartements(string deptName);
      //  public List<string> GetYear();        
        public int DeleteDepartement(int id);  
        public int BulkInsertDepartement(IEnumerable<Departement> departements);
       // public int LockDepartement(int[] ids);
       // public int DuplicateDepartement(string year);
    }
}