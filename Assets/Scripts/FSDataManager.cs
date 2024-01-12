using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace FruitSellingShop
{
    public class FSDataManager : MonoBehaviour
    {
        public static FSDataManager instance;

        private void Awake()
        {
            instance = this;
        }
        internal void SaveData(FSData data)
        {
            string dataToSave = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "dataFile.json", dataToSave);
        }
        internal FSData LoadData()
        {
            FSData data = new FSData();
            if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "dataFile.json")) ;
            {
                string dataString = File.ReadAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "dataFile.json");
                data = JsonUtility.FromJson<FSData>(dataString);
            }
            return data;
        }
    }
}
