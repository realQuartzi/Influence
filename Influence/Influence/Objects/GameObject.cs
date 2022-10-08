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

        public T GetComponent<T>()
        {
            foreach(Component component in components)
            {
                if (component is T t)
                {
                    return t;
                }

            }
            return default(T);
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

        public void DestroySelf()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is Collider collider)
                {
                    Influence.UnRegisterCollider(collider);
                }
            }

            Influence.UnRegisterGameObject(this);
         }


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
