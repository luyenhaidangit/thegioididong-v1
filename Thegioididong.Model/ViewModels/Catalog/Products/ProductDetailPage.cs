using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    //public class BrandProductDetailPage
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }
    //}

    //public class ProductCategoryProductDetailPage
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }
    //}

    //public class GalleryProductDetailPage
    //{
    //    public int Id { get; set; }

    //    public string GalleryName { get; set; }

    //    public string Image { get; set; }

    //    public List<GalleryImageProductDetailPage> GalleryImages { get; set; }
    //}

    //public class GalleryImageProductDetailPage
    //{
    //    public int Id { get; set; }

    //    public string ImageName { get; set; }

    //    public string Image { get; set; }
    //}

    //public class ProductAttribute
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //    public string Value { get; set; }
    //}

    //public class PromoDetailProductDetailPage
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }
    //}

    public class ProductAttribute
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }

    public class ProductVariant
    {
        public int Id { set; get; }

        public string Name { get; set; }

        public decimal OriginalPrice { get; set; }

        public List<ProductAttribute> Options { get; set; }
    }

    //public class ProductAttribute
    //{
    //    public string Name { get; set; }

    //    public List<AttributeValue> AttributeValues { get; set; }
    //}

    public class AttributeValue
    {
        public string Value { get; set; }

        public bool IsSelected { get; set; }

    }

    public class ProductDetailPage
    {
        public string Id { get; set; }

        public string Name { get; set; }

        //public List<ProductAttribute> ProductAttributes { get; set; }

        public List<ProductVariant> ProductVariants { get; set; }

        public decimal OriginalPrice { get; set; }
    }
}
