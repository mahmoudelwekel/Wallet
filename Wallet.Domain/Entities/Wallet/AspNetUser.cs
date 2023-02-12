using System;
using System.Collections.Generic;

#nullable disable

namespace Wallet.Domain.Entities.Wallet
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            TransactionTransactionCreateByNavigations = new HashSet<Transaction>();
            TransactionTransactionFromUsers = new HashSet<Transaction>();
            TransactionTransactionToUsers = new HashSet<Transaction>();
            TransactionTransactionUpdateByNavigations = new HashSet<Transaction>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<Transaction> TransactionTransactionCreateByNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionTransactionFromUsers { get; set; }
        public virtual ICollection<Transaction> TransactionTransactionToUsers { get; set; }
        public virtual ICollection<Transaction> TransactionTransactionUpdateByNavigations { get; set; }
    }
}
