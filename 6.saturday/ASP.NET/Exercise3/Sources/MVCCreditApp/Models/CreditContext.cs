using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MVCCreditApp.Models
{
    public class CreditContext : DbContext
    {
        public CreditContext() : base("CreditContext")
        {
        }

        public DbSet<Credit> Credits { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}