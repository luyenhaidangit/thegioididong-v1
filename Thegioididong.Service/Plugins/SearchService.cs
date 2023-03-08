using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Plugins.Search;

namespace Thegioididong.Service.Plugins
{
    public partial interface ISearchService
    {
        // Manage

        // Public

        SearchSuggestPublicGetResult GetSearchSuggest(string keyword);
    }

    public partial class SearchService : ISearchService
    {
        private ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            this._searchRepository = searchRepository;
        }

        #region Manage

        #endregion

        #region Public

        public SearchSuggestPublicGetResult GetSearchSuggest(string keyword)
        {
            return _searchRepository.GetSearchSuggest(keyword);
        }

        #endregion
    }
}
