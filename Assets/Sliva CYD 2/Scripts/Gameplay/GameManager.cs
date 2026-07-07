using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sliva_CYD_2.Save;

namespace Sliva_CYD_2.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoneController bonePrefab;
        [SerializeField] private Transform spawnPoint;
        
        private readonly List<BoneController> activeBones = new();

        private void Start()
        {
            if (SaveFlagKeeper.Instance.ShouldLoadGame)
            {
                LoadSavedBones();
                SaveFlagKeeper.Instance.ShouldLoadGame = false;
            }
            else
            {
                ThrowBones();
            }
        }

        public void ThrowBones()
        {
            foreach (var bone in activeBones.Where(bone => bone != null))
                Destroy(bone.gameObject);
            activeBones.Clear();

            for (int i = 0; i < 2; i++)
            {
                var bone = Instantiate(bonePrefab, spawnPoint.position, Quaternion.identity);
                
                var rb = bone.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), ForceMode.Impulse);
                }
                
                activeBones.Add(bone);
            }
        }

        public void SaveCurrentState()
        {
            var saveData = activeBones
                .Where(b => b != null)
                .Select(b => b.GetSaveData())
                .ToList();
            
            SaveSystem.SaveBones(saveData);
        }

        private void LoadSavedBones()
        {
            var savedBonesData = SaveSystem.LoadBones();
    
            if (savedBonesData == null || savedBonesData.Count == 0) 
            {
                ThrowBones();
                return;
            }
            
            foreach (var data in savedBonesData)
            {
                var bone = Instantiate(bonePrefab, Vector3.zero, Quaternion.identity);
                bone.ApplySaveData(data);
                activeBones.Add(bone);
            }
        }
        
        public void RequestLoadGame()
        {
            SaveFlagKeeper.Instance.ShouldLoadGame = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}