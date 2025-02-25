using System.IO;
using UnityEngine;

namespace _Project.Source.SaveLoadSystems
{
    public class JSONSaveLoadSystem : ISaveLoadSystem
    {
        private readonly string _savePath = Application.persistentDataPath;
        private readonly string _fileName = "GameData";

        public void Save<T>(T data)
        {
            string json = JsonUtility.ToJson(data, true);   
            string fullPath = Path.Combine(_savePath, _fileName);

            File.WriteAllText(fullPath, json);
            Debug.Log($"Data saved to {fullPath}");
        }

        public T Load<T>()
        {
            string fullPath = Path.Combine(_savePath, _fileName);

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                Debug.Log($"Data loaded from {fullPath}");
                return JsonUtility.FromJson<T>(json);
            }

            Debug.LogWarning($"Save file not found: {fullPath}");
            return default;
        }

        public bool SaveExists()
        {
            return File.Exists(Path.Combine(_savePath, _fileName));
        }
    }
}