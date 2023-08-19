using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class UnitMeasurement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]   
        public int Id{get;set;}
        [Required]
        public string Code{get;set;}
        [Required]
        public string Name{get;set;}
         public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}
    }
}