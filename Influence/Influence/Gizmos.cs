using System.Drawing;

namespace Influence
{
    public static class Gizmos
    {
        public static void DrawLine(this Graphics graphics, Vector2Int pos1, Vector2Int pos2)
        {
            Pen pen = new Pen(Color.Red);
            graphics.DrawLine(pen, new Point(pos1.x, pos1.y), new Point(pos2.x, pos2.y));
        }
        public static void DrawLine(this Graphics graphics, Vector2Int pos1, Vector2Int pos2, Color color)
        {
            Pen pen = new Pen(color);
            graphics.DrawLine(pen, new Point(pos1.x, pos1.y), new Point(pos2.x, pos2.y));
        }

        public static void DrawSquare(this Graphics graphics, Vector3 position, Vector3 size)
        {
            Vector2Int topLeft = new Vector2Int(position);
            Vector2Int bottomRight = new Vector2Int(position + size);

            Vector2Int bottomLeft = new Vector2Int(topLeft.x, bottomRight.y);
            Vector2Int topRight = new Vector2Int(bottomRight.x, topLeft.y);

            graphics.DrawLine(topLeft, topRight);
            graphics.DrawLine(topLeft, bottomLeft);
            graphics.DrawLine(bottomRight, topRight);
            graphics.DrawLine(bottomRight, bottomLeft);
        }
        public static void DrawSquare(this Graphics graphics, Vector3 position, Vector3 size, Color color)
        {
            Vector2Int topLeft = new Vector2Int(position);
            Vector2Int bottomRight = new Vector2Int(position + size);

            Vector2Int bottomLeft = new Vector2Int(topLeft.x, bottomRight.y);
            Vector2Int topRight = new Vector2Int(bottomRight.x, topLeft.y);

            graphics.DrawLine(topLeft, topRight, color);
            graphics.DrawLine(topLeft, bottomLeft, color);
            graphics.DrawLine(bottomRight, topRight, color);
            graphics.DrawLine(bottomRight, bottomLeft, color);
        }

    }
}
