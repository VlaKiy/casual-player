using UnityEngine;

namespace Game.Utils
{
    public static class TransformUtils
    {
        public static void DetachAllChildren(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.parent = null;
            }
        }
    }
}
