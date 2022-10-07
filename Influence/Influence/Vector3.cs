using System;

namespace Influence
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #region Quick Returns

        /// <summary>
        /// Returns Vector3 : (0,0)
        /// </summary>
        public static Vector3 zero => new Vector3(0, 0,0);

        /// <summary>
        /// Returns Vector3 : (1,1)
        /// </summary>
        public static Vector3 one => new Vector3(1, 1,1);

        /// <summary>
        /// Returns Vector3 : (0,1)
        /// </summary>
        public static Vector3 forward => new Vector3(0, 0, 1);

        /// <summary>
        /// Returns Vector3 : (0,-1)
        /// </summary>
        public static Vector3 back => new Vector3(0, 0, -1);

        /// <summary>
        /// Returns Vector3 : (0,1)
        /// </summary>
        public static Vector3 up => new Vector3(0, 1,0);

        /// <summary>
        /// Returns Vector3 : (0,-1)
        /// </summary>
        public static Vector3 down => new Vector3(0, -1,0);

        /// <summary>
        /// Returns Vector3 : (-1,0)
        /// </summary>
        public static Vector3 left => new Vector3(-1, 0,0);

        /// <summary>
        /// Returns Vector3 : (1,0)
        /// </summary>
        public static Vector3 right => new Vector3(1, 0,0);

        #endregion

        #region Operators

        public static Vector3 operator +(Vector3 a, Vector3 b)
            => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);

        public static Vector3 operator -(Vector3 a, Vector3 b)
            => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static Vector3 operator *(Vector3 a, Vector3 b)
            => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator *(Vector3 a, float b)
            => new Vector3(a.x * b, a.y * b, a.z * b);

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            if (b.x == 0 || b.y == 0 || b.z == 0)
                throw new DivideByZeroException();

            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            if(b == 0)
                throw new DivideByZeroException();

            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        #endregion

    }
}
