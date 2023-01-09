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
        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(Vector2 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = 0;
        }
        public Vector3(Vector2Int vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = 0;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }

        public float magnitude => (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        public Vector3 normalized => this / magnitude;

        public void Normalize()
        {
            Vector3 n = normalized;

            this.x = n.x;
            this.y = n.y;
            this.z = n.z;
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            Vector3 dif = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
            return (float)Math.Sqrt(Math.Pow(dif.x, 2f) + Math.Pow(dif.y, 2f) + Math.Pow(dif.z, 2f));
        }

        #region Quick Returns

        /// <summary>
        /// Returns Vector3 : (0,0)
        /// </summary>
        public static Vector3 zero => new Vector3(0, 0, 0);

        /// <summary>
        /// Returns Vector3 : (1,1)
        /// </summary>
        public static Vector3 one => new Vector3(1, 1, 1);

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
        public static Vector3 up => new Vector3(0, 1, 0);

        /// <summary>
        /// Returns Vector3 : (0,-1)
        /// </summary>
        public static Vector3 down => new Vector3(0, -1, 0);

        /// <summary>
        /// Returns Vector3 : (-1,0)
        /// </summary>
        public static Vector3 left => new Vector3(-1, 0, 0);

        /// <summary>
        /// Returns Vector3 : (1,0)
        /// </summary>
        public static Vector3 right => new Vector3(1, 0, 0);

        #endregion

        #region Operators

        public static Vector3 operator +(Vector3 a, Vector3 b)
            => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator +(Vector3 a, float b)
            => new Vector3(a.x + b, a.y + b, a.z + b);

        public static Vector3 operator -(Vector3 a, Vector3 b)
            => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator -(Vector3 a, float b)
            => new Vector3(a.x - b, a.y - b, a.z - b);

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
            if (b == 0)
                throw new DivideByZeroException();

            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        public static bool operator >(Vector3 a, Vector3 b)
        {
            if (a.x > b.x || a.y > b.y || a.z > b.z)
                return true;

            return false;
        }

        public static bool operator >=(Vector3 a, Vector3 b)
        {
            if (a.x >= b.x || a.y >= b.y || a.z >= b.z)
                return true;

            return false;
        }

        public static bool operator <(Vector3 a, Vector3 b)
        {
            if (a.x < b.x || a.y < b.y || a.z < b.z)
                return true;

            return false;
        }

        public static bool operator <=(Vector3 a, Vector3 b)
        {
            if (a.x <= b.x || a.y <= b.y || a.z <= b.z)
                return true;

            return false;
        }

        #endregion

    }
}
