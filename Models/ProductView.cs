﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjFresh.Models
{
    public class ProductView
    {
        public tblProduct _Product { get; set; }
        public tblProductImage _ProductImage { get; set; }
        public tblProductPrice _ProductPrice { get; set; }
    }
}