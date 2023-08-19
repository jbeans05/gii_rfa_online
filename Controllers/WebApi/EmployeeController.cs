using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.interfaces;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAcess _employeeAccess;
        public EmployeeController(IEmployeeAcess employeeAcess){
            _employeeAccess = employeeAcess;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees(){
            var result = _employeeAccess.GetEmployees().ToList();
            if (result.Count > 0)
            {
                return result;
            }
            return new List<Employee>();
        }

        


        [HttpPost]
        public int InsertBulkEmployee(IEnumerable<Employee> employees){
            
            try
            {
                 foreach (var item in employees)
                {                
                    item.CreatedBy = "202210110001";
                    item.CreatedDate = DateTime.UtcNow;
                    item.ModifiedBy = "202210110001";
                    item.ModifiedDate = DateTime.UtcNow;                  
                }
                var result = _employeeAccess.InsertBulkEmployee(employees);
              
                return result;
            }
            catch (System.Exception)
            {
                
                throw;
            }
           
        }


        [HttpDelete("{employeeId}")]
        public int Delete(string employeeId){
            var result = _employeeAccess.DeleteEmployee(employeeId);
            return result;
        }


        [HttpGet("search/{keyword}")]
        public IEnumerable<Employee> GetEmployees(string keyword){
           
            var result = _employeeAccess.SearchEmployee(keyword);
            return result;
        }

        [HttpPut("{employeeId}")]
        public int InactiveEmployee(string employeeId){
            var result = _employeeAccess.InActiveEmployee(employeeId);
            return result;
        }



        /*handle paging data*/
        [HttpGet("Paging/{pageIndex}/{pageSize}")]
        public IEnumerable<Employee> GetPagingEmployee(int pageIndex, int pageSize){
            var result = _employeeAccess.GetPagingEmployee(pageIndex, pageSize);
            return result;
        }
        [HttpGet("Paging/{pageIndex}/{pageSize}/{keyword}")]
        public IEnumerable<Employee> GetPagingEmployee(int pageIndex, int pageSize, string keyword){
            var result = _employeeAccess.GetPagingEmployee(pageIndex, pageSize, keyword);
            return result;
        }

        [HttpGet("TotalRecord")]
        public int GetTotalRecord(){
            var result = _employeeAccess.GetTotalRecord();
            return result;
        }
        [HttpGet("TotalRecord/{keyword}")]
        public int GetTotalRecord(string keyword){
            var result = _employeeAccess.GetTotalRecord(keyword);
            return result;
        }


    }
}