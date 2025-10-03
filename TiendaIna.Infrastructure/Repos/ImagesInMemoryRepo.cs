using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ImagesInMemoryRepo : InMemoryRepoBase<Image, int>, IImagesRepo {
    public ImagesInMemoryRepo(IInMemoryImagesStore imagesStore) : base(imagesStore) { }

}