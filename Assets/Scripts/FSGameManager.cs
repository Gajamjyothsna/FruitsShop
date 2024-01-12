using FruitSellingShop;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitSellingShop
{
    public class FSGameManager : MonoBehaviour
    {
        #region Singleton
        private static FSGameManager instance;
        public static FSGameManager Instance => instance;
        #endregion
        #region Private Variables
        [SerializeField] private List<FruitModelData> fruitModelDatas;
        [SerializeField] private Transform spawningPosition;
        #endregion
        #region DataModel
        [Serializable]
        public class FruitModelData
        {
            public GameObject fruitModel;
            public FSUIManager.FruitType type;
        }
        #endregion
        #region Private Methods
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        internal void SpawnFruit(FSUIManager.FruitType type)
        {
            GameObject _fruitModel  = GetFruitModel(type);
            GameObject _fruitModelObj = Instantiate(_fruitModel, spawningPosition);
            _fruitModelObj.GetComponent<FSFruitDragger>().SetFruitType(type);

        }
        private GameObject GetFruitModel(FSUIManager.FruitType fruitType)
        {
            return fruitModelDatas.Find(x => x.type == fruitType).fruitModel;
        }
        private void OnApplicationQuit()
        {
            FSUIManager.Instance.SaveData();
        }
        #endregion
    }
}
