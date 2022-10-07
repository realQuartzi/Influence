using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influence
{
    public class GameObject : Object
    {
        public string tag = "Default";
        public int layer = 0;
        public Transform transform = new Transform();

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
