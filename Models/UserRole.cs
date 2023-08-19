using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class UserRole
    {      
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}   
        public  UserApp UserApp{get;set;}
        public Role Role{get;set;}     
        public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}

   
        
    }
}