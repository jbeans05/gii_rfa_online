using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paperless_rfa.Models
{
    public class RFA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id{get;set;}
        public string RFANumber{get;set;}
        public string Subject{get;set;}
        public string Currency{get;set;}

        public string strWhy{get;set;}        
        public string strWho{get;set;}
        public string strWhat{get;set;}
        public string strWhen{get;set;}
        public string StrWhere{get;set;}
        public string strHow{get;set;}
        public string strHowMuch{get;set;}

        public bool isManagerApprove{get;set;}
        public bool isHODApprove{get;set;}
        public bool isCEOApprove{get;set;}
        public bool isCFOApprove{get;set;}
        public bool isAcctApprove{get;set;}
        public bool isTaxApprove{get;set;}

        public bool isInvoiceAttachment{get;set;}
        public bool isTaxAttachment{get;set;}
        public bool isDeliveryNoteAttachent{get;set;}
        public bool isROAttachment{get;set;}
        public bool isPOAttachment{get;set;}
        public bool isQuotationAttachment{get;set;}
        public bool isNoaLisAttachmentt{get;set;}
        public bool isAgreementAttachment{get;set;}
        public virtual Employee Employee{get;set;}
        public virtual Departement Departement{get;set;}
        public virtual ICollection<RFADetail> RFADetails{get;set;}
        public string CreatedBy{get;set;}
        public DateTime CreatedDate{get;set;}
        public string ModifiedBy{get;set;}
        public DateTime ModifiedDate{get;set;}

        
    }
}