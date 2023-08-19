using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paperless_rfa.Models;

namespace Paperless_rfa.interfaces
{
    public interface IItemAccess
    {
        public IEnumerable<Item> GetItems();
        public IEnumerable<Item> SearchItems(string keyword);
        public int InserBulk(IEnumerable<Item> items);
        public int DeleteItem(string itemCode);
        public int UpdateItem(string itemCode, Item item);
    }
}