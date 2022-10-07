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

        bool active;
        public bool activeSelf => active;
        public void SetActive(bool value) => active = value;

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
