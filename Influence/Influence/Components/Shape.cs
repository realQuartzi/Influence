using System.Drawing;

namespace Influence
{
    public class Shape : Component
    {
        public Vector2 size = new Vector2();
        public Color color = Color.White;

        public Shape(int sizeX, int sizeY)
        {
            size.x = sizeX;
            size.y = sizeY;
        }
        public Shape(Vector2 size)
        {
            this.size = size;
        }
        public Shape(int sizeX, int sizeY, Color color)
        {
            size.x = sizeX;
            size.y = sizeY;

            this.color = color;
        }
        public Shape(Vector2 size, Color color)
        {
            this.size = size;
            this.color = color;
        }

        public override void Render(Graphics graphics)
        {
            if (!enabled)
                return;

            graphics.FillRectangle(new SolidBrush(color),
                transform.position.x, transform.position.y,
                size.x * transform.scale.x, size.y * transform.scale.y);
        }
    }
}
