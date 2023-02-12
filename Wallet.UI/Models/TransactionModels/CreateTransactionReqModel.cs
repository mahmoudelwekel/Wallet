 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wallet.UI.Models.TransactionModels
{
    public class CreateTransactionReqModel 
    {
        public long TransactionId { get; set; }


        [Display(Name = "Amount", Prompt = "Amount")]
        public decimal TransactionAmount { get; set; }
        public string TransactionFromUserId { get; set; }
        public string TransactionToUserId { get; set; }


        [Display(Name = "Phone Number", Prompt = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^(?:01[0-9]{9})$")]
        [Phone]
        public string TransactionToUserPhone { get; set; }




        public string TransactionCreateBy { get; set; }
        public DateTime TransactionCreateDate { get; set; }
        public string TransactionUpdateBy { get; set; }
        public DateTime? TransactionUpdateDate { get; set; }
    }
}
