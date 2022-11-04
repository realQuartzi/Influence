using System.Drawing;

namespace Influence
{
    public class Sprite : Component
    {
        public string directory;
        public Bitmap sprite;

        public Sprite(string spriteDirectory)
        {
            directory = spriteDirectory;
            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            sprite = new Bitmap(tmp);
        }

        public override void Render(Graphics graphics)
        {
            if (!enabled || transform == null)
                return;

            graphics.DrawImage(sprite,
                transform.position.x, transform.position.y,
                sprite.Width * transform.scale.x, sprite.Height * transform.scale.y);
        }
    }
}
