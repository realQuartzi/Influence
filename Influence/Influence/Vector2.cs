using System;

namespace Influence
{
    public class Vector2
    {
        public float x;
        public float y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(Vector2Int vector)
        {
            this.x = vector.x;
            this.y = vector.y;
        }
        public Vector2(Vector3 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
        }

        #region Quick Returns

        /// <summary>
        /// Returns Vector2 : (0,0)
        /// </summary>
        public static Vector2 zero => new Vector2(0, 0);

        /// <summary>
        /// Returns Vector2 : (1,1)
        /// </summary>
        public static Vector2 one => new Vector2(1, 1);

        /// <summary>
        /// Returns Vector2 : (0,1)
        /// </summary>
        public static Vector2 up => new Vector2(0, 1);

        /// <summary>
        /// Returns Vector2 : (0,-1)
        /// </summary>
        public static Vector2 down => new Vector2(0, -1);

        /// <summary>
        /// Returns Vector2 : (-1,0)
        /// </summary>
        public static Vector2 left => new Vector2(-1, 0);

        /// <summary>
        /// Returns Vector2 : (1,0)
        /// </summary>
        public static Vector2 right => new Vector2(1, 0);

        #endregion

        #region Operators

        public static Vector2 operator +(Vector2 a, Vector2 b)
            => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator +(Vector2 a, float b)
            => new Vector2(a.x + b, a.y + b);

        public static Vector2 operator -(Vector2 a, Vector2 b)
            => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator -(Vector2 a, float b)
            => new Vector2(a.x - b, a.y - b);

        public static Vector2 operator *(Vector2 a, Vector2 b)
            => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator *(Vector2 a, float b)
            => new Vector2(a.x * b, a.y * b);

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            if (b.x == 0 || b.y == 0)
                throw new DivideByZeroException();

            return new Vector2(a.x / b.x, a.y / b.y);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            if(b == 0)
                throw new DivideByZeroException();

            return new Vector2(a.x / b, a.y / b);
        }

        public static bool operator >(Vector2 a, Vector2 b)
        {
            if (a.x > b.x || a.y > b.y)
                return true;

            return false;
        }

        public static bool operator >=(Vector2 a, Vector2 b)
        {
            if (a.x >= b.x || a.y >= b.y)
                return true;

            return false;
        }

        public static bool operator <(Vector2 a, Vector2 b)
        {
            if (a.x < b.x || a.y < b.y)
                return true;

            return false;
        }

        public static bool operator <=(Vector2 a, Vector2 b)
        {
            if (a.x <= b.x || a.y <= b.y)
                return true;

            return false;
        }

        #endregion

    }
}
