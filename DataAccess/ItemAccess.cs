using Paperless_rfa.Models;
using Paperless_rfa.interfaces;

namespace Paperless_rfa.DataAccess
{
    public class ItemAccess : IItemAccess
    {
        public int DeleteItem(string itemCode)
        {
            try
            {
                using(var context = new ApplicationDbContext())
                {
                    // checking that item already in used or not
                    var checkItem = context.RequestOrderDetail.Where(c=> c.Item.Code == itemCode).SingleOrDefault();
                    if (checkItem != null)
                    {
                        return -3;
                    }

                    var result = context.Item.Where(c=> c.Code == itemCode).SingleOrDefault();
                    if (result != null)
                    {
                        context.Item.Remove(result);
                        context.SaveChanges();
                        context.Dispose();
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

        public IEnumerable<Item> GetItems()
        {
            try
            {
               using (var context = new ApplicationDbContext())
               {
                 var result = context.Item.Join(
                    context.Supplier,
                    a => a.Suppliers.Id,
                    b => b.Id ,
                    (a,b) => new{
                        a.Code,
                        a.Name,
                        a.Description,
                        a.UnitPrice,
                        a.CreatedBy,
                        a.CreatedDate,
                        b.Id,
                        supplierName = b.Name,

                    }
                 )                 
                 .ToList();


                 if (result.Count() > 0)
                 {
                    List<Item> itms = new List<Item>();
                    foreach (var item in result)
                    {
                        Item itm = new Item();
                        itm.Code = item.Code;
                        itm.Name = item.Name;
                        itm.Description = item.Description;
                        itm.UnitPrice = item.UnitPrice;
                        itm.CreatedBy = item.CreatedBy;
                        itm.CreatedDate = item.CreatedDate;
                        itm.Suppliers = new Supplier(){Id = item.Id, Name=item.supplierName};
                        itms.Add(itm);
                    }
                    return itms;
                 }
                 return new List<Item>();
               }
            }
            catch (System.Exception)
            {
                return new List<Item>();
            }
        }

        public int InserBulk(IEnumerable<Item> items)
        {
            var isDbOperation =false;
            List<Item> insertedItem = new List<Item>();
            List<Item> updatedItem = new List<Item>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    foreach (var item in items)
                    {
                        var supp = context.Supplier.Where(c=> c.Id == item.Suppliers.Id).SingleOrDefault();
                        item.Suppliers = supp;
                    }

                    insertedItem = items.Where(c=> c.action.ToLower() == "insert").ToList();
                    updatedItem = items.Where(c=> c.action.ToLower() == "update").ToList();

                    if (insertedItem.Count() > 0)
                    {
                        context.Item.AddRange(insertedItem);
                        isDbOperation = true;
                    }
                    if (updatedItem.Count() > 0)
                    {
                        context.Item.UpdateRange(updatedItem);
                        isDbOperation=true;
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
                return -2;
            }
        }

        public IEnumerable<Item> SearchItems(string keyword)
        {
            try
            {
               using (var context = new ApplicationDbContext())
               {
                 var result = context.Item.Join(
                    context.Supplier,
                    a => a.Suppliers.Id,
                    b => b.Id ,
                    (a,b) => new{
                        a.Code,
                        a.Name,
                        a.Description,
                        a.UnitPrice,
                        a.CreatedBy,
                        a.CreatedDate,
                        b.Id,
                        supplierName = b.Name,

                    }
                 )
                 .Where(c=> c.Code.Contains(keyword) || c.Name.Contains(keyword))
                 .ToList();


                 if (result.Count() > 0)
                 {
                    List<Item> itms = new List<Item>();
                    foreach (var item in result)
                    {
                        Item itm = new Item();
                        itm.Code = item.Code;
                        itm.Name = item.Name;
                        itm.Description = item.Description;
                        itm.UnitPrice = item.UnitPrice;
                        itm.CreatedBy = item.CreatedBy;
                        itm.CreatedDate = item.CreatedDate;
                        itm.Suppliers = new Supplier(){Id = item.Id, Name=item.supplierName};
                        itms.Add(itm);
                    }
                    return itms;
                 }
                 return new List<Item>();
               }
            }
            catch (System.Exception)
            {
                return new List<Item>();
            }
        }

        public int UpdateItem(string itemCode, Item item)
        {
            try
            {
                using (var contex = new ApplicationDbContext())
                {
                    var supp = contex.Supplier.Where(c=> c.Id == item.Suppliers.Id).SingleOrDefault();
                    if (supp == null)
                    {
                        return -4;
                    }    

                    var result = contex.Item.Where(c=> c.Code == itemCode).SingleOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.Code) )
                    {
                        result.Name = item.Name;
                        result.Description = item.Description;
                        result.UnitPrice = item.UnitPrice;
                        result.Suppliers = supp;
                        result.ModifiedBy = "system";
                        result.ModifiedDate = DateTime.UtcNow;

                        contex.Item.Update(result);
                        contex.SaveChanges();
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
    }
}