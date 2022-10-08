using System.Drawing;

namespace Influence
{
    public class Collider : Component
    {
        public Vector3 offset = new Vector3(0, 0);
        public Vector2 size = Vector2.one;

        public Vector3 center => transform.position + offset;
        public Vector2 trueSize => size * new Vector2(transform.scale);

        public Collider(Vector2 size)
        {
            this.size = size;
        }
        public Collider(Vector2 size, Vector3 offset)
        {
            this.size = size;
            this.offset = offset;
        }

        public static bool IsColliding(Collider a, Collider b)
        {
            if (a.center.x + a.trueSize.x < b.center.x)
                return false;
            else if (a.center.x > b.center.x + b.trueSize.x)
                return false;

            if (a.center.y + a.trueSize.y < b.center.y)
                return false;
            else if (a.center.y > b.center.y + b.trueSize.y)
                return false;

            return true;
        }

        public override void Render(Graphics graphics)
        {
            #if DEBUG
                Gizmos.DrawSquare(graphics, center, new Vector3(trueSize), Color.Green);
            #endif
        }
    }
}
