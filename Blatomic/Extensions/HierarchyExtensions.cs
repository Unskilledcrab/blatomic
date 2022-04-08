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
        public static IEnumerable<IHierarchyNode<TData>> GetAllSiblingNodes<TData>(this IHierarchyNode<TData> node)
        {
            if (node.Parent is null)
            {
                yield break;
            }

            foreach (var child in node.Parent.Children)
            {
                if (child != node)
                {
                    yield return child;
                }
            }
        }
        public static IEnumerable<TData> GetAllSiblingData<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var sibling in node.GetAllSiblingNodes())
            {
                yield return sibling.Data;
            }
        }

        public static IEnumerable<IHierarchyNode<TData>> GetAllChildrenNodes<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var child in node.Children)
            {
                yield return child;
                foreach (var grandChild in child.GetAllChildrenNodes())
                {
                    yield return grandChild;
                }
            }
        }
        public static IEnumerable<TData> GetAllChildrenData<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var child in node.GetAllChildrenNodes())
            {
                yield return child.Data;
            }
        }

        public static IEnumerable<IHierarchyNode<TData>> GetAllParentNodes<TData>(this IHierarchyNode<TData> node)
        {
            if (node.Parent is null)
            {
                yield break;
            }

            yield return node.Parent;
            foreach (var grandParent in node.Parent.GetAllParentNodes())
            {
                yield return grandParent;
            }
        }
        public static IEnumerable<TData> GetAllParentsData<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var parent in node.GetAllParentNodes())
            {
                yield return parent.Data;
            }
        }

        public static IHierarchyNode<TData> GetRootNode<TData>(this IHierarchyNode<TData> node)
        {
            var parentNode = node.Parent;
            while (parentNode is not null)
            {
                node = parentNode;
                parentNode = node.Parent;
            }
            return node;
        }
        public static TData GetRootNodeData<TData>(this IHierarchyNode<TData> node)
        {
            return node.GetRootNode().Data;
        }

        public static IEnumerable<IHierarchyNode<TData>> ToFlatNodeList<TData>(this IHierarchyNode<TData> node)
        {
            yield return node;
            foreach (var child in node.GetAllChildrenNodes())
            {
                yield return child;
            }
        }
        public static IEnumerable<TData> ToFlatDataList<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var hierarchyNode in node.ToFlatNodeList())
            {
                yield return hierarchyNode.Data;
            }
        }

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
