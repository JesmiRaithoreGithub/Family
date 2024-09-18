using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopGroceryBusinessLayer.Models
{
    public class GroceryViewModel
    {
        [Key]
        public int GroceryItemId { set; get; }
        [Required]
        public string GroceryItemName { set; get; }
        [Required]
        public int NoOfGroceryItem { set; get; }
        [Required]
        public int GroceryItemTypeId { set; get; }
        [Required]
        public string GroceryItemTypeName { set; get; }
    }
}