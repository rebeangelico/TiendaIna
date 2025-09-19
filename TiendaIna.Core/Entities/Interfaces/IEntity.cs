namespace TiendaIna.Core.Entities {
    public interface IEntity<TKey> where TKey : notnull {
        public TKey Id { get; set; }
    }
}
