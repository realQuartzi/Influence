using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influence
{
    public class Transform
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale = new Vector3(1,1,1);

        public void Translate(Vector3 translation)
        {
            position += translation;
        }
        public void Translate(float x, float y, float z)
        {
            position.x += x;
            position.y += y;
            position.z += z;
        }

        public void Rotate(Vector3 rotation)
        {
            this.rotation += rotation;
        }
        public void Rotate(float x, float y, float z)
        {
            rotation.x += x;
            rotation.y += y;
            rotation.z += z;
        }
    }
}
