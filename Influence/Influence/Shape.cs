
using System.Drawing;

namespace Influence
{
    public class Shape : GameObject
    {
        public Vector2 size;
        public Color color = Color.White;

        public Shape(int sizeX, int sizeY, int positionX, int positionY, float scaleX, float scaleY)
        {
            size.x = sizeX;
            size.y = sizeY;

            transform.position = new Vector3(positionX, positionY, 0);
            transform.scale = new Vector3(scaleX, scaleY, 1);
        }
        public Shape(int sizeX, int sizeY, int positionX, int positionY)
        {
            size.x = sizeX;
            size.y = sizeY;

            transform.position = new Vector3(positionX, positionY, 0);
            transform.scale = Vector3.one;
        }

        public Shape(Vector2 size, Vector3 position)
        {
            this.size = size;
            transform.position = position;
            transform.scale = Vector3.one;
        }
        public Shape(Vector2 size, Vector3 position, Vector3 scale)
        {
            this.size = size;
            transform.position = position;
            transform.scale = scale;
        }
        public Shape(Vector2 size, Vector3 position,  Color color)
        {
            this.size = size;
            transform.position = position;
            transform.scale = Vector3.one;
            this.color = color;
        }
        public Shape(Vector2 size, Vector3 position, Vector3 scale, Color color)
        {
            this.size = size;
            transform.position = position;
            transform.scale = scale;
            this.color = color;
        }
    }
}
