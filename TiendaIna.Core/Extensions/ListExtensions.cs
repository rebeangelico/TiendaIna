namespace TiendaIna.Core {
    public static class ListExtensions {
        public static void RestoreFromList<T>(this List<T> list, Func<T, bool> predicate, List<T> originalList) {
            if (list is null) throw new ArgumentNullException(nameof(list));
            if (originalList is null) throw new ArgumentNullException(nameof(originalList));
            var originalElement = originalList.SingleOrDefault(predicate);
            if (originalElement is null) return;
            var ix = list.Remove(new Predicate<T>(predicate));

           /* falta agregarlo luego de removerlo, eso es restore
            * if (ix >= 0) {
                list[ix] = originalElement;
            } else {
                list.Add(originalElement);
            }*/

        }

        public static int Remove<T>(this List<T> list, Predicate<T> predicate) {
            if (list is null) throw new ArgumentNullException(nameof(list));
            var ix = list.FindIndex(predicate);
            if (ix < 0) return -1;
            list.RemoveAt(ix);
            return ix;
        }
    }
}
