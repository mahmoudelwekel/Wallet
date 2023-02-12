using System;
using System.Collections.Generic;

#nullable disable

namespace Wallet.Domain.Entities.Wallet
{
    public partial class Transaction
    {
        public long TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionFromUserId { get; set; }
        public string TransactionToUserId { get; set; }
        public string TransactionCreateBy { get; set; }
        public DateTime TransactionCreateDate { get; set; }
        public string TransactionUpdateBy { get; set; }
        public DateTime? TransactionUpdateDate { get; set; }

        public virtual AspNetUser TransactionCreateByNavigation { get; set; }
        public virtual AspNetUser TransactionFromUser { get; set; }
        public virtual AspNetUser TransactionToUser { get; set; }
        public virtual AspNetUser TransactionUpdateByNavigation { get; set; }
    }
}
