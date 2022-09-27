using UnityEngine;

namespace CodeBase.Enemy
{
    public static class PhysicsDebug
    {
        public static void DrawDebug(Vector3 worldPos, float radius, float second)
        {
            Debug.DrawRay(worldPos, radius * Vector3.up, Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector3.down, Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector3.left, Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector3.right, Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector3.forward, Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector3.back, Color.red, second);
        }
    }
}