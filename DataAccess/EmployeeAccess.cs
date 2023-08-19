using Paperless_rfa.interfaces;
using Paperless_rfa.Models;

namespace Paperless_rfa.DataAccess
{
    public class EmployeeAccess : IEmployeeAcess
    {
        /// <summary>
        /// adding employee data to table employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Employee.Where(c => c.EmployeeId == employee.EmployeeId).SingleOrDefault();
                    if (result != null && string.IsNullOrEmpty(result.EmployeeId))
                    {
                        context.Employee.Add(employee);
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
        /// Delete Employee by employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public int DeleteEmployee(string employeeId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // makesure that employee Id is not yet used at transaction due to cascade delete
                    // this will return -3 mean that data can't be delete  beacuse of constrain forign key 
                    var empCheck = context.RequestOrder.Where(c => c.Employee.EmployeeId == employeeId).FirstOrDefault();
                    if (empCheck != null && string.IsNullOrEmpty(empCheck.RequestOrderNumber))
                    {
                        return -3;
                    }

                    // delete can be done when the employee Id is not used in transaction
                    var result = context.Employee.Where(c => c.EmployeeId == employeeId).SingleOrDefault();
                    if (result != null)
                    {
                        context.Employee.Remove(result);
                        context.SaveChanges();
                        return 0;
                    }

                    // empllyee ID is not found 
                    return -1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }

        /// <summary>
        /// get employee by employee Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployeeByEmployeeID(string employeeId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Employee.Where(c => c.EmployeeId == employeeId).SingleOrDefault();
                    if (result != null)
                    {
                        return result;
                    }
                    return new Employee();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// get all Employee
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Employee.Join(
                        context.Departement,
                        a => a.Departement.Id,
                        b => b.Id,
                        (a, b) => new
                        {
                            a.Id,
                            a.EmployeeId,
                            a.EmployeeName,
                            a.IsActive,
                            a.CreatedBy,
                            a.CreatedDate,
                            deptId = b.Id,
                            b.DeptCode,
                            b.DeptName,
                            b.Description
                        }
                    ).Where(c => c.IsActive == true)
                    .ToList();

