using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FruitSellingShop
{
    public class FSFruitDragger : MonoBehaviour
    {
        private FSUIManager.FruitType _type;
        private Vector3 mousePosition;
        private void OnMouseDown()
        {
            mousePosition = Input.mousePosition - GetMousePos();
        }

        private void OnMouseDrag()
        {
           transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
        private Vector3 GetMousePos()
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Basket")
            {
                Debug.Log("Basket");
                FSUIManager.Instance.SetScore(_type);
                Destroy(this.gameObject, 1f);
            }
        }
        internal void SetFruitType(FSUIManager.FruitType type)
        {
            this._type = type;
        }
    }
}
