using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameProgramming2D
{
    public static class SaveSystem
    {
        private const string SaveFileName = "save.dat";
        
        public static string SaveFilePath
        {  get
            {
                return Path.Combine(Application.persistentDataPath, SaveFileName);
            }
        }
        
        public static void Save(object objectToSave)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, objectToSave);
            File.WriteAllBytes(SaveFilePath, ms.GetBuffer());
        }
        
        public static T Load<T>() where T : class
        {
            if(File.Exists(SaveFilePath))
            {
                byte[] data = File.ReadAllBytes(SaveFilePath);
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(data);
                object saveData = bf.Deserialize(ms);

                return (T)saveData;
            }

            return default(T);
        }
        
        public static bool DoesSaveExist()
        {
            return File.Exists(SaveFilePath);
        }   
    }
}
