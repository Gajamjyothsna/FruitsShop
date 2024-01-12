using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace FruitSellingShop
{
    public class FSUIManager : MonoBehaviour
    {
        #region Creating Instance
        private static FSUIManager instance;
        public static FSUIManager Instance => instance;
        #endregion
        #region DataModels
        [Serializable]
        public enum FruitType
        {
            None,
            Apple,
            Banana,
            PineApple,
            CustardApple,
            Mango,
            Grapes,
            Orange,
            Pomegranate
        }
        [Serializable]
        public class FruitsData
        {
            public FruitType type;
            public int capacity;
            public int cost;
            public Sprite icon;
        }
        #endregion
        #region Private Variables
        [SerializeField] private Button scrollableButton;
        [SerializeField] private GameObject scrollableArea;

        [SerializeField] private List<FruitsData> fruitsDatas;
        [SerializeField] private FSFruitItem fruitItem;
        [SerializeField] private Transform position;

        public List<FSFruitItem> fruitItems = new List<FSFruitItem>();
        #endregion

        #region Private Methods
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
        private void Start ()
        {
            InitMethod();
        }
        private void InitMethod()
        {
            AnimateScrollabelButton();
            scrollableButton.onClick.RemoveAllListeners();
            scrollableButton.onClick.AddListener(OpenScrollableArea);
        }
        private void AssignFruitData()
        {
            for(int i = 0; i < fruitsDatas.Count; i++)
            {
                FSFruitItem _fruitItem = Instantiate(fruitItem, position);
                _fruitItem.Init(fruitsDatas[i].icon, fruitsDatas[i].capacity, fruitsDatas[i].cost, fruitsDatas[i].type);
                fruitItems.Add(_fruitItem);
            }
        }

        private void AnimateScrollabelButton()
        {
            scrollableButton.transform.DOScale(Vector3.one * .3f, .5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                scrollableButton.transform.DOScale(Vector3.one, .5f).OnComplete(() =>
                {
                    StartCoroutine(DurationToCallAnimateScrollableButton());

                    IEnumerator DurationToCallAnimateScrollableButton()
                    {
                        yield return new WaitForSeconds(1f);

                        AnimateScrollabelButton();
                    }

                });
            });
        }
        private void OpenScrollableArea()
        {
            AssignFruitData();
            scrollableArea.SetActive(true);
            scrollableArea.gameObject.GetComponent<RectTransform>().DOAnchorPosX(-144f, 1f);
            scrollableButton.gameObject.SetActive(false);
        }
        private void CloseScrollableArea()
        {
            scrollableArea.SetActive(false);
            scrollableButton.gameObject.SetActive(true);
        }
        #endregion
    }
}
