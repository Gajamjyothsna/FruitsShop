using System.Collections;
using System.Collections.Generic;
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
            Debug.LogError("trigger enter");
            Debug.LogError("other name " + other.name);
            Debug.LogError("Object Name " + this.gameObject.name);
            int count = 0;
            if (other.gameObject.tag == "Basket")
            {
                    Debug.LogError("Basket");
                    FSUIManager.Instance.SetScore(_type);
                    Destroy(this.gameObject, 1f);
                return;
                
            }
        }
        internal void SetFruitType(FSUIManager.FruitType type)
        {
            this._type = type;
        }
    }
}
