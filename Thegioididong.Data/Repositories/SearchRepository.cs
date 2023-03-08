using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Plugins.Search;

namespace Thegioididong.Data.Repositories
{
    public partial interface ISearchRepository
    {
        SearchSuggestPublicGetResult GetSearchSuggest(string keyword);
    }

    public class SearchRepository : ISearchRepository
    {
        private IDatabaseHelper _dbHelper;
        public SearchRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public SearchSuggestPublicGetResult GetSearchSuggest(string keyword)
        {
            string[] valueJsonColumns = { "Products", "ProductCategories", "News" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_getsearchsuggestpublic", "@keyword", keyword);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var result = dt.ConvertTo<SearchSuggestPublicGetResult>(valueJsonColumns).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
