using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
        public string Phone{get;set;}
        public string Email{get;set;}
        public bool IsActive{get;set;}
        public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}

        public ICollection<Item> Items{get;set;}
        
        [NotMapped]
        public string action{get;set;}      
    }
}