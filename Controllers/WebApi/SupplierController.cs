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
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierAccess _supplierAccess;

        public SupplierController(ISupplierAccess supplierAccess){
            _supplierAccess = supplierAccess;
        }
                

        [HttpGet("totalrecord/{keyword?}")]
        public int GetTotalRecord(string keyword=null){
            if (string.IsNullOrEmpty(keyword))
            {
                var result = _supplierAccess.GetTotalRecord();               
                return result;
            }else{
                var result = _supplierAccess.GetTotalRecord(keyword);
                return result;
            }
            
        }

        [HttpGet("paging/{pageIndex}/{pageSize}/{keyWord?}")]
        public IEnumerable<Supplier> GetpagingSupplier(int pageIndex, int pageSize, string keyWord = null){
            if (string.IsNullOrEmpty(keyWord))
            {
                var result = _supplierAccess.GetPagingSupplier(pageIndex, pageSize);
                return result;
            }else{
                var result = _supplierAccess.GetPagingSupplier(pageIndex, pageSize, keyWord);
                return result;
            }            
        }       

            

        [HttpPost]
        public int BulkInsert(IEnumerable<Supplier> suppliers){
            foreach (var item in suppliers)
            {
                item.CreatedBy ="System";
                item.CreatedDate = DateTime.UtcNow;
                item.ModifiedBy ="System";
                item.ModifiedDate = DateTime.UtcNow;
                item.IsActive = true;
            }
            var result = _supplierAccess.BulkInsert(suppliers);
            return result;
        }

        [HttpDelete("{supplierId}")]
        public int DeleteSupplier(int supplierId)
        {
            var result = _supplierAccess.DeleteSupplier(supplierId);
            return result;
        }

        [HttpPut("{supplierId}")] 
        public int ArchivedSupplier (int supplierId)
        {
            var result = _supplierAccess.ArchivedSupplier(supplierId);
            return result;
        }

        [HttpPut("update/{supplierId}")]
        public int UpdateSupplier(int supplierId, Supplier supplier)
        {
            var result = _supplierAccess.UpdateSupplier(supplierId,supplier);
            return result;
        }
    }
}