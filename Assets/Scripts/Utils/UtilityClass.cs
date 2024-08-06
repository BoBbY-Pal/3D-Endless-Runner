using UnityEngine;

namespace Utils
{
    public static class UtilityClass
    {
        public static Vector3 ScreenToWorld(Camera camera, Vector2 position)
        {
            return camera.ScreenToWorldPoint(new Vector3(position.x, position.y, camera.nearClipPlane));
        }
    }
}