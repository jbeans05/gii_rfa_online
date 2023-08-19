using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paperless_rfa.Models;

namespace Paperless_rfa.interfaces
{
    public interface ISupplierAccess
    {
      
        public int BulkInsert(IEnumerable<Supplier> suppliers);
        public int DeleteSupplier (int SupplierId);
        public int UpdateSupplier(int supplierId , Supplier supplier);
        public int ArchivedSupplier (int supplierId);
        public IEnumerable<Supplier> GetPagingSupplier(int pageIndex, int pageSize);
        public IEnumerable<Supplier> GetPagingSupplier(int pageIndex, int pageSize, string keyword);
        public int GetTotalRecord();
        public int GetTotalRecord(string keyWord);
    

    }
}