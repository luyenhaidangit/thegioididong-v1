using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryService.GetAll();
        }

        //[Route("GetCategoryMainNavigation")]
        //[HttpGet]
        //public List<CategoryNavigationGetResult> GetCategoryMainNavigation()
        //{
        //    return _productCategoryService.GetCategoryMainNavigation();
        //}

        //[Route("Search")]
        //[HttpPost]
        //public ResponseViewModel Search([FromBody] Dictionary<string, object> formData)
        //{
        //    ResponseViewModel response = new ResponseViewModel();
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        int? MaDanhMuc = null;
        //        if (formData.Keys.Contains("Id") && !string.IsNullOrEmpty(Convert.ToString(formData["Id"]))) { MaDanhMuc = Convert.ToInt32(formData["Id"]); }
        //        string TenDanhMuc = "";
        //        if (formData.Keys.Contains("Name") && !string.IsNullOrEmpty(Convert.ToString(formData["Name"]))) { TenDanhMuc = Convert.ToString(formData["Name"]); }
        //        string option = "";
        //        if (formData.Keys.Contains("Option") && !string.IsNullOrEmpty(Convert.ToString(formData["Option"]))) { option = Convert.ToString(formData["Option"]); }
        //        long total = 0;
        //        var data = _productCategoryService.Search(page, pageSize, out total, MaDanhMuc, TenDanhMuc, option);
        //        response.TotalItems = total;
        //        response.Data = data;
        //        response.Page = page;
        //        response.PageSize = pageSize;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return response;
        //}

        [Route("Create")]
        [HttpPost]
        public ApiResult<string> Create([FromForm] ProductCategoryCreateRequest request)
        {
            try
            {
                bool result = _productCategoryService.Create(request);
                return new ApiSuccessResult<string>("Created successfully");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Failed to create");
            }
        }

        [Route("Update")]
        [HttpPost]
        public bool Update([FromBody] ProductCategory productCategory)
        {
            return _productCategoryService.Update(productCategory);
        }
    }
}