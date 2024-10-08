﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ShopGroceryBusinessLayer.Models;

namespace ShopGroceryBusinessLayer.Models
{
    public class Grocery
    {
        [Key]
        public int GroceryItemId { set; get; }
        [Required]
        public string GroceryItemName { set; get; }
        [Required]
        public int NoOfGroceryItem { set; get; }

        public virtual GroceryType GroceryType { set; get; }

        [Required]
        public int GroceryItemTypeId { set; get; }

      
    }
}