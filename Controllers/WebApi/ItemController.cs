using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.interfaces;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers.WebApi
{
    public class ItemController
    {
        private readonly IItemAccess _itemAccess;
        public ItemController(IItemAccess itemAccess){
            _itemAccess = itemAccess;
        }


        [HttpGet]
        public IEnumerable<Item> GetItems(){
            var result = _itemAccess.GetItems();
            if (result.Any())
            {
                return result.ToList();
            }
            return new List<Item>();
        }

        [HttpPost]
        public int InsertBulk(IEnumerable<Item> items){
            var result = _itemAccess.InserBulk(items);
            return result;
        } 

        [HttpDelete]
        public int DeleteItem(string itemCode)
        {
            var result = _itemAccess.DeleteItem(itemCode);
            return result;
        }

        [HttpPut]
        public int UpdateItem(string itemCode, Item item){
            var result = _itemAccess.UpdateItem(itemCode, item);    
            return result;
        }
    }
}