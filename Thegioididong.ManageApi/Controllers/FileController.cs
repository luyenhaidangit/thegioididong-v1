using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Plugins.File;
using Thegioididong.Service;
using Thegioididong.Service.Common;

namespace Thegioididong.ManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IStorageService _fileService;
        public FileController(IStorageService storageService)
        {
            this._fileService = storageService;
        }

        [Route("UploadImage")]
        [HttpPost]
        public string SaveImage([FromForm] FormFileCreateRequest form)
        {
            return _fileService.SaveImage(form);
        }

        //private string SaveFile(IFormFile file)
        //{
        //    var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        //    _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
        //    return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        //}
    }
}
