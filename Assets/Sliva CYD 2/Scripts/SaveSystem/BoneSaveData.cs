using Sliva_CYD_2.Save.Dto;

namespace Sliva_CYD_2.Save
{
    [System.Serializable]
    public class BoneSaveData
    {
        public readonly Vector3DTO Position;
        public readonly QuaternionDTO Rotation;

        [Newtonsoft.Json.JsonConstructor]
        public BoneSaveData(Vector3DTO position, QuaternionDTO rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}