                    if (result.Count > 0)
                    {
                        List<Employee> employees = new List<Employee>();
                        foreach (var rs in result)
                        {
                            Employee emp = new Employee();
                            emp.Id = rs.Id;
                            emp.EmployeeId = rs.EmployeeId;
                            emp.EmployeeName = rs.EmployeeName;
                            emp.IsActive = rs.IsActive;
                            emp.CreatedBy = rs.CreatedBy;
                            emp.CreatedDate = rs.CreatedDate;
                            emp.Departement = new Departement() { Id = rs.deptId, DeptCode = rs.DeptCode, DeptName = rs.DeptName, Description = rs.Description };
                            employees.Add(emp);
                        }
                        return employees;
                    }
                    return new List<Employee>();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetPagingEmployee(int pageIndex, int pageSize)
        {
            try
            {
                var PageStart = pageIndex == 1 ? 0 : (pageIndex * pageSize)-pageSize;
                using (var context = new ApplicationDbContext())
                {                   
                     var result = context.Employee.Join(
                        context.Departement,
                        a => a.Departement.Id,
                        b => b.Id,
                        (a, b) => new
                        {     
                            a.Id,                    
                            a.EmployeeId,
                            a.EmployeeName,
                            a.IsActive,
                            a.CreatedBy,
                            a.CreatedDate,
                            deptId = b.Id,
                            b.DeptCode,
                            b.DeptName,
                            b.Description
                        }
                    ).Where(c => c.IsActive == true && c.Id > PageStart)
                    .Take(pageSize)
                    .OrderBy(c=>c.Id)
                    .ToList();

                    if (result.Count > 0)
                    {
                        List<Employee> employees = new List<Employee>();
                        foreach (var rs in result)
                        {
                            Employee emp = new Employee();

                            emp.Id = rs.Id;
                            emp.EmployeeId = rs.EmployeeId;
                            emp.EmployeeName = rs.EmployeeName;
                            emp.IsActive = rs.IsActive;
                            emp.CreatedBy = rs.CreatedBy;
                            emp.CreatedDate = rs.CreatedDate;
                            emp.Departement = new Departement() { Id = rs.deptId, DeptCode = rs.DeptCode, DeptName = rs.DeptName, Description = rs.Description };
                            employees.Add(emp);
                        }
                        return employees;
                    }
                    return new List<Employee>();
                }              
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetPagingEmployee(int pageIndex, int pageSize, string keyWord)
        {
           try
            {
                var PageStart = pageIndex == 1 ? 0 : (pageIndex * pageSize)-pageSize;
                using (var context = new ApplicationDbContext())
                {
                    var rowNum = 0;
                     var result = context.Employee.Join(
                        context.Departement,
                        a => a.Departement.Id,
                        b => b.Id,
                        (a, b) => new
                        {
                            rowNum = rowNum + 1,
                            a.Id,
                            a.EmployeeId,
                            a.EmployeeName,
                            a.IsActive,
                            a.CreatedBy,
                            a.CreatedDate,
                            deptId = b.Id,
                            b.DeptCode,
                            b.DeptName,
                            b.Description
                        }
                    ).Where(c => c.IsActive == true &&  (c.EmployeeId.ToLower().Contains(keyWord.ToLower()) || c.EmployeeName.ToLower().Contains(keyWord.ToLower()) )) 
                    .OrderBy(c=> c.Id)                  
                    .ToList();

                    if (result.Count > 0)
                    {
                        var  dataPaging = result.Where(c=>c.rowNum > PageStart).Take(pageSize).ToList();

                        List<Employee> employees = new List<Employee>();
                        foreach (var rs in dataPaging)
                        {
                            Employee emp = new Employee();
                            emp.Id = rs.Id;
                            emp.EmployeeId = rs.EmployeeId;
                            emp.EmployeeName = rs.EmployeeName;
                            emp.IsActive = rs.IsActive;
                            emp.CreatedBy = rs.CreatedBy;
                            emp.CreatedDate = rs.CreatedDate;
                            emp.Departement = new Departement() { Id = rs.deptId, DeptCode = rs.DeptCode, DeptName = rs.DeptName, Description = rs.Description };
                            employees.Add(emp);
                        }
                        return employees;
                    }
                    return new List<Employee>();
                }              
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public int GetTotalRecord()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                      var result = context.Employee.Where(c=>c.IsActive ==true).Select(c=>c.EmployeeId).Count();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int GetTotalRecord(string keyWord)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                      var result = context.Employee.Where(c=>c.IsActive ==true && c.EmployeeName.ToLower().Contains(keyWord.ToLower())).Select(c=>c.EmployeeId).Count();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int InActiveEmployee(string employeeId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Employee.Where(c => c.EmployeeId == employeeId).SingleOrDefault();
                    if (result != null)
                    {
                        result.IsActive = false;
                        context.Employee.Update(result);
                        context.SaveChanges();
                        return 0;
                    }
                    return -1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }


        /// <summary>
        /// insert multiple data at the same time
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public int InsertBulkEmployee(IEnumerable<Employee> employees)
        {
            try
            {
                var isDbOperation = false;
                List<Employee> InsertData = new List<Employee>();
                List<Employee> UpdateData = new List<Employee>();


                using (var context = new ApplicationDbContext())
                {
                    // this script is made to fill the department data 
                    foreach (var itemEmployee in employees)
                    {
                        var dept = context.Departement.Where(c => c.Id == itemEmployee.Departement.Id).SingleOrDefault();
                        itemEmployee.Departement = dept;
                    }
                    //this scipt is used to separate between insert or update
                    InsertData = employees.Where(c => c.action.ToLower() == "insert").ToList();
                    UpdateData = employees.Where(c => c.action.ToLower() == "edit").ToList();

                    if (InsertData.Count() > 0)
                    {
                        context.Employee.AddRange(InsertData);
                        isDbOperation = true;
                    }
                    if (UpdateData.Count() > 0)
                    {
                        context.Employee.UpdateRange(UpdateData);
                        isDbOperation = true;
                    }

                    if (isDbOperation)
                    {
                        context.SaveChanges();
                        return 0;
                    }

                    return -1;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -2;
            }
        }

        public IEnumerable<Employee> SearchEmployee(string keyword)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Employee.Join(
                       context.Departement,
                       a => a.Departement.Id,
                       b => b.Id,
                       (a, b) => new
                       {
                           a.EmployeeId,
                           a.EmployeeName,
                           a.IsActive,
                           a.CreatedBy,
                           a.CreatedDate,
                           b.Id,
                           b.DeptCode,
                           b.DeptName,
                           b.Description
                       }
                   )
                   .Where(c => c.EmployeeId.Contains(keyword) || c.EmployeeName.Contains(keyword))
                   .ToList();

                    if (result.Count > 0)
                    {
                        List<Employee> employees = new List<Employee>();
                        foreach (var rs in result)
                        {
                            Employee emp = new Employee();
                            emp.EmployeeId = rs.EmployeeId;
                            emp.EmployeeName = rs.EmployeeName;
                            emp.IsActive = rs.IsActive;
                            emp.CreatedBy = rs.CreatedBy;
                            emp.CreatedDate = rs.CreatedDate;
                            emp.Departement = new Departement() { Id = rs.Id, DeptCode = rs.DeptCode, DeptName = rs.DeptName, Description = rs.Description };
                            employees.Add(emp);
                        }
                        return employees;
                    }
                    return new List<Employee>();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Employee>();
            }
        }


        /// <summary>
        /// update Employee Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int UpdateEmployee(string employeeId, Employee employee)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Employee.Where(c => c.EmployeeId == employeeId).SingleOrDefault();
                    if (result != null)
                    {
                        result.EmployeeName = employee.EmployeeName;
                        result.IsActive = employee.IsActive;
                        context.Employee.Update(result);
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