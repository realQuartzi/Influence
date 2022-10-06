
namespace Influence
{
    public class Sprite
    {
        public Vector2 position;
        public Vector2 scale;

        public string name = "Sprite";
        public string tag = "Default";

        public Sprite(int positionX, int positionY, float scaleX, float scaleY)
        {
            this.position = new Vector2(positionX, positionY);
            this.scale = new Vector2(scaleX, scaleY);
        }
        public Sprite(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }
        public Sprite(Vector2 position, Vector2 scale, string tag)
        {
            this.position = position;
            this.scale = scale;
            this.tag = tag;
        }

    }
}
