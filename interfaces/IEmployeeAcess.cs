using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paperless_rfa.Models;

namespace Paperless_rfa.interfaces
{
    public interface IEmployeeAcess
    {
        public Employee GetEmployeeByEmployeeID(string employeeId);
        public IEnumerable<Employee> GetEmployees();
        public int AddEmployee(Employee employee);
        public int DeleteEmployee(string employeeId);
        public int UpdateEmployee(string employeeId, Employee employee);
        public int InsertBulkEmployee(IEnumerable<Employee> employees);
        public IEnumerable<Employee> SearchEmployee(string keyword);
        public int InActiveEmployee(string employeeId);

        public IEnumerable<Employee>  GetPagingEmployee(int pageIndex, int pageSize);
        public IEnumerable<Employee>  GetPagingEmployee(int pageIndex, int pageSize, string keyWord);
        public int GetTotalRecord();
        public int GetTotalRecord(string keyWord);
    }
}