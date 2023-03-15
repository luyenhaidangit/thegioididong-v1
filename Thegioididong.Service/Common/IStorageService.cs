using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Plugins.File;

namespace Thegioididong.Service.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        string SaveFile(FormFileCreateRequest file);

        Task DeleteFileAsync(string fileName);

        string SaveImage(FormFileCreateRequest form);
    }
}
