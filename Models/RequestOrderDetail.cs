using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class RequestOrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}
        [Required]
        public int Quantity{get;set;}      
        public string Unit{get;set;}
        public decimal TotalAmount{get;set;}
        public string Currentcy{get;set;}

        public virtual Item Item{get;set;}
        public virtual RequestOrder RequestOrder {get;set;}
        public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}
    }
}