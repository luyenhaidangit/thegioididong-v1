using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.CMS.Slides;

namespace Thegioididong.Data.Repositories
{
    public partial interface ISlideRepository
    {
        bool Create(SlideCreateRequest request);
    }

    public class SlideRepository : ISlideRepository
    {
        private IDatabaseHelper _dbHelper;
        public SlideRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
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
    }
}
