using UnityEngine;

namespace Sliva_CYD_2.Save.Dto
{
    [System.Serializable]
    public class QuaternionDTO
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
        public readonly float W;

        [Newtonsoft.Json.JsonConstructor]
        public QuaternionDTO(float x, float y, float z,  float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quaternion ToUnityQuaternion()
        {
            return new Quaternion(X, Y, Z, W);
        }
        
        public static QuaternionDTO FromUnityQuaternion(Quaternion quaternion)
        {
            return new QuaternionDTO(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}