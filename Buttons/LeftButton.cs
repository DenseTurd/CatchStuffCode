using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   public void OnPointerDown(PointerEventData eventData)
   {
        PlayerControllerBlochFall.Instance.inputX = -1f;
   }

    public void OnPointerUp(PointerEventData eventdata)
    {
        PlayerControllerBlochFall.Instance.inputX = 0f;
    }
}
