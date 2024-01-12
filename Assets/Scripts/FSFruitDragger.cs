using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitSellingShop
{
    public class FSFruitDragger : MonoBehaviour
    {
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
    }
}
