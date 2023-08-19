using Paperless_rfa.interfaces;
using Paperless_rfa.Models;
using Dapper;

namespace Paperless_rfa.DataAccess
{
    public class DepartementAccess : IDepartementAccess
    {
        /// <summary>
        /// Bulk pocess should be enable to determine eather process is insert ot update
        /// ID with Zero value  = new record 
        /// ID with > zero  = Edit record
        /// </summary>
        /// <param name="departements"></param>
        /// <returns></returns>
        public int BulkInsertDepartement(IEnumerable<Departement> departements)
        {
            try
            {
                /*
                    prepare data for insert and update 
                */
                List<Departement> InsertData = new List<Departement>();
                List<Departement> UpdateData = new List<Departement>();                
                InsertData = departements.Where(c => c.Id == 0).ToList();
                UpdateData = departements.Where(c=>c.Id > 0).ToList();

                using (var context = new ApplicationDbContext())
                {
                    if (InsertData.Count() > 0 && UpdateData.Count() > 0)
                    {                    
                        context.Departement.AddRange(InsertData);
                        context.Departement.UpdateRange(UpdateData);
                        context.SaveChanges();
                        return 0;
                    }
                    if (InsertData.Count() <= 0 && UpdateData.Count() > 0)
                    {  
                        context.Departement.UpdateRange(UpdateData);
                        context.SaveChanges();
                        return 0;
                    }
                     if (InsertData.Count() > 0 && UpdateData.Count() <= 0)
                    {                    
                        context.Departement.AddRange(InsertData);
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

        /// <summary>
        /// this function is used to delete un lock departement.
        /// lock departement can't be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDepartement(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // chekcing the record is exist
                    var result = context.Departement.Where(c => c.Id == id).SingleOrDefault();     
                    if (result == null)
                    {
                        // this mean data is not exist
                        return -1;
                    } else {
                        // check the record in not yet used
                        var emp = context.Employee.Join(
                            context.Departement,
                            e => e.Departement.Id,
                            d => d.Id,
                            (e, d) => new { e.EmployeeId, d.Id }
                        ).Where(x => x.Id == id).ToList();

                        if (emp.Count > 0)
                        {
                            // this mean data is exist and already used by the other process so can't be deleted 
                            // only set to in active
                            result.IsActive = false;
                            result.ModifiedBy = "system";
                            result.ModifiedDate = DateTime.UtcNow;
                            context.Departement.Update(result);
                            
                            context.SaveChanges();
                            return -2;
                        }else 
                        {
                            // this data does not have dependency and can be deleted
                            context.Departement.Remove(result);
                            context.SaveChanges();
                            return 0;
                        }
                    }                  

                }
            }
            catch (System.Exception)
            {
                throw;               
            }
        }

      
        /// <summary>
        /// retrieve all active departement within current year
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Departement> GetAllDpartement()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {

                    var year = DateTime.Now.Year.ToString();
                    var result = context.Departement.Where(c => c.IsActive == true).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }
                    return new List<Departement>();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

       

       /// <summary>
        /// this function is used to find departement data base on name and year 
        /// </summary>
        /// <param name="deptName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<Departement> SearchDepartements(string deptName)
        {
            List<Departement> result = new List<Departement>();
            try
            {

                using (var context = new ApplicationDbContext())
                {
                   
                    if (!string.IsNullOrEmpty(deptName) )
                    {
                        result = context.Departement
                                .Where(c => c.DeptName.ToLower().Contains(deptName.ToLower()))                              
                                .ToList();   
                        if (result.Count > 0)
                        {
                            return result;
                        }                    
                    }
                    
                    return new List<Departement>();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
      
    }
}