using UnityEngine;
using Sliva_CYD_2.Save;
using Sliva_CYD_2.Save.Dto;

namespace Sliva_CYD_2.Gameplay
{
    public class BoneController : MonoBehaviour
    {
        [SerializeField] private BoneConfig config;
        [SerializeField] private Renderer boneRenderer;

        private void Awake()
        {
            boneRenderer ??= GetComponent<Renderer>();
            
            if (config != null)
            {
                GetComponent<Renderer>().sharedMaterial.color = config.BaseColor;
            }
        }

        public BoneSaveData GetSaveData()
        {
            var position = Vector3DTO.FromUnityVector3(transform.position);
            var rotation = QuaternionDTO.FromUnityQuaternion(transform.rotation);
            
            return new BoneSaveData(position, rotation);
        }

        public void ApplySaveData(BoneSaveData data)
        {
            if (data == null)
                return;
            
            var position = data.Position.ToUnityVector3();
            var rotation = data.Rotation.ToUnityQuaternion();
            
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}