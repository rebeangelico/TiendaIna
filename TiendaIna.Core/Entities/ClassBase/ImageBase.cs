namespace TiendaIna.Core.Entities.ClassBase {
    public abstract class ImageBase<TKey, TEntity> where TKey : notnull {
        public byte[]? Data { get; set; }
        public string? CdnUrl { get; set; }
        public byte[]? SmallData { get; set; }
        public string? SmallCdnUrl { get; set; }
        public string? MimeType { get; set; }

    }
}
