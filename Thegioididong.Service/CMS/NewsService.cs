using Microsoft.AspNetCore.Http;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Common.Constants;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.News;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface INewsService
    {
        // Manage
        List<News> GetNewsHome();
        PagedResult<News> Get(NewsPaingPublicGetRequest request);
        News GetById(int id);
    }
    public partial class NewsService : INewsService
    {
        private INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        #region Manage

        #endregion

        #region Public
        public List<News> GetNewsHome()
        {
            NewsPaingPublicGetRequest request = new NewsPaingPublicGetRequest()
            {
                PageIndex = 1,
                PageSize = 3,
                SortBy = "CreatedDate",
                OrderBy = "asc",
            };

            List<News> result = _newsRepository.Get(request).Items.ToList();
            return result;
        }

        public PagedResult<News> Get(NewsPaingPublicGetRequest request)
        {
            return _newsRepository.Get(request);
        }

        public News GetById(int id)
        {
            return _newsRepository.GetById(id);
        }

        #endregion
    }
}