using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Catalog.Brands;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Rating;
using Thegioididong.Model.ViewModels.CMS.Galleries;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class BrandProductDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductCategoryProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class GalleryProductDetal
    {
        public int Id { get; set; }

        public string GalleryName { get; set; }

        public string Image { get; set; }

        public List<GalleryImageProductDetailPage> GalleryImages { get; set; }
    }

    public class GalleryImageProductDetailPage
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public string Image { get; set; }
    }

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

    public class ProductVariant
    {
        public int Id { set; get; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public int DiscountPercent { get; set; }

        public bool IsInterest { get; set; }

        public List<ProductAttribute> Options { get; set; }
    }

    public class ProductDetailPage
    {
        public string Id { get; set; }

        public ProductCategoryBasicViewModel ProductCategory { get; set; }

        public BrandPublicGetResult Brand { get; set; }

        public string Name { get; set; }

        public RatingProductPageViewModel Rating { get; set; }

        public List<ProductVariant> ProductVariants { get; set; }

        public List<GalleryImageProductDetailPageViewModel> Galleries { get; set; }
    }
}
