using UnityEngine;

namespace Game.Tools
{
    public static class VectorTools
    {
        public static Vector3 GetPermissibleVector(Vector3 movingDementions, Vector3 vector)
        {
            var result = new Vector3();

            if (movingDementions.x != 0) result.x = vector.x;
            if (movingDementions.y != 0) result.y = vector.y;
            if (movingDementions.z != 0) result.z = vector.z;

            return result;
        }
    }
}
