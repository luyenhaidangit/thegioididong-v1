using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Plugins.File
{
    public class FormFileCreateRequest
    {
        public IFormFile File { get; set; }

        public string? Folder { get; set; }
    }
}
