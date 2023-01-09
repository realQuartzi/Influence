using Influence.Primitive;

namespace Influence
{
    public static class Gizmos
    {
        public static void DrawLine(this ApplicationWindow window, Vector2 pos1, Vector2 pos2)
        {
            Draw.DrawLine(window, pos1, pos2);
        }

        public static void DrawLine(this ApplicationWindow window, Vector2 pos1, Vector2 pos2, Color color)
        {
            Draw.DrawLine(window, pos1, pos2, color);
        }

        public static void DrawSquare(this ApplicationWindow window, Vector2 position, Vector2 size ,Color color)
        {
            Vector2Int bottomRight = new Vector2Int(position + (size / 2));
            Vector2Int topLeft = new Vector2Int(position - (size / 2));

            Vector2Int bottomLeft = new Vector2Int(topLeft.x, bottomRight.y);
            Vector2Int topRight = new Vector2Int(bottomRight.x, topLeft.y);

            Draw.DrawLine(window, topLeft, topRight, color);
            Draw.DrawLine(window, topLeft, bottomLeft, color);
            Draw.DrawLine(window, bottomRight, topRight, color);
            Draw.DrawLine(window, bottomRight, bottomLeft, color);
        }

    }
}
