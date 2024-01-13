using FruitSellingShop;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FruitSellingShop
{ 
public class FSFruitItem : MonoBehaviour
{
    #region Events
    public delegate void DisableSpriteIndicator();
    public static event DisableSpriteIndicator disableSpriteIndicator;
    #endregion
    #region Private Variables
    [SerializeField] private Image icon;
    [SerializeField] private Text count;
    [SerializeField] private Text cost;

    [SerializeField] private Image indicatorButtonBG;

    [SerializeField] private Button indicator;

    [SerializeField] private List<Color> colorList;

    private FSUIManager.FruitType _type;
    private int fruitCount;

    #endregion

    #region Private Methods
    private void OnEnable()
    {
        disableSpriteIndicator += DisableSpriteIndicators;
    }
    private void OnDisable()
    {
        disableSpriteIndicator -= DisableSpriteIndicators;
    }
    private void Start()
    {
        indicator.onClick.RemoveAllListeners();
        indicator.onClick.AddListener(EnableIndicator);
    }
    public void Init(Sprite _icon, int _count, int _cost, FSUIManager.FruitType _fruitType)
    {
        icon.sprite = _icon;
        count.text = "Count :" + _count.ToString();
        cost.text = "Cost : " + _cost.ToString();
        _type = _fruitType;
        fruitCount = _count;
    }
    private void EnableIndicator()
    {
        DisableSpriteIndicators();
        indicatorButtonBG.GetComponent<Image>().color = colorList[0];
        if(fruitCount > 0)
        {
            fruitCount = fruitCount - 1;
            count.text = "Count :" + fruitCount.ToString();
             // bool _status = FSUIManager.Instance.CheckIfAnyCountBecomesZero();
                //Debug.LogError("Status" + _status);
                //if(_status)
                //{
                //    int _index = FSUIManager.Instance.GetIndexFromFruitList();
                //    Destroy(FSUIManager.Instance.fruitItems[_index].gameObject);
                //}
                if(count.text == "0")
                {
                    Destroy(this.gameObject);
                }
            FSGameManager.Instance.SpawnFruit(_type);
        }
       
    }
    private void DisableSpriteIndicators()
    {
        for (int i = 0; i< FSUIManager.Instance.fruitItems.Count; i++)
        {
             FSUIManager.Instance.fruitItems[i].indicator.GetComponent<Image>().color = colorList[1];
        }
    }
    //internal int GetCount()
    //{
    //        return int.Parse(count.text);
    //}
    #endregion
}
}
