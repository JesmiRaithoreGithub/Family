﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopGroceryBusinessLayer.Models
{
    public class GroceryType
    {
        [Key]
        public int GroceryItemTypeId { get; set; }
        [Required]
        public string GroceryItemTypeName { get; set; }
        public virtual ICollection<Grocery> Groceries { get; set; }
    }
}