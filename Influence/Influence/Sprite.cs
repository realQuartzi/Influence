using System.Drawing;

namespace Influence
{
    public class Sprite : GameObject
    {
        public string directory;
        public Bitmap sprite;

        public Sprite(string spriteDirectory)
        {
            directory = spriteDirectory;
            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            sprite = new Bitmap(tmp);
        }

        public Sprite(string spriteDirectory, Vector3 position)
        {
            transform.position = position;

            directory = spriteDirectory;
            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            sprite = new Bitmap(tmp);
        }

        public Sprite(string spriteDirectory, Vector3 position, Vector3 scale)
        {
            transform.position = position;
            transform.scale = scale;

            directory = spriteDirectory;
            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            sprite = new Bitmap(tmp);
        }
    }
}
