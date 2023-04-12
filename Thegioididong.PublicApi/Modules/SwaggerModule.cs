using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Thegioididong.PublicApi.Modules
{
    public class SwaggerModule : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Đổi đường dẫn của API sang chữ thường
            foreach (var path in swaggerDoc.Paths.ToList())
            {
                var lowercasePath = path.Key.ToLowerInvariant();
                if (lowercasePath != path.Key)
                {
                    swaggerDoc.Paths[lowercasePath] = path.Value;
                    swaggerDoc.Paths.Remove(path.Key);
                }
            }
        }
    }
}
