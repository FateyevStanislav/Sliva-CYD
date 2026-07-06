using UnityEngine;

namespace Sliva_CYD_2.Save.Dto
{
    [System.Serializable]
    public class Vector3DTO
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;

        [Newtonsoft.Json.JsonConstructor]
        public Vector3DTO(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 ToUnityVector3()
        {
            return new Vector3(X, Y, Z);
        }
        
        public static Vector3DTO FromUnityVector3(Vector3 vector)
        {
            return new Vector3DTO(vector.x, vector.y, vector.z);
        }
    }
}