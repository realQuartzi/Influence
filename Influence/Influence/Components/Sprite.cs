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
            if (!enabled)
                return;

            graphics.DrawImage(sprite,
                transform.position.x, transform.position.y,
                sprite.Width * transform.scale.x, sprite.Height * transform.scale.y);

#if DEBUG
            Gizmos.DrawSquare(graphics, transform.position + new Vector3(sprite.Width, sprite.Height), new Vector3( sprite.Width * transform.scale.x, sprite.Height * transform.scale.y), Color.Green);
#endif
        }
    }
}
