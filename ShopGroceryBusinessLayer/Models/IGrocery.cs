using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopGroceryBusinessLayer.Models;

namespace ShopGroceryBusinessLayer.Models
{
    interface IGrocery
    {
        IEnumerable<Grocery> Groceries();
        IEnumerable<GroceryType> GroceryTypes();
    }
}
