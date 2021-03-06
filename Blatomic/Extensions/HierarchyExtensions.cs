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
        public static IEnumerable<TData?> GetAllSiblingNodesData<TData>(this IHierarchyNode<TData> node)
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
        public static IEnumerable<TData?> GetAllChildrenNodesData<TData>(this IHierarchyNode<TData> node)
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
        public static IEnumerable<TData?> GetAllParentNodesData<TData>(this IHierarchyNode<TData> node)
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
        public static TData? GetRootNodeData<TData>(this IHierarchyNode<TData> node)
        {
            return node.GetRootNode().Data;
        }

        public static IEnumerable<IHierarchyNode<TData>> FromBranchToFlatNodeList<TData>(this IHierarchyNode<TData> node)
        {
            yield return node;
            foreach (var child in node.GetAllChildrenNodes())
            {
                yield return child;
            }
        }
        public static IEnumerable<TData?> FromBranchToFlatNodeDataList<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var hierarchyNode in node.FromBranchToFlatNodeList())
            {
                yield return hierarchyNode.Data;
            }
        }

        public static IEnumerable<IHierarchyNode<TData>> GetLeafNodes<TData>(this IHierarchyNode<TData> node)
        {
            if (node.Children is null || node.Children.Count == 0)
            {
                yield return node;
                yield break;
            }
            foreach (var child in node.Children)
            {
                foreach (var leaf in child.GetLeafNodes())
                {
                    yield return leaf;
                }
            }
        }
        public static IEnumerable<TData?> GetLeafNodesData<TData>(this IHierarchyNode<TData> node)
        {
            foreach (var leafNode in node.GetLeafNodes())
            {
                yield return leafNode.Data;
            }
        }

        public static IEnumerable<IHierarchyNode<TData>> ToFlatNodeList<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes)
        {
            foreach (var node in hierarchyNodes)
            {
                yield return node;
                foreach (var childNode in node.GetAllChildrenNodes())
                {
                    yield return childNode;
                }
            }
        }
        public static IEnumerable<TData?> ToFlatDataList<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes)
        {
            foreach (var hierarchyNode in hierarchyNodes.ToFlatNodeList())
            {
                yield return hierarchyNode.Data;
            }
        }

        public static int Count<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes)
        {            
            return Enumerable.Count(hierarchyNodes.ToFlatNodeList());
        }

        public static int Count<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes, Func<IHierarchyNode<TData>, bool> predicate)
        {
            return Enumerable.Count(hierarchyNodes.ToFlatNodeList(), predicate);
        }

        public static IEnumerable<IHierarchyNode<TData>> Except<TData>(this IEnumerable<IHierarchyNode<TData>> first, IEnumerable<IHierarchyNode<TData>> second)
        {
            return Enumerable.Except(first.ToFlatNodeList(), second.ToFlatNodeList());
        }

        public static bool All<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes, Func<IHierarchyNode<TData>, bool> predicate)
        {
            return Enumerable.All(hierarchyNodes.ToFlatNodeList(), predicate);
        }

        public static IEnumerable<IHierarchyNode<TData>> Where<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes, Func<IHierarchyNode<TData>, bool> predicate)
        {
            return Enumerable.Where(hierarchyNodes.ToFlatNodeList(), predicate);
        }

        public static IHierarchyNode<TData> First<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes, Func<IHierarchyNode<TData>, bool> predicate)
        {
            return Enumerable.First(hierarchyNodes.ToFlatNodeList(), predicate);
        }

        public static IHierarchyNode<TData>? FirstOrDefault<TData>(this IEnumerable<IHierarchyNode<TData>> hierarchyNodes, Func<IHierarchyNode<TData>, bool> predicate)
        {
            return Enumerable.FirstOrDefault(hierarchyNodes.ToFlatNodeList(), predicate);
        }

        /// <summary>
        /// Pass in a flat list with id selectors to get back a list of hierarchy nodes in the form of a hierarchy
        /// </summary>
        /// <typeparam name="THierarchyModel">The hierarchy node model that will be used</typeparam>
        /// <typeparam name="TData">The data type of the flat list</typeparam>
        /// <typeparam name="TKey">The data type of the keys for the items id and parent id</typeparam>
        /// <param name="flatList">The flat list that will be transformed to a hierarchy</param>
        /// <param name="idSelector">Returns the unique identifier for this item</param>
        /// <param name="parentIdSelector">Returns the parent id for this item</param>
        /// <returns>A hierarchical model for each item wrapped in a hierarchy node to be able to traverse the hierarchy</returns>
        private static IEnumerable<THierarchyModel> ToHierarchyInternal<THierarchyModel, TData, TKey>(this IEnumerable<TData> flatList, Func<TData, TKey> idSelector, Func<TData, TKey?> parentIdSelector)
            where THierarchyModel : IHierarchyNode<TData>, new()
        {
            var lookup = flatList.Where(item => item is not null && idSelector(item) is not null)
                                                            .Select(f => new THierarchyModel { Data = f })
                                                            .ToDictionary(h => idSelector(h.Data));

            if (lookup is null || lookup.Count == 0)
            {
                yield break;
            }

            foreach (var item in lookup.Values)
            {
                var parentId = parentIdSelector(item.Data);
                if (parentId is null || !lookup.TryGetValue(parentId, out var parent))
                {
                    yield return item;
                    continue;
                }

                parent.Children.Add(item);
                item.Parent = parent;
            }
        }
        
        public static IEnumerable<THierarchyModel> ToHierarchy<THierarchyModel, TData, TKey>(this IEnumerable<TData> flatList, Func<TData, TKey> idSelector, Func<TData, TKey?> parentIdSelector)
            where THierarchyModel : IHierarchyNode<TData>, new()
        {
            // NOTE: If we do not call ToList() here then the children will not be present in future calls
            return flatList.ToHierarchyInternal<THierarchyModel, TData, TKey>(idSelector, parentIdSelector).ToList();
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
