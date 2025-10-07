using System.Collections.ObjectModel;

namespace TiendaIna.Core {
    public static class CollectionExtensions {
        public static void Remove<T>(this Collection<T> col, Func<T, bool> predicate) {
            if (col is null) throw new ArgumentNullException(nameof(col));
            T? obj =  col.FirstOrDefault(predicate);
            if (obj is null) return;
            col.Remove(obj);
        }
    }
}
