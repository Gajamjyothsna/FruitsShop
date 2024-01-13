using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace FruitSellingShop
{
    public class FSDataManager : MonoBehaviour
    {
        public static FSDataManager instance;

        private void Awake()
        {
            instance = this;
        }
        //internal void SaveData(FSData data)
        //{
        //    string dataToSave = JsonUtility.ToJson(data);
        //    string filePath = Path.Combine(Application.persistentDataPath, "dataFile.json");
        //    File.WriteAllText(filePath, dataToSave);
        //}
        //internal FSData LoadData()
        //{
        //    FSData data = new FSData();
        //    string filePath = Path.Combine(Application.persistentDataPath, "dataFile.json");
        //    if (File.Exists(filePath))
        //    {
        //        string dataAsJson = File.ReadAllText(filePath);
        //        data = JsonUtility.FromJson<FSData>(dataAsJson);
        //    }
        //    //if (File.Exists(Application.persistentDataPath + "dataFile.json"))
        //    //{
        //    //    string dataString = File.ReadAllText(Application.persistentDataPath +  "dataFile.json");
        //    //    data = JsonUtility.FromJson<FSData>(dataString);
        //    //}
        //    return data;
        //}
        internal void SaveData(FSData data)
        {
            try
            {
                string dataToSave = JsonUtility.ToJson(data);
                string filePath = Path.Combine(Application.persistentDataPath, "dataFile.json");
                File.WriteAllText(filePath, dataToSave);
            }
            catch (Exception e)
            {
                Debug.LogError("SaveData: " + e.Message);
            }
        }
        internal FSData LoadData()
        {
            try
            {
                FSData data = new FSData();
                string filePath = Path.Combine(Application.persistentDataPath, "dataFile.json");
                if (File.Exists(filePath))
                {
                    string dataString = File.ReadAllText(filePath);
                    data = JsonUtility.FromJson<FSData>(dataString);
                }
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError("LoadData: " + e.Message);
                return null;
            }
        }
    }
}
