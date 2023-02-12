using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices.DTOs
{
    public class TransactionDTO
    {
        public long TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionFromUserId { get; set; }
        public string TransactionToUserId { get; set; }
        public string TransactionToUserPhone { get; set; }
        public string TransactionCreateBy { get; set; }
        public DateTime TransactionCreateDate { get; set; }
        public string TransactionUpdateBy { get; set; }
        public DateTime? TransactionUpdateDate { get; set; }
    }
}
