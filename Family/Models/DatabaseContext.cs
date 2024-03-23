using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using FamilyBusinessLayer.Models;
using ShopGroceryBusinessLayer.Models;

namespace Family.Models
{
    public class DatabaseContext: DbContext
    {
        public DbSet<FamilyMemberType> FamilyMemberTypes { get;set;}
        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public System.Data.Entity.DbSet<ShopGroceryBusinessLayer.Models.Grocery> Groceries { get; set; }

        public DbSet<GroceryType> GroceryTypes { get; set; }

        

        //public DbSet<FamilyMemberDetails> FamilyMemberDetails { get; set; }
    }
}