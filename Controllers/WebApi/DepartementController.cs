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
    public class DepartementController : ControllerBase
    {
        private readonly IDepartementAccess _departementAccess;
        public DepartementController(IDepartementAccess departementAccess)
        {
            _departementAccess = departementAccess;
        }

        [HttpGet]
        public IEnumerable<Departement> Get()
        {             
            var result = _departementAccess.GetAllDpartement().ToList();  
            if (result.Count > 0)
            {               
                return result;                
            }
            return new List<Departement>();
        }

        [HttpGet("Search/{deptname}")]
        public IEnumerable<Departement> Get(string deptName)
        {           
            var result = _departementAccess.SearchDepartements(deptName).ToList();
            return result;
        }

        [HttpPost]
        public int Post(IEnumerable<Departement> departements)
        {            
            foreach (var dept in departements)
            {              
                dept.CreatedBy = "202210110001";
                dept.CreatedDate = DateTime.UtcNow;
                dept.ModifiedBy = "202210110001";
                dept.ModifiedDate = DateTime.UtcNow;
                
            }
            var result = _departementAccess.BulkInsertDepartement(departements);
            return result;
        }      

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var result = _departementAccess.DeleteDepartement(id);
            return result;
        }

       
    }
}