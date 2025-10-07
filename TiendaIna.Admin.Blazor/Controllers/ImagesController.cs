using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TiendaIna.Core.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiendaIna.Admin.Blazor.Controllers;

[Route("[controller]")]
public class ImagesController : ControllerBase {

    private readonly IImagesService _imagesService;

    public ImagesController(IImagesService imagesService) {
        _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, [FromQuery]char? size = null) {
        var result = await _imagesService.GetBytesAsync(id);
        return File(fileContents: result.Value.Item1, contentType: result.Value.Item2);
    }

}
