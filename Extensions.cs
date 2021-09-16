using Godot;

namespace StateMachineDemo
{
    public static class Extensions
    {
        public static T GetNodeInParent<T>(this Node node) where T : Node
        {
            var currentNode = node.GetParent();
            do
            {
                if (currentNode is T node1) return node1;

                var child = currentNode.GetNodeInChildren<T>();
                if (child is T c) return c;
                currentNode = currentNode.GetParent();
            } while (currentNode != null);

            return null;
        }
        
        public static T GetNodeInChildren<T>(this Node node) where T : Node
        {
            return FindChild<T>(node);
        }
        
        private static T FindChild<T>(Node parent) where T : Node
        {
            var childCount = parent.GetChildCount();

            if (parent is T node1) return node1;

            if (childCount <= 0) return null;
            for (var i = 0; i < childCount; i++)
            {
                var node = FindChild<T>(parent.GetChild(i));

                if (node != null) return node;
            }

            return null;
        }
    }
}