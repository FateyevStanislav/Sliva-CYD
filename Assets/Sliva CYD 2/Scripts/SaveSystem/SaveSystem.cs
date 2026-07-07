using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Sliva_CYD_2.Save
{
    public static class SaveSystem
    {
        private const string SAVE_FILE_NAME = "bones_save.json";
        
        public static void SaveBones(List<BoneSaveData> bones)
        {
            var json = JsonConvert.SerializeObject(bones, Formatting.Indented);
            var path = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);

            File.WriteAllText(path, json);
        }
        
        public static List<BoneSaveData> LoadBones()
        {
            var path = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
            
            return File.Exists(path) 
                ? JsonConvert.DeserializeObject<List<BoneSaveData>>(File.ReadAllText(path)) 
                : null;
        }
    }
}