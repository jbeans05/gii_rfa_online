using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class RequestOrder
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}
        [Required]
        public string RequestOrderNumber { get; set; }
        public string Reason { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Departement Department { get; set; }
        public virtual ICollection<RequestOrderDetail> RequestOrderDetails { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}