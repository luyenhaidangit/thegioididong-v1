using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface ISlideService
    {
        // Manage

        bool Create(SlideCreateRequest request);

        bool Update(SlideUpdateRequest request);

        bool Delete(int id);

        PagedResult<Slide> GetSlides(SlidePagingManageGetRequest request);

        // Public

        PagedResult<Slide> GetSlides(SlidePagingPublicGetRequest request);
    }
    public partial class SlideService : ISlideService
    {
        private ISlideRepository _slideRepository;
        private IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "upload";

        public SlideService(ISlideRepository slideRepository, IStorageService storageService)
        {
            this._slideRepository = slideRepository;
            this._storageService = storageService;
        }

        #region Manage

        public bool Create(SlideCreateRequest request) 
        {
            //foreach(SlideItemCreateRequest item in request.SlideItems)
            //{
            //    if (item.ImageFile != null)
            //    {
            //        item.Image = this.SaveFile(item.ImageFile);
            //    }
            //}

            return _slideRepository.Create(request);
        }

        public bool Delete(int id)
        {
            return _slideRepository.Delete(id);
        }

        public PagedResult<Slide> GetSlides(SlidePagingManageGetRequest request)
        {
            return _slideRepository.GetSlides(request);
        }

        public bool Update(SlideUpdateRequest request)
        {
            return _slideRepository.Update(request);
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        #endregion

        #region Public

        public PagedResult<Slide> GetSlides(SlidePagingPublicGetRequest request)
        {
            return _slideRepository.GetSlides(request);
        }

        #endregion
    }
}
