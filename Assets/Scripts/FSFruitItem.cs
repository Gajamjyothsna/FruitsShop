using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSFruitItem : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private Image icon;
    [SerializeField] private Text count;
    [SerializeField] private Text cost;
    #endregion

    #region Private Methods
    public void Init(Sprite _icon, int _count, int _cost)
    {
        icon.sprite = _icon;
        count.text = "Count :" + _count.ToString();
        cost.text = "Cost : " + _cost.ToString();
    }
    #endregion
}
