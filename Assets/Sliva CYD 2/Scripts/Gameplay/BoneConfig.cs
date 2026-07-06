using UnityEngine;

namespace Sliva_CYD_2.Gameplay
{
    [CreateAssetMenu(fileName = "NewBoneConfig", menuName = "Sliva CYD 2/Bone Config")]
    public class BoneConfig : ScriptableObject
    {
        [Header("Visual Settings")]
        public Color BaseColor = Color.white;
    }
}