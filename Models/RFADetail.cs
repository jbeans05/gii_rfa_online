using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class RFADetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}

        public decimal ActualPrice{get;set;}
        public decimal TotalPrice{get;set;}        
        public string CostAllocation{get;set;}
        public string Remark{get;set;}       

        public virtual Item Item{get;set;}
        public virtual Supplier Supplier{get;set;}
        public virtual RequestOrderDetail RequestOrderDetail{get;set;}
        public virtual RFA Rfa {get;set;}
        public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}
    }
}