using Paperless_rfa.Models;
using Paperless_rfa.interfaces;

namespace Paperless_rfa.DataAccess
{
    public class SupplierAccess : ISupplierAccess
    {
        public int ArchivedSupplier(int supplierId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Supplier.Where(c => c.Id == supplierId).SingleOrDefault();
                    if (result != null)
                    {
                        result.IsActive = false;
                        result.ModifiedBy = "system";
                        result.ModifiedDate = DateTime.UtcNow;
                        context.Supplier.Update(result);
                        context.SaveChanges();
                        return 0;
                    }
                    return -1;
                }
            }
            catch (System.Exception)
            {
                return -2;
            }
        }

        public int BulkInsert(IEnumerable<Supplier> suppliers)
        {
            try
            {
                var isDbOperation = false;
                List<Supplier> insertData = new List<Supplier>();
                List<Supplier> updateData = new List<Supplier>();

                using (var context = new ApplicationDbContext())
                {
                    insertData = suppliers.Where(c => c.action.ToLower() == "insert").ToList();
                    updateData = suppliers.Where(c => c.action.ToLower() == "edit").ToList();

                    if (insertData.Count() > 0)
                    {
                        context.Supplier.AddRange(insertData);
                        isDbOperation = true;
                    }
                    if (updateData.Count() > 0)
                    {
                        context.Supplier.UpdateRange(updateData);
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
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public int DeleteSupplier(int SupplierId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var checkSupplier = context.Item.Where(c => c.Suppliers.Id == SupplierId).SingleOrDefault();
                    if (checkSupplier != null)
                    {
                        return -3;
                    }

                    var result = context.Supplier.Where(c => c.Id == SupplierId).SingleOrDefault();
                    if (result != null)
                    {
                        context.Supplier.Remove(result);
                        context.SaveChanges();
                        return 0;
                    }
                    return -1;
                }
            }
            catch (System.Exception)
            {
                return -2;
            }
        }

        public IEnumerable<Supplier> GetPagingSupplier(int pageIndex, int pageSize)
        {
            try
            {
                var PageStart = pageIndex == 1 ? 0 : (pageIndex * pageSize)-pageSize;
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Supplier
                                .Where(c => c.IsActive == true && c.Id > PageStart)
                                .OrderBy(c => c.Id)
                                .Take(pageSize)
                                .ToList();
                    if (result.Count() > 0)
                    {
                        return result;
                    }
                }
                return new List<Supplier>();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

         public IEnumerable<Supplier> GetPagingSupplier(int pageIndex, int pageSize, string keyWord)
        {
            try
            {
                var PageStart = pageIndex == 1 ? 0 : (pageIndex * pageSize)-pageSize;
                using (var context = new ApplicationDbContext())
                {
                    if (string.IsNullOrEmpty(keyWord))
                    {
                        var result = context.Supplier
                                .Where(c => c.IsActive == true && c.Id > PageStart )
                                .OrderBy(c => c.Id)
                                .Take(pageSize)
                                .ToList();
                        if (result.Count() > 0)
                        {
                            return result;
                        }
                    } else
                    {
                         var result = context.Supplier
                                .Where(c => c.IsActive == true && c.Id > PageStart && c.Name.ToLower().Contains(keyWord.ToLower()))
                                .OrderBy(c => c.Id)
                                .Take(pageSize)
                                .ToList();
                        if (result.Count() > 0)
                        {
                            return result;
                        }
                    }                  
                   
                }
                return new List<Supplier>();
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
                    var result = context.Supplier.Where(c=>c.IsActive ==true).Select(c=>c.Id).Count();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
            }
            catch (System.Exception)
            {                
                throw;
            }
        }
        public int GetTotalRecord(string keyword)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Supplier.Where(c=>c.IsActive ==true && c.Name.ToLower().Contains(keyword.ToLower())).Select(c=>c.Id).Count();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
            }
            catch (System.Exception)
            {                
                throw;
            }
        }

        public int UpdateSupplier(int supplierId, Supplier supplier)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var result = context.Supplier.Where(c => c.Id == supplierId).SingleOrDefault();
                    if (result != null)
                    {
                        result.Name = supplier.Name;
                        result.Address = supplier.Address;
                        result.Phone = supplier.Phone;
                        result.Email = supplier.Email;
                        result.ModifiedBy = "system";
                        result.ModifiedDate = DateTime.UtcNow;

                        context.Supplier.Update(result);
                        context.SaveChanges();
                        return 0;
                    }
                    return -1;
                }
            }
            catch (System.Exception)
            {
                return -2;
            }
        }
    }
}