using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Data.Repositories
{
    public partial interface ISlideRepository
    {
        // Manage

        PagedResult<SlideManageGetResult> GetSlides(SlidePagingManageGetRequest request);

        bool Create(SlideCreateRequest request);

        bool Update(SlideUpdateRequest request);

        bool Delete(int id);

        // Public

        List<SlidePublicGetResult> GetSlides(SlidePublicGetRequest request);
    }

    public class SlideRepository : ISlideRepository
    {
        private IDatabaseHelper _dbHelper;
        public SlideRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        public PagedResult<SlideManageGetResult> GetSlides(SlidePagingManageGetRequest request)
        {
            string[] valueJsonColumns = {"Items" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_slide_getslidesmanage","@request",requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                    
                var slides = dt.ConvertTo<PagedResult<SlideManageGetResult>>(valueJsonColumns).FirstOrDefault();
                return slides;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(SlideCreateRequest request)
        {
            string msgError = "";
            var sliderItems = request.SlideItems != null ? MessageConvert.SerializeObject(request.SlideItems) : null;
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_slide_create",
                "@Name", request.Name,
                "@Page", request.Page,
                "@Position", request.Position,
                "@Published", request.Published,
                "@SlideItems", sliderItems
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SlideUpdateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_slide_update",
                "@request", requestJson
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_slide_delete",
                "@id", id
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Public

        public List<SlidePublicGetResult> GetSlides(SlidePublicGetRequest request)
        {
            string[] valueJsonColumns = { "SlideItems" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_slide_getslidespublic", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var slides = dt.ConvertTo<SlidePublicGetResult>(valueJsonColumns).ToList();
                return slides;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
