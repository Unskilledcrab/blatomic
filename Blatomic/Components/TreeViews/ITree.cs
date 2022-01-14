namespace Blatomic.Components.TreeViews
{
    public interface ITree<TData>
    {
        public List<ITreeItem<TData>> Children { get; set; }
    }

    public interface ITreeItem<TData> : ITree<TData>
    {
        public ITreeItem<TData> Parent { get; set; }
        public TData Data { get; set; }
    }

    public class Tree<TData> : ITreeItem<TData>
    {
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public ITreeItem<TData>? Parent { get; set; } = null;
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public TData? Data { get; set; } = default;
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public List<ITreeItem<TData>> Children { get; set; } = new();
    }

    public class TreeItem<TData> : ITreeItem<TData>
    {
        public TreeItem(TData data)
        {
            Data = data;
        }
        public TreeItem(TData data, ITreeItem<TData> parent)
        {
            Data = data;
            Parent = parent;
        }

#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public ITreeItem<TData>? Parent { get; set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public TData Data { get; set; }
        public List<ITreeItem<TData>> Children { get; set; } = new();
    }

    public static class TreeBuilder
    {
        public static ITreeItem<TData> Create<TData>()
        {
            return new Tree<TData>();
        }

        public static ITreeItem<TData> Build<TData>(this ITreeItem<TData> tree)
        {
            return GoToRoot(tree);
        }

        public static ITreeItem<TData> GoToRoot<TData>(this ITreeItem<TData> tree)
        {
            while (tree.GoToParent() != null)
            {
                tree = tree.GoToParent();
            }
            return tree;
        }
    }

    public static class TreeExtensions
    {
        public static bool HasChildren<TData>(this ITree<TData> tree)
        {
            return tree.Children.Any();
        }

        public static ITreeItem<TData> AddChild<TData>(this ITreeItem<TData> tree, TData child)
        {
            tree.Children.Add(new TreeItem<TData>(child, tree));
            return tree;
        }

        public static ITreeItem<TData> AddGoToChild<TData>(this ITreeItem<TData> tree, TData child)
        {
            var newChild = new TreeItem<TData>(child, tree);
            tree.Children.Add(newChild);
            return newChild;
        }

        public static ITreeItem<TData> GoTo<TData>(this ITreeItem<TData> tree)
        {
            return tree.Children.Last();
        }

        public static ITreeItem<TData> AddChildGoToParent<TData>(this ITreeItem<TData> tree, TData child)
        {
            var newChild = new TreeItem<TData>(child, tree);
            tree.Children.Add(newChild);
            return tree.Parent;
        }

        public static ITreeItem<TData> GoToParent<TData>(this ITreeItem<TData> tree)
        {            
            return tree.Parent;
        }

        public static IEnumerable<ITreeItem<TData>> GetChildrenItems<TData>(this ITree<TData> tree)
        {
            if (tree.Children == null)
            {
                yield break;
            }

            foreach (var child in tree.Children)
            {
                yield return child;
            }
        }

        public static IEnumerable<ITreeItem<TData>> GetAllChildren<TData>(this ITree<TData> tree)
        {
            foreach (var child in tree.GetChildrenItems())
            {
                yield return child;

                foreach (var grandChild in child.GetAllChildren())
                {
                    yield return grandChild;
                }
            }
        }
    }
}
