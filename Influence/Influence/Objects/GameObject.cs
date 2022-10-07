using System.Collections.Generic;

namespace Influence
{
    public class GameObject : Object
    {
        public string tag = "Default";
        public int layer = 0;
        public Transform transform = new Transform();

        List<Component> components = new List<Component>();
        public List<Component> Components => components;

        public Component AddComponent(Component component)
        {
            if(component is Component c)
            {
                Debug.Log("Adding Component");
                c.gameObject = this;
                components.Add(c);
                return c;
            }

            return null;
        }
        public Component GetComponent(Component component)
        {
            foreach (Component comp in components)
            {
                if (comp.Equals(component))
                    return comp;
            }

            return null;
        }

        public GameObject()
        {
            Influence.RegisterGameObject(this);
        }
        public GameObject(string name)
        {
            this.name = name;
            Influence.RegisterGameObject(this);
        }


        bool active;
        public bool activeSelf => active;
        public void SetActive(bool value) => active = value;

        public void DestroySelf() => Influence.UnRegisterGameObject(this);

        public override bool Equals(object obj)
        {
            return obj is GameObject @object
                && name == @object.name
                && tag == @object.tag
                && layer == @object.layer;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
