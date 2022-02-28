using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerAct : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerCol.ActOn = true;
        Debug.Log(PlayerCol.ActOn);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerCol.ActOn = false; 
        Debug.Log(PlayerCol.ActOn);
    }
}