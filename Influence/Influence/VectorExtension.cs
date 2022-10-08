
namespace Influence
{
    static class VectorExtension
    {
        public static Vector2Int ToInt(this Vector2 a)
        {
            return new Vector2Int((int)a.x, (int)a.y);
        }

        public static Vector2 ToFloat(this Vector2Int a)
        {
            return new Vector2(a.x, a.y);
        }
    }
}
