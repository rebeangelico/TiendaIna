using System.Diagnostics.CodeAnalysis;

namespace TiendaIna.Core.Extensions {
    public static class CloneHelper {
        [return: NotNullIfNotNull(nameof(obj))]
        public static T? DeepClone<T>(this T? obj) {
            return FastCloner.FastCloner.DeepClone(obj);
        }

    }
}
