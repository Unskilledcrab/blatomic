namespace Blatomic.Extensions
{
    public interface IHierarchy<TKey>
    {
        public TKey Id { get; set; }
        public TKey ParentId { get; set; }
    }

    public interface IHierarchyNode<TData>
    {
        public IHierarchyNode<TData>? Parent { get; set; }
        public IList<IHierarchyNode<TData>> Children { get; set; }
        public TData? Data { get; set; }
    }

    public class HierarchyNode<TData> : IHierarchyNode<TData>
    {
        public IHierarchyNode<TData>? Parent { get; set; }
        public IList<IHierarchyNode<TData>> Children { get; set; } = new List<IHierarchyNode<TData>>();
        public TData? Data { get; set; }
    }

    public static class HierarchyExtensions
    {
        public static IEnumerable<THierarchyModel> ToHierarchy<THierarchyModel, TData, TKey>(this IEnumerable<TData> flatList, Func<TData, TKey> idSelector, Func<TData, TKey?> parentIdSelector)
            where THierarchyModel : IHierarchyNode<TData>, new()
        {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
            var lookup = flatList.Where(item => item is not null)
                                                            .Select(f => new THierarchyModel { Data = f })
                                                            .ToDictionary(h => idSelector(h.Data));
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
#pragma warning restore CS8604 // Possible null reference argument.

            if (lookup is null || lookup.Count == 0)
            {
                yield break;
            }

            foreach (var item in lookup.Values)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                var parentId = parentIdSelector(item.Data);
#pragma warning restore CS8604 // Possible null reference argument.
                if (parentId is null || !lookup.TryGetValue(parentId, out var parent))
                {
                    yield return item;
                    continue;
                }

                parent.Children.Add(item);
                item.Parent = parent;
            }
        }

        public static IEnumerable<IHierarchyNode<TData>> ToHierarchy<TData, TKey>(this IEnumerable<TData> flatList, Func<TData, TKey> idSelector, Func<TData, TKey?> parentIdSelector)
        {
            return flatList.ToHierarchy<HierarchyNode<TData>, TData, TKey>(idSelector, parentIdSelector);
        }

        public static IEnumerable<IHierarchyNode<TData>> ToHierarchy<TData, TKey>(this IEnumerable<TData> flatList)
            where TData : IHierarchy<TKey>
        {
            return flatList.ToHierarchy<HierarchyNode<TData>, TData, TKey>(f => f.Id, f => f.ParentId);
        }
    }
}
