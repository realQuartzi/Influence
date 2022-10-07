

namespace Influence
{
    public class Object
    {
        public string name;

        public override string ToString() => name;

        public override bool Equals(object obj) => obj is Object @object && name == @object.name;

        public override int GetHashCode() => name.GetHashCode();

        #region Operators

        public static bool operator !=(Object a, Object b) => !a.Equals(b);

        public static bool operator ==(Object a, Object b) => a.Equals(b);

        #endregion
    }
}
