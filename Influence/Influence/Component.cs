using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influence
{
    public abstract class Component : Object
    {
        public bool enabled = true;
        public GameObject gameObject;
        public Transform transform => gameObject.transform;

        public Component(GameObject parent)
        {
            gameObject = parent;
        }

        public abstract void Render();
    }
}
