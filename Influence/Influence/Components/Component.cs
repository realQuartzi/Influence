using System.Drawing;

namespace Influence
{
    public abstract class Component : Object
    {
        public bool enabled = true;
        public GameObject gameObject;
        public Transform transform => gameObject.transform;

        public Component() { }

        public Component(GameObject parent)
        {
            gameObject = parent;
        }

        public abstract void Render(Graphics graphics);
    }
}
