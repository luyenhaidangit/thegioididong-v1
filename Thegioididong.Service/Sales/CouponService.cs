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
    public partial interface ICounponService
    {
        // Manage
        List<Coupon> Get();

        Coupon GetById(int id);
    }
    public partial class CouponService : ICounponService
    {
        private ICounponRepository _couponRepository;

        public CouponService(ICounponRepository newsRepository)
        {
            this._couponRepository = newsRepository;
        }

        #region Manage

        #endregion

        #region Public
        public List<Coupon> Get()
        {
            return _couponRepository.Get();
        }

        public Coupon GetById(int id)
        {
            return this._couponRepository.GetById(id);  
        }

        #endregion
    }
}