using System.Collections.Immutable;
using TiendaIna.Core.Extensions;

namespace TiendaIna.Core {
    public static class ListExtensions {
        public static void RestoreFromList<T>(this List<T> list, Func<T, bool> predicate, List<T> originalList) {
            if (list is null) throw new ArgumentNullException(nameof(list));
            if (originalList is null) throw new ArgumentNullException(nameof(originalList));
            var originalElement = originalList.SingleOrDefault(predicate);
            if (originalElement is null) return;
            var ix = list.RemoveBy(new Predicate<T>(predicate));

            if (ix >= 0)
                list.Insert(ix, originalElement.DeepClone());
            else
                list.Add(originalElement.DeepClone());
        }

        public static int RemoveBy<T>(this List<T> list, Predicate<T> predicate) {
            if (list is null) throw new ArgumentNullException(nameof(list));
            var ix = list.FindIndex(predicate);
            if (ix < 0) return ix;
            list.RemoveAt(ix);
            return ix;
        }
    }
}
