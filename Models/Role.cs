using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}
        public string RoleCode{get;set;}
        public string RoleName{get;set;}
        public string RoleDescription{get;set;}
        public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}

        public virtual ICollection<UserRole> UserRoles{get;set;}       
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}
    }
}