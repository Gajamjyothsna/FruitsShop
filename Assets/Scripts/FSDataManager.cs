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
        internal void LoadData()
        {

        }
    }
}
