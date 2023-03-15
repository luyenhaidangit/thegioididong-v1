﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductManageGetResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string DisplayOrder { get; set; }

        public bool Published { get; set; }
    }
}