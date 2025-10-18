using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ImagesDbRepo : CrudDbRepoBase<Image, int>, IImagesRepo {
    public ImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }
}

