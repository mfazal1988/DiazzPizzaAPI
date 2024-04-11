using DPizza.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class FileController(IFileManagerService fileManagerService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetFile(string name)
        {
            var bytes = await fileManagerService.Download(name);

            return File(bytes, MediaTypeNames.Application.Octet, name);
        }
    }
}